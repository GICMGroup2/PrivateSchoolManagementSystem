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

namespace HomeASP.Service
{
     class TimeTableEntryService:dbAccess
    {
         TimeTableEntry timedb = new TimeTableEntry();

         public bool isExist(DataSet.DsPSMS.ST_TIMETABLERow dr, out string msg)
         {
             msg = null;
             DataSet.DsPSMS.ST_TIMETABLERow userData = new DataSet.DsPSMS.ST_TIMETABLEDataTable().NewST_TIMETABLERow();
             DataSet.DsPSMS.ST_TIMETABLEDataTable selectedUser = new DataSet.DsPSMS.ST_TIMETABLEDataTable();
             bool existFlag = true;
             //if (dr == null)
             //{
             //    msg = "data is empty ";
             //    return false;
             //}
             //try
             //{
             //    timedb.Open();
             //    if (dr.DAY != null)
             //        userData.DAY = dr.DAY;
             //        selectedUser = timedb.selectTimetable(userData);

             //    if (selectedUser != null && selectedUser.Rows.Count > 0)
             //    {
             //        msg = "exist user";
             //    }
             //    else
             //    {
             //        selectedUser = null;
             //    }
             //}
             //catch
             //{
             //    msg = "error has occure when insert data";
             //    return false;
             //}
             //finally
             //{
             //    timedb.Close();
             //}
             return existFlag;
         }

         public DataSet.DsPSMS.ST_GRADE_MSTDataTable getAllGradeData(out string msg)
         {
             DataSet.DsPSMS.ST_GRADE_MSTDataTable result = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllGradeData();
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
                 timedb.Close();
             }
             return result;
         }

         public DataSet.DsPSMS.ST_TEACHER_DATADataTable getAllTeacherData(out string msg)
         {
             DataSet.DsPSMS.ST_TEACHER_DATADataTable result = new DataSet.DsPSMS.ST_TEACHER_DATADataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllTeacherData();
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
                 timedb.Close();
             }
             return result;
         }

         public bool saveTimeTable(DataSet.DsPSMS.ST_TIMETABLERow dr, out string msg)
         {
             bool isOk = true;

             if (dr == null)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.insertStuTimeTable(dr);
                 msg = "insert complete";
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TIMETABLE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public bool deleteTimeTable(int id, out string msg)
         {
             bool isOk = true;

             if (id == 0)
             {
                 msg = "data is empty ";
                 return false;
             }
             try
             {
                 timedb.Open();
                 int result = timedb.deleteStuTimeTable(id);
                 msg = "delete complete";
             }
             catch
             {
                 msg = "error occurs when deleting data to ST_TIMETABLE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }
             return isOk;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getAllTimeTableData(out string msg)
        {
            DataSet.DsPSMS.ST_TIMETABLEDataTable result = new DataSet.DsPSMS.ST_TIMETABLEDataTable();

            try
            {
                timedb.Open();
                result = timedb.selectAllTimetable();
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
                timedb.Close();
            }
            return result;
        }

    }
}