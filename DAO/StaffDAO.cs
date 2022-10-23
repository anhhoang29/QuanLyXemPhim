using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class StaffDAO
    {

        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }

        public DataTable readAllStaff()
        {
            String query = "select * from dbo.UF_readAllStaff()";
           
            using (var conn = new SqlConnection(DataProvider.connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }

                }
            }
        }

    }
}
