using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class ClassManagementControl : UserControl
    {
        public event EventHandler LogoutRequested;
        public event EventHandler ViewStudentsRequested;

        private List<string[]> dsLop = new List<string[]>
        {
            new string[] { "1", "68PM1", "Lớp 68PM1", "abc" },
            new string[] { "2", "68PM2", "Lớp 68PM2", "xyz" },
        };

        private int currentPage = 1;
        private int pageSize = 10;

        public ClassManagementControl()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        private void HienThiDanhSach(string keyword = "")
        {
            dgvLop.Rows.Clear();
            int start = (currentPage - 1) * pageSize;
            int count = 0;

            foreach (var lop in dsLop)
            {
                bool match = string.IsNullOrEmpty(keyword) ||
                             lop[0].ToLower().Contains(keyword) ||
                             lop[1].ToLower().Contains(keyword) ||
                             lop[2].ToLower().Contains(keyword);
                if (match) count++;
            }

            int totalPages = Math.Max(1, (int)Math.Ceiling(count / (double)pageSize));
            lblTrang.Text = $"Trang {currentPage}/{totalPages}  |  {count} bản ghi";

            int added = 0, skipped = 0;
            foreach (var lop in dsLop)
            {
                bool match = string.IsNullOrEmpty(keyword) ||
                             lop[0].ToLower().Contains(keyword) ||
                             lop[1].ToLower().Contains(keyword) ||
                             lop[2].ToLower().Contains(keyword);
                if (!match) continue;
                if (skipped < start) { skipped++; continue; }
                if (added >= pageSize) break;
                dgvLop.Rows.Add(lop);
                added++;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text) ||
                string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newId = (dsLop.Count + 1).ToString();
            dsLop.Add(new string[] {
                newId,
                txtMaLop.Text.Trim(),
                txtTenLop.Text.Trim(),
                txtGhiChu.Text.Trim()
            });
            HienThiDanhSach();
            MessageBox.Show("Thêm lớp thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null) return;
            int idx = dgvLop.CurrentRow.Index;

            dsLop[idx] = new string[] {
                txtMaID.Text.Trim(),
                txtMaLop.Text.Trim(),
                txtTenLop.Text.Trim(),
                txtGhiChu.Text.Trim()
            };
            HienThiDanhSach();
            MessageBox.Show("Cập nhật thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null) return;
            int idx = dgvLop.CurrentRow.Index;

            var result = MessageBox.Show("Bạn có chắc muốn xóa lớp này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dsLop.RemoveAt(idx);
                HienThiDanhSach();
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaID.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtGhiChu.Clear();
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            HienThiDanhSach(txtTimKiem.Text.Trim().ToLower());
        }

        private void DgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLop.Rows[e.RowIndex];
            txtMaID.Text = row.Cells["MaID"].Value?.ToString();
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
            txtTenLop.Text = row.Cells["TenLop"].Value?.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
        }

        private void BtnFirst_Click(object sender, EventArgs e) { currentPage = 1; HienThiDanhSach(txtTimKiem.Text.Trim().ToLower()); }
        private void BtnPrev_Click(object sender, EventArgs e) { if (currentPage > 1) { currentPage--; HienThiDanhSach(txtTimKiem.Text.Trim().ToLower()); } }
        private void BtnNext_Click(object sender, EventArgs e) { currentPage++; HienThiDanhSach(txtTimKiem.Text.Trim().ToLower()); }
        private void BtnLast_Click(object sender, EventArgs e)
        {
            int total = (int)Math.Ceiling(dsLop.Count / (double)pageSize);
            currentPage = Math.Max(1, total);
            HienThiDanhSach(txtTimKiem.Text.Trim().ToLower());
        }

        private void MnuSinhVien_Click(object sender, EventArgs e) => ViewStudentsRequested?.Invoke(this, EventArgs.Empty);
        private void MnuDangXuat_Click(object sender, EventArgs e) => LogoutRequested?.Invoke(this, EventArgs.Empty);
    }
}