using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class Form2 : Form
    {
        // Danh sách sinh viên mẫu
        private List<string[]> dsSinhVien = new List<string[]>
        {
            new string[] { "1", "hieu", "Nam", "11/03/2026", "68PM1" },
            new string[] { "2", "Nguyễn Văn B", "Nam", "11/03/2026", "68PM2" },
            new string[] { "3", "Trần Văn C", "Nam", "21/03/2026", "68PM2" },
        };

        public Form2()
        {
            InitializeComponent();
            this.Text = "Quản lý Sinh Viên";
            this.Size = new Size(1300, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            TaoGiaoDien();
            HienThiDanhSach();
        }

        private DataGridView dgvSinhVien;
        private TextBox txtMaSV, txtHoTen, txtTimKiem;
        private ComboBox cboGioiTinh, cboLop;
        private DateTimePicker dtpNgaySinh;

        private void TaoGiaoDien()
        {
            // ===== MENU =====
            MenuStrip menu = new MenuStrip();
            menu.BackColor = Color.FromArgb(30, 30, 30);
            menu.ForeColor = Color.White;
            ToolStripMenuItem mnuSV = new ToolStripMenuItem("Quản lý Sinh Viên");
            ToolStripMenuItem mnuLop = new ToolStripMenuItem("Quản lý Lớp Học");
            ToolStripMenuItem mnuDX = new ToolStripMenuItem("Đăng xuất");
            mnuDX.Click += (s, e) => { this.Close(); };
            mnuSV.ForeColor = Color.White;
            mnuLop.ForeColor = Color.White;
            mnuDX.ForeColor = Color.Red;
            menu.Items.AddRange(new ToolStripItem[] { mnuSV, mnuLop, mnuDX });
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            // ===== PANEL TRÁI =====
            Panel pnlTrai = new Panel();
            pnlTrai.Size = new Size(430, 750);
            pnlTrai.Location = new Point(10, 40);
            pnlTrai.BackColor = Color.WhiteSmoke;
            this.Controls.Add(pnlTrai);

            Label lblTitle = new Label();
            lblTitle.Text = "Thông tin sinh viên";
            lblTitle.Font = new Font("Arial", 11, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.AutoSize = true;
            pnlTrai.Controls.Add(lblTitle);

            // Mã SV
            Label l1 = new Label(); l1.Text = "Mã sinh viên:"; l1.Location = new Point(20, 55); l1.AutoSize = true;
            txtMaSV = new TextBox(); txtMaSV.Location = new Point(20, 80); txtMaSV.Size = new Size(380, 30);
            pnlTrai.Controls.Add(l1); pnlTrai.Controls.Add(txtMaSV);

            // Họ tên
            Label l2 = new Label(); l2.Text = "Họ và tên:"; l2.Location = new Point(20, 125); l2.AutoSize = true;
            txtHoTen = new TextBox(); txtHoTen.Location = new Point(20, 150); txtHoTen.Size = new Size(380, 30);
            pnlTrai.Controls.Add(l2); pnlTrai.Controls.Add(txtHoTen);

            // Ngày sinh
            Label l3 = new Label(); l3.Text = "Ngày sinh:"; l3.Location = new Point(20, 195); l3.AutoSize = true;
            dtpNgaySinh = new DateTimePicker(); dtpNgaySinh.Location = new Point(20, 220); dtpNgaySinh.Size = new Size(380, 30);
            pnlTrai.Controls.Add(l3); pnlTrai.Controls.Add(dtpNgaySinh);

            // Giới tính
            Label l4 = new Label(); l4.Text = "Giới tính:"; l4.Location = new Point(20, 265); l4.AutoSize = true;
            cboGioiTinh = new ComboBox(); cboGioiTinh.Location = new Point(20, 290); cboGioiTinh.Size = new Size(380, 30);
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
            cboGioiTinh.SelectedIndex = 0;
            pnlTrai.Controls.Add(l4); pnlTrai.Controls.Add(cboGioiTinh);

            // Lớp
            Label l5 = new Label(); l5.Text = "Lớp:"; l5.Location = new Point(20, 335); l5.AutoSize = true;
            cboLop = new ComboBox(); cboLop.Location = new Point(20, 360); cboLop.Size = new Size(380, 30);
            cboLop.Items.AddRange(new string[] { "68PM1 - Lớp 68PM1", "68PM2 - Lớp 68PM2" });
            cboLop.SelectedIndex = 0;
            pnlTrai.Controls.Add(l5); pnlTrai.Controls.Add(cboLop);

            // Buttons
            Button btnThem = new Button(); btnThem.Text = "Thêm"; btnThem.Size = new Size(190, 50);
            btnThem.Location = new Point(10, 620); btnThem.BackColor = Color.DodgerBlue;
            btnThem.ForeColor = Color.White; btnThem.Font = new Font("Arial", 11, FontStyle.Bold);
            btnThem.Click += BtnThem_Click;

            Button btnSua = new Button(); btnSua.Text = "Sửa"; btnSua.Size = new Size(190, 50);
            btnSua.Location = new Point(215, 620); btnSua.BackColor = Color.Green;
            btnSua.ForeColor = Color.White; btnSua.Font = new Font("Arial", 11, FontStyle.Bold);

            Button btnXoa = new Button(); btnXoa.Text = "Xóa"; btnXoa.Size = new Size(190, 50);
            btnXoa.Location = new Point(10, 685); btnXoa.BackColor = Color.Red;
            btnXoa.ForeColor = Color.White; btnXoa.Font = new Font("Arial", 11, FontStyle.Bold);

            Button btnLamMoi = new Button(); btnLamMoi.Text = "Làm mới"; btnLamMoi.Size = new Size(190, 50);
            btnLamMoi.Location = new Point(215, 685); btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.ForeColor = Color.White; btnLamMoi.Font = new Font("Arial", 11, FontStyle.Bold);
            btnLamMoi.Click += (s, e) => { txtMaSV.Clear(); txtHoTen.Clear(); };

            pnlTrai.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnLamMoi });

            // ===== PANEL PHẢI =====
            Panel pnlPhai = new Panel();
            pnlPhai.Size = new Size(820, 750);
            pnlPhai.Location = new Point(450, 40);
            this.Controls.Add(pnlPhai);

            Label lblTim = new Label(); lblTim.Text = "Tìm kiếm (Tên / Mã SV / Lớp):";
            lblTim.Location = new Point(0, 10); lblTim.AutoSize = true;
            txtTimKiem = new TextBox(); txtTimKiem.Location = new Point(0, 35); txtTimKiem.Size = new Size(620, 30);

            Button btnTim = new Button(); btnTim.Text = "Tìm"; btnTim.Size = new Size(100, 35);
            btnTim.Location = new Point(635, 33); btnTim.BackColor = Color.DarkSlateGray;
            btnTim.ForeColor = Color.White; btnTim.Font = new Font("Arial", 10, FontStyle.Bold);

            dgvSinhVien = new DataGridView();
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

            pnlPhai.Controls.AddRange(new Control[] { lblTim, txtTimKiem, btnTim, dgvSinhVien });
        }

        private void HienThiDanhSach()
        {
            dgvSinhVien.Rows.Clear();
            foreach (var sv in dsSinhVien)
                dgvSinhVien.Rows.Add(sv);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "" || txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dsSinhVien.Add(new string[] {
                txtMaSV.Text, txtHoTen.Text,
                cboGioiTinh.Text, dtpNgaySinh.Value.ToString("dd/MM/yyyy"),
                cboLop.Text.Split('-')[0].Trim()
            });
            HienThiDanhSach();
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}