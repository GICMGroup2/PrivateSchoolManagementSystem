using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace HomeASP
{
    public partial class SMS015 : System.Web.UI.Page
    {
        DataSet.DataSet2.ST_STUDENT_DATARow stdr = new DataSet.DataSet2.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
        DataSet.DataSet2.ST_STUDENT_CASHRow dr = new DataSet.DataSet2.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
        Database.StudentCashDb db = new Database.StudentCashDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            logoImage.ImageUrl = "~/Images/logo1.png";
        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {

            stdr.EDU_YEAR = "2006";
            stdr.STUDENT_ID = TxtStudID.Text;
            stdr.STUDENT_NAME = TxtStuName.Text;
            stdr.GRADE_ID = "5";
            // select Cash Type
            stdr= db.selectCashType(stdr);
            // show Cash Type
            LabCashTypeVal.Text = stdr.CASH_TYPE1;

            dr.EDU_YEAR = CoboYear.Text;
            dr.STUDENT_ID = TxtStudID.Text;
            dr.CASH_TITLE = LabCashTypeVal.Text;
            dr.CASH_DATE =cashDate.Text ;
            dr.ACCOUNT_NO = txtAccNoVal.Text;
            dr.AMOUNT = Convert.ToInt64(TxtAmountVal.Text);
            dr.CRT_DT_TM = "";
            dr.CRT_USER_ID = "";
            dr.UPD_DT_TM = "";
            dr.UPD_USER_ID = "";
            dr.DEF_FLG = 0;

            db.insertStuCash(dr);
           
        }
    }
}