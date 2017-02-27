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
    public class StudentInfo : dbAccess
    {
        int result;
        //SqlConnection conn = new SqlConnection();
        //dbAccess db = new dbAccess();
        //Inserting Student Data
        public int insertData(DataSet.DsPSMS.ST_STUDENT_DATARow dr, string tblName)
        {
            int result;
            string data = "";
            if (dr == null)
                return -1;


            Open();
            string query = "INSERT INTO " + tblName + "(EDU_YEAR, STUDENT_ID, STUDENT_NAME, ROLL_NO, GENDER, PHOTO_PATH, DOB, PHONE, NRC_NO, PASSWORD, GRADE_ID, ROOM_ID, CASH_TYPE1, CASH_TYPE2, FATHER_NAME, MOTHER_NAME, ADDRESS, CONTACT_PHONE, EMAIL, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";

            data += ", '" + dr.STUDENT_ID + "'";

            data += ", '" + dr.STUDENT_NAME + "'";

            data += ", '" + dr.ROLL_NO + "'";

            data += ", '" + dr.GENDER + "'";
            
            data += ", '" + dr.PHOTO_PATH + "'";
           
            data += ", '" + dr.DOB + "'";

            data += ", '" + dr.PHONE + "'";

            data += ", '" + dr.NRC_NO + "'";

            data += ", '" + dr.PASSWORD + "'";

            data += ", '" + dr.GRADE_ID + "'";

            data += ", '" + dr.ROOM_ID + "'";

            data += ", '" + dr.CASH_TYPE1 + "'";
            if (!dr.IsCASH_TYPE2Null())
                data += ", '" + dr.CASH_TYPE2 + "'";
            else
                data += ", '  '";
            data += ", '" + dr.FATHER_NAME + "'";

            data += ", '" + dr.MOTHER_NAME + "'";

            data += ", '" + dr.ADDRESS + "'";

            data += ", '" + dr.CONTACT_PHONE + "'";

            data += ", '" + dr.EMAIL + "'";
            if (!dr.IsCRT_DT_TMNull())
                data += ", '" + dr.CRT_DT_TM + "'";
            else
                data += ", '  '";
            if (!dr.IsCRT_USER_IDNull())
                data += ", '" + dr.CRT_USER_ID + "'";
            else
                data += ", '  '";
            if (!dr.IsUPD_DT_TMNull())
                data += ", '" + dr.UPD_DT_TM + "'";
            else
                data += ", '  '";
            
            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;

        }

        //Select all Student data
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectAllData()
        {
            Open();
            string query = "SELECT * FROM ST_STUDENT_DATA WHERE DEL_FLG =" + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            da.Fill(dt);
            Close();
            return dt;

        }

        // Select active student data by option
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectDataOption(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            Open();
            string query = "SELECT * FROM ST_STUDENT_DATA WHERE DEL_FLG=" + 0;

            if (!dr.IsGRADE_IDNull())
                query += "AND GRADE_ID =" + dr.GRADE_ID + "'";
            if (!dr.IsROOM_IDNull())
                query += "AND ROOM_ID =" + dr.ROOM_ID + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            da.Fill(dt);
            Close();
            return dt;

        }

        //select grade data
        public DataSet.DsPSMS.ST_GRADE_MSTDataTable selectAllGrade()
        {
            string query = "SELECT * FROM ST_GRADE_MST";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet.DsPSMS.ST_GRADE_MSTDataTable dt = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            da.Fill(dt);
            return dt;

        }

        //Update Student Data
        public void updateStudent(DataRow dr)
        {
            Open();
            string query = "";
            string data = "";
            int result ;

            query = "UPDATE ST_STUDENT_DATA SET ";
            data += "STUDENT_ID ='" + dr["STUDENT_ID"] + "'";
            data += ", STUDENT_NAME = '" + dr["STUDENT_NAME"] + "'";
            data += ", ROLL_NO= '" + dr["ROLL_NO"] + "'";
            data += ", GENDER = '" + dr["GENDER"] + "'";
            data += ", PHOTO_PATH = '" + dr["PHOTO_PATH"] + "'";
            data += ", DOB = '" + dr["DOB"] + "'";
            data += ", PHONE = '" + dr["PHONE"] + "'";
            data += ", NRC_NO = '" + dr["NRC_NO"] + "'";
            data += ", PASSWORD = '" + dr["PASSWORD"] + "'";
            data += ", GRADE_ID = '" + dr["GRADE_ID"] + "'";
            data += ", ROOM_ID = '" + dr["ROOM_ID"] + "'";
            data += ", CASH_TYPE1 = '" + dr["CASH_TYPE1"] + "'";
            data += ", CASH_TYPE2 = '" + dr["CASH_TYPE2"] + "'";
            data += ", FATHER_NAME = '" + dr["FATHER_NAME"] + "'";
            data += ", MOTHER_NAME = '" + dr["MOTHER_NAME"] + "'";
            data += ", ADDRESS = '" + dr["ADDRESS"] + "'";
            data += ", CONTACT_PHONE = '" + dr["CONTACT_PHONE"] + "'";
            data += ", EMAIL = '" + dr["EMAIL"] + "'";
            data += ", CRT_DT_TM = '" + dr["CRT_DT_TM"] + "'";
            data += ", CRT_USER_ID = '" + dr["CRT_USER_ID"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = '" + 0 + "'";

            query += data + " WHERE STUDENT_ID =" + dr["STUDENT_ID"];
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            
        }

        // Delete student data
        public void deleteDataById(string id)
        {
            Open();
            string query = "";
            query = "UPDATE ST_STUDENT_DATA SET DEL_FLG =" + 1 + "WHERE STUDENT_ID='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            Close();
        }

        public int deletestudentdata(DsPSMS.ST_STUDENT_DATARow dr)
        {
            if (dr == null)
                return -1;
            Open();
            string query = "UPDATE ST_STUDENT_DATA SET DEL_FLG =" + 1 + "WHERE STUDENT_ID =" + dr["STUDENT_ID"];
            SqlCommand cmd = new SqlCommand(query, conn);
            result=cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        //Select student image
        //public DataSet.DsPSMS.ST_STUDENT_DATARow selectImage(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        //{
        //    DsPSMS.ST_STUDENT_DATADataTable stuDt = new DsPSMS.ST_STUDENT_DATADataTable();
        //    Open();
        //    string query = "SELECT* FROM ST_STUDENT_DATA WHERE PHOTO_PATH'" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "' AND STUDENT_NAME='" + dr.STUDENT_NAME + "'AND GRADE_ID='" + dr.GRADE_ID + "'";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(stuDt);
        //    Close();
        //    return stuDt[0];
        //}

        //select Cash Type from ST_STUDENT_DATA table
        public DataSet.DsPSMS.ST_STUDENT_DATARow selectCashType(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            DsPSMS.ST_STUDENT_DATADataTable stuDt = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            string query = "SELECT* FROM ST_STUDENT_DATA WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "' AND STUDENT_NAME='" + dr.STUDENT_NAME + "'AND GRADE_ID='" + dr.GRADE_ID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuDt);
            Close();
            return stuDt[0];
        }

        // select Student's name from ST_STUDENT_DATA table by STUDENT_ID and EDU_YEAR
        public DataSet.DsPSMS.ST_STUDENT_DATARow selectStuName(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            DsPSMS.ST_STUDENT_DATADataTable stuDt = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            string query = "SELECT* FROM ST_STUDENT_DATA WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR='" + dr.EDU_YEAR + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuDt);
            Close();
            return stuDt[0];
        }

        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectngyear(string name,string gradeid,string eduyearid)
        {
            DsPSMS.ST_STUDENT_DATADataTable nagyearr = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            string query = "SELECT * from ST_STUDENT_DATA WHERE GRADE_ID='" + gradeid + "' AND EDU_YEAR= '" + eduyearid+"' AND STUDENT_NAME Like'"+name+"%'";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(nagyearr);
            Close();
            return nagyearr;
        }

        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectgyear(string grade, string eduyear)
        {
            DsPSMS.ST_STUDENT_DATADataTable gyearr = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            string query = "SELECT * from ST_STUDENT_DATA WHERE GRADE_ID='" + grade + "' AND EDU_YEAR= '" + eduyear + "'";
           
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(gyearr);
            Close();
            return gyearr;
        }

        public DataSet.DsPSMS.ST_STUDENT_DATADataTable selectIdNaEdGd(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            DsPSMS.ST_STUDENT_DATADataTable gyearr = new DsPSMS.ST_STUDENT_DATADataTable();
            Open();
            string query = "SELECT * from ST_STUDENT_DATA WHERE STUDENT_ID='" + dr.STUDENT_ID + "' AND EDU_YEAR= '" + dr.EDU_YEAR + "' AND STUDENT_NAME='" + dr.STUDENT_NAME + "' AND GRADE_ID = '" + dr.GRADE_ID +"'";
            //string query = "SELECT * from ST_STUDENT_DATA WHERE GRADE_ID='" + gradeid + "' AND EDU_YEAR= '" + eduyearid + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(gyearr);
            Close();
            return gyearr;
        }

    }
}
