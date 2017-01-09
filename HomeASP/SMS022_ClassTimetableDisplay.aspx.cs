using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace HomeASP
{
    public partial class SMS022 : System.Web.UI.Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();

        static int radioFlag = 0;
        private string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            bindGrade();
            bindTeacher();
            ddlgradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
            ddlteacherlist.Items.Insert(0, new ListItem("Select Teacher", "0"));
            //txtdate.Text = DateTime.Today.ToString("MM/dd/yyyy");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.Items[1].Selected == true)
            {
                radioFlag = 1;
                Panelstudent.Visible = true;
                lbteacher.Visible = false;
                ddlteacherlist.Visible = false;
            }
            else
            {
                radioFlag = 0;
                Panelstudent.Visible = false;
                lbteacher.Visible = true;
                ddlteacherlist.Visible = true;
            }
        }

        public void bindGrade()
        {
            msg = "aaa";
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddlgradelist.DataSource = grades.OrderBy(item => item.GRADE_NAME);
            ddlgradelist.DataTextField = "GRADE_NAME";
            ddlgradelist.DataValueField = "GRADE_ID";
            ddlgradelist.DataBind();
        }

        public void bindTeacher()
        {
            msg = "aaa";
            DataSet.DsPSMS.ST_TEACHER_DATADataTable grades = timeService.getAllTeacherData(out msg);
            ddlteacherlist.DataSource = grades;
            ddlteacherlist.DataTextField = "TEACHER_NAME";
            ddlteacherlist.DataValueField = "TEACHER_ID";
            ddlteacherlist.DataBind();
        }

        protected void btndate_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtdate.Text = Calendar1.SelectedDate.ToShortDateString();
            Panel1.Visible = false;
        }

        protected void btnteacher_Click(object sender, EventArgs e)
        {
            if (radioFlag == 0)
            {
                int selvalue = int.Parse(ddlteacherlist.SelectedItem.Value);
                if (!txtdate.Text.Equals("") && selvalue > 0)
                {
                    string date = txtdate.Text;
                    int teacherId = int.Parse(ddlteacherlist.SelectedItem.Value);
                    DisplayDatabydatenid(teacherId, date);
                }
                else if (txtdate.Text.Equals("") && selvalue > 0)
                {
                    int teacherId = int.Parse(ddlteacherlist.SelectedItem.Value);
                    DisplayDatabyid(teacherId);
                }
                else if (!txtdate.Text.Equals("") && selvalue == 0)
                {
                    string date = txtdate.Text;
                    DisplayDatabydate(date);
                }
            }
            else
            {
                int gradevalue = int.Parse(ddlgradelist.SelectedItem.Value);
                if (gradevalue > 0)
                {
                    int gradeId = int.Parse(ddlgradelist.SelectedItem.Value);
                    //DisplayDatabydatenid(gradeId);
                }
                else if (txtdate.Text.Equals("") && gradevalue > 0)
                {
                    int teacherId = int.Parse(ddlteacherlist.SelectedItem.Value);
                    DisplayDatabyid(teacherId);
                }
                else if (!txtdate.Text.Equals("") && gradevalue == 0)
                {
                    string date = txtdate.Text;
                    DisplayDatabydate(date);
                }
            }
        }

        private void DisplayDatabydatenid(int id,string date)
        {

            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt= timeService.getTimetableByidanddate(id, date);

            if (resultDt != null)
            {
                resultDt.Columns.Remove(resultDt.Columns["EDU_YEAR"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["DEL_FLG"]);
                resultDt.Columns.Remove(resultDt.Columns["TEACHER_ID"]);

                foreach (DataSet.DsPSMS.ST_TIMETABLERow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }
                }
 
                gvresultlist.DataSource = resultDt;
                gvresultlist.DataBind();
                gvresultlist.HeaderRow.Cells[0].Text = "NO";
                gvresultlist.HeaderRow.Cells[1].Text = "GRADE";
            }
        }

        private void DisplayDatabyid(int id)
        {

            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt = timeService.getTimetableByteacherid(id);

            if (resultDt != null)
            {
                resultDt.Columns.Remove(resultDt.Columns["EDU_YEAR"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["DEL_FLG"]);
                resultDt.Columns.Remove(resultDt.Columns["TEACHER_ID"]);

                foreach (DataSet.DsPSMS.ST_TIMETABLERow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }
                }

                gvresultlist.DataSource = resultDt;
                gvresultlist.DataBind();
                gvresultlist.HeaderRow.Cells[0].Text = "NO";
                gvresultlist.HeaderRow.Cells[1].Text = "GRADE";
            }
        }

        private void DisplayDatabydate(string date)
        {

            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt = timeService.getTimetableBydate(date);

            if (resultDt != null)
            {
                resultDt.Columns.Remove(resultDt.Columns["EDU_YEAR"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["DEL_FLG"]);
                resultDt.Columns.Remove(resultDt.Columns["TEACHER_ID"]);

                foreach (DataSet.DsPSMS.ST_TIMETABLERow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }
                }

                gvresultlist.DataSource = resultDt;
                gvresultlist.DataBind();
                gvresultlist.HeaderRow.Cells[0].Text = "NO";
                gvresultlist.HeaderRow.Cells[1].Text = "GRADE";
            }
        }



    }
}