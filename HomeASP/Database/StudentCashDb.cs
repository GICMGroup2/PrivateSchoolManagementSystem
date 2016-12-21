using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace HomeASP.Database
{
    public class StudentCashDb : DbAccess
    {
        int result=0;
        string data = "";
        string query = "";
        DataSet.DataSet2.ST_STUDENT_DATADataTable dt = new DataSet.DataSet2.ST_STUDENT_DATADataTable();

        public DataSet.DataSet2.ST_STUDENT_DATARow selectCashType(DataSet.DataSet2.ST_STUDENT_DATARow dr)
        {
            Open();
            query = "SELECT* FROM ST_STUDENT_DATA WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "' AND STUDENT_NAME='" + dr.STUDENT_NAME + "'AND GRADE_ID='" + dr.GRADE_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Close();
            return dt[0];
        }

        public int insertStuCash(DataSet.DataSet2.ST_STUDENT_CASHRow dr)
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
            data += ", '" + dr.ACCOUNT_NO+ "'";
            data += ", '" + dr.AMOUNT + "'";
            data += ", '" + dr.CRT_DT_TM + "'";
            data += ", '" + dr.CRT_USER_ID + "'";
            data += ", '" + dr.UPD_DT_TM + "'";
            data += ", '" + dr.UPD_USER_ID + "'";
            data += ", " + 0 ;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        
        }
    }
}