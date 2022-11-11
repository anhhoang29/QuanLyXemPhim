using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return CustomerDAO.instance; }
            private set { CustomerDAO.instance = value; }
        }


        public DataTable ReadAllCustomer()
        {
            String query = "SP_layTatCaKhachHang";
            DataTable dt = DataProvider.Instance.UserExecuteReader(query, new object[] { });
            return dt;
        }

        public bool addCustomerDAO(String name, int birth, String phoneNumber, int point, String address)
        {

            String query = "USP_themKhachHang @TenKhachHang ,  @DiaChi , @NamSinh , @SoDienThoai ,  @Diem ";
            try
            {
                DataProvider.Instance.UserExecuteNonQuery(query, new object[] { name, address, birth, phoneNumber, point });
                return true;
            }
            catch
            {
                return false;
            }
                
        }

        public bool deleteCustomerDAO (int CustomerID)
        {
            String query = "USP_xoaKhachHang @CustomerId";
            try
            {
                DataProvider.Instance.UserExecuteNonQuery(query, new object[] { CustomerID });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateCustomerDAO(int id, String name, String address, int birth, String phone, int point)
        {
            String query = "USP_capNhatKhachHang @CusId , @name , @address , @birth , @phone , @point ";
            try
            {
                DataProvider.Instance.UserExecuteNonQuery(query, new object[] {id, name, address, birth, phone, point });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
