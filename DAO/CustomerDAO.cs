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
                

           /* String query = "dbo.USP_AddCustomer";
            using (var conn = new SqlConnection(DataProvider.connectionStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TenKhachHang", name);
                    cmd.Parameters.AddWithValue("@DiaChi", address);
                    cmd.Parameters.AddWithValue("@NamSinh", birth);
                    cmd.Parameters.AddWithValue("@Diem", point);
                    cmd.Parameters.AddWithValue("@SoDienThoai", phoneNumber);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }*/

        }
    }
}
