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
            String query = "dbo.SP_GetALLCustomer";
            DataTable dt = DataProvider.Instance.UserExecuteReader(query, new object[] { });
            return dt;
        }

        public bool addCustomerDAO(String name, int birth, String phoneNumber, int point, String address)
        {

            String query = "dbo.USP_AddCustomer @TenKhachHang ,  @DiaChi , @NamSinh , @SoDienThoai ,  @Diem ";
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
            String query = "dbo.USP_deleteCustomer @CustomerId";
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
            String query = "USP_updateCustomer @CusId , @name , @address , @birth , @phone , @point ";
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

        public byte isMemberDAO(string phoneNumber)
        {
            string query = "Select dbo.FUNC_laThanhVien ( @phone )";
            byte kq;
            try
            {
                kq = Convert.ToByte(DataProvider.Instance.ExecuteScalar(query, new object[] { phoneNumber }));
            }
            catch
            {
                // error
                kq = 2;
            }
            return kq;
        }

        public DataTable getCustomerDAO(string phoneNumber)
        {
            string query = "USP_layThongTinKhachHang @Sdt ";
            try
            {
                return DataProvider.Instance.ExecuteQuery(query, new object[] { phoneNumber });
            }
            catch 
            {
                return null;
            }
        }

        public bool updatePointDAO(string phoneNumber, int bonus)
        {
            string query = "USP_congDiemTichLuy @Sdt , @bonus ";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { phoneNumber, bonus });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool usePointDAO (string phoneNumber)
        {
            string query = "USP_suDungDiemTichLuy @Sdt ";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query, new object[] { phoneNumber });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
