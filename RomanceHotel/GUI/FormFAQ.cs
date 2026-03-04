using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormFAQ : Form
    {
       
        private const string USER_GUIDE_RELATIVE_PATH = @"UserGuide\HuongDanSuDung.pdf";

        // Màu dùng chung cho UI (tone sáng – cam/kem)
        private readonly Color QuestionCollapsedColor = Color.White;
        private readonly Color QuestionExpandedColor = Color.FromArgb(251, 146, 60);   // cam nhạt
        private readonly Color QuestionHoverColor = Color.FromArgb(254, 215, 170);    // cam rất nhạt
        private readonly Color CardBackColor = Color.FromArgb(250, 250, 250);         // xám cực nhạt
        private readonly Color AnswerTextColor = Color.FromArgb(55, 65, 81);          // xám đậm

        // Lưu danh sách các item để làm accordion
        private readonly List<FAQItem> _faqItems = new List<FAQItem>();

        private class FAQItem
        {
            public Panel Panel;
            public Button Button;
            public Label Answer;
            public bool IsExpanded;
        }

        public FormFAQ()
        {
            InitializeComponent();
            this.Load += FormFAQ_Load;

            // Nút mở hướng dẫn
            this.btnHuongDan.Click += btnHuongDan_Click;
        }

        private void FormFAQ_Load(object sender, EventArgs e)
        {
            TaoDanhSachFAQ();
        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            MoHuongDanSuDung();
        }

        private void MoHuongDanSuDung()
        {
            try
            {
                string fullPath = Path.Combine(
                    Application.StartupPath,
                    USER_GUIDE_RELATIVE_PATH
                );

                if (!File.Exists(fullPath))
                {
                    MessageBox.Show(
                        "Không tìm thấy file hướng dẫn sử dụng.\n\n" +
                        "Vui lòng kiểm tra thư mục:\n" + fullPath,
                        "Thiếu file hướng dẫn",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = fullPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể mở file hướng dẫn.\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// Tạo danh sách các câu hỏi thường gặp
        /// </summary>
        private void TaoDanhSachFAQ()
        {
            TaoItemFAQ(
                "Làm thế nào để đặt phòng cho khách?",
                "Vào 'Sơ đồ phòng', chọn phòng muốn đặt, nhấn nút 'Đặt phòng', điền đầy đủ thông tin khách hàng và thông tin phòng cần đặt, sau đó nhấn 'Đặt trước' để thực hiện đặt phòng."
            );

            TaoItemFAQ(
                "Làm sao xem được tình trạng (trống/đã thuê) của phòng?",
                "Vào 'Quản lý phòng' hoặc màn hình sơ đồ phòng, màu sắc hoặc trạng thái sẽ cho biết phòng đang trống, đang có khách, đang sửa chữa,..."
            );

            TaoItemFAQ(
                "Làm sao để xuất lại hóa đơn cho khách khi khách làm mất hóa đơn?",
                "Vào 'Quản lý hóa đơn', chọn hóa đơn cần xuất của khách hàng, kiểm tra chi tiết hóa đơn, sau đó nhấn biểu tượng in để xuất hóa đơn."
            );

            TaoItemFAQ(
                "Tôi có thể chỉnh sửa thông tin khách hàng ở đâu?",
                "Vào 'Quản lý khách hàng', tìm khách cần chỉnh sửa, sau đó dùng chức năng 'Sửa' để cập nhật thông tin."
            );

            TaoItemFAQ(
                "Làm sao sao lưu dữ liệu hệ thống?",
                "Vào chức năng 'Sao lưu phục hồi', chọn đường dẫn lưu file sao lưu, sau đó nhấn 'Sao lưu'. Nên sao lưu định kỳ để tránh mất dữ liệu."
            );
        }

        /// <summary>
        /// Tạo 1 item FAQ dạng card + accordion
        /// </summary>
        private void TaoItemFAQ(string cauHoi, string cauTraLoi)
        {
            // Chiều rộng card dựa trên panel phải
            int itemWidth = this.flowLayoutPanelFAQ.ClientSize.Width
                            - this.flowLayoutPanelFAQ.Padding.Horizontal
                            - 10;
            if (itemWidth < 280) itemWidth = 280;

            // Card chứa cả câu hỏi + câu trả lời
            Panel panelItem = new Panel();
            panelItem.Width = itemWidth;
            panelItem.BackColor = CardBackColor;
            panelItem.Margin = new Padding(0, 0, 0, 12);
            panelItem.Padding = new Padding(12, 10, 12, 10);
            panelItem.BorderStyle = BorderStyle.FixedSingle;

            // Nút câu hỏi (header)
            Button btnQuestion = new Button();
            btnQuestion.Text = "▶  " + cauHoi;
            btnQuestion.Tag = cauHoi; // lưu text gốc để đổi lại
            btnQuestion.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            btnQuestion.Location = new Point(4, 4);
            btnQuestion.Size = new Size(itemWidth - 24, 32);
            btnQuestion.FlatStyle = FlatStyle.Flat;
            btnQuestion.FlatAppearance.BorderSize = 0;
            btnQuestion.FlatAppearance.MouseDownBackColor = QuestionExpandedColor;
            btnQuestion.BackColor = QuestionCollapsedColor;
            btnQuestion.ForeColor = Color.FromArgb(15, 23, 42);
            btnQuestion.TextAlign = ContentAlignment.MiddleLeft;
            btnQuestion.Cursor = Cursors.Hand;

            // Label câu trả lời
            Label lblAnswer = new Label();
            lblAnswer.Text = cauTraLoi;
            lblAnswer.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            lblAnswer.ForeColor = AnswerTextColor;
            lblAnswer.Location = new Point(10, btnQuestion.Bottom + 8);
            lblAnswer.MaximumSize = new Size(itemWidth - 40, 0); // cho phép xuống dòng
            lblAnswer.AutoSize = true;
            lblAnswer.Visible = false; // ban đầu ẩn

            // Set chiều cao card ở trạng thái thu gọn
            panelItem.Height = btnQuestion.Bottom + 8;

            var item = new FAQItem
            {
                Panel = panelItem,
                Button = btnQuestion,
                Answer = lblAnswer,
                IsExpanded = false
            };
            _faqItems.Add(item);

            // Click: accordion
            btnQuestion.Click += (s, e) => ToggleItem(item);

            // Hover effect
            btnQuestion.MouseEnter += (s, e) =>
            {
                if (!item.IsExpanded)
                    btnQuestion.BackColor = QuestionHoverColor;
            };
            btnQuestion.MouseLeave += (s, e) =>
            {
                if (!item.IsExpanded)
                    btnQuestion.BackColor = QuestionCollapsedColor;
            };

            panelItem.Controls.Add(btnQuestion);
            panelItem.Controls.Add(lblAnswer);

            this.flowLayoutPanelFAQ.Controls.Add(panelItem);
        }

        /// <summary>
        /// Bung/thu 1 item và đóng các item khác lại (accordion)
        /// </summary>
        private void ToggleItem(FAQItem item)
        {
            bool willExpand = !item.IsExpanded;

            // Thu tất cả item khác
            foreach (var it in _faqItems)
            {
                it.IsExpanded = false;
                it.Answer.Visible = false;
                it.Panel.Height = it.Button.Bottom + 8;
                it.Button.Text = "▶  " + (string)it.Button.Tag;
                it.Button.BackColor = QuestionCollapsedColor;
            }

            if (willExpand)
            {
                item.IsExpanded = true;
                item.Answer.Visible = true;
                item.Panel.Height = item.Answer.Bottom + 12;
                item.Button.Text = "▼  " + (string)item.Button.Tag;
                item.Button.BackColor = QuestionExpandedColor;

                this.flowLayoutPanelFAQ.ScrollControlIntoView(item.Panel);
            }
        }
    }
}
