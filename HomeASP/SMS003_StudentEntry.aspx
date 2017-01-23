<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS003_StudentEntry.aspx.cs" Inherits="HomeASP.SMS003" %>

<!-- Layout -->
<html>
<head id="Head1" runat="server">
    <title>Home </title>
    <link rel="stylesheet" href="styles/layout.css" type="text/css" />
    <link rel="stylesheet" href="styles/custom.css" type="text/css" />    
    <link rel="stylesheet" href="styles/font-awesome.css" type="text/css" />    
    <link rel="stylesheet" href="styles/bootstrap.css" type="text/css" />     
    <link rel="stylesheet" href="styles/style.css" type="text/css" />
    <link rel="stylesheet" href="styles/booking.css" type="text/css" />    
    <link rel="stylesheet" href="styles/navi.css" type="text/css" />
    
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        
    </script>

    <style type="text/css">
        #bookingForm
        {
            height: 1217px;
            width: 797px;
            margin-right: 0px;
            margin-top: 0px;
            margin-bottom: 95px;
        }

        #tablepadding
        { padding-top:2px;
          padding-bottom:1px;
          margin-left:10px;
          margin-right:5px;
        }
        
        #stupageinner {
    width:100%;
    margin:5px 7px 7px 0px;
    background-color:#1A7EBA!important;
    padding:100px 150px;
    min-height:520px;
    min-width:800px;
}   
   #stupagewrapper {
   
    min-height: 600px;
    background:#F3F3F3;
    margin: 0px 0px 0px 170px;
   
}    
        .auto-style1
        {
            height: 327px;
        }
      </style>
</head>

