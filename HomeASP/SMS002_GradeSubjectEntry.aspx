<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS002_GradeSubjectEntry.aspx.cs" Inherits="HomeASP.SMS002" %>

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
                                    <form id="GradeSubjectForm" runat="server">
                                        <div style="float:left;">
                                            <asp:Label runat="server" Text="ID" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="gradeId" runat="server" ForeColor="Black" Width="100px"></asp:TextBox>
                                            <asp:Label ID="grade" runat="server" Text="Grade" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="gradeName" runat="server" ForeColor="Black" Width="136px"></asp:TextBox><br /><br />
                                            <asp:Button class="btn_display" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                            <asp:Button class="btn_display" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                            <asp:Button class="btn_display" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                                        </div>
                                        <div class="table-responsive">                                       
                                            <asp:GridView ID="gridViewGrade" AutoGenerateColumns="true" runat="server" BackColor="#1A74BA" Width="300px" style="float:right;" ForeColor="White">
                                            </asp:GridView>
                                            <br />
                                            <br />
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <div style="float:left;">
                                            <asp:Label runat="server" Text="ID" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="subjectId" runat="server" ForeColor="Black" Width="100px"></asp:TextBox>
                                            <asp:Label ID="subject" runat="server" Text="Subject" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="subjectName" runat="server" ForeColor="Black" Width="136px"></asp:TextBox><br /><br />
                                            <asp:Button class="btn_display" ID="subjectAdd" runat="server" Text="Add" OnClick="btnSubjectAdd_Click" />
                                            <asp:Button class="btn_display" ID="subjectUpdate" runat="server" Text="Update" OnClick="btnSubjectUpdate_Click" />
                                            <asp:Button class="btn_display" ID="subjectDelete" runat="server" Text="Delete" OnClick="btnSubjectDelete_Click" />
                                        </div>
                                        <div class="table-responsive">                                       
                                            <asp:GridView ID="gridViewSubject" AutoGenerateColumns="true" runat="server" BackColor="#1A74BA" Width="300px" style="float:right;" ForeColor="White">
                                            </asp:GridView>
                                            <br />
                                            <br />
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <div style="float:left;">
                                            <asp:Label runat="server" Text="ID" ForeColor="Black"></asp:Label>
                                            <asp:TextBox ID="gradeSubjectId" runat="server" ForeColor="Black" Width="100px"></asp:TextBox>
                                            <asp:Label runat="server" Text="Grade" ForeColor="Black"></asp:Label>
                                            <asp:DropDownList ID="gradeList" Width="200px" runat="server" ForeColor="Black"></asp:DropDownList><br /><br />
                                            <asp:GridView ID="subjectGridView" AutoGenerateColumns="false" runat="server" BackColor="#1A74BA" Width="200px" Visible="true" ForeColor="White">
                                                <Columns>
                                                    <asp:templatefield HeaderText="Select">
                                                        <itemtemplate>
                                                            <asp:checkbox ID="selectedSubject" runat="server"></asp:checkbox>
                                                        </itemtemplate>
                                                    </asp:templatefield>
                                                    <asp:BoundField HeaderText="Subject" 
                                                    DataField="SUBJECT_NAME"                                                    
                                                    SortExpression="SUBJECT_NAME"></asp:BoundField>
                                                    <asp:BoundField HeaderText="ID" 
                                                    DataField="SUBJECT_ID"                                                    
                                                    SortExpression="SUBJECT_ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" ></asp:BoundField>
                                                </Columns>
                                            </asp:GridView><br />
                                            <asp:Button class="btn_display" ID="gradeSubjectAdd" runat="server" Text="Add" OnClick="btnGradeSubjectAdd_Click" />
                                            <asp:Button class="btn_display" ID="gradeSubjectUpdate" runat="server" Text="Update" OnClick="btnGradeSubjectUpdate_Click" />
                                            <asp:Button class="btn_display" ID="gradeSubjectDelete" runat="server" Text="Delete" OnClick="btnGradeSubjectDelete_Click" />
                                        </div>
                                        <div class="table-responsive">                                       
                                            <asp:GridView ID="gradeSubjectGridView" AutoGenerateColumns="false" runat="server" BackColor="#1A74BA" Width="300px" style="float:right;" ForeColor="White">
                                                <Columns>
                                                    <asp:BoundField ReadOnly="True" 
                                                      HeaderText="Year" InsertVisible="False" 
                                                      DataField="EDU_YEAR"
                                                        SortExpression="EDU_YEAR"></asp:BoundField>
                                                    <asp:BoundField HeaderText="ID" 
                                                      DataField="ID" SortExpression="ID">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Grade" 
                                                      DataField="GRADE_ID" SortExpression="GRADE_ID">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Subject" 
                                                      DataField="SUBJECT_ID_LIST" SortExpression="SUBJECT_ID_LIST">
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
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

