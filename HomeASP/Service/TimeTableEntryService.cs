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

    }
}