using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class KhoaDAL
    {
        private readonly DatabaseConnection _dbConnection;

        public KhoaDAL()
        {
            _dbConnection = new DatabaseConnection();
        }

        public DataTable GetAllKhoa()
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Khoa", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddKhoa(KhoaDTO khoa)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES (@MaKhoa, @TenKhoa)", conn);
                cmd.Parameters.AddWithValue("@MaKhoa", khoa.MaKhoa);
                cmd.Parameters.AddWithValue("@TenKhoa", khoa.TenKhoa);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateKhoa(KhoaDTO khoa)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Khoa SET TenKhoa = @TenKhoa WHERE MaKhoa = @MaKhoa", conn);
                cmd.Parameters.AddWithValue("@MaKhoa", khoa.MaKhoa);
                cmd.Parameters.AddWithValue("@TenKhoa", khoa.TenKhoa);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteKhoa(string maKhoa)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Khoa WHERE MaKhoa = @MaKhoa", conn);
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetSinhVienByMaKhoa(string maKhoa)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SinhVien WHERE MaKhoa = @MaKhoa", conn);
                da.SelectCommand.Parameters.AddWithValue("@MaKhoa", maKhoa);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable SearchKhoa(KhoaDTO khoa)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SearchKhoa", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@MaKhoa", (object)khoa.MaKhoa ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@TenKhoa", (object)khoa.TenKhoa ?? DBNull.Value);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
