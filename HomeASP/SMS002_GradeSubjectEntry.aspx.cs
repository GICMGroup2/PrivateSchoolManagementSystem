using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS002 : System.Web.UI.Page
    {
        private string msg = "";
        GradeSubjectService service = new GradeSubjectService();
        DataSet.DsPSMS.ST_GRADE_MSTRow gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
        DataSet.DsPSMS.ST_SUBJECT_MSTRow subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
        DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            msg = "";
            if (!checkValidation())
            {
                gradeRow.GRADE_ID = gradeId.Text;
                gradeRow.GRADE_NAME = gradeName.Text;

                bool existFlag = service.isExistGrade(gradeRow, out msg);

                if (existFlag)
                {     
                    //show error message
                }
                else
                {
                    //bool isOk = service.saveGrade(gradeRow, out msg);
                    DisplayGradeData();
                    FillGradeListCombo();
                    gradeId.Text = "";
                    gradeName.Text = ""; 
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        private bool checkValidation()
        {
            bool isErr = false;
            if (gradeId.Text.Trim().Length == 0)
            {
                //msg = "Please enter ID !\n";
                msg = "Please enter require field";
                isErr = true;
            }
            if (gradeName.Text.Trim().Length == 0)
            {
                //msg = "Please enter ID !\n";
                msg = "Please enter require field";
                isErr = true;
            }
            return isErr;
        }

        private void DisplayGradeData()
        {
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.getAllGradeData(out msg);
            gridViewGrade.DataSource = null;
            if (resultDt != null)
            {              
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);

                gridViewGrade.DataSource = resultDt;
                gridViewGrade.DataBind();

                gridViewGrade.HeaderRow.Cells[0].Text = "Year";
                gridViewGrade.HeaderRow.Cells[1].Text = "ID";
                gridViewGrade.HeaderRow.Cells[2].Text = "Grade";                
            }
        }

        void FillGradeListCombo()
        {
            gradeList.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.getAllGradeData(out msg);
            if (resultDt != null)
            {
                gradeList.DataSource = resultDt;
                gradeList.DataTextField = "GRADE_NAME";
                gradeList.DataValueField = "GRADE_NAME";
                gradeList.DataBind();
                gradeList.Items.Insert(0, "Select Grade");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            msg = "";
            if (!checkValidation())
            {
                gradeRow.GRADE_ID = gradeId.Text;
                gradeRow.GRADE_NAME = gradeName.Text;

                bool existFlg = service.isExistGrade(gradeRow, out msg);
                if (existFlg)
                {
                    //MessageBox.Show(msg);
                }
                else
                {                    
                    int result = service.deleteGrade(gradeRow, out msg);
                    DisplayGradeData();               
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        protected void btnSubjectAdd_Click(object sender, EventArgs e)
        {
            msg = "";
            if (subjectId.Text.Trim().Length != 0)
            {
                subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
                subjectRow.SUBJECT_ID = subjectId.Text;
                subjectRow.SUBJECT_NAME = subjectName.Text;

                bool Exist = service.isExistSubject(subjectRow, out msg);

                if (Exist)
                {
                    //MessageBox.Show(msg);
                }
                else
                {          
                    //bool isOk = service.saveSubject(subjectRow, out msg);
                    displaySubjectData();
                    displaySubjectInGridView();
                    subjectId.Text = "";
                    subjectName.Text = "";   
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        private void displaySubjectData()
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable resultDt = service.getAllSubjectData(out msg);
            if (resultDt != null)
            {                
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);
                resultDt.Columns.Remove(resultDt.Columns[3]);

                gridViewSubject.DataSource = resultDt;
                gridViewSubject.DataBind();

                gridViewSubject.HeaderRow.Cells[0].Text = "Year";
                gridViewSubject.HeaderRow.Cells[1].Text = "ID";
                gridViewSubject.HeaderRow.Cells[2].Text = "Subject";          
            }
        }

        private void displaySubjectInGridView()
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable resultDt = service.getAllSubjectData(out msg);
            if (resultDt != null)
            {                
                subjectGridView.DataSource = resultDt;
                subjectGridView.DataBind();
            }
        }

        protected void btnSubjectUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubjectDelete_Click(object sender, EventArgs e)
        {
            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            msg = "";
            if (checkValidation())
            {
                subjectRow.SUBJECT_ID = subjectId.Text;
                subjectRow.SUBJECT_NAME = subjectName.Text;

                bool existFlg = service.isExistSubject(subjectRow, out msg);
                if (existFlg)
                {
                    //MessageBox.Show(msg);
                }
                else
                {
                    int result = service.deleteSubject(subjectRow, out msg);
                    displaySubjectData();
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        protected void btnGradeSubjectAdd_Click(object sender, EventArgs e)
        {
            msg = "";
            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            string subjectId = null;
            if (checkValidation())
            {
                gradeSubjectRow.ID = gradeSubjectId.Text;
                gradeSubjectRow.GRADE_ID = gradeList.Text;
                int rowCount = 0;

                foreach (GridViewRow row in subjectGridView.Rows)
                {
                    rowCount++;
                    CheckBox chk = (CheckBox)row.FindControl("selectedSubject");
                    if (chk != null && chk.Checked)
                    {
                        subjectId += row.Cells[2].Text;
                        subjectId += ",";
                    }
                    if (rowCount == subjectGridView.Rows.Count)
                    {
                        subjectId = subjectId.Substring(0, subjectId.Length-1);
                    }
                }

                bool existFlag = service.isExistGradeSubject(gradeSubjectRow, out msg);

                if (existFlag)
                {
                    //show error message
                }
                else
                {
                    //bool isOk = service.saveGradeSubject(gradeSubjectRow, subjectId, out msg);
                    DisplayGradeSubjectData();
                    gradeSubjectId.Text = "";
                    foreach (GridViewRow row in subjectGridView.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("selectedSubject");
                        if (chk != null && chk.Checked)
                        {
                            chk.Checked = false;
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        private void DisplayGradeSubjectData()
        {
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.getAllGradeSubjectData(out msg);

            if (resultDt != null)
            {
                BoundField subjectNameList = new BoundField();
                subjectNameList.HeaderText = "Subject";                

                foreach (DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow row in resultDt.Rows)
                {
                    string subjectIdList = null;
                    string subjectName = null;
                    if (row.SUBJECT_ID_LIST != null)
                    {
                        subjectIdList = row.SUBJECT_ID_LIST.ToString();
                    }

                    DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subject = service.getAllSubjectName(subjectIdList, out msg);

                    foreach (DataSet.DsPSMS.ST_SUBJECT_MSTRow subjectRow in subject.Rows)
                    {
                        subjectName += subjectRow.SUBJECT_NAME.ToString();
                        subjectName += ",";
                    }                    
                    subjectName = subjectName.Substring(0, subjectName.Length - 1);

                    row.SUBJECT_ID_LIST = subjectName;
                }
                
                gradeSubjectGridView.DataSource = resultDt;
                gradeSubjectGridView.DataBind();
                
                //gradeSubjectGridView.Columns.Add(subjectNameList);

            }
        }

        protected void btnGradeSubjectUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnGradeSubjectDelete_Click(object sender, EventArgs e)
        {
            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            msg = "";
            if (checkValidation())
            {
                gradeSubjectRow.ID = gradeSubjectId.Text;
                gradeSubjectRow.GRADE_ID = gradeList.Text;

                bool existFlg = service.isExistGradeSubject(gradeSubjectRow, out msg);
                if (existFlg)
                {
                    //MessageBox.Show(msg);
                }
                else
                {
                    int result = service.deleteGradeSubject(gradeSubjectRow, out msg);
                    DisplayGradeSubjectData();
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }
    }
}