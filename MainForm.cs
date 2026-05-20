using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public class MainForm : Form
    {
        private LoginControl loginCtrl;
        private StudentManagementControl studentCtrl;

        public MainForm()
        {
            this.Text = "Quản lý Sinh Viên";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo LoginControl
            loginCtrl = new LoginControl();
            loginCtrl.Dock = DockStyle.Fill;
            loginCtrl.LoginSuccess += OnLoginSuccess;

            // Tạo StudentManagementControl
            studentCtrl = new StudentManagementControl();
            studentCtrl.Dock = DockStyle.Fill;
            studentCtrl.Visible = false;
            studentCtrl.LogoutRequested += OnLogoutRequested;

            this.Controls.Add(studentCtrl);
            this.Controls.Add(loginCtrl);
        }

        private void OnLoginSuccess(object sender, EventArgs e)
        {
            loginCtrl.Visible = false;
            studentCtrl.Visible = true;
        }

        private void OnLogoutRequested(object sender, EventArgs e)
        {
            studentCtrl.Visible = false;
            loginCtrl.Visible = true;
        }
    }
}