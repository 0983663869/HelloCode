using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class SinhVienBLL
    {
        private SinhVienDAL sinhVienDAL;

        public SinhVienBLL()
        {
            sinhVienDAL = new SinhVienDAL();
        }

        public DataTable GetAllSinhVien()
        {
            return sinhVienDAL.GetAllSinhVien();
        }

        public void AddSinhVien(SinhVienDTO sinhVien)
        {
            // Kiểm tra xem MaSV đã tồn tại chưa
            DataTable dt = sinhVienDAL.SearchSinhVien(new SinhVienDTO { MaSV = sinhVien.MaSV });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Mã sinh viên đã tồn tại, vui lòng chọn mã sinh viên khác.");
            }

            // Kiểm tra xem DienThoai đã tồn tại chưa
            dt = sinhVienDAL.SearchSinhVien(new SinhVienDTO { DienThoai = sinhVien.DienThoai });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Số điện thoại đã tồn tại, vui lòng chọn số điện thoại khác.");
            }

            // Kiểm tra xem Email đã tồn tại chưa
            dt = sinhVienDAL.SearchSinhVien(new SinhVienDTO { Email = sinhVien.Email });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Email đã tồn tại, vui lòng chọn email khác.");
            }

            sinhVienDAL.AddSinhVien(sinhVien);
        }

        public void UpdateSinhVien(SinhVienDTO sinhVien, string originalMaSV)
        {
            // Kiểm tra xem MaSV đã tồn tại chưa (trừ sinh viên hiện tại)
            DataTable dt = sinhVienDAL.SearchSinhVien(new SinhVienDTO { MaSV = sinhVien.MaSV });
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaSV"].ToString() != originalMaSV)
            {
                throw new Exception("Mã sinh viên đã tồn tại, vui lòng chọn mã sinh viên khác.");
            }

            // Kiểm tra xem DienThoai đã tồn tại chưa (trừ sinh viên hiện tại)
            dt = sinhVienDAL.SearchSinhVien(new SinhVienDTO { DienThoai = sinhVien.DienThoai });
            if (dt.Rows.Count > 0 && dt.Rows[0]["DienThoai"].ToString() != sinhVien.DienThoai)
            {
                throw new Exception("Số điện thoại đã tồn tại, vui lòng chọn số điện thoại khác.");
            }

            // Kiểm tra xem Email đã tồn tại chưa (trừ sinh viên hiện tại)
            dt = sinhVienDAL.SearchSinhVien(new SinhVienDTO { Email = sinhVien.Email });
            if (dt.Rows.Count > 0 && dt.Rows[0]["Email"].ToString() != sinhVien.Email)
            {
                throw new Exception("Email đã tồn tại, vui lòng chọn email khác.");
            }

            sinhVienDAL.UpdateSinhVien(sinhVien, originalMaSV);
        }

        public void DeleteSinhVien(string maSV)
        {
            sinhVienDAL.DeleteSinhVien(maSV);
        }

        public DataTable SearchSinhVien(SinhVienDTO sinhVien)
        {
            return sinhVienDAL.SearchSinhVien(sinhVien);
        }
    }
}