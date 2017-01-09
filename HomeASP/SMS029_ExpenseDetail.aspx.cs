using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS029 : System.Web.UI.Page
    {
       
        DsPSMS.ST_EXP_DETAILRow expDetDr = new DsPSMS.ST_EXP_DETAILDataTable().NewST_EXP_DETAILRow();
        ExpanseService expService = new ExpanseService();
        string msg = "";
        string subTitle;
        string amount;

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


            if (Session["EXP_ID"] != null)
            {
                LblExpIdVal.Text = (string)(Session["EXP_ID"] ?? "  ");
            }
            showExpHedGv();
        }

        protected override void Render(System.Web.UI.HtmlTextWriter textWriter)
        {
            foreach (GridViewRow gvRow in expDetList.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    gvRow.Attributes["onmouseover"] =
                       "this.style.cursor='hand';";
                    gvRow.Attributes["onmouseout"] =
                       "this.style.textDecoration='none';";
                    gvRow.Attributes["onclick"] =
                     ClientScript.GetPostBackClientHyperlink(expDetList, "Select$" + gvRow.RowIndex, true);
                }
            }
            base.Render(textWriter);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
         
            expDetDr.EXP_ID = Convert.ToInt32(LblExpIdVal.Text);
            expDetDr.EXP_SUB_TITLE = TxtExpSubTitle.Text;
            expDetDr.AMOUNT = TxtAmt.Text;
            expDetDr.CRT_DT_TM = DateTime.Now;
            expDetDr.CRT_USER_ID = "";
            expDetDr.UPD_DT_TM = "";
            expDetDr.UPD_USER_ID = "";
            expDetDr.DEL_FLG = 0;

            expService.SaveExpDetInfo(expDetDr, out msg);

            DataTable ds = new DataTable();
            ds = null;
            expDetList.DataSource = ds;
            expDetList.DataBind();

            showExpHedGv();
        }

        protected void viewDetail_Click(object sender, EventArgs e)
        {

        }

        protected void showExpHedGv()
        {
            DsPSMS.ST_EXP_DETAILDataTable expDetDt = new DsPSMS.ST_EXP_DETAILDataTable();

            int expId = Convert.ToInt32(LblExpIdVal.Text);
            expDetDt = expService.getExpDetData(expId);
            //expDetDt.Columns.Remove(expDetDt.Columns[0]);
            expDetDt.Columns.Remove(expDetDt.Columns[4]);
            expDetDt.Columns.Remove(expDetDt.Columns[4]);
            expDetDt.Columns.Remove(expDetDt.Columns[4]);
            expDetDt.Columns.Remove(expDetDt.Columns[4]);
            expDetList.DataSource = expDetDt;
            expDetList.DataBind();

        }

        protected void delete_Click(object sender, EventArgs e)
        {
            if (expDetList.SelectedIndex < 0)
            {

            }
            else
            {
                expDetDr.EXP_ID = Convert.ToInt32(expDetList.SelectedRow.Cells[0].Text);
                expDetDr.EXP_SUB_TITLE = expDetList.SelectedRow.Cells[1].Text;
                expDetDr.AMOUNT = expDetList.SelectedRow.Cells[2].Text;
                expDetDr.CRT_DT_TM = Convert.ToDateTime(expDetList.SelectedRow.Cells[3].Text);
                expService.deleteExpDet(expDetDr);

                DataTable ds = new DataTable();
                ds = null;
                expDetList.DataSource = ds;
                expDetList.DataBind();

                showExpHedGv();
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            BtnPay.Enabled = false;
            if (expDetList.SelectedIndex < 0)
            {

            }
            else
            {
                LblExpIdVal.Text = expDetList.SelectedRow.Cells[0].Text;
                TxtExpSubTitle.Text = expDetList.SelectedRow.Cells[1].Text;
                TxtAmt.Text = expDetList.SelectedRow.Cells[2].Text;
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            expDetDr.EXP_ID =Convert.ToInt32(LblExpIdVal.Text);
            expDetDr.EXP_SUB_TITLE = TxtExpSubTitle.Text;
            expDetDr.AMOUNT = TxtAmt.Text;
            expDetDr.CRT_DT_TM = Convert.ToDateTime(expDetList.SelectedRow.Cells[3].Text);
            expService.updateExpDetInfo(expDetDr, out msg);
            showExpHedGv();

            BtnPay.Enabled = true;
            CoboYear.Text = "";
            TxtExpSubTitle.Text = "";
            TxtAmt.Text = "";
        }


    }
}