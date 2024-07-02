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
            // Validate input
            ValidateGiangVien(giangVien);

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
            // Validate input
            ValidateGiangVien(giangVien);

            // Kiểm tra giảng viên có được tham chiếu tới bảng đề tài không
            if (giangVienDAL.CanUpdateGiangVien(originalMaGV))
            {
                throw new Exception("Giảng viên này đang tồn tại trong bảng đề tài, không thể sửa.");
            }

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
            if (giangVienDAL.CanDeleteGiangVien(maGV))
            {
                giangVienDAL.DeleteGiangVien(maGV);
            }
            else
            {
                throw new Exception("Không thể xóa giảng viên vì có dữ liệu liên quan trong bảng Đề tài.");
            }
        }

        public DataTable SearchGiangVien(GiangVienDTO giangVien)
        {
            return giangVienDAL.SearchGiangVien(giangVien);
        }

        private void ValidateGiangVien(GiangVienDTO giangVien)
        {
            if (string.IsNullOrWhiteSpace(giangVien.MaGV))
            {
                throw new Exception("Mã giảng viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(giangVien.TenGV))
            {
                throw new Exception("Tên giảng viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(giangVien.DienThoai))
            {
                throw new Exception("Số điện thoại không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(giangVien.Email))
            {
                throw new Exception("Email không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(giangVien.NoiCongTac))
            {
                throw new Exception("Nơi công tác không được để trống.");
            }
        }
    }
}
