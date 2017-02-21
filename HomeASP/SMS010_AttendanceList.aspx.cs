using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS010 : System.Web.UI.Page
    {
        GradeSubjectService gradeService = new GradeSubjectService();
        AttendanceService attService = new AttendanceService();
        DataSet.DsPSMS.ST_STUDENT_DATARow studentRow = null;
        DataSet.DsPSMS.ST_ATTENDANCE_DATARow attRow = null;
        DataSet.DsPSMS.ST_STUDENT_DATADataTable stdResult = null;
        DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable attResult = null;
        String msg = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            if (ddlGrade.Items.Count == 0)
            {
                getGrade();
            }
            if (ddlClass.Items.Count == 0)
            {
                //getClass();
            }
            if(ddlDay.Items.Count == 0)
            {
                getDay();
            }
        }

        protected void getGrade()
        {
            ddlGrade.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable gradeResult = gradeService.getAllGradeData(out msg);
            if (gradeResult != null)
            {
                ddlGrade.DataSource = gradeResult.OrderBy(item => item.GRADE_ID);
                ddlGrade.DataTextField = "GRADE_NAME";
                ddlGrade.DataValueField = "GRADE_ID";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, "Select Grade");
            }
        }

        protected void getDay()
        {
            ddlDay.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                if (i < 10)
                {
                    ddlDay.Items.Add("0" + i);
                }
                else
                {
                    ddlDay.Items.Add("" + i);
                }
            }
            ddlDay.Items.Insert(0, "Select Day");
        }

        protected void setDayByMonthYear()
        {         
            if (ddlMonth.SelectedIndex != 0)
            {
                int month = Convert.ToInt16(ddlMonth.Text);
                if (month == 2)
                {
                    ddlDay.Items.Remove("30");
                    ddlDay.Items.Remove("31");
                    if (ddlYear.SelectedIndex != 0)
                    {
                        int year = Convert.ToInt16(ddlYear.Text);
                        bool isLeapYear = ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0));
                        if (!isLeapYear)
                        {
                            ddlDay.Items.Remove("29");
                        }
                    }
                }
                if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    ddlDay.Items.Remove("31");
                }
            }
        }

        protected void chooseMonthYear(object sender, EventArgs e)
        {
            setDayByMonthYear();
            btnSearch_Click(sender, e);            
        }

        protected void chooseDay(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private bool checkValidation()
        {
            bool isErr = false;
            if (ddlGrade.SelectedIndex == 0)
            {
                ModelState.AddModelError(string.Empty, "Please enter Grade");
                isErr = true;
            }
            if (ddlClass.SelectedIndex == 0)
            {
                ModelState.AddModelError(string.Empty, "Please enter Class");
                isErr = true;
            }

            if (txtName.Text.Trim().Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please enter Student Name");
                isErr = true;
            }
            return isErr;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!checkValidation())
            {
                studentRow = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
                stdResult = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
                studentRow.GRADE_ID = ddlGrade.Text;
                studentRow.ROOM_ID = ddlClass.Text;
                studentRow.STUDENT_NAME = txtName.Text;
                stdResult = attService.selectStudentId(studentRow);

                attRow = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable().NewST_ATTENDANCE_DATARow();
                attResult = new DataSet.DsPSMS.ST_ATTENDANCE_DATADataTable();

                if (ddlDay.SelectedIndex != 0)
                {
                    attRow.ATTENDANCE_DATE = ddlDay.Text + "/";
                }
                else
                {
                    attRow.ATTENDANCE_DATE = "00/";
                }

                if (ddlMonth.SelectedIndex != 0)
                {
                    attRow.ATTENDANCE_DATE += ddlMonth.Text + "/";
                }
                else
                {
                    attRow.ATTENDANCE_DATE += "00/";
                }

                if (ddlYear.SelectedIndex != 0)
                {
                    attRow.ATTENDANCE_DATE += ddlYear.Text;
                }
                else
                {
                    attRow.ATTENDANCE_DATE += "0000";
                }

                if (stdResult.Count > 0)
                {                    
                    if (stdResult.Count == 1)
                    {
                        attRow.STUDENT_ID = stdResult.Rows[0]["STUDENT_ID"].ToString();
                    }
                    else
                    {
                        attRow.STUDENT_ID = "";
                        for (int i = 0; i < stdResult.Count; i++)
                        {
                            attRow.STUDENT_ID += stdResult.Rows[i]["STUDENT_ID"] + ",";
                        }
                        attRow.STUDENT_ID = attRow.STUDENT_ID.Substring(0, attRow.STUDENT_ID.Length - 1);
                    }
                    attResult = attService.selectAttendanceList(attRow);
                }

                if (attResult.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Data does not exist!");
                }
                
                gvAttendanceList.DataSource = attResult;
                gvAttendanceList.DataBind();
            }            
        }

    }
}