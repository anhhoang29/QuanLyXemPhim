using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CaChieuDAO
    {
        private static CaChieuDAO instance;
        public static CaChieuDAO Instance
        {
            get { if (instance == null) instance = new CaChieuDAO(); return CaChieuDAO.instance; }
            private set { CaChieuDAO.instance = value; }
        }

        public List<CaChieu> hienThiCaChieu()
        {
            List<CaChieu> caChieus = new List<CaChieu>();
            string query = @"USP_Show_Ca_Chieu";
            DataTable table = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in table.Rows)
            {
                CaChieu caChieu = new CaChieu(row);
                caChieus.Add(caChieu);
            }

            return caChieus;
        }
        public int xoaCaChieu(string MaPhim)
        {
            try
            {
                string query = @"USP_Delete_Phim @MaPhim ";
                int kq = DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaPhim });
                return kq;
            }
            catch
            {
                return 0;
            }
        }
    }
}
