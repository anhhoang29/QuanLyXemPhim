﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DBSQLServerUtils
    {
        static string userName = "";
        static string Password = "";
        //static string a = "";

        public DBSQLServerUtils()
        {
        }

        public DBSQLServerUtils(string username, string password)
        {
            userName = username;
            Password = password;
        }

        public string conString()
        {
            //return "Data Source=DESKTOP-SHGHBSM\\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Persist Security Info=True;" +
                //"User ID=" + userName + ";Password=" + Password;
            return "Data Source=LAPTOP-16UP1LFV\\SQLEXPRESS;Initial Catalog=QuanLyXemPhim" +
                ";Persist Security Info=True;" +
                "User ID=" + userName + ";Password=" + Password;
            //return "Data Source=DUY\\SQLEXPRESS;Initial Catalog=QuanLyXemPhim;Persist Security Info=True;" +
                //"User ID=" + userName + ";Password=" + Password;
        }
    }
}
