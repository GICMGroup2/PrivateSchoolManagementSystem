using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HomeASP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            title.InnerText = "Home";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            title.InnerText = "Login";
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        protected void stdInfo_Click(object sender, EventArgs e)
        {

        }
    }
}