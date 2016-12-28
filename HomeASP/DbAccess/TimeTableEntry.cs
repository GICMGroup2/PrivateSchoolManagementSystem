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
    class TimeTableEntry:dbAccess
    {
        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectAllGradeData()
        {
            string query = "SELECT * FROM ST_GRADE_MST ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_TEACHER_DATADataTable selectAllTeacherData()
        {
            string query = "SELECT * FROM ST_TEACHER_DATA ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TEACHER_DATADataTable dt = new DataSet.DsPSMS.ST_TEACHER_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertStuTimeTable(DataSet.DsPSMS.ST_TIMETABLERow dr)
        {
            int result;
            if (dr == null)
                return -1;
            int currentYear = DateTime.Now.Year;
            string query = "INSERT INTO ST_TIMETABLE (EDU_YEAR, GRADE_ID, TEACHER_ID,DAY,PERIOD1,PERIOD2,PERIOD3,PERIOD4,PERIOD5,PERIOD6,PERIOD7,DEL_FLG) VALUES (" + currentYear + ",'" + dr.GRADE_ID + "','" + dr.TEACHER_ID + "','" + dr.DAY + "','" + dr.PERIOD1 + "','" + dr.PERIOD2 + "','" + dr.PERIOD3 + "','" + dr.PERIOD4 + "','" + dr.PERIOD5 + "','" + dr.PERIOD6 + "','" + dr.PERIOD7 + "'," + dr.DEL_FLG + ")";
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int deleteStuTimeTable(int id)
        {
            int result;
            if (id == 0)
                return -1;
            string query = "UPDATE ST_TIMETABLE SET DEL_FLG=1 WHERE ID ="+id;
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int updateStuTimeTable(DataSet.DsPSMS.ST_TIMETABLERow dr,int id)
        {
            int result;
            if (id == 0)
                return -1;
            string query = "UPDATE ST_TIMETABLE SET DEL_FLG=1 WHERE ID =" + id;
            string sqlQuery = query;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        } 

        public DataSet.DsPSMS.ST_TIMETABLEDataTable selectAllTimetable()
        {
            string query = "SELECT * FROM ST_TIMETABLE WHERE DEL_FLG=0  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_TIMETABLEDataTable selectTimetable(DataSet.DsPSMS.ST_TIMETABLERow dr)
        {
            conn.Open();
            string query = "SELECT * FROM ST_TIMETABLE WHERE DAY= '" + dr.DAY + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_TIMETABLERow selectTimetableByid(int id)
        {
            conn.Open();
            string query = "SELECT * FROM ST_TIMETABLE WHERE ID="+id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
            da.Fill(dt);
            //return single row
            return dt[0];
        }
    }
}