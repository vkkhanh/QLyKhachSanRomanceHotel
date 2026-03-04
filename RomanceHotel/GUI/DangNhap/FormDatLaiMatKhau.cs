using RomanceHotel.DTO;
using System;
using System.Windows.Forms;
using RomanceHotel.BUS;
using RomanceHotel.CTControls;

namespace RomanceHotel.GUI
{
    public partial class FormDatLaiMatKhau : Form
    {
        private FormLogin formLoginParent;
        private TaiKhoan taiKhoan;

        public FormDatLaiMatKhau(FormLogin formMain)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
        }

        public FormDatLaiMatKhau(FormLogin formMain, TaiKhoan taiKhoan)
        {
            InitializeComponent();
            this.formLoginParent = formMain;
            this.taiKhoan = taiKhoan;
        }

        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            // Quay lại form nhập OTP
            formLoginParent.openChildForm(new FormQuenMatKhauNhapOTP(formLoginParent));
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string newPass = this.textBoxPassword.Texts;
            string confirmPass = this.textBoxPassConfirm.Texts;

            if (string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                CTMessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass != confirmPass)
            {
                CTMessageBox.Show("Mật khẩu xác nhận không khớp. Vui lòng kiểm tra lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TODO: Nếu muốn bảo mật hơn, bạn có thể hash mật khẩu tại đây trước khi lưu.
            taiKhoan.Password = newPass;

            try
            {
                TaiKhoanBUS.Instance.AddOrUpdateTK(taiKhoan);
                CTMessageBox.Show("Đổi mật khẩu thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay về form đăng nhập
                formLoginParent.openChildForm(new FormDangNhap(formLoginParent));
            }
            catch (Exception ex)
            {
                CTMessageBox.Show(ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPassword__TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Texts.Length > 0 && ctEyePassword1.IsShow == false)
            {
                textBoxPassword.PasswordChar = true;
            }
        }

        private void textBoxPassConfirm__TextChanged(object sender, EventArgs e)
        {
            if (textBoxPassConfirm.Texts.Length > 0 && ctEyePassword2.IsShow == false)
            {
                textBoxPassConfirm.PasswordChar = true;
            }
        }

        private void ctEyePassword1_Click(object sender, EventArgs e)
        {
            if (ctEyePassword1.IsShow == false)
            {
                ctEyePassword1.IsShow = true;
                textBoxPassword.PasswordChar = false;
                ctEyePassword1.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                ctEyePassword1.IsShow = false;
                if (textBoxPassword.Texts != "")
                {
                    textBoxPassword.PasswordChar = true;
                }
                ctEyePassword1.BackgroundImage = Properties.Resources.show;
            }
        }

        private void ctEyePassword2_Click(object sender, EventArgs e)
        {
            if (ctEyePassword2.IsShow == false)
            {
                ctEyePassword2.IsShow = true;
                textBoxPassConfirm.PasswordChar = false;
                ctEyePassword2.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                ctEyePassword2.IsShow = false;
                if (textBoxPassConfirm.Texts != "")
                {
                    textBoxPassConfirm.PasswordChar = true;
                }
                ctEyePassword2.BackgroundImage = Properties.Resources.show;
            }
        }
    }
}
