using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class SinhVienDAL
    {
        private readonly DatabaseConnection _dbConnection;

        public SinhVienDAL()
        {
            _dbConnection = new DatabaseConnection();
        }

        public DataTable GetAllSinhVien()
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SinhVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddSinhVien(SinhVienDTO sinhVien)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SinhVien (MaSV, TenSV, DienThoai, Email, Lop, MaKhoa) VALUES (@MaSV, @TenSV, @DienThoai, @Email, @Lop, @MaKhoa)", conn);
                cmd.Parameters.AddWithValue("@MaSV", sinhVien.MaSV);
                cmd.Parameters.AddWithValue("@TenSV", sinhVien.TenSV);
                cmd.Parameters.AddWithValue("@DienThoai", sinhVien.DienThoai);
                cmd.Parameters.AddWithValue("@Email", sinhVien.Email);
                cmd.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                cmd.Parameters.AddWithValue("@MaKhoa", sinhVien.MaKhoa);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSinhVien(SinhVienDTO sinhVien, string originalMaSV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE SinhVien 
                    SET MaSV = @MaSV, TenSV = @TenSV, DienThoai = @DienThoai, Email = @Email, Lop = @Lop, MaKhoa = @MaKhoa 
                    WHERE MaSV = @OriginalMaSV", conn);

                cmd.Parameters.AddWithValue("@MaSV", sinhVien.MaSV);
                cmd.Parameters.AddWithValue("@TenSV", sinhVien.TenSV);
                cmd.Parameters.AddWithValue("@DienThoai", sinhVien.DienThoai);
                cmd.Parameters.AddWithValue("@Email", sinhVien.Email);
                cmd.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                cmd.Parameters.AddWithValue("@MaKhoa", sinhVien.MaKhoa);
                cmd.Parameters.AddWithValue("@OriginalMaSV", originalMaSV);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM SinhVien WHERE MaSV = @MaSV", conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.ExecuteNonQuery();
            }
        }

        // Kiểm tra xem sinh viên có dữ liệu liên quan trong bảng Đề tài hay không.
        public bool HasRelatedDeTai(string maSV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DeTai WHERE MaSV = @MaSV", conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public DataTable SearchSinhVien(SinhVienDTO sinhVien)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SearchSinhVien", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@MaSV", (object)sinhVien.MaSV ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@TenSV", (object)sinhVien.TenSV ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@DienThoai", (object)sinhVien.DienThoai ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@Email", (object)sinhVien.Email ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@Lop", (object)sinhVien.Lop ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@MaKhoa", (object)sinhVien.MaKhoa ?? DBNull.Value);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Kiểm tra tính hợp lệ của Mã Khoa bằng cách xác nhận rằng Mã Khoa tồn tại trong bảng Khoa.
        public bool IsValidMaKhoa(string maKhoa)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Khoa WHERE MaKhoa = @MaKhoa", conn);
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Kiểm tra xem Mã SV đã tồn tại trong cơ sở dữ liệu hay chưa.
        public bool IsMaSVExists(string maSV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV", conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Kiểm tra xem số Điện thoại đã tồn tại trong cơ sở dữ liệu hay chưa, có hỗ trợ cho việc cập nhật (loại trừ Mã SV ban đầu).
        public bool IsDienThoaiExists(string dienThoai, string originalMaSV = null)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SinhVien WHERE DienThoai = @DienThoai";
                if (originalMaSV != null)
                {
                    query += " AND MaSV != @OriginalMaSV";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DienThoai", dienThoai);
                if (originalMaSV != null)
                {
                    cmd.Parameters.AddWithValue("@OriginalMaSV", originalMaSV);
                }
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        // Kiểm tra xem Email đã tồn tại trong cơ sở dữ liệu hay chưa, có hỗ trợ cho việc cập nhật (loại trừ Mã SV ban đầu).
        public bool IsEmailExists(string email, string originalMaSV = null)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SinhVien WHERE Email = @Email";
                if (originalMaSV != null)
                {
                    query += " AND MaSV != @OriginalMaSV";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                if (originalMaSV != null)
                {
                    cmd.Parameters.AddWithValue("@OriginalMaSV", originalMaSV);
                }
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
