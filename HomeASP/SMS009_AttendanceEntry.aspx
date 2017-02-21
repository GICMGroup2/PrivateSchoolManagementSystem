<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS009_AttendanceEntry.aspx.cs" Inherits="HomeASP.SMS009" %>

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

    <link rel="stylesheet" href="styles/jquery-ui.css">
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
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
                        <a href="SMS002_GradeSubjectEntry.aspx">Login</a>
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

                                            <asp:Label ID="year" runat="server" Text="EDU Year" ForeColor="Black"></asp:Label>
                                            <asp:DropDownList ID="eduYearList" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="110px">
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

                                            <asp:Label ID="grade" runat="server" Text="Grade" ForeColor="Black"></asp:Label>
                                            <asp:DropDownList ID="gradeList" runat="server" AppendDataBoundItems="true" ForeColor="Black" Width="120px">
                                            </asp:DropDownList>

                                            <asp:Label ID="room" runat="server" Text="Room" ForeColor="Black"></asp:Label>
                                            <asp:DropDownList ID="roomList" runat="server" ForeColor="Black" Width="120px">
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

                                            <asp:Label ID="date" runat="server" Text="Date" ForeColor="Black"></asp:Label>
                                            <asp:TextBox CssClass="datepicker" ID="attendDate" Style="color: black" runat="server" Width="150px" OnTextChanged="fillDate" AutoPostBack="true" />
                                            <br />
                                            <asp:Button class="btn_display" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                        </div>                                        
                                        <br />
                                        <br />
                                        <br />
                                        <div class="table-responsive">
                                            <asp:GridView ID="gridViewAttendance" AutoGenerateColumns="false" runat="server" BackColor="#1A74BA" Width="300px" Style="float: left;" ForeColor="White">
                                                <Columns>
                                                    <asp:BoundField HeaderText="ID"
                                                        DataField="STUDENT_ID"
                                                        SortExpression="STUDENT_ID"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Name"
                                                        DataField="STUDENT_NAME"
                                                        SortExpression="STUDENT_NAME"></asp:BoundField>
                                                    <asp:BoundField HeaderText="Roll no"
                                                        DataField="ROLL_NO"
                                                        SortExpression="ROLL_NO"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="AM">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="AM" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PM">
                                                        <ItemTemplate>                                                            
                                                            <asp:CheckBox ID="PM" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>                                                   
                                                            <asp:Label ID="date" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                    
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <br />
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Button class="btn_display" ID="btnCheckAM" runat="server" Text="Check/Uncheck(AM)" OnClick="btnCheckAllAM_Click" />
                                        <asp:Button class="btn_display" ID="btnCheckPM" runat="server" Text="Check/Uncheck(PM)" OnClick="btnCheckAllPM_Click" />
                                        <asp:Button class="btn_display" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                        <asp:Button class="btn_display" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
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

