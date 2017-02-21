<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS010_AttendanceList.aspx.cs" Inherits="HomeASP.SMS010" %>

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
                    <div id="page-inner-wrapper">
                        <div class="col-md-9 col-sm-12 col-xs-12">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <form id="AttendanceForm" runat="server">
                                        <div style="float: left;">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                DisplayMode="BulletList" ShowSummary="true" HeaderText="" ForeColor="Red" />

                                            <asp:Label ID="lblgrade" runat="server" Text="Grade" ForeColor="Black"></asp:Label>
                                            <asp:DropDownList ID="ddlGrade" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="120px">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblClass" runat="server" Text="Class" ForeColor="Black"></asp:Label>
                                            &nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlClass" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="120px">
                                                <Items>
                                                    <asp:ListItem Text="Select Room" Value="" />
                                                    <asp:ListItem Text="A" Value="A" />
                                                    <asp:ListItem Text="B" Value="B" />
                                                    <asp:ListItem Text="C" Value="C" />
                                                    <asp:ListItem Text="D" Value="D" />
                                                    <asp:ListItem Text="E" Value="E" />
                                                    <asp:ListItem Text="F" Value="F" />
                                                </Items>
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblName" runat="server" Text="Name" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="txtName" runat="server" ForeColor="Black" Width="120px"></asp:TextBox>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button class="btn_display" ID="btnSearch" runat="server" Text="Search" Width="120px" OnClick="btnSearch_Click" />
                                        </div>                                        
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Label ID="lblDay" runat="server" Text="Day" ForeColor="Black"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlDay" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="120px" OnSelectedIndexChanged="chooseDay" AutoPostBack="true">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblMonth" runat="server" Text="Month" ForeColor="Black"></asp:Label>
                                        <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="120px" OnSelectedIndexChanged="chooseMonthYear" AutoPostBack="true">
                                            <Items>
                                                <asp:ListItem Text="Select Month" Value="" />
                                                <asp:ListItem Text="01" Value="01" />
                                                <asp:ListItem Text="02" Value="02" />
                                                <asp:ListItem Text="03" Value="03" />
                                                <asp:ListItem Text="04" Value="04" />
                                                <asp:ListItem Text="05" Value="05" />
                                                <asp:ListItem Text="06" Value="06" />
                                                <asp:ListItem Text="07" Value="07" />
                                                <asp:ListItem Text="08" Value="08" />
                                                <asp:ListItem Text="09" Value="09" />
                                                <asp:ListItem Text="10" Value="10" />
                                                <asp:ListItem Text="11" Value="11" />
                                                <asp:ListItem Text="12" Value="12" />
                                            </Items>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblYear" runat="server" Text="Year" ForeColor="Black"></asp:Label>
                                        &nbsp;&nbsp;
                                        <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="120px" OnSelectedIndexChanged="chooseMonthYear" AutoPostBack="true">
                                            <Items>
                                                <asp:ListItem Text="Select Year" Value="" />
                                                <asp:ListItem Text="2016" Value="2016" />
                                                <asp:ListItem Text="2017" Value="2017" />
                                                <asp:ListItem Text="2018" Value="2018" />
                                                <asp:ListItem Text="2019" Value="2019" />
                                                <asp:ListItem Text="2020" Value="2020" />
                                                <asp:ListItem Text="2021" Value="2021" />
                                                <asp:ListItem Text="2022" Value="2022" />
                                                <asp:ListItem Text="2023" Value="2023" />
                                                <asp:ListItem Text="2024" Value="2024" />
                                                <asp:ListItem Text="2025" Value="2025" />
                                            </Items>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button class="btn_display" ID="btnClear" runat="server" Text="Clear" Width="120px" />
                                        <br /><br />
                                        <asp:GridView ID="gvAttendanceList" AutoGenerateColumns="false" runat="server" BackColor="#1A74BA" Width="300px" Style="float: left;" ForeColor="White">
                                            <Columns>
                                                <asp:BoundField HeaderText="Year"
                                                        DataField="EDU_YEAR"
                                                        SortExpression="EDU_YEAR"></asp:BoundField>
                                                <asp:BoundField HeaderText="Student ID"
                                                    DataField="STUDENT_ID"
                                                    SortExpression="STUDENT_ID"></asp:BoundField>
                                                <asp:BoundField HeaderText="Attendance ID"
                                                    DataField="ATTENDANCE_ID"
                                                    SortExpression="ATTENDANCE_ID"></asp:BoundField>
                                                <asp:BoundField HeaderText="Date"
                                                        DataField="ATTENDANCE_DATE"
                                                        SortExpression="ATTENDANCE_DATE"></asp:BoundField>
                                                <asp:BoundField HeaderText="Morning"
                                                    DataField="MORNING"
                                                    SortExpression="MORNING"></asp:BoundField>
                                                <asp:BoundField HeaderText="Evening"
                                                    DataField="EVENING"
                                                    SortExpression="EVENING"></asp:BoundField>
                                                <asp:BoundField HeaderText="Remark"
                                                    DataField="REMARK"
                                                    SortExpression="REMARK"></asp:BoundField>                                              
                                            </Columns>
                                        </asp:GridView>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>           
        </div>        
    </div>    
</body>
</html>

