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
    class GradeSubjectDb : dbAccess
    {
        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr)
        {
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
            DateTime date = DateTime.Now.Date;
            String currentDate = date.ToString().Substring(0, 19);
            string query = "INSERT INTO ST_GRADE_MST (EDU_YEAR, GRADE_ID, GRADE_NAME, CRT_DT_TM, CRT_USER_ID, DEL_FLG) VALUES (" + currentYear + "," + dr.GRADE_ID + ",'" + dr.GRADE_NAME + "','" + currentDate + "', 1, 0)";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectAllGradeData()
        {
            string query = "SELECT * FROM ST_GRADE_MST WHERE DEL_FLG = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public int updateGrade(DataSet.DsPSMS.ST_GRADE_MSTRow oldData, DataSet.DsPSMS.ST_GRADE_MSTRow newData)
        {
            if (oldData == null || newData == null)
                return -1;
            int result;
            string query = "UPDATE ST_GRADE_MST SET ";
            if (oldData.GRADE_NAME != null)
            {
                query += " GRADE_NAME ='" + newData.GRADE_NAME + "'";
            }
            query += " WHERE GRADE_ID=" + oldData.GRADE_ID;
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int deleteGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr)
        {
            int result;
            string query = "UPDATE ST_GRADE_MST SET DEL_FLG = 1 WHERE ";
            query += " GRADE_ID = " + "'" + dr.GRADE_ID + "' AND";
            query += " GRADE_NAME = " + "'" + dr.GRADE_NAME + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr)
        {
            conn.Open();
            string query = "SELECT * FROM ST_SUBJECT_MST where SUBJECT_NAME= '" + dr.SUBJECT_NAME + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable dt = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public int insertSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr)
        {
            int result;
            if (dr == null)
                return -1;
            int currentYear = DateTime.Now.Year;
            DateTime date = DateTime.Now.Date;
            String currentDate = date.ToString().Substring(0, 19);
            string query = "INSERT INTO ST_SUBJECT_MST (EDU_YEAR, SUBJECT_ID, SUBJECT_NAME, CRT_DT_TM, CRT_USER_ID, DEL_FLG) VALUES (" + currentYear + ",'" + dr.SUBJECT_ID + "','" + dr.SUBJECT_NAME + "','" + currentDate + "', 1, 0)";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectAllSubjectData()
        {
            string query = "SELECT * FROM ST_SUBJECT_MST WHERE DEL_FLG = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable dt = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public int deleteSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr)
        {
            int result;
            string query = "UPDATE ST_SUBJECT_MST SET DEL_FLG = 1 WHERE ";
            query += " SUBJECT_ID = " + "'" + dr.SUBJECT_ID + "' AND";
            query += " SUBJECT_NAME = " + "'" + dr.SUBJECT_NAME + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int insertGradeSubjectDetail(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, string sub)
        {
            int result;
            int currentYear = DateTime.Now.Year;
            DateTime date = DateTime.Now.Date;
            String currentDate = date.ToString().Substring(0, 19);
            string query = "INSERT INTO ST_GRADE_SUBJECT_DETAIL (EDU_YEAR, ID, GRADE_ID, SUBJECT_ID_LIST, CRT_DT_TM, CRT_USER_ID, DEL_FLG) VALUES (" + currentYear + "," + dr.ID + ",'" + dr.GRADE_ID + "','" + sub + "','" + currentDate + "', 1, 0)";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr)
        {
            string query = "SELECT * FROM ST_GRADE_SUBJECT_DETAIL where ID= '" + dr.ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable dt = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable getAllGradeSubjectData()
        {
            string query = "SELECT * FROM ST_GRADE_SUBJECT_DETAIL WHERE DEL_FLG = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable dt = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectName(String subjectID)
        {
            string query = "SELECT * FROM ST_SUBJECT_MST WHERE SUBJECT_ID IN (" + subjectID + ")";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable dt = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            da.Fill(dt);
            return dt;
        }

        public int deleteGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr)
        {
            int result;
            string query = "UPDATE ST_GRADE_SUBJECT_DETAIL SET DEL_FLG = 1 WHERE ";
            query += " ID = " + "'" + dr.ID + "' AND";
            query += " GRADE_ID = " + "'" + dr.GRADE_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}
   

