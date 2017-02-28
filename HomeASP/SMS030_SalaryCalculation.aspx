<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS030_SalaryCalculation.aspx.cs" Inherits="HomeASP.SMS030" %>

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
</head>

<body>
    <form id="form1" runat="server">
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
                </ul>
            </div>
            <br class="clear" />
                <ul>
                    <li>
                        <a href="#">
                            

                    </li>
                </ul>
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
                            <asp:RadioButtonList ID="radiobtnsalary" runat="server" ForeColor="White" Height="34px" RepeatDirection="Horizontal" Width="283px" AutoPostBack="True">
                                <asp:ListItem Selected="True">Teacher</asp:ListItem>
                                <asp:ListItem>Staff</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            Month&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlmonthList" runat="server" ForeColor="Black" Height="25px" Width="160px">
                                <asp:ListItem Value="0">Select  Month</asp:ListItem>
                                <asp:ListItem Value="1">January</asp:ListItem>
                                <asp:ListItem Value="2">February</asp:ListItem>
                                <asp:ListItem Value="3">March</asp:ListItem>
                                <asp:ListItem Value="4">April</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">August</asp:ListItem>
                                <asp:ListItem Value="9">September</asp:ListItem>
                                <asp:ListItem Value="10">October</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Label ID="lblerrorsalary" runat="server" ForeColor="#FF3300" Visible="False">* Please select month ! *</asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btnsalarysearch" runat="server" ForeColor="Black" Height="28px" OnClick="btnsalarysearch_Click" Text="Search" Width="135px" />
                            <br />
                            <br />
                            <asp:Panel ID="panelsalary" runat="server" Height="276px" Width="1038px">
                                <asp:GridView ID="gvsalarylist" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="95px" Width="16px" AllowPaging="True" OnRowDataBound="gvsalarylist_RowDataBound">
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
                                        <asp:BoundField HeaderText="ID"
                                            DataField=""
                                            SortExpression="" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">
                                            <HeaderStyle CssClass="hiddencol"></HeaderStyle>
                                            <ItemStyle CssClass="hiddencol"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="NAME"
                                            DataField=""
                                        SortExpression="" ItemStyle-Width="142px" ></asp:BoundField>
                                        <asp:BoundField HeaderText="SALARY"
                                            DataField=""
                                        SortExpression="" ItemStyle-Width="142px"></asp:BoundField>

                                        <asp:TemplateField HeaderText="LEAVE TIME" ControlStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLeaveTime" runat="server" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                         </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LEAVE AMOUNT" ControlStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLeaveAmt" runat="server" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LATE TIME" ControlStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtlateTime" runat="server" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LATE AMOUNT" ControlStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtLateAmt" runat="server" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OT AMOUNT" ControlStyle-Width="140px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOtAmt" runat="server" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    
                                </asp:GridView>
                                <br />
                                &nbsp;<asp:Button ID="btnsalarycal" runat="server" ForeColor="Black" Height="28px" Text="Calculate" Width="135px" OnClick="btnsalarycal_Click" Visible="False" />
                            </asp:Panel>
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
    </form>
</body>
</html>

