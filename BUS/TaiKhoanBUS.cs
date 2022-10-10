using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        public static TaiKhoanBUS Instance
        {
            get { if (instance == null) instance = new TaiKhoanBUS(); return TaiKhoanBUS.instance; }
            private set { TaiKhoanBUS.instance = value; }
        }
        public TaiKhoan handleLogin(string userName, string password)
        {
            return TaiKhoanDAO.Instance.handleLogin(userName, password);
        }
    }
}
