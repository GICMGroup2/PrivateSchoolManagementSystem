using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.DbAccess;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS027 : System.Web.UI.Page
    {
        string msg = "";
        string userId = "";
        DsPSMS.ST_EXP_HEDDataTable ExpHedDt = new DsPSMS.ST_EXP_HEDDataTable();
        DsPSMS.ST_EXP_HEDRow expHedDr = new DsPSMS.ST_EXP_HEDDataTable().NewST_EXP_HEDRow();
        ExpanseService expService = new ExpanseService();

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

            showExpHedGv();
            if (Session["USER_ID"] != null)
            {
                userId = (string)(Session["USER_ID"] ?? "  ");
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter textWriter)
        {
            foreach (GridViewRow gvRow in expHedList.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    gvRow.Attributes["onmouseover"] =
                       "this.style.cursor='hand';";
                    gvRow.Attributes["onmouseout"] =
                       "this.style.textDecoration='none';";
                    gvRow.Attributes["onclick"] =
                     ClientScript.GetPostBackClientHyperlink(expHedList, "Select$" + gvRow.RowIndex, true);
                }
            }
            base.Render(textWriter);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (CoboYear.Text.Trim().Length != 0)
            {
                expHedDr.EDU_YEAR = CoboYear.Text;
                if (TxtExpTitle.Text.Trim().Length != 0)
                {
                    expHedDr.EXP_TITLE = TxtExpTitle.Text;
                    if (cashDate.Text.Trim().Length != 0)
                    {
                        expHedDr.EXP_DATE = cashDate.Text;
                        expHedDr.REMARK = TxtRe.Text;
                        expHedDr.CRT_DT_TM = DateTime.Now;
                        expHedDr.CRT_USER_ID = this.userId;
                        expHedDr.UPD_DT_TM = DateTime.Now;
                        expHedDr.UPD_USER_ID = "";
                        expHedDr.DEL_FLG = 0;

                        expService.SaveExpHedInfo(expHedDr, out msg);
                        showExpHedGv();
                    }
                    else
                    {
                        errDatee.Text = "Please choose the date";
                    }
                }
                else
                {
                    errTitle.Text = "please enter expense title";
                }
            }
            else
            {
                erryear.Text = "please choose the year";
            }
        }

        protected void viewDetail_Click(object sender, EventArgs e)
        {
            //Session["EDU_YEAR"] = 
            Session["EXP_ID"] = expHedList.SelectedRow.Cells[1].Text;
            Response.Redirect("SMS029_ExpenseDetail.aspx");
        }

        protected void showExpHedGv()
        {
            ExpHedDt = expService.getExpHedAllData(out msg);
            if (ExpHedDt != null && ExpHedDt.Rows.Count != 0)
            {
                //ExpHedDt.Columns.Remove(ExpHedDt.Columns[0]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[6]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[6]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[6]);
                ExpHedDt.Columns.Remove(ExpHedDt.Columns[6]);
                expHedList.DataSource = ExpHedDt;
                expHedList.DataBind();
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            BtnPay.Enabled = false;
            if (expHedList.SelectedIndex < 0)
            {
                errEgd.Text = "Please select a record that you want to edit";
            }
            else
            {
                CoboYear.Text = expHedList.SelectedRow.Cells[0].Text;
                TxtExpTitle.Text = expHedList.SelectedRow.Cells[2].Text;
                cashDate.Text = expHedList.SelectedRow.Cells[3].Text;
                TxtRe.Text = expHedList.SelectedRow.Cells[4].Text;
                
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            expHedDr.EXP_ID = Convert.ToInt16(expHedList.SelectedRow.Cells[1].Text);
            expHedDr.EDU_YEAR = CoboYear.Text;
            expHedDr.EXP_TITLE = TxtExpTitle.Text;
            expHedDr.EXP_DATE = cashDate.Text;
            expHedDr.REMARK = TxtRe.Text;
            expHedDr.UPD_DT_TM = DateTime.Now;
            expHedDr.UPD_USER_ID = this.userId;
            // to write for confirm message
            expService.updateExpHedInfo(expHedDr, out msg);
            showExpHedGv();

            BtnPay.Enabled = true;
            CoboYear.Text = "";
            TxtExpTitle.Text = "";
            TxtRe.Text = "";
            cashDate.Text = "";
        }
        protected void delete_Click(object sender, EventArgs e)
        {
            expHedDr.EXP_ID = Convert.ToInt16(expHedList.SelectedRow.Cells[1].Text);
            expHedDr.CRT_DT_TM = Convert.ToDateTime(expHedList.SelectedRow.Cells[5].Text);
            // to write for confirm message
            expService.deleteExpHed(expHedDr, out msg);
        }
    }
}