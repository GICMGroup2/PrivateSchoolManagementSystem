using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeASP.DbAccess;


namespace HomeASP.Service
{
    class GradeSubjectService:dbAccess
    {
        attendanceDb db = new attendanceDb();
        
        public bool isExist(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_MSTRow userData = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable selectedUser = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            bool existFlag = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                if (dr.GRADE_NAME != null)
                    userData.GRADE_NAME = dr.GRADE_NAME;
                selectedUser = db.selectGrade(userData);

                if (selectedUser != null && selectedUser.Rows.Count > 0)
                {
                    msg = "exist user";
                }
                else
                {
                    selectedUser = null;
                }
            }
            catch
            {
                msg = "error has occure when insert data";
                return false;
            }
            finally
            {
                db.Close();
            }            
            return existFlag;
        }

        public bool saveGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            bool isOk = true;

            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertGrade(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "error occurs when inserting data to ST_GRADE_MST table";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public DataSet.DsPSMS.ST_GRADE_MSTDataTable getAllGradeData(out string msg)
        {
            DataSet.DsPSMS.ST_GRADE_MSTDataTable result = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
            try
            {
                db.Open();
                result = db.selectAllGradeData();
                if (result != null && result.Rows.Count > 0)
                {
                    msg = result.Rows.Count + " user found";
                }

                else
                {
                    result = null;
                    msg = "user not found";
                }
            }
            catch
            {
                msg = "error has occure when insert data";
                return null;
            }
            finally
            {
                db.Close();
            }
            return result;
        }
    }
}
