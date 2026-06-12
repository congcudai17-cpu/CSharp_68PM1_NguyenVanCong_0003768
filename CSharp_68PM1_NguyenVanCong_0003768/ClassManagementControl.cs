using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class ClassManagementControl : UserControl
    {
        public event EventHandler LogoutRequested;
        public event EventHandler ViewStudentsRequested;

        // ── Thay đổi connection string nếu cần ──────────────────────────────
        private readonly string connStr =
            "Server=CONGCHIMDAI;Database=qlsv;Integrated Security=True;";
        // Nếu dùng SQL Auth thì dùng dòng dưới (xoá dòng trên):
        // "Server=CONGCHIMDAI;Database=qlsv;User Id=sa;Password=YOUR_PASSWORD;";
        // ────────────────────────────────────────────────────────────────────

        private int currentPage = 1;
        private int pageSize = 10;
        private string currentKeyword = "";

        public ClassManagementControl()
        {
            InitializeComponent();
            HienThiDanhSach();
        }

        // ── Lấy tổng số bản ghi (có filter) ─────────────────────────────────
        private int GetTotalCount(string keyword)
        {
            string sql = @"SELECT COUNT(*) FROM [qlsv].[dbo].[tbl_lophoc]
                           WHERE (@kw = '' OR
                                  CAST(id AS NVARCHAR) LIKE '%'+@kw+'%' OR
                                  malop  LIKE '%'+@kw+'%' OR
                                  tenlop LIKE '%'+@kw+'%')";
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@kw", keyword);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // ── Load dữ liệu từ DB lên DataGridView ─────────────────────────────
        private void HienThiDanhSach(string keyword = "")
        {
            currentKeyword = keyword;
            dgvLop.Rows.Clear();

            try
            {
                int total = GetTotalCount(keyword);
                int totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)pageSize));
                if (currentPage > totalPages) currentPage = totalPages;
                lblTrang.Text = $"Trang {currentPage}/{totalPages}  |  {total} bản ghi";

                int offset = (currentPage - 1) * pageSize;

                string sql = @"SELECT id, malop, tenlop, ghichu
                               FROM [qlsv].[dbo].[tbl_lophoc]
                               WHERE (@kw = '' OR
                                      CAST(id AS NVARCHAR) LIKE '%'+@kw+'%' OR
                                      malop  LIKE '%'+@kw+'%' OR
                                      tenlop LIKE '%'+@kw+'%')
                               ORDER BY id
                               OFFSET @offset ROWS FETCH NEXT @size ROWS ONLY";

                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", keyword);
                    cmd.Parameters.AddWithValue("@offset", offset);
                    cmd.Parameters.AddWithValue("@size", pageSize);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvLop.Rows.Add(
                                reader["id"].ToString(),
                                reader["malop"].ToString(),
                                reader["tenlop"].ToString(),
                                reader["ghichu"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối database:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // feat: Thêm lớp học mới vào hệ thống
        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(maLop) || string.IsNullOrWhiteSpace(tenLop))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã lớp và Tên lớp!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string sql = @"INSERT INTO [qlsv].[dbo].[tbl_lophoc] (malop, tenlop, ghichu)
                         VALUES (@malop, @tenlop, @ghichu)";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", maLop);
                    cmd.Parameters.AddWithValue("@tenlop", tenLop);
                    cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                HienThiDanhSach(currentKeyword);
                LamMoi();
                MessageBox.Show("Thêm lớp thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // feat: Cập nhật thông tin lớp học
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaID.Text))
            {
                MessageBox.Show("Vui lòng chọn một lớp để sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string sql = @"UPDATE [qlsv].[dbo].[tbl_lophoc]
                         SET malop  = @malop,
                             tenlop = @tenlop,
                             ghichu = @ghichu
                         WHERE id = @id";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtMaID.Text.Trim()));
                    cmd.Parameters.AddWithValue("@malop", txtMaLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@tenlop", txtTenLop.Text.Trim());
                    cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text.Trim());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                HienThiDanhSach(currentKeyword);
                LamMoi();
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // feat: Xóa lớp học khỏi hệ thống
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaID.Text))
            {
                MessageBox.Show("Vui lòng chọn một lớp để xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa lớp này?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            const string sql = "DELETE FROM [qlsv].[dbo].[tbl_lophoc] WHERE id = @id";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtMaID.Text.Trim()));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                HienThiDanhSach(currentKeyword);
                LamMoi();
                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Làm mới form ─────────────────────────────────────────────────────
        private void LamMoi()
        {
            txtMaID.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtGhiChu.Clear();
        }

        private void BtnLamMoi_Click(object sender, EventArgs e) => LamMoi();

        // ── Tìm kiếm ─────────────────────────────────────────────────────────
        private void BtnTim_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            HienThiDanhSach(txtTimKiem.Text.Trim().ToLower());
        }

        // feat: Click vào dòng trong bảng → điền vào form
        private void DgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaID.Text = row.Cells["MaID"].Value?.ToString() ?? string.Empty;
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString() ?? string.Empty;
            txtTenLop.Text = row.Cells["TenLop"].Value?.ToString() ?? string.Empty;
            txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? string.Empty;
            // Hiển thị sinh viên thuộc lớp này
            HienThiSinhVienTheoLop(txtMaLop.Text);
        }
        

        // ── Phân trang ───────────────────────────────────────────────────────
        private void BtnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            HienThiDanhSach(currentKeyword);
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) { currentPage--; HienThiDanhSach(currentKeyword); }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            HienThiDanhSach(currentKeyword);
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            int total = GetTotalCount(currentKeyword);
            currentPage = Math.Max(1, (int)Math.Ceiling(total / (double)pageSize));
            HienThiDanhSach(currentKeyword);
        }

        // ── Menu ─────────────────────────────────────────────────────────────
        private void MnuSinhVien_Click(object sender, EventArgs e) =>
            ViewStudentsRequested?.Invoke(this, EventArgs.Empty);

        private void MnuDangXuat_Click(object sender, EventArgs e) =>
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        // feat: Hiển thị danh sách sinh viên theo lớp được chọn
        private void HienThiSinhVienTheoLop(string maLop)
        {
            dgvSinhVien.Rows.Clear();
            if (string.IsNullOrWhiteSpace(maLop)) return;

            const string sql = @"SELECT s.id,
                                        s.hoten,
                                        s.gioitinh,
                                        CONVERT(varchar, s.ngaysinh, 103) AS ngaysinh
                                 FROM   tbl_sinhviens s
                                 WHERE  s.malop = @malop
                                 ORDER BY s.id";
            try
            {
                using (var conn = new SqlConnection(connStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", maLop);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvSinhVien.Rows.Add(
                                reader["id"].ToString(),
                                reader["hoten"].ToString(),
                                reader["gioitinh"].ToString(),
                                reader["ngaysinh"].ToString()
                            );
                        }
                    }
                }
                lblSinhVien.Text = $"Sinh viên lớp: {maLop}  |  {dgvSinhVien.Rows.Count} sinh viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}