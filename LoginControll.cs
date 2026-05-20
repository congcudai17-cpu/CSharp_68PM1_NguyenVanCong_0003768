using System;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class LoginControl : UserControl
    {
        // Event để thông báo đăng nhập thành công lên Form cha
        public event EventHandler LoginSuccess;

        public LoginControl()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string emailSinhVien = "nguyenvancong@gmail.com";
            string mssv = "0003768";

            string emailNhap = txtEmail.Text.Trim();
            string matKhauNhap = txtMatKhau.Text.Trim();

            if (emailNhap == emailSinhVien && matKhauNhap == mssv)
            {
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!\nKiểm tra lại email hoặc mật khẩu.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
            txtMatKhau.Clear();
            txtEmail.Focus();
        }
    }
}