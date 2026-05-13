using System;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class Form1 : Form
    {
        public Form1()
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
                MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }
    }
}