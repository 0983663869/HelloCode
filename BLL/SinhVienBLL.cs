using System;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class SinhVienBLL
    {
        private readonly SinhVienDAL sinhVienDAL;

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
            ValidateSinhVien(sinhVien);
            CheckUniqueFields(sinhVien);

            sinhVienDAL.AddSinhVien(sinhVien);
        }

        public void UpdateSinhVien(SinhVienDTO sinhVien, string originalMaSV)
        {
            ValidateSinhVien(sinhVien);
            CheckDuplicateOnUpdate(sinhVien, originalMaSV);

            sinhVienDAL.UpdateSinhVien(sinhVien, originalMaSV);
        }

        public void DeleteSinhVien(string maSV)
        {
            if (sinhVienDAL.HasRelatedDeTai(maSV))
            {
                throw new Exception("Không thể xóa sinh viên này vì dữ liệu của nó đang tồn tại trong bảng đề tài.");
            }
            sinhVienDAL.DeleteSinhVien(maSV);
        }

        public DataTable SearchSinhVien(SinhVienDTO sinhVien)
        {
            return sinhVienDAL.SearchSinhVien(sinhVien);
        }

        // Kiểm tra tính hợp lệ của dữ liệu sinh viên. Nếu dữ liệu không hợp lệ, sẽ ném ra ngoại lệ tương ứng.
        private void ValidateSinhVien(SinhVienDTO sinhVien)
        {
            if (string.IsNullOrWhiteSpace(sinhVien.MaSV)) throw new Exception("Mã sinh viên không được để trống.");
            if (string.IsNullOrWhiteSpace(sinhVien.TenSV)) throw new Exception("Tên sinh viên không được để trống.");
            if (string.IsNullOrWhiteSpace(sinhVien.DienThoai)) throw new Exception("Số điện thoại không được để trống.");
            if (string.IsNullOrWhiteSpace(sinhVien.Email)) throw new Exception("Email không được để trống.");
            if (string.IsNullOrWhiteSpace(sinhVien.Lop)) throw new Exception("Lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(sinhVien.MaKhoa)) throw new Exception("Mã khoa không được để trống.");

            if (!sinhVienDAL.IsValidMaKhoa(sinhVien.MaKhoa))
            {
                throw new Exception("Mã khoa không tồn tại, vui lòng chọn mã khoa khác.");
            }
        }

        // Kiểm tra tính duy nhất của các trường
        private void CheckUniqueFields(SinhVienDTO sinhVien)
        {
            if (sinhVienDAL.IsMaSVExists(sinhVien.MaSV)) throw new Exception("Mã sinh viên đã tồn tại, vui lòng chọn mã sinh viên khác.");
            if (sinhVienDAL.IsDienThoaiExists(sinhVien.DienThoai)) throw new Exception("Số điện thoại đã tồn tại, vui lòng chọn số điện thoại khác.");
            if (sinhVienDAL.IsEmailExists(sinhVien.Email)) throw new Exception("Email đã tồn tại, vui lòng chọn email khác.");
        }

        // Kiểm tra sự trùng lặp khi cập nhật thông tin sinh viên, xác định xem có dữ liệu liên quan trong bảng Đề tài hay không.
        private void CheckDuplicateOnUpdate(SinhVienDTO sinhVien, string originalMaSV)
        {
            if (sinhVien.MaSV != originalMaSV && sinhVienDAL.IsMaSVExists(sinhVien.MaSV))
            {
                throw new Exception("Mã sinh viên đã tồn tại, vui lòng chọn mã sinh viên khác.");
            }

            if (sinhVienDAL.HasRelatedDeTai(originalMaSV))
            {
                throw new Exception("Không thể sửa sinh viên này vì dữ liệu của nó đang tồn tại trong bảng đề tài.");
            }

            if (sinhVienDAL.IsDienThoaiExists(sinhVien.DienThoai, originalMaSV)) throw new Exception("Số điện thoại đã tồn tại, vui lòng chọn số điện thoại khác.");
            if (sinhVienDAL.IsEmailExists(sinhVien.Email, originalMaSV)) throw new Exception("Email đã tồn tại, vui lòng chọn email khác.");
        }
    }
}
