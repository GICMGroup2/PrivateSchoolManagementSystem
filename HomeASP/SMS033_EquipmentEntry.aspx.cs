using System;
using System.Data;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS033 : System.Web.UI.Page
    {
        string msg;
        EquipmentService equipService = new EquipmentService();
        DsPSMS.ST_EQUIPMENT_MSTDataTable equipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
        DsPSMS.ST_EQUIPMENT_MSTRow equipMstDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();
        DsPSMS.ST_EQUIPMENT_DATADataTable equipDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
        DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();

        protected void Page_Load(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable equipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            
            showGd();   // binding data to datagridview
           
            // binding Equipment name to combo box
            equipMstDt = equipService.getAllEquipMST();
            if (equipMstDt.Rows.Count != 0)
            {
                CoboEquipName.DataSource = null;
                CoboEquipName.Items.Clear();
                CoboEquipName.Items.Add(new ListItem("     ", "    "));
                CoboEquipName.SelectedIndex = 0;
                CoboEquipName.DataSource = equipMstDt;
                CoboEquipName.DataTextField = "EQUIPMENT_NAME";
                CoboEquipName.DataValueField = "EQUIPMENT_ID";
                CoboEquipName.DataBind();
            }
        }

        protected void showGd()
        {
            //binding Equipment data to datagridview
            equipDt = equipService.getAllEquipData();
            equipDt.Columns.Remove(equipDt.Columns[7]);
            equipDt.Columns.Remove(equipDt.Columns[7]);
            equipDt.Columns.Remove(equipDt.Columns[7]);
            equipDt.Columns.Remove(equipDt.Columns[7]);
            equipDt.Columns.Remove(equipDt.Columns[7]);
            EqpList.DataSource = equipDt;
            EqpList.DataBind();
            // EqpList.Columns.[1].Visible = false;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter textWriter)
        {
            foreach (GridViewRow gvRow in EqpList.Rows)
            {
                if (gvRow.RowType == DataControlRowType.DataRow)
                {
                    gvRow.Attributes["onmouseover"] =
                       "this.style.cursor='hand';";
                    gvRow.Attributes["onmouseout"] =
                       "this.style.textDecoration='none';";
                    gvRow.Attributes["onclick"] =
                     ClientScript.GetPostBackClientHyperlink(EqpList, "Select$" + gvRow.RowIndex, true);
                }
            }
            base.Render(textWriter);
        }

        protected void save_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable equipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_EQUIPMENT_MSTRow equipMstDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();

            equipMstDr.EDU_YEAR = CoboYear.Text;
            equipMstDr.EQUIPMENT_ID = TxtEquipID.Text;
            equipMstDr.EQUIPMENT_NAME = TxtEqpName.Text;
            equipMstDr.CRT_DT_TM = DateTime.Now;
            equipMstDr.CRT_USER_ID = "";
            equipMstDr.UPD_DT_TM = DateTime.Now;
            equipMstDr.UPD_USER_ID = "";

            equipService.SaveEquipmentMST(equipMstDr, out msg);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable equipDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();

            equipDr.EDU_YEAR = CoboYear1.Text;
            equipDr.EQUIPMENT_ID = CoboEquipName.Text;
            equipDr.DATE = Convert.ToDateTime(EqpDate.Text);
            equipDr.QUANTITY = TxtQty.Text;
            equipDr.TYPE = TxtType.Text;
            equipDr.REMARK = TxtRemark.Text;
            equipDr.CRT_DT_TM = DateTime.Now;
            equipDr.CRT_USER_ID = "";
            equipDr.UPD_DT_TM = DateTime.Now;
            equipDr.UPD_USER_ID = "";

            equipService.SaveEquipmentData(equipDr, out msg);
            showGd();
           // EqmMstEntPannel.Visible = true;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (EqpList.SelectedIndex < 0)
            {

            }
            else
            {
                if (EqpList.SelectedRow.Cells[0].Text.Trim().Length!=0)
                    CoboYear1.Text = EqpList.SelectedRow.Cells[0].Text;
                if (EqpList.SelectedRow.Cells[2].Text.Trim().Length != 0)
                    CoboEquipName.Text = EqpList.SelectedRow.Cells[2].Text;
                if (EqpList.SelectedRow.Cells[3].Text.Trim().Length != 0)
                    EqpDate.Text = EqpList.SelectedRow.Cells[3].Text;
                if (EqpList.SelectedRow.Cells[4].Text.Trim().Length != 0) 
                    TxtQty.Text = EqpList.SelectedRow.Cells[4].Text;
                if (EqpList.SelectedRow.Cells[5].Text != "&nbsp;")
                    TxtType.Text = EqpList.SelectedRow.Cells[5].Text;
                if (EqpList.SelectedRow.Cells[6].Text != "&nbsp;")
                    TxtRemark.Text = EqpList.SelectedRow.Cells[6].Text;
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();
            equipDr.EDU_YEAR = CoboYear1.Text;
            equipDr.ID = Convert.ToInt32(EqpList.SelectedRow.Cells[1].Text);
            equipDr.EQUIPMENT_ID = CoboEquipName.Text;
            equipDr.DATE = Convert.ToDateTime(EqpDate.Text);
            equipDr.QUANTITY = TxtQty.Text;
            equipDr.TYPE = TxtType.Text;
            equipDr.REMARK = TxtRemark.Text;
            //equipDr.CRT_DT_TM = DateTime.Now;
            //equipDr.CRT_USER_ID = "";
            equipDr.UPD_DT_TM = DateTime.Now;
            equipDr.UPD_USER_ID = "";

            equipService.editEquipmentData(equipDr, out msg);
            showGd();

           // CoboEquipName.Text = "";
            CoboYear1.Text = "";
            EqpDate.Text = "";
            TxtQty.Text = "";
            TxtType.Text = "";
            TxtRemark.Text = "";
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();
            if (EqpList.SelectedIndex < 0)
            {

            }
            else
            {
                equipDr.ID = Convert.ToInt32(EqpList.SelectedRow.Cells[1].Text);

                equipService.removeEquipmentData(equipDr, out msg);
                DataTable ds = new DataTable();
                ds = null;
                EqpList.DataSource = ds;
                EqpList.DataBind();

                showGd();
            }
        }
    }
}