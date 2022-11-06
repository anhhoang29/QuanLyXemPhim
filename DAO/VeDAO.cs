using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class VeDAO
    {
        private static VeDAO instance;
        public static VeDAO Instance
        {
            get { if (instance == null) instance = new VeDAO(); return VeDAO.instance; }
            private set { VeDAO.instance = value; }
        }
        public int themVeByCaChieu(string MaCaChieu, string MaGheNgoi)
        {
            string query = "USP_themVeByCaChieu @MaCaChieu , @MaGheNgoi";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaCaChieu, MaGheNgoi });
        }
        public List<Ve> hienthiVe(string maCaChieu)
        {
            List<Ve> listTicket = new List<Ve>();
            string query = @"select * from Ve where MaCaChieu = '" + maCaChieu + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Ve ticket = new Ve(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }
        public int xoaVeByCaChieu(string MaCaChieu)
        {
            string query = "USP_Xoa_Ve_By_Ca_Chieu @MaCaChieu";
            return DataProvider.Instance.ExecuteNonQuery(query, new object[] { MaCaChieu });
        }

        public bool updateListTicketDAO(List<String> maVe)
        {

            string query = "USP_capNhatTrangThaiVe @maVe ";
            try
            {
                for (int i = 0; i < maVe.Count; i++)
                {
                    DataProvider.Instance.UserExecuteNonQuery(query, new object[] { Int32.Parse(maVe[i]) });
                }
                return true;
            }
            catch
            {
                return false;
            }
           

        }

        public float getPriceOfTicketDAO(int maVe)
        {
            string query = "Select dbo.FUNC_layGiaVe( @Id ) ";
            try
            {
                return Convert.ToSingle(DataProvider.Instance.ExecuteScalar(query, new object[] { maVe }));
            }
            catch
            {
               return -1;
            }

        }
    }
}
