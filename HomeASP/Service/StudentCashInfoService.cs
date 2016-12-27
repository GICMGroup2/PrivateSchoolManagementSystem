using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeASP.DbAccess;
using HomeASP.DataSet;

namespace HomeASP.Service
{
    public class StudentCashInfoService
    {
        string msg = "";
        dbAccess db = new dbAccess();
        StudentCashInfoDb stuCashDb = new StudentCashInfoDb();
        DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
        //DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
        DsPSMS.ST_STUDENT_DATARow stuDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
        DsPSMS.ST_GRADE_MSTRow grDr = new DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();

        public bool SaveStudentCashInfo(DsPSMS.ST_STUDENT_CASHRow stuCashDr, out string msg)
        {
            bool isOk = true;

            if (stuCashDr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = stuCashDb.insertStuCash(stuCashDr);
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

        public DataSet.DsPSMS.ST_STUDENT_CASHDataTable getCashData(DataSet.DsPSMS.ST_STUDENT_CASHRow stuCashDr, out string msg)
        {
            try
            {
                db.Open();
                stuCashDt = stuCashDb.selectCashData(stuCashDr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash data";
                return null;
            }
            finally
            {
                db.Close();
            }

            return stuCashDt;
        }

        public DataSet.DsPSMS.ST_STUDENT_CASHDataTable getCashAllData()
        {
            try
            {
                db.Open();
                stuCashDt = stuCashDb.selectCashAllData();
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

            return stuCashDt;
        }

        public DsPSMS.ST_STUDENT_DATARow getCashType(DsPSMS.ST_STUDENT_DATARow stuDr, out string msg)
        {
            
            try
            {
                db.Open();
                stuDr = stuCashDb.selectCashType(stuDr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash type";
                return null;
            }
            finally
            {
                db.Close();
            }

            return stuDr;
        }
        public DsPSMS.ST_STUDENT_DATARow getStuName(string edu_year, string stu_id)
        {

            try
            {
                db.Open();
                stuDr = stuCashDb.selectStuName(edu_year,stu_id);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash type";
                return null;
            }
            finally
            {
                db.Close();
            }

            return stuDr;
        }

        public DsPSMS.ST_GRADE_MSTRow getGradeName(string grade_id)
        {

            try
            {
                db.Open();
                grDr = stuCashDb.selectGradeName(grade_id);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash type";
                return null;
            }
            finally
            {
                db.Close();
            }

            return grDr;
        }

    }
}