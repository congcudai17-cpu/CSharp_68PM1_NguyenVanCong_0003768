using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public class MainForm : Form
    {
        private LoginControl loginCtrl;
        private StudentManagementControl studentCtrl;
        private ClassManagementControl classCtrl;

        public MainForm()
        {
            this.Text = "Quản lý Sinh Viên";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Login
            loginCtrl = new LoginControl();
            loginCtrl.Dock = DockStyle.Fill;
            loginCtrl.LoginSuccess += (s, e) => ShowControl(studentCtrl);

            // Student
            studentCtrl = new StudentManagementControl();
            studentCtrl.Dock = DockStyle.Fill;
            studentCtrl.Visible = false;

            studentCtrl.LogoutRequested += (s, e) =>
            {
                ShowControl(loginCtrl);
            };

            // DÒNG BẠN ĐANG THIẾU
            studentCtrl.ViewClassRequested += (s, e) =>
            {
                ShowControl(classCtrl);
            };

            // Class
            classCtrl = new ClassManagementControl();
            classCtrl.Dock = DockStyle.Fill;
            classCtrl.Visible = false;

            classCtrl.LogoutRequested += (s, e) =>
            {
                ShowControl(loginCtrl);
            };

            classCtrl.ViewStudentsRequested += (s, e) =>
            {
                ShowControl(studentCtrl);
            };

            // Add controls
            this.Controls.Add(classCtrl);
            this.Controls.Add(studentCtrl);
            this.Controls.Add(loginCtrl);
        }

        private void ShowControl(UserControl ctrl)
        {
            loginCtrl.Visible = false;
            studentCtrl.Visible = false;
            classCtrl.Visible = false;

            ctrl.Visible = true;
        }
    }
}