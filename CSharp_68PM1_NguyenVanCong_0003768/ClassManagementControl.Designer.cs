using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    partial class ClassManagementControl
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
            var menu = new MenuStrip();
            var mnuSV = new ToolStripMenuItem("Quản lý Sinh Viên");
            var mnuLop = new ToolStripMenuItem("Quản lý Lớp Học");
            var mnuDX = new ToolStripMenuItem("Đăng xuất");

            var pnlTrai = new Panel();
            var lblTitle = new Label();
            var lMaID = new Label();
            var lMaLop = new Label();
            var lTenLop = new Label();
            var lGhiChu = new Label();
            txtMaID = new TextBox();
            txtMaLop = new TextBox();
            txtTenLop = new TextBox();
            txtGhiChu = new TextBox();
            var btnThem = new Button();
            var btnSua = new Button();
            var btnXoa = new Button();
            var btnLamMoi = new Button();
            var btnXemSV = new Button();

            var pnlPhai = new Panel();
            var lblTim = new Label();
            txtTimKiem = new TextBox();
            var btnTim = new Button();
            dgvLop = new DataGridView();

            // Phân trang
            var pnlPage = new Panel();
            var btnFirst = new Button();
            var btnPrev = new Button();
            lblTrang = new Label();
            var btnNext = new Button();
            var btnLast = new Button();

            this.SuspendLayout();

            // ── Menu ──────────────────────────────────────────────
            menu.BackColor = Color.FromArgb(30, 30, 30);
            mnuSV.ForeColor = Color.White;
            mnuLop.ForeColor = Color.White;
            mnuDX.ForeColor = Color.Red;
            mnuSV.Click += MnuSinhVien_Click;
            mnuDX.Click += MnuDangXuat_Click;
            menu.Items.AddRange(new ToolStripItem[] { mnuSV, mnuLop, mnuDX });

            // ── Panel trái ────────────────────────────────────────
            pnlTrai.Size = new Size(430, 750);
            pnlTrai.Location = new Point(10, 30);
            pnlTrai.BackColor = Color.WhiteSmoke;

            lblTitle.Text = "Thông tin lớp học";
            lblTitle.Font = new Font("Arial", 11, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.AutoSize = true;

            // Labels + TextBoxes
            SetLabel(lMaID, "Mã ID:", new Point(20, 55));
            SetLabel(lMaLop, "Mã lớp:", new Point(20, 125));
            SetLabel(lTenLop, "Tên lớp:", new Point(20, 195));
            SetLabel(lGhiChu, "Ghi chú:", new Point(20, 265));

            txtMaID.Location = new Point(20, 80); txtMaID.Size = new Size(380, 30); txtMaID.ReadOnly = true;
            txtMaID.BackColor = Color.LightGray;
            txtMaLop.Location = new Point(20, 150); txtMaLop.Size = new Size(380, 30);
            txtTenLop.Location = new Point(20, 220); txtTenLop.Size = new Size(380, 30);
            txtGhiChu.Location = new Point(20, 290); txtGhiChu.Size = new Size(380, 30);

            // Buttons CRUD
            SetButton(btnThem, "Thêm", new Point(10, 530), Color.DodgerBlue);
            SetButton(btnSua, "Sửa", new Point(215, 530), Color.Green);
            SetButton(btnXoa, "Xóa", new Point(10, 595), Color.Red);
            SetButton(btnLamMoi, "Làm mới", new Point(215, 595), Color.Gray);

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;

            // Button Xem danh sách sinh viên
            btnXemSV.Text = "Xem danh sách sinh viên";
            btnXemSV.Size = new Size(400, 50);
            btnXemSV.Location = new Point(10, 660);
            btnXemSV.BackColor = Color.SteelBlue;
            btnXemSV.ForeColor = Color.White;
            btnXemSV.Font = new Font("Arial", 11, FontStyle.Bold);
            btnXemSV.Click += (s, e) => ViewStudentsRequested?.Invoke(this, System.EventArgs.Empty);

            pnlTrai.Controls.AddRange(new Control[] {
                lblTitle, lMaID, txtMaID, lMaLop, txtMaLop,
                lTenLop, txtTenLop, lGhiChu, txtGhiChu,
                btnThem, btnSua, btnXoa, btnLamMoi, btnXemSV
            });

            // ── Panel phải ────────────────────────────────────────
            pnlPhai.Size = new Size(820, 750);
            pnlPhai.Location = new Point(450, 30);

            lblTim.Text = "Tìm kiếm (Mã ID / Mã lớp / Tên lớp):";
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

            // DataGridView
            dgvLop.Location = new Point(0, 80);
            dgvLop.Size = new Size(820, 580);
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.ReadOnly = true;
            dgvLop.AllowUserToAddRows = false;
            dgvLop.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Columns.Add("MaID", "Mã ID");
            dgvLop.Columns.Add("MaLop", "Mã lớp");
            dgvLop.Columns.Add("TenLop", "Tên lớp");
            dgvLop.Columns.Add("GhiChu", "Ghi chú");
            dgvLop.CellClick += DgvLop_CellClick;

            // ── Phân trang ────────────────────────────────────────
            pnlPage.Location = new Point(0, 670);
            pnlPage.Size = new Size(820, 50);

            SetPageBtn(btnFirst, "<<", new Point(0, 5)); btnFirst.Click += BtnFirst_Click;
            SetPageBtn(btnPrev, "<", new Point(65, 5)); btnPrev.Click += BtnPrev_Click;
            SetPageBtn(btnNext, ">", new Point(590, 5)); btnNext.Click += BtnNext_Click;
            SetPageBtn(btnLast, ">>", new Point(655, 5)); btnLast.Click += BtnLast_Click;

            lblTrang.Text = "Trang 1/1  |  0 bản ghi";
            lblTrang.Location = new Point(140, 12);
            lblTrang.Size = new Size(430, 25);
            lblTrang.TextAlign = ContentAlignment.MiddleCenter;
            lblTrang.Font = new Font("Arial", 10);

            pnlPage.Controls.AddRange(new Control[] { btnFirst, btnPrev, lblTrang, btnNext, btnLast });
            pnlPhai.Controls.AddRange(new Control[] { lblTim, txtTimKiem, btnTim, dgvLop, pnlPage });

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

        private static void SetLabel(Label l, string text, Point loc)
        { l.Text = text; l.Location = loc; l.AutoSize = true; }

        private static void SetButton(Button b, string text, Point loc, Color color)
        {
            b.Text = text; b.Size = new Size(190, 50); b.Location = loc;
            b.BackColor = color; b.ForeColor = Color.White;
            b.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        private static void SetPageBtn(Button b, string text, Point loc)
        {
            b.Text = text; b.Size = new Size(55, 35); b.Location = loc;
            b.BackColor = Color.WhiteSmoke; b.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        #endregion

        private DataGridView dgvLop;
        private TextBox txtMaID, txtMaLop, txtTenLop, txtGhiChu, txtTimKiem;
        private Label lblTrang;
    }
}