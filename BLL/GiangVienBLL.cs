using System;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class GiangVienBLL
    {
        private GiangVienDAL giangVienDAL;

        public GiangVienBLL()
        {
            giangVienDAL = new GiangVienDAL();
        }

        public DataTable GetAllGiangVien()
        {
            return giangVienDAL.GetAllGiangVien();
        }

        public void AddGiangVien(GiangVienDTO giangVien)
        {
            // Kiểm tra xem MaGV đã tồn tại chưa
            DataTable dt = giangVienDAL.SearchGiangVien(new GiangVienDTO { MaGV = giangVien.MaGV });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Mã giảng viên đã tồn tại, vui lòng chọn mã giảng viên khác.");
            }

            // Kiểm tra xem DienThoai đã tồn tại chưa
            dt = giangVienDAL.SearchGiangVien(new GiangVienDTO { DienThoai = giangVien.DienThoai });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Số điện thoại đã tồn tại, vui lòng chọn số điện thoại khác.");
            }

            // Kiểm tra xem Email đã tồn tại chưa
            dt = giangVienDAL.SearchGiangVien(new GiangVienDTO { Email = giangVien.Email });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Email đã tồn tại, vui lòng chọn email khác.");
            }

            giangVienDAL.AddGiangVien(giangVien);
        }

        public void UpdateGiangVien(GiangVienDTO giangVien, string originalMaGV)
        {
            // Kiểm tra xem MaGV đã tồn tại chưa (trừ giảng viên hiện tại)
            DataTable dt = giangVienDAL.SearchGiangVien(new GiangVienDTO { MaGV = giangVien.MaGV });
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaGV"].ToString() != originalMaGV)
            {
                throw new Exception("Mã giảng viên đã tồn tại, vui lòng chọn mã giảng viên khác.");
            }

            // Kiểm tra xem DienThoai đã tồn tại chưa (trừ giảng viên hiện tại)
            dt = giangVienDAL.SearchGiangVien(new GiangVienDTO { DienThoai = giangVien.DienThoai });
            if (dt.Rows.Count > 0 && dt.Rows[0]["DienThoai"].ToString() != giangVien.DienThoai)
            {
                throw new Exception("Số điện thoại đã tồn tại, vui lòng chọn số điện thoại khác.");
            }

            // Kiểm tra xem Email đã tồn tại chưa (trừ giảng viên hiện tại)
            dt = giangVienDAL.SearchGiangVien(new GiangVienDTO { Email = giangVien.Email });
            if (dt.Rows.Count > 0 && dt.Rows[0]["Email"].ToString() != giangVien.Email)
            {
                throw new Exception("Email đã tồn tại, vui lòng chọn email khác.");
            }

            giangVienDAL.UpdateGiangVien(giangVien, originalMaGV);
        }

        public void DeleteGiangVien(string maGV)
        {
            giangVienDAL.DeleteGiangVien(maGV);
        }

        public DataTable SearchGiangVien(GiangVienDTO giangVien)
        {
            return giangVienDAL.SearchGiangVien(giangVien);
        }
    }
}
