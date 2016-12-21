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
    public partial class SMS021 :Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
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
            ddltimegradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
        }

        public void bindGrade()
        {
            string msg = "aaa";
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddltimegradelist.DataSource = grades;
            ddltimegradelist.DataTextField = "GRADE_NAME";
            ddltimegradelist.DataValueField = "GRADE_ID";
            ddltimegradelist.DataBind();
        }
    }
}