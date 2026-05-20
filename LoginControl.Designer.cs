namespace CSharp_68PM1_NguyenVanCong_0003768
{
    partial class LoginControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F,
                                         System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(256, 67);
            this.lblTitle.Text = "ĐĂNG NHẬP";

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(259, 127);
            this.lblEmail.Text = "Email sinh viên:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(262, 148);
            this.txtEmail.Size = new System.Drawing.Size(200, 22);

            // lblMatKhau
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(259, 173);
            this.lblMatKhau.Text = "Mật khẩu (MSSV):";

            // txtMatKhau
            this.txtMatKhau.Location = new System.Drawing.Point(262, 192);
            this.txtMatKhau.Size = new System.Drawing.Size(200, 22);
            this.txtMatKhau.PasswordChar = '*';

            // btnDangNhap
            this.btnDangNhap.Location = new System.Drawing.Point(262, 243);
            this.btnDangNhap.Size = new System.Drawing.Size(117, 32);
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);

            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(385, 243);
            this.btnHuy.Size = new System.Drawing.Size(75, 32);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.BackColor = System.Drawing.Color.Gray;
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // LoginControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnHuy);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnHuy;
    }
}