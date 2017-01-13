using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using HomeASP.DbAccess;
using HomeASP.DataSet;
using System.Text;
using System.Threading.Tasks;

namespace HomeASP.Service
{
    public class StudentInfoService : dbAccess
    { StudentInfo stu = new StudentInfo();

    //SqlConnection conn = new SqlConnection();
    //dbAccess db = new dbAccess();

        //saving Student Data
    public bool saveData(DataSet.DsPSMS.ST_STUDENT_DATARow dr,string tbName,out string msg)
    {
        bool isOk = true;
        int result = 0;
        if (dr == null)
        {
            msg = "data is empty";
            return false;
        }
        try
        {
            Open();
            result = stu.insertData(dr, tbName);
            msg = "insert complete";
        }
        catch
        {
            msg = "error has occure when insert data";
            return false;
        }
        finally
        {
            Close();
        }
        return isOk;
        }

        // Get all student data
        public DataTable getAllData(out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
               Open();
                dt = stu.selectAllData();
                msg = "Student found";
            }
            catch
            {
                msg = "error has occure when select data";
                return null;
            }
            finally
            { Close(); }
            return dt;
        }

        //Update student's data
        public bool updatedata(DataSet.DsPSMS.ST_STUDENT_DATARow dr, out string msg)
        {
            bool isOk = true;
            if (dr == null)
            {
                msg = "data is empty";
                return false;
            }
            try
            {
                Open();
                stu.updateStudent(dr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            { Close(); }
            return isOk;
        }

        //delete student's data
        public bool deleteData(string id, out string msg)
        {
            bool isOk = true;
            if (id == null)
            {
                msg = "data is empty";
                return false;
            }
            try
            {
                Open();
                stu.deleteDataById(id);
                msg = "delete complete";
            }
            catch
            {
                msg = "error has occure when delete data";
                return false;
            }
            finally
            {
                Close();
            }
            return isOk;
        }

        // Get student by option
        public DataSet.DsPSMS.ST_STUDENT_DATADataTable getAllDataByOption(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            DataSet.DsPSMS.ST_STUDENT_DATADataTable dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            try
            {
                Open();
                dt = stu.selectDataOption(dr);
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
            return dt;
        }

        public DsPSMS.ST_STUDENT_DATARow getCashType(DsPSMS.ST_STUDENT_DATARow stuDr, out string msg)
        {

            try
            {
                Open();
                stuDr = stu.selectCashType(stuDr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash type";
                return null;
            }
            finally
            {
                Close();
            }

            return stuDr;
        }
        public DsPSMS.ST_STUDENT_DATARow getStuName(DsPSMS.ST_STUDENT_DATARow dr, out string msg)
        {
            DataSet.DsPSMS.ST_STUDENT_DATARow stuDr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            try
            {
                Open();
                stuDr = stu.selectStuName(dr);
                msg = "Have data";
            }
            catch
            {
                msg = "error occurs when selecting cash type";
                return null;
            }
            finally
            {
                Close();
            }

            return stuDr;
        }

    }
}



        


       
    



