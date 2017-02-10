<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM_StudentTimeTabledisplay.aspx.cs" Inherits="HomeASP.SM_StudentTimeTabledisplay" %>

<!-- Layout -->
<html>
<head id="Head1" runat="server">
    <title>Timetable Display </title>
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
            height: 244px;
            width: 811px;
            margin-right: 90px;
        }

        .auto-style1 {
            width: 138px;
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
                    <li>
                        <asp:Image ID="imgSchool" runat="server" Height="105px" Width="150px" /></li>
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="errSelectGrade" runat="server" ForeColor="Red" Text="Please select Grade !" Visible="False"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="errSelectRoom" runat="server" ForeColor="#FF3300" Text="Please select Room !" Visible="False"></asp:Label>
                            <br />
                            Grade&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlstugradelist" runat="server" Height="25px" Width="160px" ForeColor="Black">
                                </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Room&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlstuclasslist" runat="server" Height="25px" Width="160px" ForeColor="Black">
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" ForeColor="Black" Text="Search" OnClick="btnSearch_Click" Height="30px" Width="100px" />
                            <br />
                            <br />
                            <asp:Panel ID="Panelteacher" runat="server" Visible="False">
                                <table style="width: 43%; height: 10px; color: white;">
                                    <tr>
                                        <td class="auto-style1">Room Teacher</td>
                                        <td>
                                            <asp:Label ID="lblroomteachname" runat="server" ForeColor="White"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Label ID="lblNodata" runat="server" Font-Size="Medium" ForeColor="White"></asp:Label>
                            <br />
                            <asp:GridView ID="gvStuTimetable" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Height="196px" Width="660px">
                                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#330099" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                <Columns>
                                    <asp:BoundField HeaderText="PERIOD"
                                        DataField="TIMETABLE_TIME"
                                        SortExpression="TIMETABLE_TIME"></asp:BoundField>
                                    <asp:BoundField HeaderText="MONDAY"
                                        DataField="MONDAY"
                                        SortExpression="MONDAY" ItemStyle-Width="142px"></asp:BoundField>
                                    <asp:BoundField HeaderText="TUESDAY"
                                        DataField="TUESDAY"
                                        SortExpression="TUESDAY" ItemStyle-Width="142px"></asp:BoundField>
                                    <asp:BoundField HeaderText="WEDNESDAY"
                                        DataField="WEDNESDAY"
                                        SortExpression="WEDNESDAY" ItemStyle-Width="142px"></asp:BoundField>
                                    <asp:BoundField HeaderText="THURSDAY"
                                        DataField="THURSDAY"
                                        SortExpression="THURSDAY" ItemStyle-Width="142px"></asp:BoundField>
                                    <asp:BoundField HeaderText="FRIDAY"
                                        DataField="FRIDAY"
                                        SortExpression="FRIDAY" ItemStyle-Width="142px">
                                        <ItemStyle Width="142px"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ID"
                                        DataField="ID"
                                        SortExpression="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                        <HeaderStyle CssClass="hiddencol"></HeaderStyle>

                                        <ItemStyle CssClass="hiddencol"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
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

