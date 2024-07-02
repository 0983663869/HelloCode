using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class GiangVienDAL
    {
        private readonly DatabaseConnection _dbConnection;

        public GiangVienDAL()
        {
            _dbConnection = new DatabaseConnection();
        }

        public DataTable GetAllGiangVien()
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM GiangVien", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddGiangVien(GiangVienDTO giangVien)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO GiangVien (MaGV, TenGV, DienThoai, Email, NoiCongTac) VALUES (@MaGV, @TenGV, @DienThoai, @Email, @NoiCongTac)", conn);
                cmd.Parameters.AddWithValue("@MaGV", giangVien.MaGV);
                cmd.Parameters.AddWithValue("@TenGV", giangVien.TenGV);
                cmd.Parameters.AddWithValue("@DienThoai", giangVien.DienThoai);
                cmd.Parameters.AddWithValue("@Email", giangVien.Email);
                cmd.Parameters.AddWithValue("@NoiCongTac", giangVien.NoiCongTac);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateGiangVien(GiangVienDTO giangVien, string originalMaGV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE GiangVien 
                    SET MaGV = @MaGV, 
                        TenGV = @TenGV, 
                        DienThoai = @DienThoai,
                        Email = @Email, 
                        NoiCongTac = @NoiCongTac 
                    WHERE MaGV = @OriginalMaGV", conn);

                cmd.Parameters.AddWithValue("@MaGV", giangVien.MaGV);
                cmd.Parameters.AddWithValue("@TenGV", giangVien.TenGV);
                cmd.Parameters.AddWithValue("@DienThoai", giangVien.DienThoai);
                cmd.Parameters.AddWithValue("@Email", giangVien.Email);
                cmd.Parameters.AddWithValue("@NoiCongTac", giangVien.NoiCongTac);
                cmd.Parameters.AddWithValue("@OriginalMaGV", originalMaGV);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteGiangVien(string maGV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM GiangVien WHERE MaGV = @MaGV", conn);
                cmd.Parameters.AddWithValue("@MaGV", maGV);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable SearchGiangVien(GiangVienDTO giangVien)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SearchGiangVien", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@MaGV", (object)giangVien.MaGV ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@TenGV", (object)giangVien.TenGV ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@DienThoai", (object)giangVien.DienThoai ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@Email", (object)giangVien.Email ?? DBNull.Value);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Kiểm tra xem có thể xóa giảng viên hay không (nếu có dữ liệu liên quan trong bảng Đề tài).
        public bool CanDeleteGiangVien(string maGV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DeTai WHERE MaGV = @MaGV", conn);
                cmd.Parameters.AddWithValue("@MaGV", maGV);
                int count = (int)cmd.ExecuteScalar();
                return count == 0; // Trả về true nếu không có đề tài nào liên kết với giảng viên này
            }
        }

        // Kiểm tra xem có thể cập nhật thông tin giảng viên hay không (nếu đã có dữ liệu liên quan trong bảng Đề tài). 
        public bool CanUpdateGiangVien(string maGV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DeTai WHERE MaGV = @MaGV", conn);
                cmd.Parameters.AddWithValue("@MaGV", maGV);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
