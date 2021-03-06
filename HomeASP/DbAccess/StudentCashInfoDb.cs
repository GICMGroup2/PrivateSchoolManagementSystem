﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DbAccess;
using System.Data.SqlClient;
using HomeASP.DataSet;
using System.Data;

namespace HomeASP.DbAccess
{
    class StudentCashInfoDb: dbAccess
    {
        int result = 0;
        string data = "";
        string query = "";
        DsPSMS.ST_STUDENT_DATADataTable stuDt = new DsPSMS.ST_STUDENT_DATADataTable();
        DsPSMS.ST_GRADE_MSTDataTable grdDt = new DsPSMS.ST_GRADE_MSTDataTable();
        DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
      
        //insert student's cash information into ST_STUDENT_CASH table
        public int insertStuCash(DataSet.DsPSMS.ST_STUDENT_CASHRow dr)
        {
            if (dr == null)
                return -1;

            Open();
            query = "INSERT INTO ST_STUDENT_CASH (EDU_YEAR, STUDENT_ID, CASH_TITLE, CASH_DATE, ACCOUNT_NO, AMOUNT, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
            //data += ", '" + dr.CASH_ID + "'";
            data += ", '" + dr.STUDENT_ID + "'";
            data += ", '" + dr.CASH_TITLE + "'";
            data += ", '" + dr.CASH_DATE + "'";
            data += ", '" + dr.ACCOUNT_NO + "'";
            data += ", '" + dr.AMOUNT + "'";
            data += ", '" + dr.CRT_DT_TM + "'";
            data += ", '" + dr.CRT_USER_ID + "'";
            data += ", '" + dr.UPD_DT_TM + "'";
            data += ", '" + dr.UPD_USER_ID + "'";
            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        //select all cash information from ST_STUDENT_CASH table
        public DataSet.DsPSMS.ST_STUDENT_CASHDataTable selectCashAllData()
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            Open();
            query = "SELECT* FROM ST_STUDENT_CASH ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuCashDt);
            Close();
            return stuCashDt;
        }

        //select Cash information from ST_STUDENT_CASH table
        public DataSet.DsPSMS.ST_STUDENT_CASHDataTable selectCashDataByIdYear(DataSet.DsPSMS.ST_STUDENT_CASHRow dr)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            Open();
            query = "SELECT* FROM ST_STUDENT_CASH WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuCashDt);
            Close();
            return stuCashDt;
        }

        //select Cash Type from ST_STUDENT_DATA table
        public DataSet.DsPSMS.ST_STUDENT_DATARow selectCashType(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
            Open();
            query = "SELECT* FROM ST_STUDENT_DATA WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "' AND STUDENT_NAME='" + dr.STUDENT_NAME + "'AND GRADE_ID='" + dr.GRADE_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuDt);
            Close();
            return stuDt[0];
        }
        // select Student's name from ST_STUDENT_DATA table by STUDENT_ID and EDU_YEAR
        public DataSet.DsPSMS.ST_STUDENT_DATARow selectStuName(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            Open();
            query = "SELECT* FROM ST_STUDENT_DATA WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuDt);
            Close();
            return stuDt[0];
        }

    }
}