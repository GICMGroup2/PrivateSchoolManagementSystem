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
        string userId = "";
        EquipmentService equipService = new EquipmentService();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable equipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();

            showGd();   // binding data to datagridview

            // binding Equipment name to combo box
           /* CoboEquipName.DataSource = null;
            CoboEquipName.Items.Clear();
            CoboEquipName.Items.Add(new ListItem("     ", "    "));
            CoboEquipName.SelectedIndex = 0;*/
            if (!IsPostBack)
            {
                equipMstDt = equipService.getAllEquipMST(out msg);

                if (equipMstDt != null && equipMstDt.Rows.Count != 0)
                {
                    CoboEquipName.DataSource = equipMstDt;
                    CoboEquipName.DataTextField = "EQUIPMENT_NAME";
                    CoboEquipName.DataValueField = "EQUIPMENT_ID";
                    CoboEquipName.DataBind();
                }
            }
            if (Session["USER_ID"] != null)
            {
                userId = (string)(Session["USER_ID"] ?? "  ");
            }
        }

        protected void showGd()
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable equipDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            //binding Equipment data to datagridview
            equipDt = equipService.getAllEquipData(out msg);
            if (equipDt != null && equipDt.Rows.Count != 0)
            {
                equipDt.Columns.Remove(equipDt.Columns[7]);
                equipDt.Columns.Remove(equipDt.Columns[7]);
                equipDt.Columns.Remove(equipDt.Columns[7]);
                equipDt.Columns.Remove(equipDt.Columns[7]);
                equipDt.Columns.Remove(equipDt.Columns[7]);
                EqpList.DataSource = equipDt;
                EqpList.DataBind();
            }
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

            if (CoboYear.Text.Trim().Length != 0)
            {
                equipMstDr.EDU_YEAR = CoboYear.Text;
                if (TxtEquipID.Text.Trim().Length != 0)
                {
                    equipMstDr.EQUIPMENT_ID = TxtEquipID.Text;
                    if (TxtEqpName.Text.Trim().Length != 0)
                    {
                        equipMstDr.EQUIPMENT_NAME = TxtEqpName.Text;
                        equipMstDr.CRT_DT_TM = DateTime.Now;
                        equipMstDr.CRT_USER_ID = this.userId;
                        equipMstDr.UPD_DT_TM = DateTime.Now;
                        equipMstDr.UPD_USER_ID = "";

                        equipService.SaveEquipmentMST(equipMstDr, out msg);
                    }
                    else
                    {
                        errName.Text = "Please Equipment Name";
                    }
                }
                else
                {
                    errid.Text = "Enter Equipment ID";
                }
            }
            else
            {
                errYY.Text = "Please choose the year";
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_DATADataTable equipDt = new DsPSMS.ST_EQUIPMENT_DATADataTable();
            DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();

            if (CoboYear1.Text.Trim().Length != 0)
            {
                equipDr.EDU_YEAR = CoboYear1.Text;
                if (CoboEquipName.Text.Trim().Length != 0)
                {
                    equipDr.EQUIPMENT_ID = CoboEquipName.Text;
                    if (EqpDate.Text.Trim().Length != 0)
                    {
                        equipDr.DATE = Convert.ToDateTime(EqpDate.Text);
                        if (TxtQty.Text.Trim().Length != 0)
                        {
                            equipDr.QUANTITY = TxtQty.Text;
                            equipDr.TYPE = TxtType.Text;
                            equipDr.REMARK = TxtRemark.Text;
                            equipDr.CRT_DT_TM = DateTime.Now;
                            equipDr.CRT_USER_ID = this.userId;
                            equipDr.UPD_DT_TM = DateTime.Now;
                            equipDr.UPD_USER_ID = "";

                            equipService.SaveEquipmentData(equipDr, out msg);
                            showGd();
                        }
                        else
                        {
                            errQty.Text = "Please Enter the quantity";
                        }
                    }
                    else
                    {
                        errDate.Text = "Please choose the date";
                    }
                }
                else
                {
                    errEqN.Text = "Please choose Equipment Name";
                }
            }
            else
            {
                errYear.Text = "Please choose the year";
            }
            // EqmMstEntPannel.Visible = true;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            BtnConfirm.Enabled = true;
            if (EqpList.SelectedIndex < 0)
            {
                errgrid.Text = "Please select the record that you want to edit";
            }
            else
            {
                if (EqpList.SelectedRow.Cells[0].Text.Trim().Length != 0)
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
            if (CoboYear1.Text.Trim().Length != 0)
            {
                equipDr.EDU_YEAR = CoboYear1.Text;
                equipDr.ID = Convert.ToInt32(EqpList.SelectedRow.Cells[1].Text);
                if (CoboEquipName.Text.Trim().Length != 0)
                {
                    equipDr.EQUIPMENT_ID = CoboEquipName.Text;
                    if (EqpDate.Text.Trim().Length != 0)
                    {
                        equipDr.DATE = Convert.ToDateTime(EqpDate.Text);
                        if (TxtQty.Text.Trim().Length != 0)
                        {
                            equipDr.QUANTITY = TxtQty.Text;
                            equipDr.TYPE = TxtType.Text;
                            equipDr.REMARK = TxtRemark.Text;
                            equipDr.UPD_DT_TM = DateTime.Now;
                            equipDr.UPD_USER_ID = this.userId;

                            equipService.editEquipmentData(equipDr, out msg);
                            showGd();

                            // CoboEquipName.Text = "";
                            CoboYear1.Text = "";
                            EqpDate.Text = "";
                            TxtQty.Text = "";
                            TxtType.Text = "";
                            TxtRemark.Text = "";
                        }
                        else
                        {
                            errQty.Text = "Please Enter the quantity";
                        }
                    }
                    else
                    {
                        errDate.Text = "Please choose the date";
                    }
                }
                else
                {
                    errEqN.Text = "Please choose Equipment Name";
                }
            }
            else
            {
                errYear.Text = "Please choose the year";
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
           
            DsPSMS.ST_EQUIPMENT_DATARow equipDr = new DsPSMS.ST_EQUIPMENT_DATADataTable().NewST_EQUIPMENT_DATARow();
            if (EqpList.SelectedIndex < 0)
            {
                errgrid.Text = "Please select the record that you want to delete";
            }
            else
            {
                equipDr.ID = Convert.ToInt32(EqpList.SelectedRow.Cells[1].Text);
                //to write for confirm message
                equipService.removeEquipmentData(equipDr, out msg);
                DataTable ds = new DataTable();
                ds = null;
                EqpList.DataSource = ds;
                EqpList.DataBind();

                showGd();
            }
        }

        protected void removeErrorMsg(object sender, EventArgs e)
        {
            errQty.Visible = false ;
        }

    }
}