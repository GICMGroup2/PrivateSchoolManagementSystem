using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using HomeASP.DataSet;

namespace HomeASP.DbAccess
{
    public class EquipmentDb :dbAccess
    {
        string query;
        string data;
        int result;

        //insert Equipment Title  into ST_EQUIPMENT_MST table
        public int insertEquipMST(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            if (dr == null)
                return -1;

            Open();
            query = "INSERT INTO ST_EQUIPMENT_MST (EDU_YEAR, EQUIPMENT_ID, EQUIPMENT_NAME, CRT_DT_TM, CRT_USER_ID, UPD_DT_TM, UPD_USER_ID, DEL_FLG)";

            data += " '" + dr.EDU_YEAR + "'";
            data += ", '" + dr.EQUIPMENT_ID + "'";
            data += ", '" + dr.EQUIPMENT_NAME + "'";
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

        // select all Equipment data from ST_EQUIPMENT_MST
        public DsPSMS.ST_EQUIPMENT_MSTDataTable selectAllEquipMSTData()
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable stuEquipMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            Open();
            query = "SELECT* FROM ST_EQUIPMENT_MST WHERE DEL_FLG = "+0;
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(stuEquipMSTDt);
            Close();
            return stuEquipMSTDt;
        }
        
        // update the Equipment Data of ST_EQUIPMENT_MST
        public int updateEquipMST(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EQUIPMENT_MST SET ";
           
            data += " EDU_YEAR = '" + dr["EDU_YEAR"] + "'";
            //data += ", EQUIPMENT_ID = '" + dr["EQUIPMENT_ID"] + "'";
            data += ", EQUIPMENT_NAME = '" + dr["EQUIPMENT_NAME"] + "'";
            data += ", UPD_DT_TM = '" + dr["UPD_DT_TM"] + "'";
            data += ", DEL_FLG = " + 0 ;
            query += data + " WHERE EQUIPMENT_ID =" + dr["EQUIPMENT_ID"];
            
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

        // delet the Equipment Data of ST_EQUIPMENT_MST but not delete just update the DEL_FLG
        public int deleteEquipMST(DsPSMS.ST_EQUIPMENT_MSTRow dr)
        {
            if (dr == null)
                return -1;
            Open();
            query = "UPDATE ST_EQUIPMENT_MST SET DEL_FLG = " + 1 + " WHERE EQUIPMENT_ID =" + dr["EQUIPMENT_ID"];
           
            SqlCommand cmd = new SqlCommand(query, conn);
            result = cmd.ExecuteNonQuery();
            Close();
            return result;
        }

    }
}