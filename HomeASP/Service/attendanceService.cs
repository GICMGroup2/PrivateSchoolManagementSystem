using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSMS.dataSet;
using System.Data;
using PSMS.DbAccess;


namespace PSMS.Service
{
    class attendanceService:dbAccess
    {

        attendanceDb db = new attendanceDb();
        public dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable getAttendance()
        {
            dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable dt = new dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
            return dt;
        }

        //select Attendacne from Student table for record input
        public dataSet.DsPSMS.StudentShowDataTable getSelectedAttendance(dataSet.DsPSMS.ST_STUDENT_DATARow dr, out string msg)
        {
            dataSet.DsPSMS.ST_STUDENT_DATARow atddata = new dataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            dataSet.DsPSMS.StudentShowDataTable selectedAttendance = new dataSet.DsPSMS.StudentShowDataTable();
            if (dr == null)
            {
                msg = "data is empty";
                return null;
            }
            try
            {
                db.Open();
                selectedAttendance = db.selectAttendance(dr);
                if (selectedAttendance != null )
                {
                    msg = selectedAttendance.Rows.Count + " student found";
                }
                else
                {
                    selectedAttendance = null;
                    msg = "attendance not found";
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

            return selectedAttendance;
        }
        //search Attendance by date,grade,class and classType from Attendance Table
        public dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable getSearchAttendance(dataSet.DsPSMS.ST_ATTENDANCE_DATARow dr, out string msg)
        {
            dataSet.DsPSMS.ST_ATTENDANCE_DATARow atddata = new dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
            dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable selectedAttendance = new dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
            if (dr == null)
            {
                msg = "data is empty";
                return null;
            }
            try
            {
                db.Open();
                selectedAttendance = db.searchAttendance(dr);
                if (selectedAttendance != null)
                {
                    msg = selectedAttendance.Rows.Count + " day found";
                }
                else
                {
                    selectedAttendance = null;
                    msg = "attendance not found";
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

            return selectedAttendance;
        }

        //save Attendance record
        public int saveAttendanceRecord(dataSet.DsPSMS.ST_ATTENDANCE_DATARow adr, out string msg)
        {
            int resultDt = 0;
            dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable dt = new dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
            dataSet.DsPSMS.ST_ATTENDANCE_DATARow dr = new dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
            if (dr == null)
            {
                msg = "data in empty";
                return resultDt;
            }
            try
            {
                db.Open();
                db.insertAttendanceRecord(adr);                             
                msg = "record complete";
                return resultDt;
            }
            catch
            {
                msg = "error has occurred when insert data";
                return resultDt;
            }
            finally
            {
                db.Close();
            }
        }
        //update attendance record//
        public int updateAttendanceRecord(dataSet.DsPSMS.ST_ATTENDANCE_DATARow adr, out string msg)
        {
            int resultDt = 0;

            if (adr == null)
            {
                msg = "data in empty";
                return resultDt;
            }
            try
            {
                db.Open();
                db.updateAttendance(adr);
                msg = "update complete";
                return resultDt;
            }
            catch
            {
                msg = "error has occurred when update data";
                return resultDt;
            }
            finally
            {
                db.Close();
            }
        }
        public dataSet.DsPSMS.AttShowDataTable getAttendance(dataSet.DsPSMS.ST_STUDENT_DATARow sr, dataSet.DsPSMS.ST_ATTENDANCE_DATARow dr, out string msg)
        {
            dataSet.DsPSMS.ST_STUDENT_DATARow atddata = new dataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            dataSet.DsPSMS.AttShowDataTable selectedAttendance = new dataSet.DsPSMS.AttShowDataTable();
            if (dr == null)
            {
                msg = "data is empty";
                return null;
            }
            try
            {
                db.Open();
                selectedAttendance = db.selectAttendance(sr, dr);
                if (selectedAttendance != null)
                {
                    msg = selectedAttendance.Rows.Count + " day found";
                }
                else
                {
                    selectedAttendance = null;
                    msg = "attendance not found";
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

            return selectedAttendance;
        }
        //for insert validation//
        public dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable getAttendanceByDate(dataSet.DsPSMS.ST_ATTENDANCE_DATARow dr)
        {
            if (dr == null)
                return null;
            try
            {
                db.Open();
                dataSet.DsPSMS.ST_ATTENDANCE_DATADataTable dt = db.selectByDate(dr);
                if (dt != null && (dt.Rows.Count > 0))
                    return dt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Close();
            }
        }

        //Grade and Subject 

        public bool saveGrade(dataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
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
                msg = "duplicate id cannot be inserted";
                return false;

            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public bool Exist(dataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            dataSet.DsPSMS.ST_GRADE_MSTRow userdata = new dataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            dataSet.DsPSMS.ST_GRADE_MSTDataTable selectedUser = new dataSet.DsPSMS.ST_GRADE_MSTDataTable();
            bool Exist = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                if (!dr.IsGRADE_NAMENull())
                    userdata.GRADE_NAME = dr.GRADE_NAME;
                selectedUser = db.selectGrade(userdata);

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
            msg = "exist user";
            return Exist;
        }
        public dataSet.DsPSMS.ST_GRADE_MSTDataTable getAllC(out string msg)
        {
            dataSet.DsPSMS.ST_GRADE_MSTDataTable selectC = new dataSet.DsPSMS.ST_GRADE_MSTDataTable();

            try
            {
                db.Open();

                selectC = db.selectCP();
                if (selectC != null && selectC.Rows.Count > 0)
                {
                    msg = selectC.Rows.Count + " user found";
                }

                else
                {
                    selectC = null;
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

            return selectC;
        }

        public dataSet.DsPSMS.ST_GRADE_MSTDataTable getDeleteUser(dataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            dataSet.DsPSMS.ST_GRADE_MSTRow userdata = new dataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            dataSet.DsPSMS.ST_GRADE_MSTDataTable deleteUser = new dataSet.DsPSMS.ST_GRADE_MSTDataTable();
            try
            {
                db.Open();
                deleteUser = db.deleteC(dr);
                msg = "1 company deleted";               
                if (dr == null)
                {
                    msg = "data is empty ";
                    return null;
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return null;
            }
            finally
            {
                db.Close();
            }

            return deleteUser;
        }

        public bool getUpdateUser(dataSet.DsPSMS.ST_GRADE_MSTRow dr, dataSet.DsPSMS.ST_GRADE_MSTRow whr, out string msg)
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
                int result = db.updateUser(dr, whr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }
        //Subject
        public bool saveSubject(dataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
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

                int result = db.insertSubject(dr);
                msg = "insert complete";
            }
            catch
            {
                msg = "duplicate id cannot be inserted";
                return false;

            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public dataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllC1(out string msg)
        {
            dataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectC = new dataSet.DsPSMS.ST_SUBJECT_MSTDataTable();

            try
            {
                db.Open();

                selectC = db.selectCP1();
                if (selectC != null && selectC.Rows.Count > 0)
                {
                    msg = selectC.Rows.Count + " user found";
                }

                else
                {
                    selectC = null;
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

            return selectC;
        }
        public bool getUpdateUser1(dataSet.DsPSMS.ST_SUBJECT_MSTRow dr, dataSet.DsPSMS.ST_SUBJECT_MSTRow whr, out string msg)
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
                int result = db.updateUser(dr, whr);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }
        public bool saveSubAndGrade(dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr,string subject, out string msg)
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

                int result = db.insertGAS(dr, subject);
                msg = "insert complete";
            }
            catch
            {
                msg = "duplicate id cannot be inserted";
                return false;

            }
            finally
            {
                db.Close();
            }

            return isOk;
        }

        public dataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectSubjectName1(String id, out string msg)
        {
            dataSet.DsPSMS.ST_SUBJECT_MSTDataTable selectC = new dataSet.DsPSMS.ST_SUBJECT_MSTDataTable();

            try
            {
                db.Open();

                selectC = db.selectSubjectName1(id);
                if (selectC != null && selectC.Rows.Count > 0)
                {
                    msg = selectC.Rows.Count + " user found";
                }

                else
                {
                    selectC = null;
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

            return selectC;
        }
        public dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable getAllC2(out string msg)
        {
            dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectC = new dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();

            try
            {
                db.Open();

                selectC = db.selectCP2();
                if (selectC != null && selectC.Rows.Count > 0)
                {
                    msg = selectC.Rows.Count + " user found";
                }

                else
                {
                    selectC = null;
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

            return selectC;
        }
        public dataSet.DsPSMS.ST_SUBJECT_MSTDataTable getDeleteSubject(dataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
        {
            dataSet.DsPSMS.ST_SUBJECT_MSTRow userdata = new dataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            dataSet.DsPSMS.ST_SUBJECT_MSTDataTable deleteUser = new dataSet.DsPSMS.ST_SUBJECT_MSTDataTable();



            try
            {

                db.Open();
                deleteUser = db.deleteC(dr);
                msg = "1 company deleted";               
                if (dr == null)
                {
                    msg = "data is empty ";
                    return null;
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return null;
            }
            finally
            {
                db.Close();
            }

            return deleteUser;
        }


        public bool getUpdateGradeAndSubject(dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dd, string Id,string subject, out string msg)
        {
            bool isOk = true;
            if (dd == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.updateGradeAndSubject(dd,Id,subject);
                msg = "update complete";
            }
            catch
            {
                msg = "error has occure when update data";
                return false;
            }
            finally
            {
                db.Close();
            }

            return isOk;
        }
        public dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable getDeleteGradeAndSubject(dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dd, out string msg)
        {
            dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow userdata = new dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable deleteUser = new dataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();



            try
            {

                db.Open();
                deleteUser = db.deletegs(dd);
                msg = "1 company deleted";               
                if (dd == null)
                {
                    msg = "data is empty ";
                    return null;
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return null;
            }
            finally
            {
                db.Close();
            }

            return deleteUser;
        }


    }
}
