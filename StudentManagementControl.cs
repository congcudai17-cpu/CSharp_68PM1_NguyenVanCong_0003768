using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class StudentManagementControl : UserControl
    {
        // Event để thông báo đăng xuất lên Form cha
        public event EventHandler LogoutRequested;

        private List<string[]> dsSinhVien = new List<string[]>
        {
            new string[] { "1", "hieu",         "Nam", "11/03/2026", "68PM1" },
            new string[] { "2", "Nguyễn Văn B", "Nam", "11/03/2026", "68PM2" },
            new string[] { "3", "Trần Văn C",   "Nam", "21/03/2026", "68PM2" },
        };

        public StudentManagementControl()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        // ── Hiển thị ──────────────────────────────────────────────
        private void HienThiDanhSach()
        {
            dgvSinhVien.Rows.Clear();
            foreach (var sv in dsSinhVien)
                dgvSinhVien.Rows.Add(sv);
        }

        // ── Thêm ──────────────────────────────────────────────────
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) ||
                string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dsSinhVien.Add(new string[] {
                txtMaSV.Text.Trim(),
                txtHoTen.Text.Trim(),
                cboGioiTinh.Text,
                dtpNgaySinh.Value.ToString("dd/MM/yyyy"),
                cboLop.Text.Split('-')[0].Trim()
            });

            HienThiDanhSach();
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Sửa ───────────────────────────────────────────────────
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;
            int idx = dgvSinhVien.CurrentRow.Index;

            dsSinhVien[idx] = new string[] {
                txtMaSV.Text.Trim(),
                txtHoTen.Text.Trim(),
                cboGioiTinh.Text,
                dtpNgaySinh.Value.ToString("dd/MM/yyyy"),
                cboLop.Text.Split('-')[0].Trim()
            };

            HienThiDanhSach();
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ── Xóa ───────────────────────────────────────────────────
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;
            int idx = dgvSinhVien.CurrentRow.Index;

            var result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dsSinhVien.RemoveAt(idx);
                HienThiDanhSach();
            }
        }

        // ── Làm mới ───────────────────────────────────────────────
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboGioiTinh.SelectedIndex = 0;
            cboLop.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Today;
        }

        // ── Tìm kiếm ──────────────────────────────────────────────
        private void BtnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            dgvSinhVien.Rows.Clear();

            foreach (var sv in dsSinhVien)
            {
                if (sv[0].ToLower().Contains(keyword) ||   // Mã SV
                    sv[1].ToLower().Contains(keyword) ||   // Họ tên
                    sv[4].ToLower().Contains(keyword))     // Lớp
                {
                    dgvSinhVien.Rows.Add(sv);
                }
            }
        }

        // ── Chọn dòng trên DataGridView → điền vào form ───────────
        private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSinhVien.Rows[e.RowIndex];

            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();

            string gt = row.Cells["GioiTinh"].Value?.ToString();
            cboGioiTinh.SelectedItem = gt ?? "Nam";

            if (DateTime.TryParseExact(row.Cells["NgaySinh"].Value?.ToString(),
                    "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime ngay))
                dtpNgaySinh.Value = ngay;

            string lop = row.Cells["Lop"].Value?.ToString();
            foreach (var item in cboLop.Items)
                if (item.ToString().StartsWith(lop))
                { cboLop.SelectedItem = item; break; }
        }

        // ── Đăng xuất ─────────────────────────────────────────────
        private void MnuDangXuat_Click(object sender, EventArgs e)
        {
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}