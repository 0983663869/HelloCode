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
            // Kiểm tra xem MaDT đã tồn tại chưa
            if (deTaiDAL.ExistsMaDT(deTai.MaDT))
            {
                throw new Exception("Mã đề tài đã tồn tại trong hệ thống.");
            }

            deTaiDAL.AddDeTai(deTai);
        }

        public void UpdateDeTai(DeTaiDTO deTai, string originalMaDT)
        {
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
