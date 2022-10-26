﻿using System;
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

        public bool addStaffDAO (String id, String name, DateTime birth, String address,  String phone, int identity)
        {
            String query = "USP_AddStaff @idNV , @HoTen , @NgaySinh , @DiaChi , @SDT , @CMND ";
            try
            {
                DataProvider.Instance.UserExecuteNonQuery(query, new object[] { id, name, birth, address, phone, identity });
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool deleteStaffDAO (String staffId)
        {
            String query = "dbo.USP_deleteStaff @StaffId";
            try
            {
                DataProvider.Instance.UserExecuteNonQuery(query, new object[] { staffId });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateStaffDAO(String id, String name, DateTime birth, String address, String phone, int number)
        {
            String query = "dbo.USP_UpdateStaff @id , @name , @birth , @address , @phone , @identity ";
            try
            {
                DataProvider.Instance.UserExecuteNonQuery(query, new object[] { id, name, birth, address, phone, number });
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
