using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return TaiKhoanDAO.instance; }
            private set { TaiKhoanDAO.instance = value; }
        }
        public TaiKhoan handleLogin(string userName, string password)
        {
            string query = @"USP_Login @userName , @pass ";
            DataTable table = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });
            if (table.Rows.Count > 0)
            {
                TaiKhoan taiKhoan = new TaiKhoan(table.Rows[0]); 
                return taiKhoan;
            }
            return null;
        }
    }
}
