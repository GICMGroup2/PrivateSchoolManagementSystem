<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS005_StudentDetail.aspx.cs" Inherits="HomeASP.SMS005" %>

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
        #bookingForm
        {
            height: 769px;
            width: 797px;
            margin-right: 0px;
            margin-top: 0px;
            margin-bottom: 95px;
            margin-left: 0px;
        }

        #tablepadding
        { padding-top:2px;
          padding-bottom:1px;
          margin-left:10px;
          margin-right:5px;
        }
        
        #stupagedetailinner {
    width:100%;
    margin:5px 7px 7px 0px;
    background-color:#1A7EBA!important;
    padding:100px 120px;
    min-height:520px;
    min-width:800px;
}   
   #stupagewrapper {
   
    min-height: 600px;
    background:#F3F3F3;
    margin: 0px 0px 0px 170px;
   
}    
        .auto-style1
        {
            width: 225px;
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
    <div id="Div1" class="wrapper col1" runat="server">
        <div style="width: 1109px; height: 560px; color: #FFFFFF; background-color: #1A7EBA; padding: 0px; border-spacing: 0px;">
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
                        <div id="stupagedetailinner">
                            <form id="bookingForm" runat="server">

                                &nbsp;<asp:Image ID="picturebox" runat="server" Height="133px" Width="142px" />

                                <br />
                                
                                <div style="width: 937px">
                                                                  
                                <table align="left" style="background-color:#302c2c; height: 493px; width: 450px; margin-right: 47px;">
                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label1" Text="ID" runat="server" /></td> 
                                     <td><asp:Label ID="lblID" Text="Show ID" runat="server" /></td>
                                </tr>  
                                     
                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label2" Text="Name" runat="server" /></td> 
                                     <td><asp:Label ID="lblName" Text="Show Name" runat="server" /></td>
                                </tr> 

                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label3" Text="Roll No" runat="server" /></td> 
                                     <td><asp:Label ID="lblRoll" Text="Show Roll" runat="server" /></td>
                                </tr> 

                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label4" Text="Date of Birth" runat="server" /></td> 
                                     <td><asp:Label ID="lbldob" Text="Show dob" runat="server" /></td>
                                </tr> 
                                                                   
                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label5" Text="NRC No" runat="server" /></td> 
                                     <td><asp:Label ID="lblNrc" Text="Show NRC" runat="server" /></td>
                                </tr> 

                                <tr> <td>&nbsp; &nbsp;<asp:Label ID="Label" Text="Gender" runat="server" /></td>
                                     <td><asp:Label ID="lblGender" Text="Show Gender" runat="server" /></td>
                                </tr>

                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label6" Text="Grade" runat="server" /></td> 
                                     <td><asp:Label ID="lblGrade" Text="Show Grade" runat="server" /></td>
                                </tr> 

                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="ll" Text="Room" runat="server" /></td>
                                     <td><asp:Label ID="lblRoom" Text="Show Room" runat="server" /></td>
                                </tr>

                                <tr> <td>&nbsp;&nbsp; <asp:Label ID="Label7" Text="Education Year" runat="server" /></td> 
                                     <td><asp:Label ID="lblClass" Text="Show Class" runat="server" /></td>
                                </tr> 

                                <tr>
                                    <td>&nbsp;&nbsp; <asp:Label ID="Label8" Text="Phone No" runat="server"></asp:Label></td>
                                    <td><asp:Label ID="lblPhone" Text="Show Phone" runat="server" /></td>
                                </tr>
                                </table>
                                
                                
                                
                                <table align="right" style="background-color:#302c2c; height: 494px; width: 443px; margin-right: 47px;">
                                <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label9" Text="Father Name" runat="server" /></td> 
                                     <td><asp:Label ID="lblFather" Text="Show Fname" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label10" Text="Mother Name" runat="server" /></td> 
                                     <td><asp:Label ID="lblMother" Text="Show Mname" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label11" Text="Address" runat="server" /></td> 
                                     <td><asp:Label ID="lblAddress" Text="Show Address" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label12" Text="Contact Phone" runat="server" /></td> 
                                     <td><asp:Label ID="lblCphone" Text="Show Phone" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label13" Text="Email" runat="server" /></td> 
                                     <td><asp:Label ID="lblEmail" Text="Show Email" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label14" Text="Password" runat="server" /></td> 
                                     <td><asp:Label ID="lblPwd" Text="Show Pwd" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label15" Text="CashType" runat="server" /></td> 
                                     <td><asp:Label ID="lblCashtype" Text="Show Ctype" runat="server" /></td>
                                </tr> 

                                    <tr> <td class="auto-style1">&nbsp;&nbsp; <asp:Label ID="Label16" Text="Cash Month" runat="server" /></td> 
                                     <td><asp:Label ID="lblCashMonth" Text="Show Month" runat="server" /></td>
                                </tr> 
                                </table>
                                </div>

                                <br />
                                <div align="center">
                                
                                
                                <asp:Button ID="btnprevious" runat="server" Text="Previous" ForeColor="#FF0066" OnClick="btnprevious_Click" Width="101px" OnClientClick="window.open('SMS004_StudentList.aspx','OtherPage');" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnedit" runat="server" Text="Edit" Width="101px" ForeColor="#FF0066" OnClick="btnedit_Click" OnClientClick="window.open('SMS003_StudentEntry.aspx','OtherPage');" />
                                 &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnprint" runat="server" Text="Print" ForeColor="#FF0066" Width="101px" OnClick="btnprint_Click"/>
                                </div>
                            </form>
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
</body>
</html>

