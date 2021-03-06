﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS016_StudentCashList.aspx.cs" Inherits="HomeASP.SMS016" %>

<!-- Layout -->
<html>

<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Student Cah List</title>
    <link rel="stylesheet" href="styles/layout.css" type="text/css" />
    <link rel="stylesheet" href="styles/custom.css" type="text/css" />
    <link rel="stylesheet" href="styles/font-awesome.css" type="text/css" />
    <link rel="stylesheet" href="styles/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="styles/style.css" type="text/css" />
    <link rel="stylesheet" href="styles/booking.css" type="text/css" />
    <link rel="stylesheet" href="styles/BgImage.css" type="text/css" />


    <link rel="stylesheet" href="http://localhost:59463/code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>

<body>
    <div>
        <div id="logoimg" runat="server">
            <table>
                <tr>
                    <th style="background-color: #358A90">
                        <asp:Image ID="logoImage" runat="server" Height="105px" Width="150px" /></th>
                    <%--<asp:Image ID="logoImage" runat="server" class="ressize"/></th>--%>
                    <th width="1200px" style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; text-align: center; height: 50px; color: #7AE995; background-color: #358A90; line-height: 50px;">
                        <asp:Label ID="labtitle" runat="server" Style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; text-align: center; height: 50px; color: #7AE995; background-color: #358A90; line-height: 50px;">Student Management System</asp:Label></th>
                </tr>
            </table>
        </div>
    </div>

    <div class="wrapper col2">

        <div style="background-color: #b1f2eb">
            <div id="topnav" style="background-color: #b1f2eb">
                <div class="noneimageli" style="background-color: #b1f2eb">
                    <ul>
                        <li class="active">
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="stdInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Student Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS003_StudentEntry.aspx">Student Entry</a></li>
                                <li><a href="SMS004_StudentList.aspx">Student List</a></li>
                                <li><a href="SMS017_StudentCashDetail.aspx">Payment</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="attendanceInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Attendance Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS009_AttendanceEntry.aspx">Attendance Entry</a></li>
                                <li><a href="SMS010_AttendanceList.aspx">Attendance List</a></li>
                                <li><a href="SMS022_ClassTimetableDisplay.aspx">Class Timetable</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="examInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Exam Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS006_StudentResultEntry.aspx">Exam Result Entry</a></li>
                                <li><a href="SMS007_StudentResultList.aspx">Exam Result</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="teacherInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Teacher Information" /><br />
                            </a>
                            <ul>
                                <%--<li><a href="#">Account Creation</a></li>--%>
                                <li style="opacity: 0.5"><a href="SMS023_StaffEntry.aspx">Staff Entry</a></li>
                                <li style="opacity: 0.5"><a href="SMS024_StaffList.aspx">Staff List</a></li>
                                <li style="opacity: 0.5"><a href="SMS030_SalaryCalculation.aspx">Salary Calculation</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="system" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="System Information" /><br />
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
            </div>
            <br class="clear" />
        </div>
    </div>
    <div id="Div1" class="wrapper col1" runat="server" height="561px" style="background-color: #b1f2eb">
        <div style="width: 150px; height: 550px; color: #FFFFFF; background-color: #1A7EBA; padding: 0px; border-spacing: 0px;">
            <%-- <br />--%>
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu" style="width: 150px">
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

                <div id="page-separate" style="background-color: #b1f2eb">
                    <div id="bg-Frm">
                        <form id="cashListform"  runat="server">
                            <div style="float:left">
                            <table id="cashTbl" runat="server" >
                                <tr class="spaceUnder">
                                    <td>
                                        <asp:Label ID="LabStudId" CssClass="Lab-format" runat="server" >ID*</asp:Label></td>
                                    <td><span style="margin-left: 2em"></span></td>
                                    <td>
                                        <asp:TextBox ID="TxtStudID" CssClass="Txtbox-format" runat="server" ForeColor="Black"></asp:TextBox></td>
                                    <td><span style="margin-left: 2em"></span></td>
                                    <td>
                                        <asp:Label ID="LabStuName" CssClass="Lab-format" runat="server">Name*</asp:Label></td>
                                    <td><span style="margin-left: 2em"></span></td>
                                    <td>
                                        <asp:Label ID="LabStuNameVal" CssClass="Txtbox-format" runat="server"></asp:Label></td>
                                    <td><span style="margin-left: 2em"></span></td>
                                    <td>
                                        <asp:Label ID="LabYear" CssClass="Lab-format" runat="server">Year*</asp:Label></td>
                                    <td><span style="margin-left: 2em"></span></td>
                                    <td>
                                        <asp:DropDownList ID="CoboYear" CssClass="Txtbox-format" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CoboSelect_Change" OnTextChanged="CoboSelect_Change" >
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>2010-2011</asp:ListItem>
                                            <asp:ListItem>2011-2012</asp:ListItem>
                                            <asp:ListItem>2012-2013</asp:ListItem>
                                            <asp:ListItem>2013-2014</asp:ListItem>
                                            <asp:ListItem>2014-2015</asp:ListItem>
                                            <asp:ListItem>2015-2016</asp:ListItem>
                                            <asp:ListItem>2016-2017</asp:ListItem>
                                            <asp:ListItem>2017-2018</asp:ListItem>
                                            <asp:ListItem>2018-2019</asp:ListItem>
                                            <asp:ListItem>2019-2020</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                              </table>
                            </div>
                            <br />
                            <br />
                            <div style="float:left"><asp:Label ID="errSeach" ForeColor="Red" Font-Size="Medium" style="float:left" runat ="server"></asp:Label> <asp:Button ID="btnSearch" Text="Search" Color="Black" ForeColor="#333333" style="float:right" runat="server" OnClick="search_Click"  /></div>
                            <div runat="server" >
                                <asp:GridView ID="cashList" class="cashList-Frm" Width="100%"  runat="server" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3">
                                    <AlternatingRowStyle Wrap="False" />
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                                <br />
                                <br />
                                <asp:Label ID="errGrid" ForeColor="Red" Font-Size="Medium" runat ="server"></asp:Label>
                            </div>
                            <div><asp:Button ID="viewDetail" Text="Detail" Color="Black" ForeColor="#333333" runat="server" OnClick="viewDetail_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

