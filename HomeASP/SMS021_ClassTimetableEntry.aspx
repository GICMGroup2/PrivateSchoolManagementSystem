<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS021_ClassTimetableEntry.aspx.cs" Inherits="HomeASP.SMS021" %>
<%@ Register TagPrefix="Ajaxified" Assembly="Ajaxified" Namespace="Ajaxified" %>

<!-- Layout -->
<html>
<head id="Head1" runat="server">
    <title>Time Table Entry</title>
    <link rel="stylesheet" href="styles/layout.css" type="text/css" />
    <link rel="stylesheet" href="styles/custom.css" type="text/css" />    
    <link rel="stylesheet" href="styles/font-awesome.css" type="text/css" />    
    <link rel="stylesheet" href="styles/bootstrap.css" type="text/css" />     
    <link rel="stylesheet" href="styles/style.css" type="text/css" />
    <link rel="stylesheet" href="styles/booking.css" type="text/css" />
   
    <style type="text/css">
        #bookingForm {
            height: 1135px;
            width: 1511px;
            margin-right: 133px;
            margin-left: 0px;
        }
        .auto-style1 {
            width: 397px;
        }
        .auto-style2 {
            width: 125px;
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
                                <div style="margin-left: 80px">
                                    <asp:RequiredFieldValidator ID="validatorgrade" runat="server" ControlToValidate="ddltimegradelist" ErrorMessage="Please select grade !" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RequiredFieldValidator ID="validatorteacher" runat="server" ControlToValidate="ddlTeacherList" ErrorMessage="Please select teacher !" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                                Grade&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddltimegradelist" runat="server" Width="158px" AppendDataBoundItems="True" ForeColor="#003300">
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Teacher&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlTeacherList" runat="server" ForeColor="Black" Width="166px" AppendDataBoundItems="True">
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date&nbsp;
                                <asp:TextBox ID="txttimetabledate" style="color:black" runat="server" Height="23px" Width="154px" />
                                <asp:Button ID="btncalendar" runat="server" ForeColor="Black" OnClick="btncalendar_Click" Text="Calendar" />
                                <div style="margin-left: 520px">
                                    <asp:Panel ID="Panel1" runat="server" Height="23px" style="margin-left: 72px" Visible="False" Width="700px">
                                        <asp:Calendar ID="Calendar1" runat="server" Height="200px" OnSelectionChanged="Calendar1_SelectionChanged" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399">
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
                                <br />
                                <table style="width:75%; margin-left: 34px; height: 217px;">
                                    <tr>
                                        <td class="auto-style2" style="color:white;">Period</td>
                                        <td class="auto-style1" style="color:white;">Select Class</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2" style="color:white;">&nbsp;8:00&nbsp; ~ 8:45 AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass1" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2" style="color:white;">&nbsp;8:55&nbsp; ~ 9:40 AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass2" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2" style="color:white;">&nbsp;9:50&nbsp; ~ 10:35 AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass3" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2" style="color:white;">10:45 ~ 11:20AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass4" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2" style="color:white;">10:45 ~ 11:20AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass5" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="auto-style2" style="color:white;">10:45 ~ 11:20AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass6" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="auto-style2" style="color:white;">10:45 ~ 11:20AM</td>
                                        <td>
                                            <asp:DropDownList ID="ddlclass7" runat="server" Width="165px">
                                                <asp:ListItem>Select Class</asp:ListItem>
                                                <asp:ListItem>Class A</asp:ListItem>
                                                <asp:ListItem>Class B</asp:ListItem>
                                                <asp:ListItem>Class C</asp:ListItem>
                                                <asp:ListItem>Class D</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" Text="INSERT" Width="105px" ForeColor="#003300" OnClick="Button1_Click" />
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" ForeColor="Black" OnClick="btnUpdate_Click" Text="UPDATE" Visible="False" Width="105px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" ForeColor="Black" Text="CANCEL" Width="105px" OnClick="Button2_Click" />
                                <br />
                                <br />
                                <asp:GridView ID="dvtimetable" runat="server" Width="280px" ForeColor="Black" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" AllowPaging="True" PageSize="5"
                                    DataKeyNames="ID" OnRowDeleting="Delete" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True" OnSelectedIndexChanging="Edit" OnPageIndexChanging="dvtimetable_PageIndexChanging" CellSpacing="1">
                                    <AlternatingRowStyle BackColor="White" />
                                    <FooterStyle BackColor="#CCCC99" />
                                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F7DE" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
                                </asp:GridView>
                                <br />
                                <br />
                                <br />
                                <br />
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

