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
    public partial class SM_StudentTimeTableEntry : System.Web.UI.Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
        private string msg = "";
        static int updateTimeHedId;
        DataSet.DsPSMS.ST_TIMETABLE_HEDRow timetablehed = new DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable().NewST_TIMETABLE_HEDRow();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";

            if (ddlentrygradelist.Items.Count == 0)
            {
                bindGrade();
            }

            if (ddlentryclasslist.Items.Count == 0)
            {
                bindClass();
            }
            if (ddlentryteacherlist.Items.Count == 0)
            {
                bindRoomTeacher();
            }
            
            DisplayRoomTeacher();
        }

        public void bindGrade()
        {
            msg = "aaa";
            ddlentrygradelist.Items.Clear();
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddlentrygradelist.DataSource = grades;
            ddlentrygradelist.DataTextField = "GRADE_NAME";
            ddlentrygradelist.DataValueField = "GRADE_ID";
            ddlentrygradelist.DataBind();
            ddlentrygradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
        }

        public void bindClass()
        {
            msg = "aaa";
            ddlentryclasslist.Items.Clear();
            DataSet.DsPSMS.ST_ROOM_MSTDataTable rooms = timeService.getAllRoomData(out msg);
            ddlentryclasslist.DataSource = rooms;
            ddlentryclasslist.DataTextField = "ROOM_NAME";
            ddlentryclasslist.DataValueField = "ROOM_ID";
            ddlentryclasslist.DataBind();
            ddlentryclasslist.Items.Insert(0, new ListItem("Select Class", "0"));
        }

        public void bindRoomTeacher()
        {
            msg = "aaa";
            ddlentryteacherlist.Items.Clear();
            DataSet.DsPSMS.ST_TEACHER_DATADataTable teachers = timeService.getAllTeacherData(out msg);
            ddlentryteacherlist.DataSource = teachers;
            ddlentryteacherlist.DataTextField = "TEACHER_NAME";
            ddlentryteacherlist.DataValueField = "TEACHER_ID";
            ddlentryteacherlist.DataBind();
            ddlentryteacherlist.Items.Insert(0, new ListItem("Select Teacher", "0"));
        }

        public void DisplayRoomTeacher()
        {
            DataSet.DsPSMS.ST_TIMETABLE_HEDDataTable resultDt = timeService.getAllTimetableHedData(out msg);

            if (resultDt != null)
            {
                resultDt.Columns.Remove(resultDt.Columns["EDU_YEAR"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["DEL_FLG"]);

                foreach (DataSet.DsPSMS.ST_TIMETABLE_HEDRow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    int teacherId;
                    string teachervalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }

                    if (row.ROOM_TEACHER_ID != null)
                    {
                        teacherId = int.Parse(row.ROOM_TEACHER_ID);
                        DataSet.DsPSMS.ST_TEACHER_DATARow teacher = timeService.getTeacherByid(teacherId);
                        teachervalue = teacher.TEACHER_NAME;
                        row.ROOM_TEACHER_ID = teachervalue;
                    }

                    if (row.ROOM_ID != null)
                    {
                        int roomId = int.Parse(row.ROOM_ID);
                        DataSet.DsPSMS.ST_ROOM_MSTRow room = timeService.getClassByid(roomId);
                        string roomvalue = room.ROOM_NAME;
                        row.ROOM_ID = roomvalue;
                    }
                }
                gvRoomTeacher.DataSource = resultDt;
                gvRoomTeacher.DataBind();
                gvRoomTeacher.HeaderRow.Cells[2].Text = "NO";
                gvRoomTeacher.HeaderRow.Cells[3].Text = "ROOM TEACHER";
                gvRoomTeacher.HeaderRow.Cells[4].Text = "GRADE";
                gvRoomTeacher.HeaderRow.Cells[5].Text = "ROOM";
            }
        }

        protected void btnRoomteaSave_Click(object sender, EventArgs e)
        {
            bool  isOK = true;
            if (btnRoomteaSave.Text.Equals("INSERT"))
            {
                timetablehed.GRADE_ID = ddlentrygradelist.SelectedItem.Value;
                timetablehed.ROOM_ID = ddlentryclasslist.SelectedItem.Value;
                timetablehed.ROOM_TEACHER_ID = ddlentryteacherlist.SelectedItem.Value;
                timetablehed.DEL_FLG = 0;
                isOK = timeService.saveTimetableHedData(timetablehed, out msg);
            }
            else if (btnRoomteaSave.Text.Equals("UPDATE"))
            {
                timetablehed.GRADE_ID = ddlentrygradelist.SelectedItem.Value;
                timetablehed.ROOM_ID = ddlentryclasslist.SelectedItem.Value;
                timetablehed.ROOM_TEACHER_ID = ddlentryteacherlist.SelectedItem.Value;
                isOK = timeService.updateTimeTableHed(timetablehed, updateTimeHedId, out msg);
            }

            if (isOK)
            {
                DisplayRoomTeacher();
                resetForm();
            }
        }

        protected void resetForm()
        {
            ddlentrygradelist.SelectedIndex = 0;
            ddlentryclasslist.SelectedIndex = 0;
            ddlentryteacherlist.SelectedIndex = 0;
            btnRoomteaSave.Text = "INSERT";
        }

        protected void btnRoomTeaUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string timetablrHedId = btn.CommandName;
            if (timetablrHedId != null)
            {
                updateTimeHedId = int.Parse(timetablrHedId);
                DataSet.DsPSMS.ST_TIMETABLE_HEDRow timetableHed = timeService.getTimetableHedByid(updateTimeHedId);
                ddlentrygradelist.SelectedIndex = int.Parse(timetableHed.GRADE_ID);
                ddlentryteacherlist.SelectedIndex = int.Parse(timetableHed.ROOM_TEACHER_ID);
                ddlentryclasslist.SelectedIndex = int.Parse(timetableHed.ROOM_ID);
                btnRoomteaSave.Text = "UPDATE";
            }
        }

        protected void btnroomteaCancel_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        protected void btnRoomTeaNext_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string timetablrHedId = btn.CommandName;
            if (timetablrHedId != null)
            {
                Session["TimetableHedId"] = timetablrHedId;
                Response.Redirect("SM_StudentTimeTableEntry_2.aspx");
            }
        }
    }
}