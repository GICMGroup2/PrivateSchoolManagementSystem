using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HomeASP.Service;
using HomeASP.DataSet;
using System.Drawing.Printing;

namespace HomeASP
{
    public partial class SMS005 : System.Web.UI.Page
    {
        Page ch;
        StudentInfoService stuentry = new StudentInfoService();
        DataSet.DsPSMS.ST_STUDENT_DATADataTable dt;
        DataSet.DsPSMS.ST_STUDENT_DATARow dr;
        List<string> roll = new List<string>();
        string rollNo;
        int i = 0;
        string msg = "";

        public SMS005()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            picturebox.ImageUrl = "~/Images/school.jpg";
            //education.Text = Convert.ToString(DateTime.Today.Year);

           // FileUpload1.Attributes["onchange"] = "UploadFile(this)";
        }

        public SMS005(List<string> array)
        {
            int count = array.Count;
            for (int j = 0; j < count; j++)
                roll.Add(array[j]);
        }

        private void Student_Detail(object sender, EventArgs e)
        {
            dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();
            dr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            btnprevious.Enabled = false;
            dr.ROLL_NO = roll[i];
            dt = stuentry.getAllDataByOption(dr);
            dr = dt[0];

            lblID.Text = dr[1].ToString();
            lblName.Text = dr[2].ToString();
            lblRoll.Text = dr[3].ToString();
            lbldob.Text = dr[6].ToString();
            lblPhone.Text = dr[7].ToString();
            lblNrc.Text = dr[8].ToString();
            lblPwd.Text = dr[9].ToString();
            lblGrade.Text = dr[10].ToString();
            lblClass.Text = dr[11].ToString();
            lblCashtype.Text = dr[12].ToString();
            lblCashMonth.Text = dr[13].ToString();
            lblFather.Text = dr[14].ToString();
            lblMother.Text = dr[15].ToString();
            lblAddress.Text = dr[16].ToString();
            lblCphone.Text = dr[17].ToString();
            lblEmail.Text = dr[18].ToString();
        }

        

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS004_StudentList.aspx");
        }
        protected void btnedit_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS003_StudentEntry.aspx");
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            
        }

       


    }
}