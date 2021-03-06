﻿using System;
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
    class AttendanceDb : dbAccess
    {
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectStudentData(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            if (dr == null)
                return null;
            string query = "SELECT * FROM ST_STUDENT_DATA WHERE";
            if (dr.EDU_YEAR.ToString().Trim().Length != 0)
            {
                query += " EDU_YEAR = '" + dr.EDU_YEAR + "'";
            }
            if (!dr.IsGRADE_IDNull())
            {
                query += "AND GRADE_ID = '" + dr.GRADE_ID + "'";
            }
            if (!dr.IsROOM_IDNull())
            {
                query += " AND ROOM_ID = '" + dr.ROOM_ID + "'";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            da.Fill(dt);
            return dt;
        }        

        public DsPSMS.ATTENDANCE_RESULTDataTable selectAttendanceData(DsPSMS.ST_STUDENT_DATARow sr, DsPSMS.ST_ATTENDANCE_DATARow dr)
        {
            if (dr == null)
                return null;
            string query = "SELECT ST_STUDENT_DATA.STUDENT_ID, ST_STUDENT_DATA.STUDENT_NAME,  ST_STUDENT_DATA.ROLL_NO, ST_ATTENDANCE_DATA.MORNING,  ST_ATTENDANCE_DATA.EVENING,  ST_ATTENDANCE_DATA.ATTENDANCE_DATE  FROM ST_STUDENT_DATA INNER JOIN ST_ATTENDANCE_DATA ON ST_STUDENT_DATA.STUDENT_ID = ST_ATTENDANCE_DATA.STUDENT_ID WHERE (ST_STUDENT_DATA.GRADE_ID = '" + sr.GRADE_ID + "' AND ST_STUDENT_DATA.ROOM_ID= '" + sr.ROOM_ID + "' AND ST_ATTENDANCE_DATA.ATTENDANCE_DATE = '" + dr.ATTENDANCE_DATE + "');";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DsPSMS.ATTENDANCE_RESULTDataTable st = new DsPSMS.ATTENDANCE_RESULTDataTable();
            da.Fill(st);
            return st;
        }

        public int insertAttendanceRecord(DsPSMS.ST_ATTENDANCE_DATARow adr)
        {
            if (adr == null)
                return -1;
            string query = "INSERT INTO ST_ATTENDANCE_DATA (";
            string data = "";
            int result;

            query += "STUDENT_ID ";
            data += "" + adr.STUDENT_ID;
            query += ", EDU_YEAR";
            data += ",'" + adr.EDU_YEAR + "'";
            query += ", MORNING";
            data += ",'" + adr.MORNING + "'";           
            query += ", EVENING";
            data += ",'" + adr.EVENING + "'";
            query += ", ATTENDANCE_DATE";
            data += ",'" + adr.ATTENDANCE_DATE.ToString() + "'";

            if (!adr.IsREMARKNull())
            {
                query += ", REMARK";
                data += "," + adr.REMARK;
            }
            if (!adr.IsCRT_DT_TMNull())
            {
                query += ", CRT_DT_TM";
                data += "," + adr.CRT_DT_TM;
            }
            if (!adr.IsCRT_USER_IDNull())
            {
                query += ", CRT_USER_ID";
                data += "," + adr.CRT_USER_ID;
            }
            if (!adr.IsUPD_DT_TMNull())
            {
                query += ", UPD_DT_TM";
                data += "," + adr.UPD_DT_TM;
            }
            if (!adr.IsUPD_USER_IDNull())
            {
                query += ", UPD_USER_ID";
                data += "," + adr.UPD_USER_ID;
            }
            query += ", DEL_FLG";
            data += "," + 0;

            query += ") VALUES(" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectAttendanceByDate(DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr)
        {
            if (dr == null)
                return null;
            string query = "SELECT * FROM ST_ATTENDANCE_DATA ";
            string where = "";
            if (dr.STUDENT_ID != null)
            {
                where += " STUDENT_ID = '" + dr.STUDENT_ID + "'";
            }

            if (dr.ATTENDANCE_DATE != null)
            {
                if (where.Length > 0)
                    where += " AND ATTENDANCE_DATE= '" + dr.ATTENDANCE_DATE.ToString() + "'";
            }

            if (where.Length > 0)
                query += " WHERE " + where;

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable dt = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public int updateAttendanceRecord(DataSet.DsPSMS.ST_ATTENDANCE_DATARow adr)
        {
            if (adr == null)
                return -1;
            int result = 0;
            string query = "UPDATE ST_ATTENDANCE_DATA SET";            
            if (Convert.ToInt16(adr.MORNING) == 1)
                query += " MORNING = '" + 1 + "'";
            else
                query += " MORNING = '" + 0 + "'";

            if (Convert.ToInt16(adr.EVENING) == 1)
                query += ", EVENING = '" + 1 + "'";
            else
                query += ", EVENING = '" + 0 + "'";

            query += " WHERE STUDENT_ID= '" + adr.STUDENT_ID + "'";
            query += " AND ATTENDANCE_DATE= '" + adr.ATTENDANCE_DATE.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectStudentId(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            string query = "SELECT * FROM ST_STUDENT_DATA WHERE STUDENT_NAME = '" + dr.STUDENT_NAME + "' AND GRADE_ID = '" + dr.GRADE_ID + "' AND ROOM_ID = '" + dr.ROOM_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectAttendanceList(DataSet.DsPSMS.ST_ATTENDANCE_DATARow dr)
        {
            string query = "SELECT * FROM ST_ATTENDANCE_DATA WHERE STUDENT_ID IN (" + dr.STUDENT_ID + ")";
            if (dr.ATTENDANCE_DATE.Substring(0, 2) != "00")
            {
                query += " AND DAY(ATTENDANCE_DATE) LIKE " + dr.ATTENDANCE_DATE.Substring(0, 2);
            }
            if (dr.ATTENDANCE_DATE.Substring(3, 2) != "00")
            {
                query += " AND MONTH(ATTENDANCE_DATE) LIKE " + dr.ATTENDANCE_DATE.Substring(3, 2);
            }
            if (dr.ATTENDANCE_DATE.Substring(6, 4) != "0000")
            {
                query += " AND YEAR(ATTENDANCE_DATE) LIKE " + dr.ATTENDANCE_DATE.Substring(6, 4);
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable dt = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
   

