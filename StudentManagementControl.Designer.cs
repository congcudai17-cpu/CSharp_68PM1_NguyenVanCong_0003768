using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    partial class StudentManagementControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            // ── Khai báo controls ──────────────────────────────────
            var menu = new MenuStrip();
            var mnuSV = new ToolStripMenuItem("Quản lý Sinh Viên");
            var mnuLop = new ToolStripMenuItem("Quản lý Lớp Học");
            var mnuDX = new ToolStripMenuItem("Đăng xuất");

            var pnlTrai = new Panel();
            var lblTitle = new Label();
            var l1 = new Label();
            var l2 = new Label();
            var l3 = new Label();
            var l4 = new Label();
            var l5 = new Label();
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cboGioiTinh = new ComboBox();
            cboLop = new ComboBox();
            var btnThem = new Button();
            var btnSua = new Button();
            var btnXoa = new Button();
            var btnLamMoi = new Button();

            var pnlPhai = new Panel();
            var lblTim = new Label();
            txtTimKiem = new TextBox();
            var btnTim = new Button();
            dgvSinhVien = new DataGridView();

            this.SuspendLayout();

            // ── Menu ──────────────────────────────────────────────
            menu.BackColor = Color.FromArgb(30, 30, 30);
            mnuSV.ForeColor = mnuLop.ForeColor = Color.White;
            mnuDX.ForeColor = Color.Red;
            mnuDX.Click += MnuDangXuat_Click;
            menu.Items.AddRange(new ToolStripItem[] { mnuSV, mnuLop, mnuDX });

            // ── Panel trái ────────────────────────────────────────
            pnlTrai.Size = new Size(430, 750);
            pnlTrai.Location = new Point(10, 30);
            pnlTrai.BackColor = Color.WhiteSmoke;

            lblTitle.Text = "Thông tin sinh viên";
            lblTitle.Font = new Font("Arial", 11, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.AutoSize = true;

            l1.Text = "Mã sinh viên:"; l1.Location = new Point(20, 55); l1.AutoSize = true;
            l2.Text = "Họ và tên:"; l2.Location = new Point(20, 125); l2.AutoSize = true;
            l3.Text = "Ngày sinh:"; l3.Location = new Point(20, 195); l3.AutoSize = true;
            l4.Text = "Giới tính:"; l4.Location = new Point(20, 265); l4.AutoSize = true;
            l5.Text = "Lớp:"; l5.Location = new Point(20, 335); l5.AutoSize = true;

            txtMaSV.Location = new Point(20, 80); txtMaSV.Size = new Size(380, 30);
            txtHoTen.Location = new Point(20, 150); txtHoTen.Size = new Size(380, 30);
            dtpNgaySinh.Location = new Point(20, 220); dtpNgaySinh.Size = new Size(380, 30);

            cboGioiTinh.Location = new Point(20, 290); cboGioiTinh.Size = new Size(380, 30);
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;

            cboLop.Location = new Point(20, 360); cboLop.Size = new Size(380, 30);
            cboLop.Items.AddRange(new string[] { "68PM1 - Lớp 68PM1", "68PM2 - Lớp 68PM2" });
            cboLop.SelectedIndex = 0;

            SetupButton(btnThem, "Thêm", new Point(10, 620), Color.DodgerBlue);
            SetupButton(btnSua, "Sửa", new Point(215, 620), Color.Green);
            SetupButton(btnXoa, "Xóa", new Point(10, 685), Color.Red);
            SetupButton(btnLamMoi, "Làm mới", new Point(215, 685), Color.Gray);

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;

            pnlTrai.Controls.AddRange(new Control[] {
                lblTitle, l1, txtMaSV, l2, txtHoTen, l3, dtpNgaySinh,
                l4, cboGioiTinh, l5, cboLop, btnThem, btnSua, btnXoa, btnLamMoi
            });

            // ── Panel phải ────────────────────────────────────────
            pnlPhai.Size = new Size(820, 750);
            pnlPhai.Location = new Point(450, 30);

            lblTim.Text = "Tìm kiếm (Tên / Mã SV / Lớp):";
            lblTim.Location = new Point(0, 10); lblTim.AutoSize = true;

            txtTimKiem.Location = new Point(0, 35);
            txtTimKiem.Size = new Size(620, 30);

            btnTim.Text = "Tìm";
            btnTim.Size = new Size(100, 35);
            btnTim.Location = new Point(635, 33);
            btnTim.BackColor = Color.DarkSlateGray;
            btnTim.ForeColor = Color.White;
            btnTim.Font = new Font("Arial", 10, FontStyle.Bold);
            btnTim.Click += BtnTim_Click;

            dgvSinhVien.Location = new Point(0, 80);
            dgvSinhVien.Size = new Size(820, 600);
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvSinhVien.Columns.Add("MaSV", "Mã SV");
            dgvSinhVien.Columns.Add("HoTen", "Họ và Tên");
            dgvSinhVien.Columns.Add("GioiTinh", "Giới Tính");
            dgvSinhVien.Columns.Add("NgaySinh", "Ngày Sinh");
            dgvSinhVien.Columns.Add("Lop", "Lớp");
            dgvSinhVien.CellClick += DgvSinhVien_CellClick;

            pnlPhai.Controls.AddRange(new Control[] { lblTim, txtTimKiem, btnTim, dgvSinhVien });

            // ── UserControl ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Size = new Size(1300, 800);
            this.Controls.Add(menu);
            this.Controls.Add(pnlTrai);
            this.Controls.Add(pnlPhai);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Helper tạo button đồng nhất
        private static void SetupButton(Button btn, string text, Point loc, Color back)
        {
            btn.Text = text;
            btn.Size = new Size(190, 50);
            btn.Location = loc;
            btn.BackColor = back;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        #endregion

        // ── Fields ────────────────────────────────────────────────
        private DataGridView dgvSinhVien;
        private TextBox txtMaSV, txtHoTen, txtTimKiem;
        private ComboBox cboGioiTinh, cboLop;
        private DateTimePicker dtpNgaySinh;
    }
}