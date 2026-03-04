using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using RomanceHotel.DTO;
using RomanceHotel.CTControls;

namespace RomanceHotel.GUI
{
    public partial class FormQuenMatKhauNhapOTP : Form
    {
        private string OTP;               // OTP thực
        private string emailto;           // Email người nhận
        private Random random = new Random();
        private FormLogin formLoginParent;
        private TaiKhoan taiKhoan;        // Tài khoản cần reset pass

        private int time = 60;            // đếm ngược resend OTP (giây)

        // Constructor chỉ nhận FormLogin (không dùng trong flow chính, để nguyên nếu bạn đang dùng chỗ khác)
        public FormQuenMatKhauNhapOTP(FormLogin formMain)
        {
            this.formLoginParent = formMain;
            InitializeComponent();
        }

        // Constructor chính: nhận FormLogin + email + tài khoản
        public FormQuenMatKhauNhapOTP(FormLogin formMain, string emailto = null, TaiKhoan taiKhoan = null)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
            this.emailto = emailto;
            this.taiKhoan = taiKhoan;

            LoadOTP();  // Khi form mở, tự động gửi OTP
        }

        /// <summary>
        /// Tạo OTP ngẫu nhiên và gửi email.
        /// </summary>
        void LoadOTP()
        {
            time = 60;
            ButtonResend.Enabled = false;
            timer1.Start();

            // Tạo OTP 6 chữ số
            OTP = random.Next(100000, 999999).ToString();

            // Thông tin email
            string fromEmail = "khanhvk22.btt.knt@gmail.com";     // <--- Thay bằng email của khách sạn
            string appPassword = "dtie uxsp zvlv jeap";           // <--- App Password Gmail

            MailMessage mail = new MailMessage(fromEmail, emailto);
            mail.Subject = "Mã OTP Xác Thực - Romance Hotel";
            mail.IsBodyHtml = true;

            // Nội dung email được thiết kế đẹp & chuyên nghiệp
            mail.Body = $@"
<div style='font-family:Arial, Helvetica, sans-serif; padding:20px; background:#f5f5f5;'>
    <div style='max-width:600px; margin:auto; background:white; border-radius:8px; padding:25px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);'>

        <h2 style='color:#58BCBC; text-align:center; font-size:28px; margin-bottom:10px;'>
            Romance Hotel
        </h2>

        <p style='font-size:15px; color:#555;'>
            Xin chào,
        </p>

        <p style='font-size:15px; color:#555; line-height:1.6;'>
            Đây là email tự động từ hệ thống quản lý của <b>Romance Hotel</b>.<br/>
            Chúng tôi gửi cho bạn mã OTP để xác minh yêu cầu <b>đặt lại mật khẩu</b> tài khoản.
        </p>

        <div style='margin:30px 0; text-align:center;'>
            <span style='display:inline-block; padding:14px 28px; font-size:26px;
                         background:#58BCBC; color:white; border-radius:6px; letter-spacing:3px;'>
                <b>{OTP}</b>
            </span>
        </div>

        <p style='font-size:14px; color:#777; line-height:1.6;'>
            Mã OTP này có hiệu lực trong vòng <b>5 phút</b>.<br/>
            Nếu bạn không yêu cầu thao tác này, vui lòng bỏ qua email.
        </p>

        <hr style='border:none; border-top:1px solid #eee; margin:25px 0;' />

        <p style='font-size:13px; color:#999; text-align:center;'>
            © {DateTime.Now.Year} Romance Hotel. All rights reserved.
        </p>
    </div>
</div>";


            // Cấu hình SMTP Gmail
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromEmail, appPassword)
            };

            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                CTMessageBox.Show("Không gửi được email: " + ex.Message,
                    "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Kiểm tra OTP nhập có đúng với OTP đã gửi hay không.
        /// </summary>
        private bool checkOTPCorrect()
        {
            return this.textBoxOTP.Texts == OTP;
        }

        private void ButtonContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkOTPCorrect())
                {
                    // OTP đúng -> sang form đặt lại mật khẩu, truyền luôn tài khoản
                    formLoginParent.openChildForm(new FormDatLaiMatKhau(formLoginParent, this.taiKhoan));
                }
                else
                {
                    CTMessageBox.Show("Mã OTP bạn nhập chưa đúng. Vui lòng kiểm tra lại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            // Quay lại form lấy OTP (nhập username + email)
            formLoginParent.openChildForm(new FormQuenMatKhauLayOTP(formLoginParent));
        }

        private void ButtonResend_Click(object sender, EventArgs e)
        {
            // Gửi lại OTP mới
            LoadOTP();
        }

        /// <summary>
        /// Timer đếm ngược cho nút RESEND.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ButtonResend.Text = time.ToString();
            time--;

            if (this.time == 0)
            {
                timer1.Stop();
                this.ButtonResend.Enabled = true;
                this.ButtonResend.Text = "RESEND";
            }
        }
    }
}
