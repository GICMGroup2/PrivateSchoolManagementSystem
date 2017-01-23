using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
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
    public partial class SMS003 : Page
    {
        Page ch;
        Page child;
        string msg = "";

        StudentInfoService stuentry = new StudentInfoService();
        DataSet.DsPSMS.ST_STUDENT_DATARow dr;
        DataSet.DsPSMS.ST_STUDENT_DATADataTable dt;

        public SMS003()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            imgSchool.ImageUrl = "~/Images/school.png";
            stdInfo.ImageUrl = "~/Images/student.png";
            attendanceInfo.ImageUrl = "~/Images/attendance.jpg";
            examInfo.ImageUrl = "~/Images/exam.png";
            teacherInfo.ImageUrl = "~/Images/teacher.png";
            system.ImageUrl = "~/Images/system.jpg";
            picturebox.ImageUrl = "~/Images/school.jpg";
            //education.Text = Convert.ToString(DateTime.Today.Year);

        }

        public SMS003(DataSet.DsPSMS.ST_STUDENT_DATARow dr)
        {
            //education.Text = Convert.ToString(dr.EDU_YEAR);
            education.Text = dr["EDU_YEAR"].ToString();
            stuname.Text = dr["STUDENT_NAME"].ToString(); //name
            stuid.Text = dr["STUDENT_ID"].ToString(); //id
            if (dr.ROLL_NO == null) //roll
                rollno.Text = "";
            else
                rollno.Text = dr.ROLL_NO;

            if (dr.GENDER != null) //gender
            {
                if (dr.GENDER == "Male")
                    Male.Checked = true;
                else
                    Female.Checked = true;
            }


            dob.Text = Convert.ToString(dr.DOB);
            phone.Text = dr["PHONE"].ToString();
            nrcno.Text = dr["NRC_NO"].ToString();
            password.Text = dr["PASSWORD"].ToString();
            grade.Text = dr["GRADE_ID"].ToString();

            if (dr.ROOM_ID == null)
                roomid.Text = "";
            else
                roomid.Text = dr.ROOM_ID;

            cashtype.Text = dr["CASH_TYPE1"].ToString();
            if (cashtype.Text == "Annually")
            {
                firstmonth.Enabled = false;
                thirdmonth.Enabled = false;
                fourmonth.Enabled = false;
            }
            else
            {
                if (dr["CASH_TYPE2"].ToString() == "1")
                    firstmonth.Checked = true;
                else if (dr["CASH_TYPE2"].ToString() == "3")
                    thirdmonth.Checked = true;
                else if (dr["CASH_TYPE2"].ToString() == "4")
                    fourmonth.Checked = true;
            }


            father.Text = dr["FATHER_NAME"].ToString();
            mother.Text = dr["MOTHER_NAME"].ToString();
            address.Text = dr["ADDRESS"].ToString();
            phone.Text = dr["CONTACT_PHONE"].ToString();
            email.Text = dr["EMAIL"].ToString();

        }
        // Saving data
        protected void saved_Click(object sender, EventArgs e)
        {
            bool isOk;
            dr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();





            if (stuid.Text.Trim().Length != 0)
            {
                //dr[0] =Convert.ToInt16( education.Text);
               // dr[0] = int.Parse(education.Text);
                dr[0] = education.Text;
                dr[1] = Convert.ToString(stuid.Text);
                if (stuname.Text.Trim().Length != 0)
                {
                    dr[2] = stuname.Text;

                    if (rollno.Text.Trim().Length != 0)
                        dr[3] = rollno.Text;
                    else
                        dr[3] = "";

                    if (Female.Checked == true)
                        dr[4] = "Female ";
                    if (Male.Checked == true)
                        dr[4] = " Male ";

                    // picture input kyan tay

                    dr[6] = dob.Text;

                    if (phone.Text.Trim().Length != 0)
                        dr[7] = phone.Text;
                    else
                        dr[7] = "";

                    if (nrcno.Text.Trim().Length != 0)
                        dr[8] = nrcno.Text;

                    if (password.Text.Trim().Length != 0)
                    {
                        dr[9] = password.Text;

                        if (grade.Text.Trim().Length != 0)
                        {
                            dr[10] = grade.Text;

                            if (roomid.Text.Trim().Length != 0)
                                dr[11] = roomid.Text;
                            else
                                dr[11] = "";

                            //
                            //if(dt.Rows.Count == 0 || dt == null)
                            //{
                            //    if(ckeckAge())
                            //{
                            if (cashtype.Text.Length != 0)
                            { dr[12] = ""; }
                            else
                            {
                                dr[12] = cashtype.Text;

                                if (cashtype.Text == "Monthly")
                                {
                                    if (firstmonth.Checked == true)
                                        dr[13] = "1";
                                    if (thirdmonth.Checked == true)
                                        dr[13] = "3";
                                    if (fourmonth.Checked == true)
                                        dr[13] = "4";
                                }
                                else
                                    dr[13] = "";
                            }

                            if (father.Text.Trim().Length != 0)
                                dr[14] = father.Text;
                            else
                                dr[14] = "";

                            if (mother.Text.Trim().Length != 0)
                                dr[15] = mother.Text;
                            else
                                dr[15] = "";

                            if (address.Text.Trim().Length != 0)
                                dr[16] = address.Text;
                            else
                                dr[16] = "";

                            if (phone.Text.Trim().Length != 0)
                                dr[17] = phone.Text;
                            else
                                dr[17] = "";

                            if (email.Text.Trim().Length == 0)
                            {
                                dr[18] = "";
                                dr[19] = "";
                                dr[20] = "";
                                dr[21] = "";
                                bool result = stuentry.saveData(dr, "ST_STUDENT_DATA", out msg);

                            }
                            else
                            {
                                isOk = IsValidEmail(email.Text);
                                if (isOk == true)
                                {
                                    dr[18] = email.Text;
                                    dr[19] = "";
                                    dr[20] = "";
                                    dr[21] = "";
                                    bool result = stuentry.saveData(dr, "ST_STUDENT_DATA", out msg);
                                }
                                else

                                { Response.Write("<script>alert('Please check your Email address')</script>"); }

                            }
                        }


                        else
                        { Response.Write("<script>alert('Student is already exsist')</script>"); }
                    }


                    else
                    { Response.Write("<script>alert('Enter student grade')</script>"); }
                }

                else
                { Response.Write("<script>alert('Enter password for security')</script>"); }
            }

            else
            { Response.Write("<script>alert('Check student name')</script>"); }
        }

        protected void savephoto_Click(object sender, EventArgs e)
        {

        }

        protected void showlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS004_StudentList.aspx");

        }

        protected void display_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS005_StudentDetail.aspx");
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            stuname.Text = String.Empty;
            stuid.Text = String.Empty;
            roomid.Text = String.Empty;
            rollno.Text = String.Empty;
            father.Text = String.Empty;
            mother.Text = String.Empty;
            phone.Text = String.Empty;
            email.Text = String.Empty;
            password.Text = String.Empty;

        }



        protected void btndobcalendar_Click(object sender, EventArgs e)
        {
            p1.Visible = true;
        }
        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            dob.Text = Calendar.SelectedDate.ToShortDateString();
            p1.Visible = false;
        }

        protected void cashtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cashtype.Text == "Annually")
            {
                firstmonth.Enabled = false;
                thirdmonth.Enabled = false;
                fourmonth.Enabled = false;
            }
            else
            {
                firstmonth.Enabled = true;
                thirdmonth.Enabled = true;
                fourmonth.Enabled = true;
            }
        }


        bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            { return false; }
        }

                
        
               
            }
}



