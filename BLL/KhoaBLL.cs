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
    public class KhoaBLL
    {
        private KhoaDAL khoaDAL;

        public KhoaBLL()
        {
            khoaDAL = new KhoaDAL();
        }

        public DataTable GetAllKhoa()
        {
            return khoaDAL.GetAllKhoa();
        }

        public void AddKhoa(KhoaDTO khoa)
        {
            // Kiểm tra xem MaKhoa đã tồn tại chưa
            DataTable dt = khoaDAL.SearchKhoa(new KhoaDTO { MaKhoa = khoa.MaKhoa });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Mã khoa đã tồn tại, vui lòng chọn mã khoa khác.");
            }

            // Kiểm tra xem TenKhoa đã tồn tại chưa
            dt = khoaDAL.SearchKhoa(new KhoaDTO { TenKhoa = khoa.TenKhoa });
            if (dt.Rows.Count > 0)
            {
                throw new Exception("Tên khoa đã tồn tại, vui lòng chọn tên khoa khác.");
            }

            khoaDAL.AddKhoa(khoa);
        }

        public void UpdateKhoa(KhoaDTO khoa)
        {
            // Lấy bản ghi Khoa hiện tại
            DataTable currentKhoaData = khoaDAL.SearchKhoa(new KhoaDTO { MaKhoa = khoa.MaKhoa });
            if (currentKhoaData.Rows.Count == 0)
            {
                throw new Exception("Khoa không tồn tại.");
            }

            string currentMaKhoa = currentKhoaData.Rows[0]["MaKhoa"].ToString();
            string currentTenKhoa = currentKhoaData.Rows[0]["TenKhoa"].ToString();

            // Kiểm tra xem MaKhoa có bị thay đổi không
            if (currentMaKhoa != khoa.MaKhoa)
            {
                throw new Exception("Không được phép thay đổi Mã Khoa.");
            }

            // Kiểm tra xem TenKhoa có duy nhất, ngoại trừ bản ghi hiện tại
            DataTable dt = khoaDAL.SearchKhoa(new KhoaDTO { TenKhoa = khoa.TenKhoa });
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaKhoa"].ToString() != khoa.MaKhoa)
            {
                throw new Exception("Tên khoa đã tồn tại, vui lòng chọn tên khoa khác.");
            }

            // Chỉ cập nhật TenKhoa
            khoaDAL.UpdateKhoa(khoa);
        }

        public void DeleteKhoa(string maKhoa)
        {
            // Kiểm tra xem có sinh viên nào đang tham chiếu tới mã khoa này không
            DataTable sinhVienData = khoaDAL.GetSinhVienByMaKhoa(maKhoa);
            if (sinhVienData.Rows.Count > 0)
            {
                throw new Exception("Không thể xóa mã khoa này vì có sinh viên đang liên kết tới mã khoa này.");
            }

            // Nếu không có sinh viên liên quan, tiến hành xóa
            khoaDAL.DeleteKhoa(maKhoa);
        }

        public DataTable SearchKhoa(KhoaDTO khoa)
        {
            return khoaDAL.SearchKhoa(khoa);
        }
    }
}
