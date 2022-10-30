using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private DataProvider()
        {

        }



        //public const string connectionStr = @"Data Source=DUY\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true";
        public static string connectionString = @"Data Source=DUY\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true";
        public const string connectionStr = @"Data Source=MSI;Initial Catalog=QuanLyXemPhim;Integrated Security=true";


        //private const string connectionStr = @"Data Source=DESKTOP-SHGHBSM\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true"
        private const string connectionStr = @"Data Source=LAPTOP-16UP1LFV\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true";
        public static string connectionString = @"Data Source=LAPTOP-16UP1LFV\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true";
        //public const string connectionStr = @"Data Source=DUY\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true";
        //public static string connectionString = @"Data Source=DUY\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Integrated Security=true";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        public DataTable UserExecuteReader(string query, object[] parameters = null)
        {
            DataTable dataResult = new DataTable();
            using (var conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                cmd.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                            }
                        }
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    dataResult.Load(reader);
                    return dataResult;
                }
            }
        }

        public void UserExecuteNonQuery(String query, object[] parameters = null)
        {
            using (var conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                Console.WriteLine(item, parameters[i]);
                                cmd.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                            }
                        }
                    }
                    cmd.ExecuteNonQuery();

                }
            }
        }

    }
}
