using AForge.Video;
using AForge.Video.DirectShow;
using RomanceHotel.BUS;
using RomanceHotel.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace RomanceHotel.GUI
{
    public partial class FormQuetQRHoaDon : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;

        private readonly BarcodeReader reader;

        // Fix lỗi "Object is currently in use elsewhere"
        private readonly object _imgLock = new object();
        private bool _isProcessingFrame = false;

        // Tránh quét trùng liên tục cùng 1 QR
        private string _lastQrText = "";
        private DateTime _lastQrTime = DateTime.MinValue;

        public FormQuetQRHoaDon()
        {
            InitializeComponent();

            reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = { PossibleFormats = new[] { BarcodeFormat.QR_CODE } }
            };
        }

        private void FormQuetQRHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy camera!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                cboCamera.Items.Clear();
                foreach (FilterInfo device in videoDevices)
                    cboCamera.Items.Add(device.Name);

                cboCamera.SelectedIndex = 0;
                lblStatus.Text = "Chọn camera rồi bấm Bắt đầu.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load camera:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoDevices == null || videoDevices.Count == 0)
                {
                    MessageBox.Show("Không có camera để chạy.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (videoSource != null && videoSource.IsRunning)
                    return;

                int idx = cboCamera.SelectedIndex;
                if (idx < 0) idx = 0;

                videoSource = new VideoCaptureDevice(videoDevices[idx].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();

                lblStatus.Text = "Đang quét QR...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được camera:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCamera();
            lblStatus.Text = "Đã dừng camera.";
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Tránh xử lý chồng frame (camera bắn rất nhanh)
            if (_isProcessingFrame) return;
            _isProcessingFrame = true;

            Bitmap frameForUi = null;
            Bitmap frameForDecode = null;

            try
            {
                // Clone frame ra bitmap riêng (tách khỏi buffer của camera)
                frameForDecode = (Bitmap)eventArgs.Frame.Clone();

                // Clone thêm 1 bản để show UI (tránh xài chung 1 bitmap)
                frameForUi = (Bitmap)frameForDecode.Clone();

                // Update UI an toàn (KHÔNG clone Image từ PictureBox nữa)
                this.BeginInvoke(new Action(() =>
                {
                    lock (_imgLock)
                    {
                        Image old = picCamera.Image;
                        picCamera.Image = frameForUi; // gán ảnh mới
                        old?.Dispose();               // dọn ảnh cũ
                    }
                }));

                // Decode QR trên bản decode
                var result = reader.Decode(frameForDecode);
                if (result == null) return;

                // Chống quét spam liên tục 1 QR
                if (IsDuplicateQr(result.Text)) return;

                // Chuyển về UI thread xử lý kết quả
                this.BeginInvoke(new Action(() =>
                {
                    HandleQrResult(result.Text);
                }));
            }
            catch
            {
                // bỏ qua lỗi frame
            }
            finally
            {
                // frameForUi đã giao cho PictureBox -> KHÔNG dispose ở đây
                frameForDecode?.Dispose();
                _isProcessingFrame = false;
            }
        }

        private bool IsDuplicateQr(string text)
        {
            // nếu cùng text trong vòng 1.2 giây thì bỏ qua
            var now = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(text)
                && text == _lastQrText
                && (now - _lastQrTime).TotalMilliseconds < 1200)
            {
                return true;
            }

            _lastQrText = text ?? "";
            _lastQrTime = now;
            return false;
        }

        private void HandleQrResult(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            // Payload chuẩn: ROMANCEHD|HDxxxx
            if (!text.StartsWith("ROMANCEHD|", StringComparison.OrdinalIgnoreCase))
            {
                lblStatus.Text = "QR không hợp lệ (không phải hóa đơn).";
                return;
            }

            string maHD = text.Split('|').LastOrDefault()?.Trim();
            if (string.IsNullOrWhiteSpace(maHD))
            {
                lblStatus.Text = "Không đọc được mã hóa đơn.";
                return;
            }

            lblStatus.Text = $"Đã đọc: {maHD}";

            // Dừng camera để tránh mở form nhiều lần
            StopCamera();

            // Lấy hóa đơn theo mã
            HoaDon hd = HoaDonBUS.Instance.GetHoaDonByMaHD(maHD);
            if (hd == null)
            {
                MessageBox.Show($"Không tìm thấy hóa đơn: {maHD}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblStatus.Text = "Không tìm thấy hóa đơn. Bạn có thể quét lại.";
                return;
            }

            using (FormHoaDon frm = new FormHoaDon(hd))
            {
                frm.ShowDialog();
            }

            // Sau khi xem hóa đơn xong, cho phép quét lại (nếu muốn)
            lblStatus.Text = "Xem hóa đơn xong. Bấm Bắt đầu để quét tiếp.";
        }

        private void StopCamera()
        {
            try
            {
                if (videoSource != null)
                {
                    videoSource.NewFrame -= VideoSource_NewFrame;

                    if (videoSource.IsRunning)
                    {
                        videoSource.SignalToStop();
                        videoSource.WaitForStop();
                    }

                    videoSource = null;
                }
            }
            catch
            {
                // ignore
            }
        }

        private void FormQuetQRHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();

            lock (_imgLock)
            {
                picCamera.Image?.Dispose();
                picCamera.Image = null;
            }
        }
    }
}
