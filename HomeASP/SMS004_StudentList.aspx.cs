using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.DataSet;


namespace HomeASP
{
    public partial class SMS004 : System.Web.UI.Page
    {
        StudentInfoService stuentry = new StudentInfoService();
       // DsPSMS.ST_STUDENT_DATADataTable show = new DsPSMS.ST_STUDENT_DATADataTable();
        string userid = "";
        string msg;

    protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";


            showgrid();
            
           
        }

    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow gvrow in GridView1.Rows)
        {
            if (gvrow.RowType == DataControlRowType.DataRow)
            {
                gvrow.Attributes["onmouseover"] = "this.style.cursor='hand';";
                gvrow.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                gvrow.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + gvrow.RowIndex, true);
            }
        }
        base.Render(writer);
    }

    protected void showGridData(DsPSMS.ST_STUDENT_DATARow dr)
    {
        DsPSMS.ST_STUDENT_DATADataTable studata = new DsPSMS.ST_STUDENT_DATADataTable();
        studata = stuentry.getAllData(out msg);
        GridView1.DataSource = studata;
        GridView1.DataBind();
    }

   protected void btnSearch_Click(object sender, EventArgs e)
    {
        
        DsPSMS.ST_STUDENT_DATARow studata = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
        if (checkValidation())
        {
            string gradeid = stulistgrade.SelectedItem.Value;

            string eduyearid = comboYear.SelectedItem.Value;

            DsPSMS.ST_STUDENT_DATADataTable studentData = stuentry.searchgradeyear(gradeid, eduyearid);
            if (studentData != null)
            {
                displayGrid(studentData);
            }
            else
            {
                GridView1.Visible = false;
                errorSeach.Visible = true;
                errorSeach.Text = "There is no data";
            }
    
        }
    }

    public bool checkValidation()
    {
        bool check = true;
        if (stulistgrade.SelectedIndex == 0)
        {
            errgrade.Visible = true;
            check = false;
        }
        else
        {
            errgrade.Visible=false;
        }
        if(comboYear.SelectedIndex == 0)
        {
            erreducation.Visible = true;
            check=false;
        }
        else
        {
            erreducation.Visible=false;
        }
        return check;
    }

    

    protected void btnDetail_Click(object sender, EventArgs e)
        {
           
            if (GridView1.SelectedIndex < 0)
            { showerror.Text = "Please select the row that you want to view"; }
            else
            {
                Session["EDU_YEAR"] = GridView1.SelectedRow.Cells[0].Text;
                Session["STUDENT_ID"] = GridView1.SelectedRow.Cells[1].Text;
                Session["STUDENT_NAME"] = GridView1.SelectedRow.Cells[2].Text;
                Session["ROLL_NO"] = GridView1.SelectedRow.Cells[3].Text;
                Session["GENDER"] = GridView1.SelectedRow.Cells[4].Text;
                Session["PHOTO_PATH"] = GridView1.SelectedRow.Cells[5].Text;
                Session["DOB"] = GridView1.SelectedRow.Cells[6].Text;
                Session["PHONE"] = GridView1.SelectedRow.Cells[7].Text;
                Session["NRC_NO"] = GridView1.SelectedRow.Cells[8].Text;
                Session["PASSWORD"] = GridView1.SelectedRow.Cells[9].Text;
                Session["GRADE_ID"] = GridView1.SelectedRow.Cells[10].Text;
                Session["ROOM_ID"] = GridView1.SelectedRow.Cells[11].Text;
                Session["CASH_TYPE1"] = GridView1.SelectedRow.Cells[12].Text;
                Session["CASH_TYPE2"] = GridView1.SelectedRow.Cells[13].Text;
                Session["FATHER_NAME"] = GridView1.SelectedRow.Cells[14].Text;
                Session["MOTHER_NAME"] = GridView1.SelectedRow.Cells[15].Text;
                Session["ADDRESS"] = GridView1.SelectedRow.Cells[16].Text;
                Session["CONTACT_PHONE"] = GridView1.SelectedRow.Cells[17].Text;
                Session["EMAIL"] = GridView1.SelectedRow.Cells[18].Text;

                Response.Redirect("SMS005_StudentDetail.aspx");
            }
              
        }

       

        // go to Student Entry for updating
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex < 0)
            { showerror.Text = "Please select the row that you want to view"; }
            else
            {
                Session["EDU_YEAR"] = GridView1.SelectedRow.Cells[0].Text;
                Session["STUDENT_ID"] = GridView1.SelectedRow.Cells[1].Text;
                Session["STUDENT_NAME"] = GridView1.SelectedRow.Cells[2].Text;
                Session["ROLL_NO"] = GridView1.SelectedRow.Cells[3].Text;
                Session["GENDER"] = GridView1.SelectedRow.Cells[4].Text;
                Session["PHOTO_PATH"] = GridView1.SelectedRow.Cells[5].Text;
                Session["DOB"] = GridView1.SelectedRow.Cells[6].Text;
                Session["PHONE"] = GridView1.SelectedRow.Cells[7].Text;
                Session["NRC_NO"] = GridView1.SelectedRow.Cells[8].Text;
                Session["PASSWORD"] = GridView1.SelectedRow.Cells[9].Text;
                Session["GRADE_ID"] = GridView1.SelectedRow.Cells[10].Text;
                Session["ROOM_ID"] = GridView1.SelectedRow.Cells[11].Text;
                Session["CASH_TYPE1"] = GridView1.SelectedRow.Cells[12].Text;
                Session["CASH_TYPE2"] = GridView1.SelectedRow.Cells[13].Text;
                Session["FATHER_NAME"] = GridView1.SelectedRow.Cells[14].Text;
                Session["MOTHER_NAME"] = GridView1.SelectedRow.Cells[15].Text;
                Session["ADDRESS"] = GridView1.SelectedRow.Cells[16].Text;
                Session["CONTACT_PHONE"] = GridView1.SelectedRow.Cells[17].Text;
                Session["EMAIL"] = GridView1.SelectedRow.Cells[18].Text;

                Response.Redirect("SMS003_StudentEntry.aspx");
            }
            
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DsPSMS.ST_STUDENT_DATARow sturowdelete = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (GridView1.SelectedIndex < 0)
            {
                showerror.Text = "Please select the record that you want to delete";
            }
            else
            {
                sturowdelete.STUDENT_ID = GridView1.SelectedRow.Cells[1].Text;

                stuentry.removedata(sturowdelete, out msg);
                DataTable ds = new DataTable();
                ds = null;
                GridView1.DataSource = ds;
                GridView1.DataBind();
                showgrid();
            }
          }

        protected void showgrid()
        {
            DsPSMS.ST_STUDENT_DATADataTable show = new DsPSMS.ST_STUDENT_DATADataTable();
            show = stuentry.getAllData(out msg);
            if (show != null && show.Rows.Count != 0)
            {

                GridView1.DataSource = show;
                GridView1.DataBind();
            }
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SMS003_StudentEntry.aspx");
        }

        protected void displayGrid(DsPSMS.ST_STUDENT_DATADataTable student)
        {
            if (student != null)
            {
                GridView1.DataSource = student;
                GridView1.DataBind();
            }
        }
            

     
    }
}