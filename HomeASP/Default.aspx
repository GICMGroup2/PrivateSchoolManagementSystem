<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="HomeASP._Default" %>

<!-- Layout -->
<html>

<head runat="server">
    <title>Home </title>
    <link rel="stylesheet" href="styles/layout.css" type="text/css" />
    <link rel="stylesheet" href="styles/custom.css" type="text/css" />    
    <link rel="stylesheet" href="styles/font-awesome.css" type="text/css" />    
    <link rel="stylesheet" href="styles/bootstrap.css" type="text/css" />     
    <link rel="stylesheet" href="styles/style.css" type="text/css" />
    <link rel="stylesheet" href="styles/booking.css" type="text/css" />
    <link rel="stylesheet" href="styles/BgImage.css" type="text/css" />
    <script type="text/javascript">

    </script>
</head>

<body>
    <div>
        <div id="title" runat="server" style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; text-align:center;height: 50px;color: #7AE995;background-color: #358A90;line-height: 50px;">
            Student Management System
        </div>
    </div>
    
    <div class="wrapper col2">
        <div  style="background-color:#b1f2eb">
            <div id="topnav">
                <ul>
                    <li><asp:Image ID="imgSchool" runat="server"  Height="105px" Width="150px" /></li>
                    <li class="active">
                        <a href="#" style="background-color:#b1f2eb">
                            <asp:Image ID="stdInfo" runat="server" style="border-radius:7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Student Information"  /><br />
                        </a>
                        <ul>
                            <li><a href="SMS003_StudentEntry.aspx">Student Entry</a></li>
                            <li><a href="SMS004_StudentList.aspx">Student List</a></li>
                            <li><a href="SMS017_StudentCashDetail.aspx">Payment</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" style="background-color:#b1f2eb">
                            <asp:Image ID="attendanceInfo" runat="server"  style="border-radius:7px 7px"  Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Attendance Information" /><br />
                        </a>
                        <ul>
                            <li><a href="SMS009_AttendanceEntry.aspx">Attendance Entry</a></li>
                            <li><a href="SMS010_AttendanceList.aspx">Attendance List</a></li>
                            <li><a href="SMS022_ClassTimetableDisplay.aspx">Class Timetable</a></li>
                        </ul>
                        </li>
                    <li>
                        <a href="#" style="background-color:#b1f2eb">
                            <asp:Image ID="examInfo" runat="server"  style="border-radius:7px 7px"  Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Exam Information" /><br />
                        </a>
                        <ul>
                            <li><a href="SMS006_StudentResultEntry.aspx">Exam Result Entry</a></li>
                            <li><a href="SMS007_StudentResultList.aspx">Exam Result</a></li>
                        </ul>
                        </li>
                    <li>
                        <a href="#" style="background-color:#b1f2eb">
                            <asp:Image ID="teacherInfo" runat="server"  style="border-radius:7px 7px"  Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Teacher Information" /><br />
                        </a>
                        <ul>
                            <%--<li><a href="#">Account Creation</a></li>--%>
                            <li><a href="SMS023_StaffEntry.aspx">Staff Entry</a></li>
                            <li><a href="SMS024_StaffList.aspx">Staff List</a></li>
                            <li><a href="SMS030_SalaryCalculation.aspx">Salary Calculation</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" style="background-color:#b1f2eb">
                            <asp:Image ID="system" runat="server"  style="border-radius:7px 7px"  Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="System Information"  /><br />
                        </a>
                         <ul>
                            <li><a href="SMS028_ExpenseList.aspx">Expense List</a></li>
                            <li><a href="SMS034_EquipmentDisplay.aspx">Equipment List</a></li>
                            <li><a href="SMS032_OfficialDocDisplay.aspx">Official Doc</a></li>
                            <li><a href="SMS026_EventsNewsEntry.aspx">Events and News Entry</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
            <br class="clear" />
        </div>
    </div>
    <div class="wrapper col1" runat="server" height="561px" style="background-color:#b1f2eb">
        <div style="width: 150px; height: 550px; color: #FFFFFF; background-color: #1A7EBA; padding: 0px; border-spacing: 0px;">
           <%-- <br />--%>
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu" style="width:150px">
                <li>
                    <a href="Default.aspx">Home</a>
                </li>
                <li>
                    <a href="Contact.aspx">Logout</a>
                </li>
                <li>
                    <a href="index.html">Exit</a>
                </li>
                </ul>

               <div id="page-separate" style="background-color:#b1f2eb">
                        <div id="bg-image">
                            <%--<asp:Image ID="Image1" runat="server" />--%>
                                
                        </div>
                   </div>
            </div>
        </div>
    </div>
</body>
</html>
