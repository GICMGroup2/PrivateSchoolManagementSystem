using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HomeASP.DbAccess;


namespace HomeASP.Service
{
    class GradeSubjectService : dbAccess
    {
        GradeSubjectDb db = new GradeSubjectDb();
        
        public bool isExistGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_MSTRow gradeData = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable selectedGrade = new DataSet.DsPSMS.ST_GRADE_MSTDataTable();
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
                    gradeData.GRADE_NAME = dr.GRADE_NAME;
                selectedGrade = db.selectGrade(gradeData);

                if (selectedGrade != null && selectedGrade.Rows.Count > 0)
                {
                    msg = "exist user";
                }
                else
                {
                    selectedGrade = null;
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
            bool isOk = false;
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

        public bool updateGrade(DataSet.DsPSMS.ST_GRADE_MSTRow oldData, DataSet.DsPSMS.ST_GRADE_MSTRow newData, out string msg)
        {
            bool isOk = false;
            if (newData == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.updateGrade(oldData, newData);
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

        public int deleteGrade(DataSet.DsPSMS.ST_GRADE_MSTRow dr, out string msg)
        {
            int result;
            try
            {
                if (dr == null)
                {
                    msg = "data is empty";
                    return 0;
                }
                else
                {
                    db.Open();
                    result = db.deleteGrade(dr);
                    msg = "grade deleted";
                }             
            }
            catch
            {
                msg = "error has occure when delete data";
                return 0;
            }
            finally
            {
                db.Close();
            }
            return result;
        }              

        public bool isExistSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow subject, out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTRow requestSubject = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            bool Exist = false;
            if (subject == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                if (subject.SUBJECT_NAME != null)
                    requestSubject.SUBJECT_NAME = subject.SUBJECT_NAME;
                result = db.selectSubject(requestSubject);

                if (result != null && result.Rows.Count > 0)
                {
                    msg = "exist user";
                }
                else
                {
                    result = null;
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

        public bool saveSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
        {
            bool isOk = false;
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

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectData(out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            try
            {
                db.Open();
                result = db.selectAllSubjectData();
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

        public DataSet.DsPSMS.ST_SUBJECT_MSTDataTable getAllSubjectName(string subjectId, out string msg)
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable result = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable();
            try
            {
                db.Open();
                result = db.getAllSubjectName(subjectId);
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

        public int deleteSubject(DataSet.DsPSMS.ST_SUBJECT_MSTRow dr, out string msg)
        {
            int result;
            try
            {
                if (dr == null)
                {
                    msg = "data is empty";
                    return 0;
                }
                else
                {
                    db.Open();
                    result = db.deleteSubject(dr);
                    msg = "grade deleted";
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return 0;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public bool isExistGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, out string msg)
        {
            msg = null;
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow userData = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable selectedUser = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            bool existFlag = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                userData.ID = dr.ID;
                selectedUser = db.selectGradeSubject(userData);
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

        public bool saveGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, string subjectIdList, out string msg)
        {
            bool isOk = false;
            if (dr == null)
            {
                msg = "data is empty ";
                return false;
            }
            try
            {
                db.Open();
                int result = db.insertGradeSubjectDetail(dr, subjectIdList);
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

        public DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable getAllGradeSubjectData(out string msg)
        {
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable result = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable();
            try
            {
                db.Open();
                result = db.getAllGradeSubjectData();
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

        public int deleteGradeSubject(DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow dr, out string msg)
        {
            int result;
            try
            {
                if (dr == null)
                {
                    msg = "data is empty";
                    return 0;
                }
                else
                {
                    db.Open();
                    result = db.deleteGradeSubject(dr);
                    msg = "grade deleted";
                }
            }
            catch
            {
                msg = "error has occure when delete data";
                return 0;
            }
            finally
            {
                db.Close();
            }
            return result;
        }

    }
}
