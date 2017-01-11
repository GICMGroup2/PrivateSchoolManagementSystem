using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.DataSet;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS033 : System.Web.UI.Page
    {
        string msg;
        EquipmentService equipService = new EquipmentService(); 

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_EQUIPMENT_MSTDataTable equipMstDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_EQUIPMENT_MSTRow equipMstDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();

            equipMstDr.EDU_YEAR = CoboYear.Text;
            equipMstDr.EQUIPMENT_ID = TxtEquipID.Text;
            equipMstDr.EQUIPMENT_NAME = TxtEquipName.Text;
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

            //equipDr.EDU_YEAR = CoboYear1.Text;
            //equipDr.EQUIPMENT_ID = TxtEquipName.Text;
            //equipDr.DATE = Convert.ToDateTime(EqpDate.Text);
            //equipDr.QUANTITY = TxtQty.Text;
            //equipDr.TYPE= TxtType.Text;
            //equipDr.REMARK = TxtRemark.Text;
            //equipDr.CRT_DT_TM = DateTime.Now;
            //equipDr.CRT_USER_ID = "";
            //equipDr.UPD_DT_TM = DateTime.Now;
            //equipDr.UPD_USER_ID = "";

            //equipService.SaveEquipmentData(equipDr,out msg);

            EqmMstEntPannel.Visible = true;
        }
    }
}