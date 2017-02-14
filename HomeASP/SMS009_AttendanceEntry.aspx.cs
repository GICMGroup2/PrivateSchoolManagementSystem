using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;

namespace HomeASP
{    
    public partial class SMS009 : System.Web.UI.Page
    {
        GradeSubjectService gradeService = new GradeSubjectService();
        AttendanceService attService = new AttendanceService();
        DataSet.DsPSMS.ST_STUDENT_DATARow studentRow = null;
        string msg = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            if (gradeList.Items.Count == 0)
            {
                getGrade();
            }            
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnCheckAM.Visible = false;
            btnCheckPM.Visible = false;
        }

        private void showAllButton()
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnCheckAM.Visible = true;
            btnCheckPM.Visible = true;
        }

        protected void getGrade()
        {            
            gradeList.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeResult = gradeService.getAllGradeData(out msg);
            if (gradeResult != null)
            {
                gradeList.DataSource = gradeResult.OrderBy(item => item.GRADE_ID);
                gradeList.DataTextField = "GRADE_NAME";
                gradeList.DataValueField = "GRADE_ID";
                gradeList.DataBind();
                gradeList.Items.Insert(0, "Select Grade");
            }
        }

        protected Boolean checkValidation()
        {
            Boolean isError = false;
            if (eduYearList.Text.Trim().Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please enter Education Year");
                isError = true;
            }
            if (gradeList.Text.Equals("Select Grade"))
            {
                ModelState.AddModelError(string.Empty, "Please enter Grade");
                isError = true;
            }
            if (roomList.Text.Trim().Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please enter Room");
                isError = true;
            }
            return isError;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!checkValidation())
            {
                gridViewAttendance.DataSource = null;
                gridViewAttendance.DataBind();
                studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
                studentRow.EDU_YEAR = Convert.ToInt16(eduYearList.Text);
                studentRow.GRADE_ID = gradeList.Text;
                studentRow.ROOM_ID = roomList.Text;
                studentRow.ROLL_NO = "";
                studentRow.STUDENT_NAME = "";

                if (attendDate.Text.Trim().Length == 0)
                {                    
                    DataSet.DsPSMS.ST_STUDENT_DATADataTable resultDt = attService.selectStudentData(studentRow, out msg);
                    if (resultDt == null || resultDt.Count == 0)
                    {
                        ModelState.AddModelError(string.Empty, "Data doesn't found");
                        gridViewAttendance.DataSource = null;
                        gridViewAttendance.DataBind();
                    }
                    else
                    {                
                        gridViewAttendance.DataSource = resultDt;
                        gridViewAttendance.DataBind();
                    }
                }
                else
                {
                    DataSet.DsPSMS.ST_ATTENDANCE_DATARow adr = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                    adr.ATTENDANCE_DATE = attendDate.Text;
                    DataSet.DsPSMS.ATTENDANCE_RESULTDataTable resultDt = attService.selectAttendanceData(studentRow, adr, out msg);                                    

                    if (resultDt.Count != 0)
                    {
                        gridViewAttendance.DataSource = resultDt;
                        gridViewAttendance.DataBind();

                        for (int i = 0; i < resultDt.Count; i++)
                        {     
                            Label date = (Label)gridViewAttendance.Rows[i].FindControl("Date");
                            date.Text = resultDt.Rows[i]["ATTENDANCE_DATE"].ToString();

                            CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
                            chkAM.Checked = false;
                            if (Convert.ToInt16(resultDt.Rows[i]["MORNING"]) == 1)
                            {
                                chkAM.Checked = true;
                            }
                            else
                            {
                                chkAM.Checked = false;
                            }

                            CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
                            chkPM.Checked = false;
                            if (Convert.ToInt16(resultDt.Rows[i]["EVENING"]) == 1)
                            {
                                chkPM.Checked = true;
                            }
                            else
                            {
                                chkPM.Checked = false;
                            }
                        }              
                    }                    
                }
                showAllButton();
            }            
        }

        protected void fillDate(object sender, EventArgs e)
        {
            if (gridViewAttendance.Rows.Count != 0)
            {
                foreach(GridViewRow row in gridViewAttendance.Rows)
                {
                    Label date = (Label)row.FindControl("Date");
                    date.Text = attendDate.Text;
                }                
            }
            showAllButton();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {            
            if (checkAldyRecord())
            {
                ModelState.AddModelError(string.Empty, "Already Record! Choose another date");
            }
            else
            {
                studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
                studentRow.EDU_YEAR = Convert.ToInt16(eduYearList.Text);
                studentRow.GRADE_ID = gradeList.Text;
                studentRow.ROOM_ID = roomList.Text;
                for (int i = 0; i < gridViewAttendance.Rows.Count; i++)
                {
                    int resultDt = 0;
                    DataSet.DsPSMS.ST_ATTENDANCE_DATARow row = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                    row.STUDENT_ID = gridViewAttendance.Rows[i].Cells[0].Text;
                    row.EDU_YEAR = Convert.ToInt16(eduYearList.Text);
                    row.ATTENDANCE_DATE = attendDate.Text;          

                    CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
                    if (chkAM != null && chkAM.Checked == false)
                    {
                        row.MORNING = "0";
                    }
                    else
                    {
                        row.MORNING = "1";
                    }

                    CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
                    if (chkPM != null && chkPM.Checked == false)
                    {
                        row.EVENING = "0";
                    }
                    else
                    {
                        row.EVENING = "1";
                    }
                    resultDt = attService.saveAttendanceRecord(row, out msg);
                }
            }
            showAllButton();
        }

        private bool checkAldyRecord()
        {
            bool alreadyExist = false;
            for (int i = 0; i < gridViewAttendance.Rows.Count; i++)
            {
                DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable result = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();
                DataSet.DsPSMS.ST_ATTENDANCE_DATARow drr = result.NewST_ATTENDANCE_DATARow();
                drr.STUDENT_ID = gridViewAttendance.Rows[i].Cells[0].Text;
                drr.ATTENDANCE_DATE = attendDate.Text;
                result = attService.getAttendanceByDate(drr);
                if (result != null && result.Rows.Count > 0)
                { 
                    alreadyExist = true; 
                }
                else
                { 
                    alreadyExist = false; 
                }
            }
            return alreadyExist;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridViewAttendance.Rows.Count; i++)
            {
                int resultDt = 0;
                DataSet.DsPSMS.ST_ATTENDANCE_DATARow row = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                row.EDU_YEAR = Convert.ToInt16(eduYearList.Text);
                row.STUDENT_ID = gridViewAttendance.Rows[i].Cells[0].Text;
                row.ATTENDANCE_DATE = attendDate.Text;

                CheckBox chkAM = (CheckBox)gridViewAttendance.Rows[i].FindControl("AM");
                if (chkAM != null && chkAM.Checked == false)
                {
                    row.MORNING = "0";
                }
                else
                {
                    row.MORNING = "1";
                }

                CheckBox chkPM = (CheckBox)gridViewAttendance.Rows[i].FindControl("PM");
                if (chkPM != null && chkPM.Checked == false)
                {
                    row.EVENING = "0";
                }
                else
                {
                    row.EVENING = "1";
                }
                resultDt = attService.updateAttendanceRecord(row, out msg);
                showAllButton();
            }
        }

        protected void btnCheckAllAM_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewAttendance.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("AM");                
                if (chk != null && chk.Checked == false)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
            showAllButton();
        }

        protected void btnCheckAllPM_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridViewAttendance.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("PM");
                if (chk != null && chk.Checked == false)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
            showAllButton();
        }
    }
}