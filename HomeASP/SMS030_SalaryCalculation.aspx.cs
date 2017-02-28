using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using HomeASP.Common;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace HomeASP
{
    public partial class SMS030 : System.Web.UI.Page
    {
        SalaryCalculationService salarySerivce = new SalaryCalculationService();
        
        private string msg = "";
        static int reFlag = 0;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            //system.ImageUrl = "~/Images/system.jpg";
        }

       
        private void displayTeacherData()
        {
            DataSet.DsPSMS.ST_TEACHER_DATADataTable teachers = salarySerivce.getAllTeacherData(out msg);
            if (gvsalarylist.Columns.Count == 9)
            {
                gvsalarylist.Columns.Remove(gvsalarylist.Columns[8]);
            }

            if (teachers != null)
            {
                gvsalarylist.DataSource = teachers;
                ((BoundField)gvsalarylist.Columns[0]).DataField = "TEACHER_ID";
                ((BoundField)gvsalarylist.Columns[1]).DataField = "TEACHER_NAME";
                ((BoundField)gvsalarylist.Columns[2]).DataField = "SALARY";
                gvsalarylist.DataBind();
               
            }

        }

        private void displayStaffData()
        {
            DataSet.DsPSMS.ST_STAFF_DATADataTable staffs = salarySerivce.getAllStaffData(out msg);
            if (gvsalarylist.Columns.Count == 9)
            {
                gvsalarylist.Columns.Remove(gvsalarylist.Columns[8]);
            }

            if (staffs != null)
            {
                gvsalarylist.DataSource = staffs;
                
                ((BoundField)gvsalarylist.Columns[0]).DataField = "STAFF_ID";
                ((BoundField)gvsalarylist.Columns[1]).DataField = "STAFF_NAME";
                ((BoundField)gvsalarylist.Columns[2]).DataField = "SALARY";
                gvsalarylist.DataBind();
            }
        }

        protected void btnsalarycal_Click(object sender, EventArgs e)
        {
            string month = ddlmonthList.SelectedItem.Value; 
            if (radiobtnsalary.Items[0].Selected == true)
            {
                reFlag = 0;//TEACHER
                DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month,reFlag);
                if (chkSalary != null)
                {
                    bool isDelete = salarySerivce.deleteSalaryData(month, reFlag);
                }
                saveSalaryData();
            }
            else
            {
                reFlag = 1;//STAFF
                DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month, reFlag);
                if (chkSalary != null)
                {
                    bool isDelete = salarySerivce.deleteSalaryData(month, reFlag);
                }
                saveSalaryData();
            }
        }

        protected int calculateSalary(DataSet.DsPSMS.ST_SALARYRow temp,string salaryATM)
        {
            int resultAmt=0;
            if (temp != null)
            {
                resultAmt = int.Parse(salaryATM);

                if (temp.LEAVE_AMOUNT != 0)
                {
                    int leave = temp.LEAVE_TIMES * temp.LEAVE_AMOUNT;
                    resultAmt -= leave;
                }

                if (temp.LATE_AMOUNT != 0)
                {
                    int late = temp.LATE_TIMES * temp.LATE_AMOUNT;
                    resultAmt -= late;
                }

                if (temp.OT_AMOUNT != 0)
                {
                    resultAmt += temp.OT_AMOUNT;
                }
            }
            return resultAmt;
        }

        private void displayGridData(int reFlag)
        {
            string month = ddlmonthList.SelectedItem.Value; 
            DataSet.DsPSMS.ST_SALARYDataTable salarys = salarySerivce.getSalaryByMonthRemark(month, reFlag);
            
            if (salarys != null)
            {
                gvsalarylist.DataSource = salarys;
                ((BoundField)gvsalarylist.Columns[0]).DataField = "SALARY_ID";
                ((BoundField)gvsalarylist.Columns[1]).DataField ="STAFF_ID";
                ((BoundField)gvsalarylist.Columns[2]).DataField = "SALARY_AMOUNT";

                foreach (DataSet.DsPSMS.ST_SALARYRow row in salarys.Rows)
                {
                    if (reFlag == 0 && row.REMARK == 0)
                    {
                        DataSet.DsPSMS.ST_TEACHER_DATARow teacher = salarySerivce.getTeacherByid(int.Parse(row.STAFF_ID));
                        if (teacher != null)
                        {
                            
                            row.STAFF_ID = teacher.TEACHER_NAME;
                            row.SALARY_AMOUNT = teacher.SALARY;
                        }
                    }
                    else
                    {
                        DataSet.DsPSMS.ST_STAFF_DATARow staff = salarySerivce.getStaffIdByid(int.Parse(row.STAFF_ID));
                        if (staff != null)
                        {
                            row.STAFF_ID = staff.STAFF_NAME;
                            row.SALARY_AMOUNT = staff.SALARY;
                        }
                    }  
                }

                if (gvsalarylist.Columns.Count < 9)
                {
                    BoundField bfield = new BoundField();
                    bfield.HeaderText = "SALARY AMOUNT";
                    bfield.DataField = "SALARY_AMOUNT";
                    gvsalarylist.Columns.Add(bfield);
                }
                else
                {
                    ((BoundField)gvsalarylist.Columns[8]).DataField = "SALARY_AMOUNT";
                }
                gvsalarylist.DataBind();
                bindSalaryDatatxt(salarys);
                
            }
        }

        protected void bindSalaryDatatxt(DataSet.DsPSMS.ST_SALARYDataTable salarys)
        {
            int j = 0;
            foreach (GridViewRow row in gvsalarylist.Rows)
            {
                //myfunction(row,salarys);
                TextBox tb1 = new TextBox();
                //tb1 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[3].FindControl("txtLeaveTime"));
                tb1 = (TextBox)(row.FindControl("txtLeaveTime"));
                tb1.Text = salarys.Rows[j]["LEAVE_TIMES"].ToString();

                TextBox tb2 = new TextBox();
                tb2 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[4].FindControl("txtLeaveAmt"));
                tb2.Text = salarys.Rows[j]["LEAVE_AMOUNT"].ToString();

                TextBox tb3 = new TextBox();
                tb3 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[5].FindControl("txtlateTime"));
                tb3.Text = salarys.Rows[j]["LATE_TIMES"].ToString();

                TextBox tb4 = new TextBox();
                tb4 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[6].FindControl("txtLateAmt"));
                tb4.Text = salarys.Rows[j]["LATE_AMOUNT"].ToString();

                TextBox tb5 = new TextBox();
                tb5 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[7].FindControl("txtOtAmt"));
                tb5.Text = salarys.Rows[j]["OT_AMOUNT"].ToString();

                j++;
            }
        }

        protected void saveSalaryData()
        {
            foreach (GridViewRow row in gvsalarylist.Rows)
            {
                DataSet.DsPSMS.ST_SALARYRow salary = new DataSet.DsPSMS.ST_SALARYDataTable().NewST_SALARYRow();

                salary.STAFF_ID = gvsalarylist.Rows[row.RowIndex].Cells[0].Text;
                string salaryAMT = gvsalarylist.Rows[row.RowIndex].Cells[2].Text;
                salary.YEAR = 2016;
                TextBox tb1 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[3].FindControl("txtLeaveTime"));
                salary.LEAVE_TIMES = int.Parse(tb1.Text);

                TextBox tb2 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[4].FindControl("txtLeaveAmt"));
                salary.LEAVE_AMOUNT = int.Parse(tb2.Text);

                TextBox tb3 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[5].FindControl("txtlateTime"));
                salary.LATE_TIMES = int.Parse(tb3.Text);


                TextBox tb4 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[6].FindControl("txtLateAmt"));
                salary.LATE_AMOUNT = int.Parse(tb4.Text);

                TextBox tb5 = (TextBox)(gvsalarylist.Rows[row.RowIndex].Cells[7].FindControl("txtOtAmt"));
                salary.OT_AMOUNT = int.Parse(tb5.Text);
                salary.REMARK = reFlag;
                salary.SALARY_AMOUNT = calculateSalary(salary, salaryAMT);
                salary.MONTH = ddlmonthList.SelectedItem.Value;

                bool isOk = salarySerivce.saveSalaryData(salary, out msg);
            }

            displayGridData(reFlag);
        }

        protected void btnsalarysearch_Click(object sender, EventArgs e)
        {
            if (ddlmonthList.SelectedIndex == 0)
            {
                lblerrorsalary.Visible = true;
                btnsalarycal.Visible = false;
            }
            else
            {
                btnsalarycal.Visible = true;
                string month = ddlmonthList.SelectedItem.Value; 
                lblerrorsalary.Visible = false;
                if (radiobtnsalary.Items[0].Selected == true)
                {
                    reFlag = 0;
                    panelsalary.Visible = true;
                    DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month, reFlag);
                    if (chkSalary.Count > 0)
                    {
                        displayGridData(reFlag);
                    }
                    else
                    {
                        displayTeacherData();
                    }
                }
                else
                {
                    reFlag = 1;
                    panelsalary.Visible = true;
                    DataSet.DsPSMS.ST_SALARYDataTable chkSalary = salarySerivce.getSalaryByMonthRemark(month, reFlag);
                    if (chkSalary.Count > 0)
                    {
                        displayGridData(reFlag);
                    }
                    else
                    {
                        displayStaffData();
                    }
                } 
            }
           
        }



        protected void gvsalarylist_RowDataBound(object sender, GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
            }
        }

        private void myfunction(GridViewRow gvRow, DataSet.DsPSMS.ST_SALARYDataTable salarys)
        {
            int j = 0;
            TextBox tb1 = new TextBox();
            tb1 = (TextBox)(gvRow.FindControl("txtLeaveTime"));
            tb1.Text = salarys.Rows[j]["LEAVE_TIMES"].ToString();

            TextBox tb2 = new TextBox();
            tb2 = (TextBox)(gvRow.FindControl("txtLeaveAmt"));
            tb2.Text = salarys.Rows[j]["LEAVE_AMOUNT"].ToString();

            TextBox tb3 = new TextBox();
            tb3 = (TextBox)(gvRow.FindControl("txtlateTime"));
            tb3.Text = salarys.Rows[j]["LATE_TIMES"].ToString();

            TextBox tb4 = new TextBox();
            tb4 = (TextBox)(gvRow.FindControl("txtLateAmt"));
            tb4.Text = salarys.Rows[j]["LATE_AMOUNT"].ToString();

            TextBox tb5 = new TextBox();
            tb4 = (TextBox)(gvRow.FindControl("txtOtAmt"));
            tb5.Text = salarys.Rows[j]["OT_AMOUNT"].ToString();  
        }
       
    }
}