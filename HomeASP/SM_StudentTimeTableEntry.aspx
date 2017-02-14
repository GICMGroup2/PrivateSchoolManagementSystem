<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM_StudentTimeTableEntry.aspx.cs" Inherits="HomeASP.SM_StudentTimeTableEntry" %>

<!-- Layout -->
<html>
<head id="Head1" runat="server">
    <title>Student TimeTable Entry </title>
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
            height: 410px;
            width: 1290px;
            margin-right: 90px;
        }
        .auto-style1 {
            width: 210px;
        }
        .auto-style2 {
            width: 110px;
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
                               <br />
                                <table style="color:white;">
                                    <tr>
                                        <td class="auto-style2">Grade</td>
                                        <td><asp:DropDownList ID="ddlentrygradelist" runat="server" Height="25px" Width="160px" ForeColor="Black" AppendDataBoundItems="True" AutoPostBack="True">
                                            </asp:DropDownList></td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errmsggradelist" runat="server" Text="Please select grade !" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">Class</td>
                                        <td><asp:DropDownList ID="ddlentryclasslist" runat="server" Height="25px" Width="160px" ForeColor="Black" AppendDataBoundItems="True">
                                        </asp:DropDownList></td>
                                        <td class="auto-style1"><asp:Label ID="errmsgclasslist" runat="server" Text="Please select class!" ForeColor="Red" Visible="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">Room Teacher</td>
                                        <td><asp:DropDownList ID="ddlentryteacherlist" runat="server" Height="25px" Width="160px" ForeColor="Black" AppendDataBoundItems="True">
                                        </asp:DropDownList></td>
                                        <td class="auto-style1"><asp:Label ID="errmsgteaacherlist" runat="server" Text="Please select Room Teacher !" ForeColor="Red" Visible="False"></asp:Label></td>
                                    </tr>
                                </table>
                                <br />
&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRoomteaSave" runat="server" ForeColor="Black" Height="30px" Text="INSERT" Width="100px" OnClick="btnRoomteaSave_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnroomteaCancel" runat="server" ForeColor="Black" Height="30px" Text="CANCEL" Width="100px" OnClick="btnroomteaCancel_Click" />
                                <br />
                                <br />
                                <asp:GridView ID="gvRoomTeacher" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="164px" Width="473px" AutoGenerateColumns="False">
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
                                         <asp:BoundField HeaderText="GRADE"
                                            DataField="GRADE_ID"
                                        SortExpression="GRADE_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="ROOM"
                                            DataField="ROOM_ID"
                                        SortExpression="ROOM_ID"></asp:BoundField>
                                        <asp:BoundField HeaderText="ROOM TEACHER"
                                            DataField="ROOM_TEACHER_ID"
                                        SortExpression="ROOM_TEACHER_ID"></asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRoomTeacherEdit" runat="server" Text="Edit" CommandName='<%# Eval("TIMETABLE_ID") %>' OnClick="btnRoomTeaUpdate_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRoomTeacherSelect" runat="server" Text="Next" CommandName='<%# Eval("TIMETABLE_ID") %>' OnClick="btnRoomTeaNext_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </form>
                        </div>
                    </div>
            </div>
        </div>        
    </div>    
</body>
</html>

