using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP.Service
{
    public class ExpanseService
    {
        dbAccess db = new dbAccess();
        ExpanseDb expDb = new ExpanseDb();
        DsPSMS.ST_EXP_HEDDataTable expHedDt = new DsPSMS.ST_EXP_HEDDataTable();
        DsPSMS.ST_EXP_HEDRow expHedDr = new DsPSMS.ST_EXP_HEDDataTable().NewST_EXP_HEDRow();
        DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
        DsPSMS.ST_EXP_DETAILRow expDetDr = new DsPSMS.ST_EXP_DETAILDataTable().NewST_EXP_DETAILRow(); 

        public bool SaveExpInfo(DsPSMS.ST_EXP_HEDRow expDr, out string msg)
        {
            bool isOk = true;

            if (expDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = expDb.insertExpanseHed(expDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_EXP_HEDDataTable getExpHedAllData()
        {
            try
            {
                db.Open();
                expHedDt = expDb.selectExpHedAllData();
                //msg = "Have data";
            }
            catch
            {
                // msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                db.Close();
            }

            return expHedDt;
        }

        public bool updateExpInfo(DsPSMS.ST_EXP_HEDRow expDr, out string msg)
        {
            bool isOk = true;

            if (expDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = expDb.updateExpanseHed(expDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public bool deleteExpHed(DsPSMS.ST_EXP_HEDRow expDr)
        {
            bool isOk = true;
            if (expDr == null)
            {
               // msg = "data is empty ";
                return false;
            }
            try
            {
               db.Open();
               expDb.deleteExpHed(expDr);
               // msg = "delete complete";
            }
            catch
            {
               // msg = "error has occure when delete data";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public bool SaveExpDetInfo(DsPSMS.ST_EXP_DETAILRow expDr, out string msg)
        {
            bool isOk = true;

            if (expDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = expDb.insertExpanseDet(expDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_EXP_DETAILDataTable getExpDetData(int expId)
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();
            try
            {
                db.Open();
                expDetDt = expDb.selectExpDetData(expId);
                int ttt = expDetDt.Rows.Count;
                //msg = "Have data";
            }
            catch
            {
                // msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                db.Close();
            }

            return expDetDt;
        }

        public bool updateExpDetInfo(DsPSMS.ST_EXP_DETAILRow expDr, out string msg)
        {
            bool isOk = true;

            if (expDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = expDb.updateExpanseDet(expDr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data Student Cash Information";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public bool deleteExpDet(DsPSMS.ST_EXP_DETAILRow expDr)
        {
            bool isOk = true;
            if (expDr == null)
            {
                // msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                expDb.deleteExpDet(expDr);
                // msg = "delete complete";
            }
            catch
            {
                // msg = "error has occure when delete data";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }
    }
}