using RomanceHotel.BUS;
using System;
using System.Windows.Forms;
using RomanceHotel.DTO;
using RomanceHotel.CTControls;

namespace RomanceHotel.GUI
{
    public partial class FormQuenMatKhauLayOTP : Form
    {
        private FormLogin formLoginParent;

        public FormQuenMatKhauLayOTP(FormLogin formMain)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
        }

        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            formLoginParent.openChildForm(new FormDangNhap(formLoginParent));
        }

        private void ButtonLayOTP_Click(object sender, EventArgs e)
        {
            try
            {
                string username = this.textBoxUsername.Texts.Trim();
                string email = this.TextBoxEmail.Texts.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
                {
                    CTMessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Email.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra username + email hợp lệ (CheckLegit đã xử lý ở DAO)
                TaiKhoan taiKhoan = TaiKhoanBUS.Instance.CheckLegit(username, email);
                if (taiKhoan != null)
                {
                    // Nếu hợp lệ, chuyển sang form nhập OTP,
                    // đồng thời truyền email & tài khoản để form sau dùng.
                    formLoginParent.openChildForm(new FormQuenMatKhauNhapOTP(
                        formLoginParent,
                        email,
                        taiKhoan
                    ));
                }
                else
                {
                    CTMessageBox.Show("Email hoặc tài khoản đăng nhập không đúng.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
