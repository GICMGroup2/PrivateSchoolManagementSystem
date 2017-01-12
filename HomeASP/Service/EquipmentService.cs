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

        public bool SaveEquipmentData(DsPSMS.ST_EQUIPMENT_DATARow EqiDataDr, out string msg)
        {
            bool isOk = true;

            if (EqiDataDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                Open();
                int result = equipDb.insertEquipData(EqiDataDr);
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

        public DataSet.DsPSMS.ST_EQUIPMENT_MSTRow getEquipDataById(int id)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable EqMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            try
            {
                Open();
                EqMstDt = equipDb.selectEquipDataById(id);
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

            return EqMstDt[0];
        }

        public DataSet.DsPSMS.ST_EQUIPMENT_DATADataTable getAllEquipData()
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable EqDataDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();

            try
            {
                Open();
                EqDataDt = equipDb.selectAllEquipData();
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

            return EqDataDt;
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

        public bool editEquipmentData(DsPSMS.ST_EQUIPMENT_DATARow EqiDataDr, out string msg)
        {
            bool isOk = true;

            if (EqiDataDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                Open();
                int result = equipDb.updateEquipData(EqiDataDr);
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

        public bool removeEquipmentData(DsPSMS.ST_EQUIPMENT_DATARow EqiMstDr, out string msg)
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
                int result = equipDb.deleteEquipData(EqiMstDr);
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