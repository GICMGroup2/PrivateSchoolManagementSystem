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
    public partial class SM_StudentTimeTableEntry_2 : System.Web.UI.Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
        private string msg = "";
        static string timeHedId;
        static int timeDetailId;
        DataSet.DsPSMS.ST_TIMETABLE_DETAILRow timedetail = new DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable().NewST_TIMETABLE_DETAILRow();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";

            if (Session["TimetableHedId"] != null)
            {
                timeHedId = (string)Session["TimetableHedId"];
                DisplayTimeDetail(timeHedId);
            }
            if (ddlmonsublist.Items.Count == 0)
            {
                bindMonSubject();
            }
            if (ddltuesublist.Items.Count == 0)
            {
                bindTueSubject();
            }
            if (ddlwedsublist.Items.Count == 0)
            {
                bindWedSubject();
            }
            if (ddlthusublist.Items.Count == 0)
            {
                bindThuSubject();
            }
            if (ddlfrisublist.Items.Count == 0)
            {
                bindFriSubject();
            }
        }

        public void bindMonSubject()
        {
            msg = "aaa";
            ddlmonsublist.Items.Clear();
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable grades = timeService.getAllSubjectData(out msg);
            ddlmonsublist.DataSource = grades;
            ddlmonsublist.DataTextField = "SUBJECT_NAME";
            ddlmonsublist.DataValueField = "SUBJECT_ID";
            ddlmonsublist.DataBind();
            ddlmonsublist.Items.Insert(0, new ListItem("Select Subject", "0")); 
        }

        public void bindTueSubject()
        {
            msg = "aaa";
            ddltuesublist.Items.Clear();
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable grades = timeService.getAllSubjectData(out msg);
            ddltuesublist.DataSource = grades;
            ddltuesublist.DataTextField = "SUBJECT_NAME";
            ddltuesublist.DataValueField = "SUBJECT_ID";
            ddltuesublist.DataBind();
            ddltuesublist.Items.Insert(0, new ListItem("Select Subject", "0"));
        }

        public void bindWedSubject()
        {
            msg = "aaa";
            ddlwedsublist.Items.Clear();
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable grades = timeService.getAllSubjectData(out msg);
            ddlwedsublist.DataSource = grades;
            ddlwedsublist.DataTextField = "SUBJECT_NAME";
            ddlwedsublist.DataValueField = "SUBJECT_ID";
            ddlwedsublist.DataBind();
            ddlwedsublist.Items.Insert(0, new ListItem("Select Subject", "0"));
        }

        public void bindThuSubject()
        {
            msg = "aaa";
            ddlthusublist.Items.Clear();
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable grades = timeService.getAllSubjectData(out msg);
            ddlthusublist.DataSource = grades;
            ddlthusublist.DataTextField = "SUBJECT_NAME";
            ddlthusublist.DataValueField = "SUBJECT_ID";
            ddlthusublist.DataBind();
            ddlthusublist.Items.Insert(0, new ListItem("Select Subject", "0"));
        }

        public void bindFriSubject()
        {
            msg = "aaa";
            ddlfrisublist.Items.Clear();
            DataSet.DsPSMS.ST_SUBJECT_MSTDataTable grades = timeService.getAllSubjectData(out msg);
            ddlfrisublist.DataSource = grades;
            ddlfrisublist.DataTextField = "SUBJECT_NAME";
            ddlfrisublist.DataValueField = "SUBJECT_ID";
            ddlfrisublist.DataBind();
            ddlfrisublist.Items.Insert(0, new ListItem("Select Subject", "0"));
        }

        protected void btntimedetailAdd_Click(object sender, EventArgs e)
        {
            bool isOK = true;
            if (btntimedetailAdd.Text.Equals("ADD"))
            {
                timedetail.TIMETABLE_ID = timeHedId;
                timedetail.TIMETABLE_TIME = ddlperiodlist.SelectedItem.Value;
                timedetail.MONDAY = ddlmonsublist.SelectedItem.Value;
                timedetail.TUESDAY = ddltuesublist.SelectedItem.Value;
                timedetail.WEDNESDAY = ddlwedsublist.SelectedItem.Value;
                timedetail.THURSDAY = ddlthusublist.SelectedItem.Value;
                timedetail.FRIDAY = ddlfrisublist.SelectedItem.Value;
                timedetail.DEL_FLG = 0;
                isOK = timeService.saveTimetableDetailData(timedetail,out msg);
            }
            else if (btntimedetailAdd.Text.Equals("UPDATE"))
            {
                timedetail.TIMETABLE_ID = timeHedId;
                timedetail.TIMETABLE_TIME = ddlperiodlist.SelectedItem.Value;
                timedetail.MONDAY = ddlmonsublist.SelectedItem.Value;
                timedetail.TUESDAY = ddltuesublist.SelectedItem.Value;
                timedetail.WEDNESDAY = ddlwedsublist.SelectedItem.Value;
                timedetail.THURSDAY = ddlthusublist.SelectedItem.Value;
                timedetail.FRIDAY = ddlfrisublist.SelectedItem.Value;
                isOK = timeService.updateTimeTableDetail(timedetail, timeDetailId, out msg);
            }

            if (isOK)
            {
                DisplayTimeDetail(timeHedId);
                resetForm();
            }
        }

        protected void resetForm()
        {
            ddlmonsublist.SelectedIndex = 0;
            ddltuesublist.SelectedIndex = 0;
            ddlwedsublist.SelectedIndex = 0;
            ddlthusublist.SelectedIndex = 0;
            ddlfrisublist.SelectedIndex = 0;
            btntimedetailAdd.Text = "ADD";
        }

        protected void btntimedetailcancel_Click(object sender, EventArgs e)
        {
            if (btntimedetailAdd.Text.Equals("ADD"))
            {
                Response.Redirect("SM_StudentTimeTableEntry.aspx");
            }
            else if (btntimedetailAdd.Text.Equals("UPDATE"))
            {
                resetForm();
            }
        }

        protected void btnTimeDetailUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string detailId = btn.CommandName;
            if (detailId != null)
            {
                timeDetailId = int.Parse(detailId);
                DataSet.DsPSMS.ST_TIMETABLE_DETAILRow timetableDetail= timeService.getTimetableDetailByid(timeDetailId);
                ddlmonsublist.SelectedIndex = ddlmonsublist.Items.IndexOf(ddlmonsublist.Items.FindByValue(timetableDetail.MONDAY));
                ddltuesublist.SelectedIndex = ddltuesublist.Items.IndexOf(ddltuesublist.Items.FindByValue(timetableDetail.TUESDAY));
                ddlwedsublist.SelectedIndex = ddlwedsublist.Items.IndexOf(ddlwedsublist.Items.FindByValue(timetableDetail.WEDNESDAY));
                ddlthusublist.SelectedIndex = ddlthusublist.Items.IndexOf(ddlthusublist.Items.FindByValue(timetableDetail.THURSDAY));
                ddlfrisublist.SelectedIndex = ddlfrisublist.Items.IndexOf(ddlthusublist.Items.FindByValue(timetableDetail.FRIDAY));
                btntimedetailAdd.Text = "UPDATE";
            }
        }

        protected void btnTimeDetailDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string detailId = btn.CommandName;
            if (detailId != null)
            {
                bool isOk = timeService.deleteTimeDetail(int.Parse(detailId), out msg);
                DisplayTimeDetail(timeHedId);
            }
        }

        public void DisplayTimeDetail(string id)
        {
            DataSet.DsPSMS.ST_TIMETABLE_DETAILDataTable resultDt = timeService.getAllTimeDetailData(id, out msg);

            if (resultDt != null)
            {
                resultDt.Columns.Remove(resultDt.Columns["CRT_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["DEL_FLG"]);
                resultDt.Columns.Remove(resultDt.Columns["TIMETABLE_ID"]);

                foreach (DataSet.DsPSMS.ST_TIMETABLE_DETAILRow row in resultDt.Rows)
                {
                    int subjectId;
                    string subvalue = null;

                    if (row.MONDAY != null)
                    {
                        subjectId = int.Parse(row.MONDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.MONDAY = subvalue;
                    }

                    if (row.TUESDAY != null)
                    {
                        subjectId = int.Parse(row.TUESDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.TUESDAY = subvalue;
                    }

                    if (row.WEDNESDAY != null)
                    {
                        subjectId = int.Parse(row.WEDNESDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.WEDNESDAY = subvalue;
                    }

                    if (row.THURSDAY != null)
                    {
                        subjectId = int.Parse(row.THURSDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.THURSDAY = subvalue;
                    }

                    if (row.FRIDAY != null)
                    {
                        subjectId = int.Parse(row.FRIDAY);
                        DataSet.DsPSMS.ST_SUBJECT_MSTRow subject = timeService.getSubjectByid(subjectId);
                        subvalue = subject.SUBJECT_NAME;
                        row.FRIDAY = subvalue;
                    }
                }

                gvtimedetail.DataSource = resultDt;
                gvtimedetail.DataBind();
                gvtimedetail.HeaderRow.Cells[2].Text = "NO";
                gvtimedetail.HeaderRow.Cells[3].Text = "PERIOD";
                gvtimedetail.HeaderRow.Cells[4].Text = "MONDAY";
                gvtimedetail.HeaderRow.Cells[5].Text = "TUESDAY";
                gvtimedetail.HeaderRow.Cells[6].Text = "WEDNESDAY";
                gvtimedetail.HeaderRow.Cells[7].Text = "THURSDAY";
                gvtimedetail.HeaderRow.Cells[8].Text = "FRIDAY";
            }
        }
    }
}