using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class DeTaiBLL
    {
        private DeTaiDAL deTaiDAL;

        public DeTaiBLL()
        {
            deTaiDAL = new DeTaiDAL();
        }

        public DataTable GetAllDeTai()
        {
            return deTaiDAL.GetAllDeTai();
        }

        public void AddDeTai(DeTaiDTO deTai)
        {
            // Validate MaGV and MaSV
            if (!deTaiDAL.ExistsMaGV(deTai.MaGV))
            {
                throw new Exception("Mã giảng viên không tồn tại trong bảng Giảng Viên.");
            }
            if (!deTaiDAL.ExistsMaSV(deTai.MaSV))
            {
                throw new Exception("Mã sinh viên không tồn tại trong bảng Sinh Viên.");
            }

            // Kiểm tra xem MaDT đã tồn tại chưa
            if (deTaiDAL.ExistsMaDT(deTai.MaDT))
            {
                throw new Exception("Mã đề tài đã tồn tại trong hệ thống.");
            }

            deTaiDAL.AddDeTai(deTai);
        }

        public void UpdateDeTai(DeTaiDTO deTai, string originalMaDT)
        {
            // Validate MaGV and MaSV
            if (!deTaiDAL.ExistsMaGV(deTai.MaGV))
            {
                throw new Exception("Mã giảng viên không tồn tại trong bảng Giảng Viên.");
            }
            if (!deTaiDAL.ExistsMaSV(deTai.MaSV))
            {
                throw new Exception("Mã sinh viên không tồn tại trong bảng Sinh Viên.");
            }

            deTaiDAL.UpdateDeTai(deTai, originalMaDT);
        }

        public void DeleteDeTai(string maDT)
        {
            deTaiDAL.DeleteDeTai(maDT);
        }

        public DataTable SearchDeTai(DeTaiDTO deTai)
        {
            return deTaiDAL.SearchDeTai(deTai);
        }
    }
}
