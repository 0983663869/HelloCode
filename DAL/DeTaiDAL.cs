using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DeTaiDAL
    {
        private readonly DatabaseConnection _dbConnection;

        public DeTaiDAL()
        {
            _dbConnection = new DatabaseConnection();
        }

        public DataTable GetAllDeTai()
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DeTai", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddDeTai(DeTaiDTO deTai)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO DeTai (MaDT, TenDT, MaGV, MaSV, Diem, TrangThai, XepLoai)
            VALUES (@MaDT, @TenDT, @MaGV, @MaSV, @Diem, @TrangThai, @XepLoai)", conn);

                cmd.Parameters.AddWithValue("@MaDT", deTai.MaDT);
                cmd.Parameters.AddWithValue("@TenDT", deTai.TenDT);
                cmd.Parameters.AddWithValue("@MaGV", deTai.MaGV);
                cmd.Parameters.AddWithValue("@MaSV", deTai.MaSV);
                cmd.Parameters.AddWithValue("@Diem", (object)deTai.Diem ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", deTai.TrangThai);

                // Ensure @XepLoai is provided, even if it's null
                cmd.Parameters.AddWithValue("@XepLoai", (object)deTai.XepLoai ?? DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateDeTai(DeTaiDTO deTai, string originalMaDT)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE DeTai
                    SET TenDT = @TenDT, MaGV = @MaGV, MaSV = @MaSV, Diem = @Diem, TrangThai = @TrangThai, XepLoai = @XepLoai
                    WHERE MaDT = @OriginalMaDT", conn);

                cmd.Parameters.AddWithValue("@TenDT", deTai.TenDT);
                cmd.Parameters.AddWithValue("@MaGV", deTai.MaGV);
                cmd.Parameters.AddWithValue("@MaSV", deTai.MaSV);
                cmd.Parameters.AddWithValue("@Diem", (object)deTai.Diem ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", deTai.TrangThai);
                cmd.Parameters.AddWithValue("@XepLoai", deTai.XepLoai);
                cmd.Parameters.AddWithValue("@OriginalMaDT", originalMaDT);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDeTai(string maDT)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM DeTai WHERE MaDT = @MaDT", conn);
                cmd.Parameters.AddWithValue("@MaDT", maDT);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable SearchDeTai(DeTaiDTO deTai)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_SearchDeTai", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@MaDT", (object)deTai.MaDT ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@TenDT", (object)deTai.TenDT ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@MaGV", (object)deTai.MaGV ?? DBNull.Value);
                da.SelectCommand.Parameters.AddWithValue("@MaSV", (object)deTai.MaSV ?? DBNull.Value);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool ExistsMaDT(string maDT)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DeTai WHERE MaDT = @MaDT", conn);
                cmd.Parameters.AddWithValue("@MaDT", maDT);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool ExistsMaGV(string maGV)
        {
            using (SqlConnection conn = _dbConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GiangVien WHERE MaGV = @MaGV", conn);
                cmd.Parameters.AddWithValue("@MaGV", maGV);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public bool ExistsMaSV(string maSV)
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
    }
}
