using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.DbAccess
{
    public class SalaryCalculationDb:dbAccess
    {
        public DataSet.DsPSMS.ST_TEACHER_DATADataTable selectAllTeacherData()
        {
            string query = "SELECT * FROM ST_TEACHER_DATA ORDER BY TEACHER_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TEACHER_DATADataTable dt = new DataSet.DsPSMS.ST_TEACHER_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_STAFF_DATADataTable selectAllStaffData()
        {
            string query = "SELECT * FROM ST_STAFF_DATA ORDER BY STAFF_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STAFF_DATADataTable dt = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertSalaryData(DataSet.DsPSMS.ST_SALARYRow dr)
        {
            int result;
            if (dr == null)
                return -1;
            int currentYear = DateTime.Now.Year;
            string query = " INSERT INTO ST_SALARY (EDU_YEAR, YEAR, MONTH,STAFF_ID,LEAVE_TIMES,LEAVE_AMOUNT,LATE_TIMES,LATE_AMOUNT,OT_AMOUNT,SALARY_AMOUNT,REMARK) VALUES (" + currentYear + ",'" + dr.YEAR + "','" + dr.MONTH + "','" + dr.STAFF_ID + "'," + dr.LEAVE_TIMES + "," + dr.LEAVE_AMOUNT + "," + dr.LATE_TIMES + "," + dr.LATE_AMOUNT + "," + dr.OT_AMOUNT + "," + dr.SALARY_AMOUNT + "," + dr.REMARK + ")";
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_SALARYDataTable selectAllSalaryData(int remark)
        {
            string query = "SELECT * FROM ST_SALARY WHERE REMARK = " + remark + "ORDER BY SALARY_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_SALARYDataTable dt = new DataSet.DsPSMS.ST_SALARYDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_STAFF_DATARow selectStaffByid(int id)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_STAFF_DATA WHERE STAFF_ID=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STAFF_DATADataTable dt = new DataSet.DsPSMS.ST_STAFF_DATADataTable();
            da.Fill(dt);
            //return single row
            return dt[0];
        }

        public DataSet.DsPSMS.ST_TEACHER_DATARow selectTeacherByid(int id)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_TEACHER_DATA WHERE TEACHER_ID=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TEACHER_DATADataTable dt = new DataSet.DsPSMS.ST_TEACHER_DATADataTable();
            da.Fill(dt);
            //return single row
            return dt[0];
        }

        public DataSet.DsPSMS.ST_SALARYDataTable selectSalaryByRemark(string month,int remark)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_SALARY WHERE MONTH= '" + month + "' AND REMARK =" + remark;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_SALARYDataTable dt = new DataSet.DsPSMS.ST_SALARYDataTable();
            da.Fill(dt);
            return dt;
        }

        public int deleteSalaryByRemark(string month, int remark)
        {
            //conn.Open();
            string query = "DELETE FROM ST_SALARY WHERE MONTH= '" + month + "' AND REMARK =" + remark;
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            return 1;
        }
    }
}