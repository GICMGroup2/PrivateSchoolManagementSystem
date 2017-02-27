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
          
            
            if( !IsPostBack)
            {
            DsPSMS.ST_STUDENT_DATARow stuentryupdate = new DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            if (Session["EDU_YEAR"] != null)
            {
                education.Text = (string)(Session["EDU_YEAR"] ?? " ");
            }

            if (Session["STUDENT_ID"] != null)
            {
                stuid.Text = (string)(Session["STUDENT_ID"] ?? " ");
            }


            if (Session["STUDENT_NAME"] != null)
            {
                stuname.Text = (string)(Session["STUDENT_NAME"] ?? " ");
            }

            if (Session["ROLL_NO"] != null)
            {
                rollno.Text = (string)(Session["ROLL_NO"] ?? " ");
            }

            if (Session["GENDER"] != null)
            {
                if (Session["GENDER"].Equals("Female"))
                { Female.Checked = true; }
                else
                { Male.Checked = true; }
            }
            
            if (Session["PHOTO_PATH"] != null)
            {
                studentpicture.ImageUrl = (string)(Session["PHOTO_PATH"] ?? " ");
            }

            if (Session["DOB"] != null)
            {
                dob.Text = (string)(Session["DOB"] ?? " ");
            }

            if (Session["PHONE"] != null)
            {
                stuphone.Text = (string)(Session["PHONE"] ?? " ");
            }

            if (Session["NRC_NO"] != null)
            {
                nrcno.Text = (string)(Session["NRC_NO"] ?? " ");
            }

            if (Session["PASSWORD"] != null)
            {
                password.Text = (string)(Session["PASSWORD"] ?? " ");
            }

            if (Session["GRADE_ID"] != null)
            {
                grade.Text = (string)(Session["GRADE_ID"] ?? " ");
            }

            if(Session["ROOM_ID"]!=null)
            {
                roomid.Text = (string)(Session["ROOM_ID"] ?? " ");
            }

            if (Session["FATHER_NAME"] != null)
            {
                father.Text = (string)(Session["FATHER_NAME"] ?? " ");
            }

            if (Session["MOTHER_NAME"] != null)
            {
                mother.Text = (string)(Session["MOTHER_NAME"] ?? " ");
            }

            if (Session["ADDRESS"] != null)
            {
                address.Text = (string)(Session["ADDRESS"] ?? " ");
            }

            if (Session["CONTACT_PHONE"] != null)
            {
                phone.Text = (string)(Session["CONTACT_PHONE"] ?? " ");
            }
            if (Session["EMAIL"] != null)
            {
                email.Text = (string)(Session["EMAIL"] ?? " ");
            }
            if (Session["CASH_TYPE1"] != null)
            {
                cashtype.Text = (string)(Session["CASH_TYPE1"] ?? " ");
            }
            if (Session["CASH_TYPE2"] != null)
            {
                if (Session["CASH_TYPE2"].Equals("1"))
                { firstmonth.Checked = true; }
                if (Session["CASH_TYPE2"].Equals("3"))
                { thirdmonth.Checked = true; }
                if (Session["CASH_TYPE2"].Equals("4"))
                { fourmonth.Checked = true; }

            }
           
            }

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
            stuphone.Text = dr["PHONE"].ToString();
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

        public string getFilePath()
        {
            string strPath = "";

            string folderPath = Server.MapPath("~/Images/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            strPath = folderPath + Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(strPath);
            

            return strPath;
        }
        // Saving data
        protected void saved_Click(object sender, EventArgs e)
        {

            dr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();

            //string str = getFilePath();



            if (stuid.Text.Trim().Length != 0)
            {
                if (education.Text != null)
                {
                    string edu = education.Text;
                    dr[0] = edu;
                }
                else
                {

                    Response.Write("<script>alert('Please Enter Education Year !')</script>");
                }


                if (stuid.Text.Trim().Length != 0)
                {
                    dr[1] = Convert.ToString(stuid.Text);
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student ID !')</script>");
                }


                if (stuname.Text.Trim().Length != 0)
                {
                    dr[2] = stuname.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student Name !')</script>");
                }


                if (rollno.Text.Trim().Length != 0)
                {
                    dr[3] = rollno.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Roll No. !')</script>");
                }

                if (Female.Checked == true)
                    dr[4] = "Female ";

                if (Male.Checked == true)
                    dr[4] = " Male ";


                

                    dr[5] = FileUpload1.FileName;

               



                if (dob.Text.Trim().Length != 0)
                {
                    dr[6] = dob.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter DOB !')</script>");
                }


                if (phone.Text.Trim().Length != 0)
                {
                    dr[7] = stuphone.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student Phone !')</script>");
                }


                if (nrcno.Text.Trim().Length != 0)
                {
                    dr[8] = nrcno.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student NRC No. !')</script>");
                }


                if (password.Text.Trim().Length != 0)
                {
                    dr[9] = password.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Password !')</script>");
                }


                if (grade.Text.Trim().Length != 0)
                {
                    dr[10] = grade.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Grade !')</script>");
                }


                if (roomid.Text.Trim().Length != 0)
                {
                    dr[11] = roomid.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Room !')</script>");
                }


                if (cashtype.Text.Length == 0)
                { Response.Write("<script>alert('Please Select Cash Type !')</script>"); }
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
                {
                    dr[14] = father.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Father Name !')</script>");
                }


                if (mother.Text.Trim().Length != 0)
                {
                    dr[15] = mother.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Mother Name !')</script>");
                }



                if (address.Text.Trim().Length != 0)
                {
                    dr[16] = address.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Address !')</script>");
                }


                if (phone.Text.Trim().Length != 0)
                {
                    dr[17] = phone.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Phone !')</script>");
                }


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
                    dr[18] = email.Text;
                    dr[19] = "";
                    dr[20] = "";
                    dr[21] = "";
                    bool result = stuentry.saveData(dr, "ST_STUDENT_DATA", out msg);

                }

            } Response.Write("<script>alert('Your Student Entry is Successful !')</script>");

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            dr = new DataSet.DsPSMS.ST_STUDENT_DATADataTable().NewST_STUDENT_DATARow();
            dt = new DataSet.DsPSMS.ST_STUDENT_DATADataTable();


            if (stuid.Text.Trim().Length != 0)
            {
                if (education.Text != null)
                {
                    string edu = education.Text;
                    dr[0] = edu;
                }
                else
                {

                    Response.Write("<script>alert('Please Enter Education Year !')</script>");
                }


                if (stuid.Text.Trim().Length != 0)
                {
                    dr[1] = Convert.ToString(stuid.Text);
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student ID !')</script>");
                }


                if (stuname.Text.Trim().Length != 0)
                {
                    dr[2] = stuname.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student Name !')</script>");
                }


                if (rollno.Text.Trim().Length != 0)
                {
                    dr[3] = rollno.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Roll No. !')</script>");
                }

                if (Female.Checked == true)
                    dr[4] = "Female ";

                if (Male.Checked == true)
                    dr[4] = " Male ";

                
                string upFile = (string)(Session["PHOTO_PATH"] ?? " ");
                if (FileUpload1.FileName == "")
                {
                    dr[5] = upFile;
                }
                else
                {
                    if (!upFile.Equals(FileUpload1.FileName))
                    {
                        string str = getFilePath();
                        dr[5] = FileUpload1.FileName;
                    }
                    else
                    {
                        dr[5] = FileUpload1.FileName;
                    }
                }

                if (dob.Text.Trim().Length != 0)
                {
                    dr[6] = dob.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter DOB !')</script>");
                }


                if (phone.Text.Trim().Length != 0)
                {
                    dr[7] = stuphone.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student Phone !')</script>");
                }


                if (nrcno.Text.Trim().Length != 0)
                {
                    dr[8] = nrcno.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Student NRC No. !')</script>");
                }


                if (password.Text.Trim().Length != 0)
                {
                    dr[9] = password.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Password !')</script>");
                }


                if (grade.Text.Trim().Length != 0)
                {
                    dr[10] = grade.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Grade !')</script>");
                }


                if (roomid.Text.Trim().Length != 0)
                {
                    dr[11] = roomid.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Room !')</script>");
                }


                if (cashtype.Text.Length == 0)
                { Response.Write("<script>alert('Please Select Cash Type !')</script>"); }
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
                {
                    dr[14] = father.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Father Name !')</script>");
                }


                if (mother.Text.Trim().Length != 0)
                {
                    dr[15] = mother.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Mother Name !')</script>");
                }



                if (address.Text.Trim().Length != 0)
                {
                    dr[16] = address.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Address !')</script>");
                }


                if (phone.Text.Trim().Length != 0)
                {
                    dr[17] = phone.Text;
                }
                else
                {
                    Response.Write("<script>alert('Please Enter Phone !')</script>");
                }


                if (email.Text.Trim().Length == 0)
                {
                    dr[18] = "";
                    dr[19] = "";
                    dr[20] = "";
                    dr[21] = "";
                    bool result = stuentry.updatedata(this.dr, out msg);

                }
                else
                {
                    dr[18] = email.Text;
                    dr[19] = "";
                    dr[20] = "";
                    dr[21] = "";
                    bool result = stuentry.updatedata(this.dr, out msg);

                }
            }
        }


        protected void showlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMS004_StudentList.aspx");

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


        protected void photoUpload_Click(object sender, EventArgs e)
        {
           
            string strPhoto = getFilePath();
            if (strPhoto != null)
            {
                studentpicture.ImageUrl = "~/Images/" + FileUpload1.FileName;
            }
            
           
            
            

        }
       






    }
}



