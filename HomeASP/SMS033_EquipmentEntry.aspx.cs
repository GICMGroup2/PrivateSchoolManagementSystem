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
            DsPSMS.ST_EQUIPMENT_MSTDataTable equipDt = new DsPSMS.ST_EQUIPMENT_MSTDataTable();
            DsPSMS.ST_EQUIPMENT_MSTRow equipDr = new DsPSMS.ST_EQUIPMENT_MSTDataTable().NewST_EQUIPMENT_MSTRow();

            equipDr.EDU_YEAR = CoboYear.Text;
            equipDr.EQUIPMENT_ID = TxtEquipID.Text;
            equipDr.EQUIPMENT_NAME = TxtEquipName.Text;
            equipDr.CRT_DT_TM = DateTime.Now;
            equipDr.CRT_USER_ID = "";
            equipDr.UPD_DT_TM = DateTime.Now;
            equipDr.UPD_USER_ID = "";

            equipService.SaveEquipmentMST(equipDr, out msg);
        }
    }
}