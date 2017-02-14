<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SM_StudentTimeTableEntry_2.aspx.cs" Inherits="HomeASP.SM_StudentTimeTableEntry_2" %>

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
            height: 708px;
            width: 1131px;
            margin-right: 90px;
        }
        .auto-style1 {
        }
        .auto-style2 {
            width: 148px;
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
                                &nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                <table style="width: 46%; height: 199px; color:white;">
                                    <tr>
                                        <td class="auto-style2">Period</td>
                                        <td>
                                            <asp:DropDownList ID="ddlperiodlist" runat="server" Height="25px" Width="160px" ForeColor="Black">
                                                <asp:ListItem>Period 1</asp:ListItem>
                                                <asp:ListItem>Period 2</asp:ListItem>
                                                <asp:ListItem>Period 3</asp:ListItem>
                                                <asp:ListItem>Period 4</asp:ListItem>
                                                <asp:ListItem>Period 5</asp:ListItem>
                                                <asp:ListItem>Period 6</asp:ListItem>
                                                <asp:ListItem>Period 7</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td></td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">MON</td>
                                        <td>
                                            <asp:DropDownList ID="ddlmonsublist" runat="server" Height="25px" Width="160px" ForeColor="Black">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errmonlist" runat="server" Text="Please select subject !" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">TUE</td>
                                        <td>
                                            <asp:DropDownList ID="ddltuesublist" runat="server" Height="25px" Width="160px" ForeColor="Black">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">
                                            <asp:Label ID="errtuelist" runat="server" Text="Please select subject !" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">WED</td>
                                        <td>
                                            <asp:DropDownList ID="ddlwedsublist" runat="server" ForeColor="Black" Height="25px" Width="160px">
                                            </asp:DropDownList>
                                        </td>
                                         <td class="auto-style1">
                                            <asp:Label ID="errwedlist" runat="server" Text="Please select subject !" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">THU</td>
                                        <td>
                                            <asp:DropDownList ID="ddlthusublist" runat="server" ForeColor="Black" Height="25px" Width="160px">
                                            </asp:DropDownList>
                                        </td>
                                         <td class="auto-style1">
                                            <asp:Label ID="errthulist" runat="server" Text="Please select subject !" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">FRI</td>
                                        <td>
                                            <asp:DropDownList ID="ddlfrisublist" runat="server" ForeColor="Black" Height="25px" Width="160px">
                                            </asp:DropDownList>
                                        </td>
                                         <td class="auto-style1">
                                            <asp:Label ID="errfrilist" runat="server" Text="Please select subject !" ForeColor="Red" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1" colspan="3">
                                            <asp:Button ID="btntimedetailAdd" runat="server" ForeColor="Black" Height="30px" OnClick="btntimedetailAdd_Click" Text="ADD" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btntimedetailcancel" runat="server" ForeColor="Black" Height="30px" OnClick="btntimedetailcancel_Click" Text="CANCEL" Width="100px" />
                                        </td>
                                    </tr>
                                    </table>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;
                                <br />
                                <asp:GridView ID="gvtimedetail" runat="server" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" Height="189px" Width="419px" AutoGenerateColumns="False">
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
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnTimeDetailEdit" runat="server" Text="Edit" CommandName='<%# Eval("ID") %>' OnClick="btnTimeDetailUpdate_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnTimeDetailDelete" runat="server" Text="Delete" CommandName='<%# Eval("ID") %>' OnClick="btnTimeDetailDelete_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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


