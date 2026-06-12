using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSharp_68PM1_NguyenVanCong_0003768
{
    public partial class StudentManagementControl : UserControl
    {
        public event EventHandler LogoutRequested;
        public event EventHandler ViewClassRequested;

        private string connectionString = "Server=congchimdai;Database=qlsv;Trusted_Connection=True;";

        public StudentManagementControl()
        {
            InitializeComponent();
            LoadDanhSachLop();
            HienThiDanhSach();
        }

        // ── Kết nối DB ────────────────────────────────────────────
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // ── Load danh sách lớp vào ComboBox ───────────────────────
        private void LoadDanhSachLop()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    string sql = "SELECT malop, tenlop FROM tbl_lophoc ORDER BY malop";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboLop.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                        cboLop.Items.Add(row["malop"].ToString() + " - Lớp " + row["tenlop"].ToString());

                    if (cboLop.Items.Count > 0)
                        cboLop.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách lớp:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Hiển thị danh sách sinh viên ──────────────────────────
        private void HienThiDanhSach()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    string sql = @"SELECT s.id, s.hoten, s.gioitinh, 
                                          CONVERT(varchar, s.ngaysinh, 103) AS ngaysinh, 
                                          s.malop
                                   FROM tbl_sinhviens s
                                   ORDER BY s.id";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSinhVien.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvSinhVien.Rows.Add(
                            row["id"].ToString(),
                            row["hoten"].ToString(),
                            row["gioitinh"].ToString(),
                            row["ngaysinh"].ToString(),
                            row["malop"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Kiểm tra trùng mã SV ──────────────────────────────────
        private bool KiemTraTrungMaSV(string maSV, string boQuaId = "-1")
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    string sql = "SELECT COUNT(*) FROM tbl_sinhviens WHERE CAST(id AS varchar) = @id AND CAST(id AS varchar) <> @boQua";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", maSV);
                    cmd.Parameters.AddWithValue("@boQua", boQuaId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
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

            // ✅ Kiểm tra trùng mã SV
            if (KiemTraTrungMaSV(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Mã sinh viên \"" + txtMaSV.Text.Trim() + "\" đã tồn tại!\nVui lòng nhập mã khác.",
                    "Trùng mã sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                txtMaSV.SelectAll();
                return;
            }

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    string sql = @"INSERT INTO tbl_sinhviens (id, hoten, gioitinh, ngaysinh, malop)
                                   VALUES (@id, @hoten, @gioitinh, @ngaysinh, @malop)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtMaSV.Text.Trim()));
                    cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@malop", cboLop.Text.Split('-')[0].Trim());
                    cmd.ExecuteNonQuery();
                }

                HienThiDanhSach();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Sửa ───────────────────────────────────────────────────
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;

            string idGoc = dgvSinhVien.CurrentRow.Cells["MaSV"].Value?.ToString();

            // ✅ Kiểm tra trùng mã SV (bỏ qua chính nó)
            if (txtMaSV.Text.Trim() != idGoc &&
                KiemTraTrungMaSV(txtMaSV.Text.Trim(), boQuaId: idGoc))
            {
                MessageBox.Show("Mã sinh viên \"" + txtMaSV.Text.Trim() + "\" đã tồn tại!\nVui lòng nhập mã khác.",
                    "Trùng mã sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                txtMaSV.SelectAll();
                return;
            }

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    string sql = @"UPDATE tbl_sinhviens 
                                   SET id = @idMoi, hoten = @hoten, gioitinh = @gioitinh, 
                                       ngaysinh = @ngaysinh, malop = @malop
                                   WHERE id = @idGoc";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@idMoi", int.Parse(txtMaSV.Text.Trim()));
                    cmd.Parameters.AddWithValue("@hoten", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@malop", cboLop.Text.Split('-')[0].Trim());
                    cmd.Parameters.AddWithValue("@idGoc", int.Parse(idGoc));
                    cmd.ExecuteNonQuery();
                }

                HienThiDanhSach();
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Xóa ───────────────────────────────────────────────────
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null) return;

            string idXoa = dgvSinhVien.CurrentRow.Cells["MaSV"].Value?.ToString();

            var result = MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = GetConnection())
                    {
                        con.Open();
                        string sql = "DELETE FROM tbl_sinhviens WHERE id = @id";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@id", int.Parse(idXoa));
                        cmd.ExecuteNonQuery();
                    }

                    HienThiDanhSach();
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên:\n" + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            HienThiDanhSach();
        }

        // ── Tìm kiếm ──────────────────────────────────────────────
        private void BtnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    string sql = @"SELECT s.id, s.hoten, s.gioitinh,
                                          CONVERT(varchar, s.ngaysinh, 103) AS ngaysinh,
                                          s.malop
                                   FROM tbl_sinhviens s
                                   WHERE CAST(s.id AS varchar) LIKE @kw 
                                      OR s.hoten LIKE @kw 
                                      OR s.malop LIKE @kw
                                   ORDER BY s.id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSinhVien.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dgvSinhVien.Rows.Add(
                            row["id"].ToString(),
                            row["hoten"].ToString(),
                            row["gioitinh"].ToString(),
                            row["ngaysinh"].ToString(),
                            row["malop"].ToString()
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm:\n" + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // feat: Xử lý sự kiện click vào dòng DataGridView
        private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

            // Điền mã sinh viên và họ tên
            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? string.Empty;
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;

            // Điền giới tính
            string gioiTinh = row.Cells["GioiTinh"].Value?.ToString() ?? "Nam";
            if (cboGioiTinh.Items.Contains(gioiTinh))
                cboGioiTinh.SelectedItem = gioiTinh;

            // Điền ngày sinh
            string ngaySinhStr = row.Cells["NgaySinh"].Value?.ToString() ?? string.Empty;
            if (DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime ngaySinh))
            {
                dtpNgaySinh.Value = ngaySinh;
            }

            // Điền lớp học
            string maLop = row.Cells["Lop"].Value?.ToString() ?? string.Empty;
            foreach (var item in cboLop.Items)
            {
                if (item.ToString().StartsWith(maLop))
                {
                    cboLop.SelectedItem = item;
                    break;
                }
            }
        }

        private void MnuLop_Click(object sender, EventArgs e)
            => ViewClassRequested?.Invoke(this, EventArgs.Empty);

        // ── Đăng xuất ─────────────────────────────────────────────
        private void MnuDangXuat_Click(object sender, EventArgs e)
        {
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}