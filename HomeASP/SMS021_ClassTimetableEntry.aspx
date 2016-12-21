﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS021_ClassTimetableEntry.aspx.cs" Inherits="HomeASP.SMS021" %>

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
    <script type="text/javascript">

    </script>
    <style type="text/css">
        #bookingForm {
            height: 386px;
            width: 783px;
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
            <br />
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
                    <div id="page-wrapper">
                        <div id="page-inner">
                            <form id="bookingForm" runat="server">
                                Grade&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddltimegradelist" runat="server" Width="152px" AppendDataBoundItems="True" ForeColor="#003300">
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp; Class&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="161px" ForeColor="#003300">
                                    <asp:ListItem>Select Class</asp:ListItem>
                                    <asp:ListItem>Class A</asp:ListItem>
                                    <asp:ListItem>Class B</asp:ListItem>
                                    <asp:ListItem>Class C</asp:ListItem>
                                    <asp:ListItem>Class D</asp:ListItem>
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp; Subject&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList3" runat="server" Width="171px">
                                </asp:DropDownList>
                                <br />
                                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:Button ID="Button1" runat="server" Text="INSERT" Width="105px" ForeColor="#003300" />
                                <br />
                                <br />
                                <br />
                                <br />
                            </form>
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
</body>
</html>

