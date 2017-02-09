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
            string query = "SELECT * FROM ST_GRADE_MST ORDER BY GRADE_ID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_ROOM_MSTDataTable selectAllRoomData()
        {
            string query = "SELECT * FROM ST_ROOM_MST ORDER BY ROOM_ID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_ROOM_MSTDataTable dt = new DataSet.DsPSMS.ST_ROOM_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_TEACHER_DATADataTable selectAllTeacherData()
        {
            string query = "SELECT * FROM ST_TEACHER_DATA ORDER BY TEACHER_ID";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TEACHER_DATADataTable dt = new DataSet.DsPSMS.ST_TEACHER_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectAllSubjectData()
        {
            string query = "SELECT * FROM ST_SUBJECT_MST ORDER BY SUBJECT_ID ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable dt = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
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

        public int insertTeacherGrade(DataSet.DsPSMS.ST_TEACHER_GRADERow dr)
        {
            int result;
            if (dr == null)
                return -1;
            int currentYear = DateTime.Now.Year;
            string query = "INSERT INTO ST_TEACHER_GRADE (EDU_YEAR, TEACHER_ID,TEACH_GRADE,TEACH_SUBJECT,DEL_FLG) VALUES (" + currentYear + ",'" + dr.TEACHER_ID + "','" + dr.TEACH_GRADE + "','" + dr.TEACH_SUBJECT + "'," + dr.DEL_FLG + ")";
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
            string query = "UPDATE ST_TIMETABLE SET GRADE_ID='" + dr.GRADE_ID + "',TEACHER_ID='" + dr.TEACHER_ID + "',DAY='" + dr.DAY + "',PERIOD1='" + dr.PERIOD1 + "',PERIOD2='" + dr.PERIOD2 + "',PERIOD3='" + dr.PERIOD3 + "',PERIOD4='" + dr.PERIOD4 + "',PERIOD5='" + dr.PERIOD5 + "',PERIOD6='" + dr.PERIOD6 + "',PERIOD7='" + dr.PERIOD7 + "' WHERE ID=" + id;
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

        public DataSet.DsPSMS.ST_GRADE_MSTRow selectGradeByid(int id)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_GRADE_MST WHERE GRADE_ID=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
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

        public DataSet.DsPSMS.ST_ROOM_MSTRow selectClassByid(int id)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_ROOM_MST WHERE ROOM_ID=" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_ROOM_MSTDataTable dt = new DataSet.DsPSMS.ST_ROOM_MSTDataTable();
            da.Fill(dt);
            //return single row
            return dt[0];
        }

        public DataSet.DsPSMS.ST_TIMETABLEDataTable selectTimetableBydateandid(int id, string date)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_TIMETABLE WHERE TEACHER_ID=" + id + " AND DAY='" + date + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
            da.Fill(dt);
            return dt;
        }

       public DataSet.DsPSMS.ST_TIMETABLEDataTable selectTimetableByteacherid(int id)
        {
            //conn.Open();
            string query = "SELECT * FROM ST_TIMETABLE WHERE TEACHER_ID=" + id ;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
            da.Fill(dt);
            return dt;
        }

       public DataSet.DsPSMS.ST_TIMETABLEDataTable selectTimetableBydate(string date)
       {
           //conn.Open();
           string query = "SELECT * FROM ST_TIMETABLE WHERE DAY='" + date + "'";
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
           da.Fill(dt);
           return dt;
       }

       public DataSet.DsPSMS.ST_TIMETABLEDataTable selectTimetableBygradeid(int id)
       {
           //conn.Open();
           string query = "SELECT * FROM ST_TIMETABLE WHERE GRADE_ID=" + id;
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_TIMETABLEDataTable dt = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
           da.Fill(dt);
           return dt;
       }

       public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow selectGradeSubjectBygradeId(int id)
       {
           string query = "SELECT * FROM ST_GRADE_SUBJECT_DETAIL WHERE GRADE_ID=" + id;
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable dt = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
           da.Fill(dt);
           //return single row
           return dt[0];
       }

       //public DataSet.DsPSMS.ST_TEACHER_GRADERow selectTeacherGradeID(DataSet.DsPSMS.ST_TEACHER_GRADERow dr)
       //{
       //    string query = "SELECT * FROM ST_TEACHER_GRADE WHERE TEACHER_ID='" + dr.TEACHER_ID + "'and TEACH_GRADE='" + dr.TEACH_GRADE + "'and TEACH_SUBJECT='" + dr.TEACH_SUBJECT + "'";
       //    SqlCommand cmd = new SqlCommand(query, conn);
       //    SqlDataAdapter da = new SqlDataAdapter(cmd);
       //    DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable dt = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
       //    da.Fill(dt);
       //    //return single row
       //    return dt[0];
       //}

       public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectName(String subjectID)
       {
           string query = "SELECT * FROM ST_SUBJECT_MST WHERE SUBJECT_ID IN (" + subjectID + ")";
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_SUBJECT_MSTDataTable dt = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
           da.Fill(dt);
           return dt;
       }

       public DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable selectAllTimetableHed()
       {
           string query = "SELECT * FROM ST_TIMETABLE_HED WHERE DEL_FLG=0 ";
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable dt = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable();
           da.Fill(dt);
           return dt;
       }

       public int insertTimetableHed(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr)
       {
           int result;
           if (dr == null)
               return -1;
           int currentYear = DateTime.Now.Year;
           string query = "INSERT INTO ST_TIMETABLE_HED (EDU_YEAR, ROOM_TEACHER_ID, GRADE_ID,ROOM_ID,DEL_FLG) VALUES (" + currentYear + ",'" + dr.ROOM_TEACHER_ID + "','" + dr.GRADE_ID + "','" + dr.ROOM_ID + "'," + dr.DEL_FLG + ")";
           string sqlQuery = query;
           SqlCommand cmd = new SqlCommand(query, conn);
           result = cmd.ExecuteNonQuery();
           return result;
       }

       public DataSet.DsPSMS.ST_TIMETABLE_HEDRow selectTimetableHedByid(int id)
       {
           //conn.Open();
           string query = "SELECT * FROM ST_TIMETABLE_HED WHERE TIMETABLE_ID=" + id;
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable dt = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable();
           da.Fill(dt);
           //return single row
           return dt[0];
       }

       public int updateTimeTableHed(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr, int id)
       {
           int result;
           if (id == 0)
               return -1;
           string query = "UPDATE ST_TIMETABLE_HED SET GRADE_ID='" + dr.GRADE_ID + "',ROOM_TEACHER_ID='" + dr.ROOM_TEACHER_ID + "',ROOM_ID='" + dr.ROOM_ID + "' WHERE TIMETABLE_ID=" + id;
           string sqlQuery = query;
           SqlCommand cmd = new SqlCommand(query, conn);
           result = cmd.ExecuteNonQuery();
           return result;
       }

       public int insertTimetableDetail(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr)
       {
           int result;
           if (dr == null)
               return -1;
           int currentYear = DateTime.Now.Year;
           string query = "INSERT INTO ST_TIMETABLE_DETAIL (TIMETABLE_ID, TIMETABLE_TIME,MONDAY,TUESDAY,WEDNESDAY,THURSDAY,FRIDAY,DEL_FLG) VALUES ('" + dr.TIMETABLE_ID + "','" + dr.TIMETABLE_TIME + "','" + dr.MONDAY +"','" + dr.TUESDAY +"','" + dr.WEDNESDAY + "','" + dr.THURSDAY+"','" + dr.FRIDAY +"'," + dr.DEL_FLG + ")";
           string sqlQuery = query;
           SqlCommand cmd = new SqlCommand(query, conn);
           result = cmd.ExecuteNonQuery();
           return result;
       }

       public DataSet.DsPSMS.ST_TIMETABLE_DETAILRow selectTimetableDetailByid(int id)
       {
           //conn.Open();
           string query = "SELECT * FROM ST_TIMETABLE_DETAIL WHERE ID=" + id;
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable dt = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable();
           da.Fill(dt);
           //return single row
           return dt[0];
       }

       public int updateTimeTableDetail(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr, int id)
       {
           int result;
           if (id == 0)
               return -1;
           string query = "UPDATE ST_TIMETABLE_DETAIL SET TIMETABLE_ID='" + dr.TIMETABLE_ID + "',TIMETABLE_TIME='" + dr.TIMETABLE_TIME + "',MONDAY='" + dr.MONDAY + "',TUESDAY='" + dr.TUESDAY + "',WEDNESDAY='" + dr.WEDNESDAY + "',THURSDAY='" + dr.THURSDAY + "',FRIDAY='" + dr.FRIDAY + "' WHERE ID=" + id;
           string sqlQuery = query;
           SqlCommand cmd = new SqlCommand(query, conn);
           result = cmd.ExecuteNonQuery();
           return result;
       }

       public int deleteTimeTableDetail(int id)
       {
           int result;
           if (id == 0)
               return -1;
           string query = "UPDATE ST_TIMETABLE_DETAIL SET DEL_FLG=1 WHERE ID =" + id;
           string sqlQuery = query;
           SqlCommand cmd = new SqlCommand(query, conn);
           result = cmd.ExecuteNonQuery();
           return result;
       }

       public DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable selectAllTimeDetail(string id)
       {
           string query = "SELECT * FROM ST_TIMETABLE_DETAIL WHERE DEL_FLG=0 AND TIMETABLE_ID="+id;
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable dt = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable();
           da.Fill(dt);
           return dt;
       }

       public DataSet.DsPSMS.ST_SUBJECT_MSTRow selectSubjectByid(int id)
       {
           //conn.Open();
           string query = "SELECT * FROM ST_SUBJECT_MST WHERE SUBJECT_ID=" + id;
           SqlCommand cmd = new SqlCommand(query, conn);
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet.DsPSMS.ST_SUBJECT_MSTDataTable dt = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
           da.Fill(dt);
           //return single row
           return dt[0];
       }
    }
}