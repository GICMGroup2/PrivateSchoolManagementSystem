using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP
{
    public partial class SMS015 : System.Web.UI.Page
    {
        string msg = "";
        GradeSubjectDb grdDb = new GradeSubjectDb();

        StudentCashInfoService stuCashService = new StudentCashInfoService();
        StudentCashInfoDb stuCashDb = new StudentCashInfoDb();
        GradeSubjectService grdSubService = new GradeSubjectService();
        
        DsPSMS.ST_STUDENT_DATARow stDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
        DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
        DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
        DsPSMS.ST_GRADE_MSTDataTable grdDt = new DsPSMS.ST_GRADE_MSTDataTable();
        DsPSMS.ST_GRADE_MSTRow grdDr = new DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();

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

                if (Session["EDU_YEAR"] != null)
                {
                    CoboYear.Text = (string)(Session["EDU_YEAR"] ?? "  ");
                    stDr.EDU_YEAR = CoboYear.Text;
                    Session["EDU_YEAR"] = null;
                }
                if (Session["STUDENT_ID"] != null)
                {
                    TxtStudID.Text = (string)(Session["STUDENT_ID"] ?? "  ");
                    stDr.STUDENT_ID = TxtStudID.Text;
                    stDr = stuCashService.getStuName(stDr);
                    TxtStuName.Text = stDr.STUDENT_NAME;
                    grdDr = stuCashService.getGradeName(stDr.GRADE_ID);
                   // CoboGrade.Text = grdDr.GRADE_NAME;
                    CoboGrade.SelectedItem.Text = stDr.GRADE_ID;
                   
                    CoboSelect_Change(sender,e);
                    Session["STUDENT_ID"] = null;
                }
                if (Session["CASH_DATE"] != null)
                {
                    cashDate.Text = (string)(Session["CASH_DATE"] ?? "  ");
                    Session["CASH_DATE"] = null;
                }

                // binding grade to combo box
                grdDt = grdSubService.getAllGradeData(out msg);
                if (grdDt.Rows.Count != 0)
                {
                    CoboGrade.DataSource = null;
                    CoboGrade.DataSource = grdDt;
                    CoboGrade.DataTextField = "GRADE_NAME";
                    CoboGrade.DataValueField = "GRADE_ID";
                    CoboGrade.DataBind();
                }
                
        }

        protected void BtnPay_Click(object sender, EventArgs e)
        {
            stuCashDr.EDU_YEAR = CoboYear.Text;
            stuCashDr.STUDENT_ID = TxtStudID.Text;
            stuCashDr.CASH_TITLE = LabCashTypeVal.Text;
            stuCashDr.CASH_DATE = cashDate.Text;
            stuCashDr.ACCOUNT_NO = txtAccNoVal.Text;
            stuCashDr.AMOUNT = Convert.ToInt64(TxtAmountVal.Text);
            stuCashDr.CRT_DT_TM = "";
            stuCashDr.CRT_USER_ID = "";
            stuCashDr.UPD_DT_TM = "";
            stuCashDr.UPD_USER_ID = "";
            stuCashDr.DEL_FLG = 0;

            stuCashService.SaveStudentCashInfo(stuCashDr, out msg);

            calculation();
           // Response.Write("<script>alert('login successful');</script>");
        }

        protected void CoboSelect_Change(object sender, EventArgs e)
        {
            if(TxtStudID.Text.Trim().Length!=0 && TxtStuName.Text.Trim().Length!=0 &&  CoboGrade.SelectedItem.Text.Trim().Length !=0 && CoboYear.Text.Trim().Length!=0)
            {
                
                // select Cash Type
                stDr.EDU_YEAR = CoboYear.Text;
                stDr.STUDENT_ID = TxtStudID.Text;
                stDr.STUDENT_NAME = TxtStuName.Text;
                stDr.GRADE_ID = calculation();
                stDr = stuCashService.getCashType(stDr,out msg);

                // show Cash Type
                if(stDr!=null)
                   LabCashTypeVal.Text = stDr.CASH_TYPE1;
            }
        }

        public string calculation()
        {
            int totalPaid = 0;
            string gradeId = "";

           // select GRADE_ID and CASH_AMOUNT
            grdDr.GRADE_ID = CoboGrade.SelectedItem.Text;
            grdDt = grdSubService.selectGradeByID(grdDr,out msg);   

            //get cash data and calculate paid amount
            stuCashDr.STUDENT_ID = TxtStudID.Text;
            stuCashDr.EDU_YEAR = CoboYear.Text;
            stuCashDt = stuCashService.getCashData(stuCashDr, out msg);
            for (int i = 0; i < stuCashDt.Rows.Count; i++)
            {
                totalPaid += Convert.ToInt32(stuCashDt[i].AMOUNT);
            }
            gradeId = grdDt[0].GRADE_ID;
           // gradeId = CoboGrade.Text;
            LabMonVal.Text = "10 months";
            LabKyatVal.Text = grdDt[0].MONTHLY_FEE;
            LabPaidVal.Text = Convert.ToString(totalPaid);
            LabRemainVal.Text = Convert.ToString((10 * Convert.ToInt32(LabKyatVal.Text)) - totalPaid);

            return gradeId;
        }
    }
}