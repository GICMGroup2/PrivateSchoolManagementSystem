using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;

namespace HomeASP
{
    public partial class SMS016 : System.Web.UI.Page
    {
        StudentCashInfoService stuCashService = new StudentCashInfoService();
        DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            stuCashDt=stuCashService.getCashAllData();
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            cashList.DataSource = stuCashDt;
            cashList.DataBind();
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtShow.Text = cashList.SelectedRow.Cells[2].Text;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter textWriter)
        {
            foreach (GridViewRow gvRow in cashList.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    gvRow.Attributes["onmouseover"] =
                       "this.style.cursor='hand';";
                    gvRow.Attributes["onmouseout"] =
                       "this.style.textDecoration='none';";
                    gvRow.Attributes["onclick"] =
                     ClientScript.GetPostBackClientHyperlink(cashList, "Select$" + gvRow.RowIndex, true);
                }
            }
            base.Render(textWriter);
        }

        protected void viewDetail_Click(object sender, EventArgs e)
        {
            //txtShow.Text = cashList.SelectedRow.Cells[2].Text;

            Session["EDU_YEAR"] = cashList.SelectedRow.Cells[0].Text;
            Session["CASH_ID"] = cashList.SelectedRow.Cells[1].Text;
            Session["STUDENT_ID"] = cashList.SelectedRow.Cells[2].Text;// insert name into session
            Response.Redirect("SMS015_StudentCashInfo.aspx");
        }
    }
}