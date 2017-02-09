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

         public DataSet.DsPSMS.ST_ROOM_MSTDataTable getAllRoomData(out string msg)
         {
             DataSet.DsPSMS.ST_ROOM_MSTDataTable result = new DataSet.DsPSMS.ST_ROOM_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllRoomData();
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

         public bool saveTeacherGrade(DataSet.DsPSMS.ST_TEACHER_GRADERow dr, out string msg)
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
                 int result = timedb.insertTeacherGrade(dr);
                 msg = "insert complete";
                 
                 
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TEACHER_GRADE table";
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

         public DataSet.DsPSMS.ST_TIMETABLERow getTimeTableByid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLERow resultData = new DataSet.DsPSMS.ST_TIMETABLEDataTable().NewST_TIMETABLERow();
             resultData = timedb.selectTimetableByid(id);
             return resultData;
         }

         public bool updateTimeTable(DataSet.DsPSMS.ST_TIMETABLERow dr,int id, out string msg)
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
                 int result = timedb.updateStuTimeTable(dr,id);
                 msg = "update complete";
             }
             catch
             {
                 msg = "error occurs when updating data to ST_TIMETABLE table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_GRADE_MSTRow getGradeByid(int id)
         {
             DataSet.DsPSMS.ST_GRADE_MSTRow resultData = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
             resultData = timedb.selectGradeByid(id);
             return resultData;
         }

         public DataSet.DsPSMS.ST_TEACHER_DATARow getTeacherByid(int id)
         {
             DataSet.DsPSMS.ST_TEACHER_DATARow resultData = new DataSet.DsPSMS.ST_TEACHER_DATADataTable().NewST_TEACHER_DATARow();
             resultData = timedb.selectTeacherByid(id);
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableByidanddate(int id,string date)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = timedb.selectTimetableBydateandid(id,date);
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableByteacherid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = timedb.selectTimetableByteacherid(id);
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableBydate(string date)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = timedb.selectTimetableBydate(date);
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLEDataTable getTimetableBygradeid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLEDataTable resultData = timedb.selectTimetableBygradeid(id);
             return resultData;
         }

         public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow getGradeSubjectBygradeid(int id)
         {
             DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow resultData = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
             resultData = timedb.selectGradeSubjectBygradeId(id);
             return resultData;
         }

         public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectName(string subjectId, out string msg)
         {
             DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.getAllSubjectName(subjectId);
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

         public DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable getAllTimetableHedData(out string msg)
         {
             DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable result = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllTimetableHed();
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

         public bool saveTimetableHedData(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr, out string msg)
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
                 int result = timedb.insertTimetableHed(dr);
                 msg = "insert complete";
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TIMETABLE_HED table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_ROOM_MSTRow getClassByid(int id)
         {
             DataSet.DsPSMS.ST_ROOM_MSTRow resultData = new DataSet.DsPSMS.ST_ROOM_MSTDataTable().NewST_ROOM_MSTRow();
             resultData = timedb.selectClassByid(id);
             return resultData;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_HEDRow getTimetableHedByid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLE_HEDRow resultData = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable().NewST_TIMETABLE_HEDRow();
             resultData = timedb.selectTimetableHedByid(id);
             return resultData;
         }

         public bool updateTimeTableHed(DataSet.DsPSMS.ST_TIMETABLE_HEDRow dr, int id, out string msg)
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
                 int result = timedb.updateTimeTableHed(dr, id);
                 msg = "update complete";
             }
             catch
             {
                 msg = "error occurs when updating data to ST_TIMETABLE_HED table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectData(out string msg)
         {
             DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
             try
             {
                 timedb.Open();
                 result = timedb.selectAllSubjectData();
                 
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

         public bool saveTimetableDetailData(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr, out string msg)
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
                 int result = timedb.insertTimetableDetail(dr);
                 msg = "insert complete";
             }
             catch
             {
                 msg = "error occurs when inserting data to ST_TIMETABLE_DETAIL table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_DETAILRow getTimetableDetailByid(int id)
         {
             DataSet.DsPSMS.ST_TIMETABLE_DETAILRow resultData = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable().NewST_TIMETABLE_DETAILRow();
             resultData = timedb.selectTimetableDetailByid(id);
             return resultData;
         }

         public bool updateTimeTableDetail(DataSet.DsPSMS.ST_TIMETABLE_DETAILRow dr, int id, out string msg)
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
                 int result = timedb.updateTimeTableDetail(dr, id);
                 msg = "update complete";
             }
             catch
             {
                 msg = "error occurs when updating data to ST_TIMETABLE_DETAIL table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }

             return isOk;
         }

         public bool deleteTimeDetail(int id, out string msg)
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
                 int result = timedb.deleteTimeTableDetail(id);
                 msg = "delete complete";
             }
             catch
             {
                 msg = "error occurs when deleting data to ST_TIMETABLEDETAIL table";
                 return false;
             }
             finally
             {
                 timedb.Close();
             }
             return isOk;
         }

         public DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable getAllTimeDetailData(string id,out string msg)
         {
             DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable result = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable();

             try
             {
                 timedb.Open();
                 result = timedb.selectAllTimeDetail(id);
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

         public DataSet.DsPSMS.ST_SUBJECT_MSTRow getSubjectByid(int id)
         {
             DataSet.DsPSMS.ST_SUBJECT_MSTRow resultData = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
             resultData = timedb.selectSubjectByid(id);
             return resultData;
         }
    }
}