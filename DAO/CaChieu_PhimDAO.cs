using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CaChieu_PhimDAO
    {
        private static CaChieu_PhimDAO instance;
        public static CaChieu_PhimDAO Instance
        {
            get { if (instance == null) instance = new CaChieu_PhimDAO(); return CaChieu_PhimDAO.instance; }
            private set { CaChieu_PhimDAO.instance = value; }
        }
        public static List<CaChieu_Phim> GetCaChieuByTicket()
        {
            List<CaChieu_Phim> listcachieu = new List<CaChieu_Phim>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetCaChieubyTicket");
            foreach (DataRow row in data.Rows)
            {
                CaChieu_Phim showTimes = new CaChieu_Phim(row);
                listcachieu.Add(showTimes);
            }
            return listcachieu;
        }
    }
}
