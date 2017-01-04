using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace HomeASP
{
    public partial class SMS021 :Page
    {
        TimeTableEntryService timeService = new TimeTableEntryService();
        DataSet.DsPSMS.ST_TIMETABLERow timetable = new DataSet.DsPSMS.ST_TIMETABLEDataTable().NewST_TIMETABLERow();

        private string msg = "";
        static int delFlag = 0;
        static int updateId;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            bindGrade();
            bindTeacher();
            ddltimegradelist.Items.Insert(0, new ListItem("Select Grade", "0"));
            ddlTeacherList.Items.Insert(0, new ListItem("Select Teacher", "0"));
            txttimetabledate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            DisplayData();
        }

        public void bindGrade()
        {
            msg = "aaa";
            DataSet.DsPSMS.ST_GRADE_MSTDataTable grades = timeService.getAllGradeData(out msg);
            ddltimegradelist.DataSource = grades;
            ddltimegradelist.DataTextField = "GRADE_NAME";
            ddltimegradelist.DataValueField = "GRADE_ID";
            ddltimegradelist.DataBind();
        }

        public void bindTeacher()
        {
            msg = "aaa";
            DataSet.DsPSMS.ST_TEACHER_DATADataTable grades = timeService.getAllTeacherData(out msg);
            ddlTeacherList.DataSource = grades;
            ddlTeacherList.DataTextField = "TEACHER_NAME";
            ddlTeacherList.DataValueField = "TEACHER_ID";
            ddlTeacherList.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            msg = "";
            if (!checkValidation())
            {
                timetable.GRADE_ID = ddltimegradelist.SelectedItem.Value;
                timetable.TEACHER_ID = ddlTeacherList.SelectedItem.Value;
                timetable.DAY = txttimetabledate.Text;
                timetable.PERIOD1 = checkselectIndex(ddlclass1.SelectedIndex, ddlclass1.SelectedItem.Value);
                timetable.PERIOD2 = checkselectIndex(ddlclass2.SelectedIndex, ddlclass2.SelectedItem.Value);
                timetable.PERIOD3 = checkselectIndex(ddlclass3.SelectedIndex, ddlclass3.SelectedItem.Value);
                timetable.PERIOD4 = checkselectIndex(ddlclass4.SelectedIndex, ddlclass4.SelectedItem.Value);
                timetable.PERIOD5 = checkselectIndex(ddlclass5.SelectedIndex, ddlclass5.SelectedItem.Value);
                timetable.PERIOD6 = checkselectIndex(ddlclass6.SelectedIndex, ddlclass6.SelectedItem.Value);
                timetable.PERIOD7 = checkselectIndex(ddlclass7.SelectedIndex, ddlclass7.SelectedItem.Value);
                timetable.DEL_FLG = 0;

                bool isOk = timeService.saveTimeTable(timetable, out msg);
                DisplayData();
                resetForm();
                //bool existFlag = timeService.isExist(timetable, out msg);

                //if (existFlag)
                //{
                //    //DisplayData();
                //}
                //else
                //{
                //    //bool isOk = timeService.saveTimeTable(timetable, out msg);
                //    //MessageBox.Show(msg);
                //    //DisplayData();
                //    //Fillcombo();
                //}
            }

        }

        protected string checkselectIndex(int selectIndex,string value)
        {
            string selectValue;

            if (selectIndex == 0)
            {
                selectValue = "-";
            }
            else
            {
                selectValue = value;
            }
            return selectValue;
        }

        private bool checkValidation()
        {
            bool isErr = false;
            //if (txtId.Text.Trim().Length == 0)
            //{
            //    //msg = "Please enter ID !\n";
            //    msg = "Please enter require field";
            //    isErr = true;
            //}
            //if (txtGrade.Text.Trim().Length == 0)
            //{
            //    //msg = "Please enter ID !\n";
            //    msg = "Please enter require field";
            //    isErr = true;
            //}
            return isErr;
        }

        protected void btncalendar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txttimetabledate.Text = Calendar1.SelectedDate.ToShortDateString();
            Panel1.Visible = false;
        }

        private void DisplayData()
        {

            DataSet.DsPSMS.ST_TIMETABLEDataTable resultDt = timeService.getAllTimeTableData(out msg);

            if (resultDt != null)
            {
                // MessageBox.Show(msg);
                resultDt.Columns.Remove(resultDt.Columns["CRT_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["CRT_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_DT_TM"]);
                resultDt.Columns.Remove(resultDt.Columns["UPD_USER_ID"]);
                resultDt.Columns.Remove(resultDt.Columns["DEL_FLG"]);

                foreach (DataSet.DsPSMS.ST_TIMETABLERow row in resultDt.Rows)
                {
                    int gradeId;
                    string gradevalue = null;

                    int teacherId;
                    string teachervalue = null;

                    if (row.GRADE_ID != null)
                    {
                        gradeId = int.Parse(row.GRADE_ID);
                        DataSet.DsPSMS.ST_GRADE_MSTRow grade = timeService.getGradeByid(gradeId);
                        gradevalue = grade.GRADE_NAME;
                        row.GRADE_ID = gradevalue;
                    }

                    if (row.TEACHER_ID != null)
                    {
                        teacherId = int.Parse(row.TEACHER_ID);
                        DataSet.DsPSMS.ST_TEACHER_DATARow teacher = timeService.getTeacherByid(teacherId);
                        teachervalue = teacher.TEACHER_NAME;
                        row.TEACHER_ID = teachervalue;
                    }
                }
                
                dvtimetable.DataSource = resultDt;
                dvtimetable.DataBind();
                dvtimetable.HeaderRow.Cells[1].Text = "Year";
                dvtimetable.HeaderRow.Cells[2].Text = "ID";
                dvtimetable.HeaderRow.Cells[3].Text = "GRADE";
                dvtimetable.HeaderRow.Cells[4].Text = "TEACHER";
            }
        }

        protected void Delete(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(dvtimetable.DataKeys[e.RowIndex].Value.ToString());
            bool isOk = timeService.deleteTimeTable(id,out msg);
            DisplayData();
        }

        protected int checkClassIndex(String strClass)
        {
            int resIndex;
            if (strClass.Equals("Class A"))
            {
                resIndex = 1;
            }
            else if (strClass.Equals("Class B"))
            {
                resIndex = 2;
            }
            else if (strClass.Equals("Class C"))
            {
                resIndex = 3;
            }
            else if (strClass.Equals("Class D"))
            {
                resIndex = 4;
            }
            else if (strClass.Equals("Class E"))
            {
                resIndex = 5;
            }
            else
            {
                resIndex = 0;
            }
            return resIndex;
        }

        protected void resetForm()
        {
            txttimetabledate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            ddltimegradelist.SelectedIndex = 0;
            ddlTeacherList.SelectedIndex = 0;
            ddlclass1.SelectedIndex = 0;
            ddlclass2.SelectedIndex = 0;
            ddlclass3.SelectedIndex = 0;
            ddlclass4.SelectedIndex = 0;
            ddlclass5.SelectedIndex = 0;
            ddlclass6.SelectedIndex = 0;
            ddlclass7.SelectedIndex = 0;
            Button1.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            btnUpdate.Visible = false;
            resetForm();
            //DisplayData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             msg = "";
             if (!checkValidation())
             {
                 timetable.GRADE_ID = ddltimegradelist.SelectedItem.Value;
                 timetable.TEACHER_ID = ddlTeacherList.SelectedItem.Value;
                 timetable.DAY = txttimetabledate.Text;
                 timetable.PERIOD1 = checkselectIndex(ddlclass1.SelectedIndex, ddlclass1.SelectedItem.Value);
                 timetable.PERIOD2 = checkselectIndex(ddlclass2.SelectedIndex, ddlclass2.SelectedItem.Value); 
                 timetable.PERIOD3 = checkselectIndex(ddlclass3.SelectedIndex, ddlclass3.SelectedItem.Value); 
                 timetable.PERIOD4 = checkselectIndex(ddlclass4.SelectedIndex, ddlclass4.SelectedItem.Value); 
                 timetable.PERIOD5 = checkselectIndex(ddlclass5.SelectedIndex, ddlclass5.SelectedItem.Value); 
                 timetable.PERIOD6 = checkselectIndex(ddlclass6.SelectedIndex, ddlclass6.SelectedItem.Value); 
                 timetable.PERIOD7 = checkselectIndex(ddlclass7.SelectedIndex, ddlclass7.SelectedItem.Value); 
                 timetable.DEL_FLG = delFlag;
                 bool isOk = timeService.updateTimeTable(timetable, updateId, out msg);
                 DisplayData();
                 resetForm();
             }
        }

        protected void Edit(object sender, GridViewSelectEventArgs e)
        {
            updateId = int.Parse(dvtimetable.DataKeys[e.NewSelectedIndex].Value.ToString());
            DataSet.DsPSMS.ST_TIMETABLERow timetable = timeService.getTimeTableByid(updateId);

            if (timetable != null)
            {
                delFlag = (int)timetable.DEL_FLG;
                txttimetabledate.Text = timetable.DAY;
                ddltimegradelist.SelectedIndex = int.Parse(timetable.GRADE_ID);
                ddlTeacherList.SelectedIndex = int.Parse(timetable.TEACHER_ID);
                ddlclass1.SelectedIndex = checkClassIndex(timetable.PERIOD1);
                ddlclass2.SelectedIndex = checkClassIndex(timetable.PERIOD2);
                ddlclass3.SelectedIndex = checkClassIndex(timetable.PERIOD3);
                ddlclass4.SelectedIndex = checkClassIndex(timetable.PERIOD4);
                ddlclass5.SelectedIndex = checkClassIndex(timetable.PERIOD5);
                ddlclass6.SelectedIndex = checkClassIndex(timetable.PERIOD6);
                ddlclass7.SelectedIndex = checkClassIndex(timetable.PERIOD7);
                Button1.Visible = false;
                btnUpdate.Visible = true;
            }  
        }

        protected void dvtimetable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvtimetable.PageIndex = e.NewPageIndex;
            dvtimetable.DataBind();
        }
    }
}