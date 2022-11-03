using DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
