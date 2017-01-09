using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;
using HomeASP.DbAccess;

namespace HomeASP
{
    public partial class SMS016 : System.Web.UI.Page
    {
        string msg;
        StudentCashInfoService stuCashService = new StudentCashInfoService();
        DsPSMS.ST_STUDENT_CASHDataTable stuCashDt = new DsPSMS.ST_STUDENT_CASHDataTable();
        DsPSMS.ST_STUDENT_CASHRow stuCashDr = new DsPSMS.ST_STUDENT_CASHDataTable().NewST_STUDENT_CASHRow();
        DsPSMS.ST_STUDENT_DATADataTable stuDataDt = new DsPSMS.ST_STUDENT_DATADataTable();
        DsPSMS.ST_STUDENT_DATARow stuDataDr = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow(); 

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
            Session["CASH_DATE"] = cashList.SelectedRow.Cells[4].Text;
            Session["STUDENT_ID"] = cashList.SelectedRow.Cells[2].Text; 
            Response.Redirect("SMS015_StudentCashInfo.aspx");
        }

        protected void CoboSelect_Change(object sender, EventArgs e)
        {
            if (TxtStudID.Text.Trim().Length != 0)
            {
                stuDataDr.STUDENT_ID = TxtStudID.Text;
                stuCashDr.STUDENT_ID = TxtStudID.Text;
                stuDataDr.EDU_YEAR = CoboYear.Text;
                stuCashDr.EDU_YEAR = CoboYear.Text;
                stuDataDr = stuCashService.getStuName(stuDataDr);
                if (stuDataDr != null)
                    LabStuNameVal.Text = stuDataDr.STUDENT_NAME;
                showOneCashData(stuCashDr);
            }
        }

        protected void showOneCashData(DsPSMS.ST_STUDENT_CASHRow dr)
        {
            stuCashDt = stuCashService.getCashData(dr,out msg);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            stuCashDt.Columns.Remove(stuCashDt.Columns[7]);
            cashList.DataSource = stuCashDt;
            cashList.DataBind();
        }

        protected void search_Click(object sender, EventArgs e)
        {
            if (CoboYear.Text.Trim().Length != 0 && TxtStudID.Text.Trim().Length != 0)
            {
                stuDataDr.STUDENT_ID = TxtStudID.Text;
                stuCashDr.STUDENT_ID = TxtStudID.Text;
                stuDataDr.EDU_YEAR = CoboYear.Text;
                stuCashDr.EDU_YEAR = CoboYear.Text;
                stuDataDr = stuCashService.getStuName(stuDataDr);
                if (stuDataDr != null)
                {
                    LabStuNameVal.Text = stuDataDr.STUDENT_NAME;
                    showOneCashData(stuCashDr);
                }
            }
        }
    }
}