<body>
    <div>
        <div id="title" runat="server" align="center" style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; color: #FFFFFF; background-color: #1A7EBA; height: 40px;">
            Student Management System
        </div>
    </div>
    
    <div class="wrapper col2">
        <div>
            <div id="topnav">
                <ul>
                    <li><asp:Image ID="imgSchool" runat="server" Height="105px" Width="150px" /></li>
                    <li class="active">
                        <a href="#">
                            <asp:Image ID="stdInfo" runat="server" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Student Information" /><br />
                        </a>
                        <ul>
                            <li><a href="#">Student Entry</a></li>
                            <li><a href="#">Student List</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <asp:Image ID="attendanceInfo" runat="server" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Attendance Information" /><br />
                        </a>
                        <ul>
                            <li><a href="#">Attendance Entry</a></li>
                            <li><a href="#">Attendance List</a></li>
                        </ul>
                        </li>
                    <li>
                        <a href="#">
                            <asp:Image ID="examInfo" runat="server" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Exam Information" /><br />
                        </a>
                        <ul>
                            <li><a href="#">Exam Result Entry</a></li>
                            <li><a href="#">Exam Result</a></li>
                        </ul>
                        </li>
                    <li>
                        <a href="#">
                            <asp:Image ID="teacherInfo" runat="server" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Teacher Information" /><br />
                        </a>
                        <ul>
                            <li><a href="#">Account Creation</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#">
                            <asp:Image ID="system" runat="server" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="System Information" /><br />
                        </a>
                    </li>
                </ul>
            </div>
            <br class="clear" />
        </div>
    </div>
    <div id="Div1" class="wrapper col1" runat="server" height="561px">
        <div style="width: 150px; height: 560px; color: #FFFFFF; background-color: #1A7EBA; padding: 0px; border-spacing: 0px;">
                <div class="sidebar-collapse">
                <ul class="nav" id="main-menu">
                <li>
                    <a href="#">Home</a>
                </li>
                <li>
                    <a href="Contact.aspx">Login</a>
                </li>
                <li>
                    <a href="index.html">Exit</a>
                </li>
                </ul>
                    <div id="stupagewrapper">
                        <div id="stupageinner">
                            <form id="bookingForm" runat="server">                            
                                  
                                <asp:Image ID="picturebox" runat="server" Height="130px" Width="145px" />
                                &nbsp; &nbsp;
                                <asp:Label ID="photo" runat="server" Text="Choose Photo" />
                                <br />

                                                                                              
                                <div style="height: 36px">
                                <table  align="left" style="background-color:#302c2c; height: 918px; width: 450px; margin-right: 47px;"> 
                                <tr> <td class="auto-style6">&nbsp; Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                     <td>&nbsp;<asp:TextBox ID="stuname" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                                </tr>  

                                <tr> <td class="auto-style6">&nbsp; Grade ID</td>
                                     <td>&nbsp;<asp:DropDownList ID="grade" runat="server" Width="190px" Height="30px" ForeColor="Black" >
                                            
                                               <asp:ListItem>Grade 1</asp:ListItem>
                                               <asp:ListItem>Grade 2</asp:ListItem>
                                               <asp:ListItem>Grade 3</asp:ListItem>
                                               <asp:ListItem>Grade 4</asp:ListItem>
                                               <asp:ListItem>Grade 5</asp:ListItem>
                                               <asp:ListItem>Grade 6</asp:ListItem>
                                               <asp:ListItem>Grade 7</asp:ListItem>
                                               <asp:ListItem>Grade 8</asp:ListItem>
                                               <asp:ListItem>Grade 9</asp:ListItem>
                                               <asp:ListItem>Grade 10</asp:ListItem>
                                            </asp:DropDownList>
                                     </td>
                               </tr>  

                               <tr> <td class="auto-style6">&nbsp; Student ID</td>
                                    <td>&nbsp;<asp:TextBox ID="stuid" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black" ></asp:TextBox></td>
                               </tr>       
                                    
                               <tr> <td class="auto-style6">&nbsp; Room ID</td>
                                    <td>&nbsp;<asp:TextBox ID="roomid" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                               </tr>
                                   
                               <tr> <td class="auto-style6">&nbsp; Roll No.</td>
                                    <td>&nbsp;<asp:TextBox ID="rollno" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                               </tr>

                               <tr> <td class="auto-style6">&nbsp; Gender</td>
                                    <td>&nbsp;<asp:RadioButton ID="Male" runat="server"  GroupName="Gender" Text="Male" />&nbsp; &nbsp; &nbsp;
                                              <asp:RadioButton ID="Female" runat="server" Text="Female" GroupName="Gender" /></td>
                               </tr>

                               <tr> <td class="auto-style1">&nbsp; Date of Birth </td>
                                    <td class="auto-style1">&nbsp;<asp:TextBox runat="server" ID="dob" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black" />
                                              <asp:Button ID="btndobcalendar" runat="server" ForeColor="#FF0066" OnClick="btndobcalendar_Click" Text="Calendar" />
                                    <div> <asp:Panel ID="p1" runat="server" Height="16px" Visible="false" Width="271px">
                                          &nbsp; <asp:Calendar ID="Calendar" runat="server" OnSelectionChanged="Calendar_SelectionChanged" BackColor="White" Height="200px" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Width="220px">
                                              <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                              <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                              <OtherMonthDayStyle ForeColor="#999999" />
                                              <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                              <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                              <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                              <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                              <WeekendDayStyle BackColor="#CCCCFF" />
                                          </asp:Calendar>
                                          </asp:Panel>
                                    </div>
                                    </td>
                               </tr>
                                                                                        
                               <tr> <td class="auto-style6">&nbsp; NRC No. </td>
                                    <td>&nbsp;<asp:TextBox ID="nrcno" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black" ></asp:TextBox></td>
                               </tr>                                                                                                                                                 
                                                                                                                                                                                                                    
                               <tr> <td class="auto-style6">&nbsp; Education Year </td>
                                    <td >&nbsp;<asp:DropDownList ID="education" runat="server" Width="190px" Height="30px" ForeColor="Black">
                                               <asp:ListItem>2001 - 2002</asp:ListItem>
                                               <asp:ListItem>2002 - 2003</asp:ListItem>
                                               <asp:ListItem>2003 - 2004</asp:ListItem>
                                               <asp:ListItem>2004 - 2005</asp:ListItem>
                                               <asp:ListItem>2005 - 2006</asp:ListItem>
                                               <asp:ListItem>2007 - 2008</asp:ListItem>
                                               <asp:ListItem></asp:ListItem>
                                               </asp:DropDownList>
                                              
                                    </td>
                                </tr>                                        
                       </table> 

                      
                        
                                    
                       
                       <table align="right" style="background-color:#302c2c; height: 494px; width: 443px; margin-right: 47px;">
                                 <tr>
                                       <td class="auto-style11">&nbsp; Father Name</td>
                                       <td class="auto-style14"><asp:TextBox ID="father" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black" ></asp:TextBox></td>
                                 </tr>

                                 <tr>
                                        <td class="auto-style11">&nbsp; Mother Name</td>
                                        <td class="auto-style14"><asp:TextBox ID="mother" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                                 </tr>
                                                            
                                 <tr>
                                        <td class="auto-style11">&nbsp; Contact Phone</td>
                                        <td class="auto-style14"> <asp:TextBox ID="phone" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                                 </tr>
                                 
                                 <tr>
                                        <td class="auto-style13">&nbsp; Email</td>
                                        <td class="auto-style15"><asp:TextBox ID="email" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox>&nbsp;</td>
                                 </tr>

                                 <tr>
                                        <td class="auto-style11">&nbsp; Password</td>
                                        <td class="auto-style14"><asp:TextBox ID="password" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                                 </tr>

                                 <tr>
                                        <td class="auto-style11">&nbsp; Address   
                                        </td>
                                        <td class="auto-style14"> <asp:TextBox ID="address" runat="server" Width="190px" Height="30px" BorderStyle="Ridge" ForeColor="Black"></asp:TextBox></td>
                                 </tr>

                                 <tr>
                                        <td class="auto-style11">&nbsp; Cash Type</td>
                                        <td class="auto-style14"> <asp:DropDownList ID="cashtype" runat="server" Width="190px" Height="30px" ForeColor="Black" OnSelectedIndexChanged="cashtype_SelectedIndexChanged">
                                                                <asp:ListItem>Annually</asp:ListItem>
                                                                <asp:ListItem>Monthly</asp:ListItem>
                                                               </asp:DropDownList><br />
                                                <asp:RadioButton ID="firstmonth" runat="server" GroupName="cash2" Text="1 Month" /> 
                                                <asp:RadioButton ID="thirdmonth" runat="server" GroupName="cash2" Text="3 Month" />
                                                <asp:RadioButton ID="fourmonth" runat="server" GroupName="cash2" Text="4 Month" /></td>
                                 </tr>

                               
                       </table> </div>

                          
                       &nbsp;&nbsp;
                                     
                       <br />
                                
                              <div align="center">
                                
                                <asp:Button ID="save" runat="server" Text="Save Info" OnClick="saved_Click" ForeColor="#FF0066" /> &nbsp;
                                <asp:Button ID="showlist" runat="server" Text="Show List" Width="101px" OnClick="showlist_Click" OnClientClick="window.open('SMS004_StudentList.aspx','OtherPage');" ForeColor="#FF0066"/>&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="display" runat="server" Text="Display" Width="100px" OnClick="display_Click" OnClientClick="window.open('SMS005_StudentDetail.aspx','OtherPage');" ForeColor="#FF0066"/>&nbsp;&nbsp;
                                <asp:Button ID="clear" runat="server" Text="Clear" Width="100px" OnClick="clear_Click" ForeColor="#FF0066" />       
                                </div>
                                   
                            
                                     
                                          
                                                             
                     
                                </form>
                            
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
</body>
</html>
