﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace HomeASP.DbAccess
{
    class dbAccess
    {
        private string path = @"C:\Users\AyeThin\Desktop\PSMS_ASP\ConStrPSMS.txt";
        private string conStr = "";
        public SqlConnection conn = new SqlConnection();

        // Reading file path
        private void getConnectionStr()
        {
            StreamReader sr = File.OpenText(path);
            conStr = sr.ReadLine();
        }

        //Get connection to Database
        public SqlConnection Open()
        {
            getConnectionStr();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return conn;
            }
            else
            {
                conn = new SqlConnection(conStr);
                conn.Open();
            }
            return conn;
        }

        //close Database connection
        public void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    
    }
}
