using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess 
{
    public class ExpanseDb
    {
        string query = "";
        string data = "";
        int result = 0;
        SqlConnection conn = new SqlConnection();
        dbAccess db = new dbAccess();
        DsPSMS.ST_EXP_HEDDataTable expHedDt = new DsPSMS.ST_EXP_HEDDataTable();
        DsPSMS.ST_EXP_HEDRow expHedDr = new DsPSMS.ST_EXP_HEDDataTable().NewST_EXP_HEDRow();
        DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
        DsPSMS.ST_EXP_DETAILRow expDetDr = new DsPSMS.ST_EXP_DETAILDataTable().NewST_EXP_DETAILRow(); 

        //insert expanse info into ST_EXP_HED table
        public int insertExpanseHed(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            if (dr == null)
                return -1;
           conn= db.Open();
            query = "INSERT INTO ST_EXP_HED (EDU_YEAR, EXP_TITLE, EXP_DATE, REMARK, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
           // data += ", '" + dr.EXP_ID + "'";
            data += ", '" + dr.EXP_TITLE + "'";
            data += ", '" + dr.EXP_DATE + "'";
            data += ", '" + dr.REMARK + "'";
            data += ", '" + dr.CRT_DT_TM + "'";
            data += ", '" + dr.CRT_USER_ID + "'";
            data += ", '" + dr.UPD_DT_TM + "'";
            data += ", '" + dr.UPD_USER_ID + "'";
            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            db.Close();
            return result;
        }

        //select all cash information from ST_EXP_HED table
        public DataSet.DsPSMS.ST_EXP_HEDDataTable selectExpHedAllData()
        {
            conn = db.Open();
            query = "SELECT* FROM ST_EXP_HED WHERE DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(expHedDt);
            db.Close();
            return expHedDt;
        }

        public int updateExpanseHed(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            if (dr == null)
                return -1;
            conn = db.Open();
            query = "UPDATE ST_EXP_HED SET ";
           
            data += " EDU_YEAR = '" + dr["EDU_YEAR"] + "'";
          //  data += ", EXP_ID = '" + dr["EXP_ID"] + "'";
            data += ", EXP_TITLE = '" + dr["EXP_TITLE"] + "'";
            data += ", EXP_DATE = '" + dr["EXP_DATE"] + "'";
            data += ", REMARK = '" + dr["REMARK"] + "'";
            data += ", CRT_DT_TM = '" + dr["CRT_DT_TM"] + "'";
            data += ", CRT_USER_ID = '" + dr["CRT_USER_ID"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = " + 0 ;
            query += data + " WHERE EXP_ID =" + dr["EXP_ID"];
            
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            db.Close();
            return result;
        }

        public void deleteExpHed(DataSet.DsPSMS.ST_EXP_HEDRow dr)
        {
            conn = db.Open();
            string query = "";

            query = "UPDATE ST_EXP_HED SET DEL_FLG =" + 1 + " WHERE EXP_ID = " + dr.EXP_ID + " AND CRT_DT_TM='" + dr.CRT_DT_TM + "'"  ;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            db.Close();

        }

        //insert expanse info into ST_EXP_DETAIL table
        public int insertExpanseDet(DataSet.DsPSMS.ST_EXP_DETAILRow dr)
        {
            if (dr == null)
                return -1;
            conn = db.Open();
            query = "INSERT INTO ST_EXP_DETAIL (EXP_ID, EXP_SUB_TITLE, AMOUNT, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += dr.EXP_ID ;
            data += ", '" + dr.EXP_SUB_TITLE + "'";
            data += ", '" + dr.AMOUNT + "'";
            data += ", '" + DateTime.Now + "'";
            data += ", '" + dr.CRT_USER_ID + "'";
            data += ", '" + dr.UPD_DT_TM + "'";
            data += ", '" + dr.UPD_USER_ID + "'";
            data += ", " + 0;

            query += " VALUES (" + data + ");";
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            db.Close();
            return result;
        }

        //select all cash information from ST_EXP_DETAIL table
        public DataSet.DsPSMS.ST_EXP_DETAILDataTable selectExpDetData(int expId)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            conn = db.Open();
            query = "SELECT* FROM ST_EXP_DETAIL WHERE EXP_ID = "+ expId +" AND DEL_FLG = " + 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(expDetDt);
            db.Close();
            return expDetDt;
        }

        public int updateExpanseDet(DataSet.DsPSMS.ST_EXP_DETAILRow dr)
        {
            if (dr == null)
                return -1;
            conn = db.Open();
            query = "UPDATE ST_EXP_DETAIL SET ";
            data += " EXP_ID = " + dr.EXP_ID;
            data += ", EXP_SUB_TITLE = '" + dr.EXP_SUB_TITLE + "'";
            data += ", AMOUNT = '" + dr.AMOUNT + "'";
            query += data + " WHERE EXP_ID =" + dr.EXP_ID + " AND CRT_DT_TM = '" + dr.CRT_DT_TM + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            db.Close();
            return result;
        }

        public void deleteExpDet(DataSet.DsPSMS.ST_EXP_DETAILRow dr)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
                conn = db.Open();
                string query = "";
                query = "UPDATE ST_EXP_DETAIL SET DEL_FLG =" + 1 + " WHERE EXP_ID = " + dr.EXP_ID + " AND CRT_DT_TM='" + dr.CRT_DT_TM + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                db.Close();
            

        }
    }
}