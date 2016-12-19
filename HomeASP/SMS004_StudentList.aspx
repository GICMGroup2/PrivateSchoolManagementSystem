<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS004_StudentList.aspx.cs" Inherits="HomeASP.SMS004" %>

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
    <link rel="stylesheet" href="styles/navi.css" type="text/css" />
    <script type="text/javascript">
         </script>

    <style type="text/css">
        #bookingForm
        {
            height: 498px;
            width: 909px;
            margin-right: 0px;
            margin-top: 0px;
        }
         #stupageinner {
            width:100%;
            margin:5px 7px 7px 0px;
            background-color:#1A7EBA!important;
            padding:100px 150px;
            min-height:520px;
            min-width:800px;
        }   
         #stupagewrapper {
   
            min-height: 600px;
            background:#F3F3F3;
            margin: 0px 0px 0px 170px;                  
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
                    <div id="stupagewrapper">
                        <div id="stupageinner">
                            <form id="bookingForm" runat="server">
                                
                                <asp:Table runat="server" CellSpacing="0" ForeColor="White" Height="94px" CellPadding="3" Width="795px"> 
                                <asp:TableRow>

                                <asp:TableCell>
                                <asp:Label runat="server" Text="Name"> </asp:Label>&nbsp; &nbsp; &nbsp;
                                <asp:TextBox ID="stulistname" runat="server" Width="166px"></asp:TextBox> </asp:TableCell>

                                <asp:TableCell><asp:Label runat="server" Text="Grade"></asp:Label>&nbsp; &nbsp;
                                <asp:DropDownList ID="stulistgrade" runat="server" Height="33px" Width="168px"> </asp:DropDownList></asp:TableCell>

                                <asp:TableCell><asp:Label  runat="server" Text="Student ID"></asp:Label>&nbsp; &nbsp;
                                <asp:TextBox ID="stulistid" runat="server" Width="166px"></asp:TextBox><br /></asp:TableCell></asp:TableRow>


                                <asp:TableRow><asp:TableCell>
                                <asp:Label ID="Label2" runat="server" Text="Roll No"></asp:Label>&nbsp; &nbsp;
                                <asp:TextBox ID="stulistroll" runat="server" Width="166px"></asp:TextBox></asp:TableCell>
                              
                                    
                               
                                <asp:TableCell> 
                                
                                <asp:Label Text="Class" runat="server"></asp:Label> &nbsp; &nbsp;
                                    <asp:DropDownList ID="stulistclass" runat="server" Height="33px" Width="168px"> </asp:DropDownList>
                                </asp:TableCell>

                                <asp:TableCell>
                               
                                <asp:Label ID="Label4" runat="server" Text="Class Year"></asp:Label>&nbsp; &nbsp;
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="33px" Width="166px"> </asp:DropDownList>

                                </asp:TableCell>
                                    </asp:TableRow>
                               </asp:Table> 
                                <br />

                                <div align="center">

                                    <asp:Button ID="search" runat="server" Text="Search" BackColor="Gray" Width="103px" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="searchall" runat="server" Text="Search All" BackColor="Gray" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="detail" runat="server" Text="Detail" BackColor="Gray" Width="103px" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="add" runat="server" Text="Add" BackColor="Gray" Width="103px" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="edit" runat="server" Text="Edit" BackColor="Gray" Width="103px" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                  
                                </div>
                                 <br />
                          <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="400" Width="800"></asp:TextBox>
                        <script type="text/javascript">
                         window.onload = function () {
                         var textarea = document.getElementById('<%=TextBox2.ClientID %>');
                         textarea.scrollTop = textarea.scrollHeight;
                            }
                        </script>
                                
                           
                                
                            </form>
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
</body>
</html>

