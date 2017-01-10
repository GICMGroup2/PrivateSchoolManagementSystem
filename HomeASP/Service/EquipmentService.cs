using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using System.Data.SqlClient;

namespace HomeASP.Service 
{
    public class EquipmentService :dbAccess
    {
        EquipmentDb equipDb = new EquipmentDb();

        public bool SaveEquipmentMST(DsPSMS.ST_EQUIPMENT_MSTRow EqiMstDr, out string msg)
        {
            bool isOk = true;

            if (EqiMstDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                    Open();
                int result = equipDb.insertEquipMST(EqiMstDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                    Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_EQUIPMENT_MSTDataTable getAllEquipMST()
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMSTDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            try
            {
                Open();
                EqMSTDt = equipDb.selectAllEquipMSTData();
                //msg = "Have data";
            }
            catch
            {
                // msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                Close();
            }

            return EqMSTDt;
        }
        public bool editEquipmentMST(DsPSMS.ST_EQUIPMENT_MSTRow EqiMstDr, out string msg)
        {
            bool isOk = true;

            if (EqiMstDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                Open();
                int result = equipDb.updateEquipMST(EqiMstDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }

        public bool removeEquipmentMST(DsPSMS.ST_EQUIPMENT_MSTRow EqiMstDr, out string msg)
        {
            bool isOk = true;

            if (EqiMstDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                Open();
                int result = equipDb.deleteEquipMST(EqiMstDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                Close();
            }

            return isOk;
        }
    }
}