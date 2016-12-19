using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HomeASP.Service;

namespace HomeASP
{
    public partial class SMS002 : System.Web.UI.Page
    {
        private string msg = "";
        GradeSubjectService service = new GradeSubjectService();
        DataSet.DsPSMS.ST_GRADE_MSTRow gradeRow = new DataSet.DsPSMS.ST_GRADE_MSTDataTable().NewST_GRADE_MSTRow();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            msg = "";
            if (!checkValidation())
            {
                gradeRow.GRADE_ID = txtId.Text;
                gradeRow.GRADE_NAME = txtGrade.Text;

                bool existFlag = service.isExist(gradeRow, out msg);

                if (existFlag)
                {                    
                    //DisplayData();
                }
                else
                {
                    bool isOk = service.saveGrade(gradeRow, out msg);
                    //MessageBox.Show(msg);
                    DisplayData();
                    //Fillcombo();
                }
            }
            else
            {
                //MessageBox.Show(msg);
            }
        }

        private bool checkValidation()
        {
            bool isErr = false;
            if (txtId.Text.Trim().Length == 0)
            {
                //msg = "Please enter ID !\n";
                msg = "Please enter require field";
                isErr = true;
            }
            if (txtGrade.Text.Trim().Length == 0)
            {
                //msg = "Please enter ID !\n";
                msg = "Please enter require field";
                isErr = true;
            }
            return isErr;
        }

        private void DisplayData()
        {
            DataSet.DsPSMS.ST_GRADE_MSTDataTable resultDt = service.getAllGradeData(out msg);

            if (resultDt != null)
            {
                // MessageBox.Show(msg);
                GridView1.DataSource = resultDt;

                //resultDt.Columns.Remove(resultDt.Columns[3]);
                //resultDt.Columns.Remove(resultDt.Columns[3]);
                //resultDt.Columns.Remove(resultDt.Columns[3]);
                //resultDt.Columns.Remove(resultDt.Columns[3]);
                //resultDt.Columns.Remove(resultDt.Columns[3]);
                //GridView1.Columns[0].HeaderText = "Year";
                //GridView1.Columns[1].HeaderText = "ID";
                //GridView1.Columns[2].HeaderText = "Grade";
            }
        }

        //void Fillcombo()
        //{

        //    CBGrade.Items.Clear();
        //    string query = "select * from ST_GRADE_MST;";
        //    SqlConnection conn = new SqlConnection(@"Data Source=AYETHINKHAING\MSSQL12;Initial Catalog=Db_PSMS;Persist Security Info=True;User ID=sa;Password=pass0000;Pooling=False");
        //    SqlCommand s = new SqlCommand(query, conn);
        //    SqlDataReader myReader;
        //    DataTable dt = new DataTable();
        //    conn.Open();
        //    myReader = s.ExecuteReader();
        //    while (myReader.Read())
        //    {
        //        string sname = myReader.GetString(2);
        //        // txtcombo.Items.Add(sname);
        //        CBGrade.Items.Add(sname);
        //        //  txtcombo.SelectedIndex = -1;
        //        CBGrade.SelectedIndex = -1;
        //    }
        //    conn.Close();
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}