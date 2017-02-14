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
        string msg = "";
        StudentInfoService stuservice = new StudentInfoService();
        
               
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
           
            DsPSMS.ST_STUDENT_DATARow studetail = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (Session["EDU_YEAR"] != null)
            {
                lblClass.Text = (string)(Session["EDU_YEAR"] ?? " ");
            }

            if (Session["STUDENT_ID"] != null)
            {
                lblID.Text = (string)(Session["STUDENT_ID"] ?? " ");
            }


            if (Session["STUDENT_NAME"] != null)
            {
                lblName.Text = (string)(Session["STUDENT_NAME"] ?? " ");
            }

            if (Session["ROLL_NO"] != null)
            {
                lblRoll.Text = (string)(Session["ROLL_NO"] ?? " ");
            }

            if (Session["GENDER"] != null)
            {
                lblGender.Text = (string)(Session["GENDER"] ?? " ");
            }

            if (Session["DOB"] != null)
            {
                lbldob.Text = (string)(Session["DOB"] ?? " ");
            }

            if (Session["PHONE"] != null)
            {
                lblPhone.Text = (string)(Session["PHONE"] ?? " ");
            }

            if (Session["NRC_NO"] != null)
            {
                lblNrc.Text = (string)(Session["NRC_NO"] ?? " ");
            }

            if (Session["PASSWORD"] != null)
            {
                lblPwd.Text = (string)(Session["PASSWORD"] ?? " ");
            }

            if (Session["GRADE_ID"] != null)
            {
                lblGrade.Text = (string)(Session["GRADE_ID"] ?? " ");
            }

            if(Session["ROOM_ID"]!=null)
            {
                lblRoom.Text = (string)(Session["ROOM_ID"] ?? " ");
            }

            if (Session["FATHER_NAME"] != null)
            {
                lblFather.Text = (string)(Session["FATHER_NAME"] ?? " ");
            }

            if (Session["MOTHER_NAME"] != null)
            {
                lblMother.Text = (string)(Session["MOTHER_NAME"] ?? " ");
            }

            if (Session["ADDRESS"] != null)
            {
                lblAddress.Text = (string)(Session["ADDRESS"] ?? " ");
            }

            if (Session["CONTACT_PHONE"] != null)
            {
                lblCphone.Text = (string)(Session["CONTACT_PHONE"] ?? " ");
            }
            if (Session["EMAIL"] != null)
            {
                lblEmail.Text = (string)(Session["EMAIL"] ?? " ");
            }

            if (Session["CASH_TYPE1"] != null)
            {
                lblCashtype.Text = (string)(Session["CASH_TYPE1"] ?? " ");
            }

            if (Session["CASH_TYPE2"] != null)
            {
                lblCashMonth.Text = (string)(Session["CASH_TYPE2"] ?? " ");
            }
        }

        

                      
               
        protected void btnedit_Click(object sender, EventArgs e)
        {
            Session["EDU_YEAR"] = lblClass.Text;
            Session["STUDENT_ID"] = lblID.Text;
            Session["STUDENT_NAME"] = lblName.Text;
            Session["ROLL_NO"] = lblRoll.Text;
            Session["GENDER"] = lblGender.Text;
            Session["PHOTO_PATH"] = picturebox.AlternateText;
            Session["DOB"] = lbldob.Text;
            Session["PHONE"] = lblPhone.Text;
            Session["NRC_NO"] = lblNrc.Text;
            Session["PASSWORD"] = lblPwd.Text;
            Session["GRADE_ID"] = lblGrade.Text;
            Session["ROOM_ID"] = lblRoom.Text;
            Session["CASH_TYPE1"] = lblCashtype.Text;
            Session["CASH_TYPE2"] = lblCashMonth.Text;
            Session["FATHER_NAME"] = lblFather.Text;
            Session["MOTHER_NAME"] = lblMother.Text;
            Session["ADDRESS"] = lblAddress.Text;
            Session["CONTACT_PHONE"] = lblCphone.Text;
            Session["EMAIL"] = lblEmail.Text;
            Response.Redirect("SMS003_StudentEntry.aspx");
           
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS004_StudentList.aspx");
        }

       


    }
}