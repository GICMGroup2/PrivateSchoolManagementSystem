using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DataSet;
using HomeASP.DbAccess;


namespace HomeASP.DbAccess
{
    class attendanceDb:dbAccess
    {
        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr)
        {
            conn.Open();
            string query = "SELECT * FROM ST_GRADE_MST where GRADE_NAME= '" + dr.GRADE_NAME + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr)
        {
            int result;
            if (dr == null)
                return -1;
            int currentYear = DateTime.Now.Year;
            string query = "INSERT INTO ST_GRADE_MST (EDU_YEAR, GRADE_ID, GRADE_NAME) VALUES (" + currentYear + ",'" + dr.GRADE_ID + "','" + dr.GRADE_NAME + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectAllGradeData()
        {
            string query = "SELECT * FROM ST_GRADE_MST ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
   

