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
        DataSet.DsPSMS.ST_GRADE_MSTRow gradeRow = null;
        DataSet.DsPSMS.ST_SUBJECT_MSTRow subjectRow = null;
        DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILRow gradeSubjectRow = null;

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
            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            if (btnAdd.Text.Equals("Add"))
            {
                msg = "";                
                if (!checkValidation())
                {
                    gradeRow.GRADE_ID = gradeId.Text;
                    gradeRow.GRADE_NAME = gradeName.Text;

                    DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeData = service.selectGradeByID(gradeRow, out msg);

                    if (gradeData != null && gradeData.Rows.Count > 0)
                    {
                        //bool isOk = service.saveGrade(gradeRow, out msg);
                        
                    }
                    else
                    {                        
                        //show error message
                    }
                }                
            }
            else if (btnAdd.Text.Equals("Update"))
            {
                if (gradeName.Text.Trim().Length != 0)
                {
                    gradeRow.GRADE_NAME = gradeName.Text;
                    gradeRow.GRADE_ID = gradeId.Text;
                    service.updateGrade(gradeRow, out msg);

                    btnAdd.Text = "Add";
                    gradeId.Enabled = true;
                    btnDelete.Enabled = true;
                    btnShowAll.Enabled = true; 
                }
                else
                { 
                    //display error message;
                }
            }
            displayGradeData();
            FillGradeListCombo();
            gradeId.Text = "";
            gradeName.Text = "";
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

        private void displayGradeData()
        {
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.getAllGradeData(out msg);
            gridViewGrade.DataSource = null;
            gridViewGrade.DataBind();
            if (resultDt != null)
            {              
                gridViewGrade.DataSource = resultDt;
                gridViewGrade.DataBind();         
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
            LinkButton btn = (LinkButton)(sender);
            string editGradeId = btn.CommandName;
            gradeId.Text = editGradeId;
            gradeId.Enabled = false;

            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            if (editGradeId != null)
                gradeRow.GRADE_ID = editGradeId;
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeData = service.selectGradeByID(gradeRow, out msg);
            gradeName.Text = gradeData.Rows[0]["GRADE_NAME"].ToString();

            btnAdd.Text = "Update";
            btnDelete.Enabled = false;
            btnShowAll.Enabled = false;            
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            displayGradeData();
            FillGradeListCombo();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
            msg = "";
            if (!checkValidation())
            {
                gradeRow.GRADE_ID = gradeId.Text;
                gradeRow.GRADE_NAME = gradeName.Text;

                DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.selectGradeByID(gradeRow, out msg);
                if (resultDt != null)
                {
                    //MessageBox.Show(msg);
                }
                else
                {                    
                    int result = service.deleteGrade(gradeRow, out msg);
                    displayGradeData();               
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        protected void btnAddSubject_Click(object sender, EventArgs e)
        {            
            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            if (subjectAdd.Text.Equals("Add"))
            {
                msg = "";
                if (subjectId.Text.Trim().Length != 0)
                {
                    subjectRow.SUBJECT_ID = subjectId.Text;
                    subjectRow.SUBJECT_NAME = subjectName.Text;

                    DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjectData = service.selectSubjectByID(subjectRow, out msg);

                    if (subjectData != null && subjectData.Rows.Count > 0)
                    {
                        //MessageBox.Show(msg);                       
                    }
                    else
                    {
                        //bool isOk = service.saveSubject(subjectRow, out msg);
                    }
                }                
            }
            else if (subjectAdd.Text.Equals("Update"))
            {
                if (subjectName.Text.Trim().Length != 0)
                {
                    subjectRow.SUBJECT_NAME = subjectName.Text;
                    subjectRow.SUBJECT_ID = subjectId.Text;
                    service.updateSubject(subjectRow, out msg);
                    
                    subjectAdd.Text = "Add";
                    subjectId.Enabled = true;
                    subjectDelete.Enabled = true;
                    subjectShowAll.Enabled = true;
                }
                else
                {
                    //display error message;
                }
            }
            displaySubjectData();
            displaySubjectInGridView();
            subjectId.Text = "";
            subjectName.Text = "";
        }

        private void displaySubjectData()
        {
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable resultDt = service.getAllSubjectData(out msg);
            gridViewSubject.DataSource = null;
            gridViewSubject.DataBind();  
            if (resultDt != null)
            {                
                gridViewSubject.DataSource = resultDt;
                gridViewSubject.DataBind();      
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

        protected void btnUpdateSubject_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editSubjectId = btn.CommandName;
            subjectId.Text = editSubjectId;
            subjectId.Enabled = false;

            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            if (editSubjectId != null)
                subjectRow.SUBJECT_ID = editSubjectId;
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjectData = service.selectSubjectByID(subjectRow, out msg);
            subjectName.Text = subjectData.Rows[0]["SUBJECT_NAME"].ToString();

            subjectAdd.Text = "Update";
            subjectDelete.Enabled = false;
            subjectShowAll.Enabled = false; 
        }

        protected void btnSelectSubject_Click(object sender, EventArgs e)
        {
            displaySubjectData();
            displaySubjectInGridView();
        }

        protected void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            subjectRow = new DataSet.DsPSMS.ST_SUBJECT_MSTDataTable().NewST_SUBJECT_MSTRow();
            msg = "";
            if (checkValidation())
            {
                subjectRow.SUBJECT_ID = subjectId.Text;
                subjectRow.SUBJECT_NAME = subjectName.Text;

                DataSet.DsPSMS.ST_SUBJECT_MSTDataTable subjectData = service.selectSubjectByID(subjectRow, out msg);
                if (subjectData == null)
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

        protected void btnAddGradeSubject_Click(object sender, EventArgs e)
        {
            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            if (gradeSubjectAdd.Text.Equals("Add"))
            {
                msg = "";
                string subjectId = null;
                if (checkValidation())
                {
                    gradeSubjectRow.ID = gradeSubjectId.Text;
                    gradeSubjectRow.GRADE_ID = gradeList.Text;

                    subjectId = getSubjectIdList();
                    DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.selectGradeSubjectByID(gradeSubjectRow, out msg);

                    if (resultDt == null)
                    {
                        //show error message
                    }
                    else
                    {
                        //bool isOk = service.saveGradeSubject(gradeSubjectRow, subjectId, out msg);                        
                    }
                }
            }
            else if (gradeSubjectAdd.Text.Equals("Update"))
            {
                if (gradeList.Text.Trim().Length != 0)
                {
                    gradeSubjectRow.ID = gradeSubjectId.Text;
                    gradeSubjectRow.GRADE_ID = gradeList.Text;
                    gradeSubjectRow.SUBJECT_ID_LIST = getSubjectIdList();
                    service.updateGradeSubject(gradeSubjectRow, out msg);

                    gradeSubjectAdd.Text = "Add";
                    gradeSubjectId.Enabled = true;
                    gradeSubjectDelete.Enabled = true;
                    gradeSubjectShowAll.Enabled = true; 
                }
                else
                {
                    //display error message;
                }
            }

            displayGradeSubjectData();
            gradeSubjectId.Text = "";
            gradeList.SelectedIndex = 0;
            foreach (GridViewRow row in subjectGridView.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("selectedSubject");
                if (chk != null && chk.Checked)
                {
                    chk.Checked = false;
                }
            }
        }

        private string getSubjectIdList()
        {
            string subjectId = null;
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
                    subjectId = subjectId.Substring(0, subjectId.Length - 1);
                }
            }
            return subjectId;
        }

        private void displayGradeSubjectData()
        {
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.getAllGradeSubjectData(out msg);
            gradeSubjectGridView.DataSource = null;
            gradeSubjectGridView.DataBind();

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
            }
        }

        protected void btnUpdateGradeSubject_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string editId = btn.CommandName;
            gradeSubjectId.Text = editId;
            gradeSubjectId.Enabled = false;

            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            if (editId != null)
                gradeSubjectRow.ID = editId;
            DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable subjectGradeData = service.selectGradeSubjectByID(gradeSubjectRow, out msg);

            gradeSubjectAdd.Text = "Update";
            gradeSubjectDelete.Enabled = false;
            gradeSubjectShowAll.Enabled = false; 
        }

        protected void btnSelectGradeSubject_Click(object sender, EventArgs e)
        {
            displayGradeSubjectData();
        }

        protected void btnDeleteGradeSubject_Click(object sender, EventArgs e)
        {
            gradeSubjectRow = new DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable().NewST_GRADE_SUBJECT_DETAILRow();
            msg = "";
            if (checkValidation())
            {
                gradeSubjectRow.ID = gradeSubjectId.Text;
                gradeSubjectRow.GRADE_ID = gradeList.Text;

                DataSet.DsPSMS.ST_GRADE_SUBJECT_DETAILDataTable resultDt = service.selectGradeSubjectByID(gradeSubjectRow, out msg);
                if (resultDt == null)
                {
                    //MessageBox.Show(msg);
                }
                else
                {
                    int result = service.deleteGradeSubject(gradeSubjectRow, out msg);
                    displayGradeSubjectData();
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }
    }
}