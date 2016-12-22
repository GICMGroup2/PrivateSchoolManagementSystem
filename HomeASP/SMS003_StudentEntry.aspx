<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS003_StudentEntry.aspx.cs" Inherits="HomeASP.SMS003" %>

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
    
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=TextBox1.ClientID %>").dynDateTime({
               showsTime: true,
               ifFormat: "%Y/%m/%d %H:%M",
               daFormat: "%l;%M %p, %e %m,  %Y",
               align: "BR",
               electric: false,
               singleClick: false,
               displayArea: ".siblings('.dtcDisplayArea')",
               button: ".next()"
           });
       });
    </script>

    <style type="text/css">
        #bookingForm
        {
            height: 713px;
            width: 797px;
            margin-right: 0px;
            margin-top: 0px;
        }

        #tablepadding
        { padding-top:2px;
          padding-bottom:1px;
          margin-left:10px;
          margin-right:5px;
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
                                   <div>
                                        
                                         <asp:Table runat="server" >
                                          <asp:TableRow> <asp:TableCell> <asp:Image ID="stupicture" runat="server" Width="145px" BackColor="Gray" ForeColor="White" /><br />
                                          <asp:Button ID="btnpicture" runat="server" BorderStyle="Ridge" Text="Choose Photo" ForeColor="#CC0099" /></asp:TableCell>

                                          <asp:TableCell><div>
                                                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label1"  runat="server" Text="Name" ForeColor="White"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="stuname" runat="server"></asp:TextBox><br /><br />
                                                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label2"  runat="server" Text="Grade" ForeColor="White"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="stugrade" runat="server"></asp:TextBox><br /><br />
                                                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label3"  runat="server" Text="Student ID" ForeColor="White"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="stuid" runat="server"></asp:TextBox><br /><br />
                                                        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label4"  runat="server" Text="Roll No." ForeColor="White"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="rollno" runat="server"></asp:TextBox><br />


                                                         </div> 
                                                         

                                        </asp:TableCell> </asp:TableRow>   </asp:Table>                        
                                                                                                                                                                                                                                                                                                                                                 
                                         <br />
                                         
                                         <br />
                                  
                                <div style="height: 382px; width: 794px;">  
                                                                                                  
                                  <asp:Table runat="server" align="left" Width="359px" CellPadding="2"  CellSpacing="0" Height="326px">
                                                                                                                    
                                  <asp:TableRow ID="TableRow1" runat="server"  ForeColor="#FFFFCC"><asp:TableCell>Genter </asp:TableCell> 
                                  <asp:TableCell><asp:RadioButton ID="Male" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" GroupName="Gender" />Male &nbsp; &nbsp; &nbsp;
                                                 <asp:RadioButton ID="Female" runat="server" GroupName="Gender" /> Female</asp:TableCell> </asp:TableRow>
                                           
                                                                           
                                  <asp:TableRow runat="server"><asp:TableCell runat="server"  ForeColor="#FFFFCC">Class</asp:TableCell> 
                                                               <asp:TableCell> <asp:DropDownList ID="stuclass" runat="server"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="192px"> </asp:DropDownList> </asp:TableCell> 
                                  </asp:TableRow>                                            
                                                                                                                
                                  <asp:TableRow runat="server"><asp:TableCell  ForeColor="#FFFFCC"> Date of Birth </asp:TableCell> 
                                                               <asp:TableCell > <asp:TextBox ID="TextBox1" runat="server" ReadOnly = "true" Width="150px"></asp:TextBox></asp:TableCell><asp:TableCell><img src="Images/calender.png" /></asp:TableCell>
                                  </asp:TableRow>

                                       
                                                                                                    
                                  <asp:TableRow runat="server"><asp:TableCell  ForeColor="#FFFFCC">NRC No. </asp:TableCell>
                                                               <asp:TableCell>  <asp:TextBox ID="nrcno" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell>
                                  </asp:TableRow>  

                                  <asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Education Year"  ForeColor="#FFFFCC"></asp:Label></asp:TableCell>
                                                <asp:TableCell><asp:TextBox ID="edudate" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell></asp:TableRow>
                                 
                                  <asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Class Type"  ForeColor="#FFFFCC"></asp:Label></asp:TableCell>
                                                <asp:TableCell><asp:DropDownList ID="stuclasstype" runat="server" Width="192px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"> </asp:DropDownList></asp:TableCell></asp:TableRow>
                                  </asp:Table>       
                                 
                                  <asp:Table runat="server" align="center" Height="324px"  Width="365px" CellPadding="2">

                                  <asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Father Name" ForeColor="White"></asp:Label> </asp:TableCell>
                                                <asp:TableCell><asp:TextBox ID="father" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell>
                                  </asp:TableRow>

                                  <asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Mother Name" ForeColor="White"></asp:Label></asp:TableCell>
                                                <asp:TableCell><asp:TextBox ID="mother" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell>
                                  </asp:TableRow>

                                  <asp:TableRow><asp:TableCell ForeColor="White">  Contact Phone</asp:TableCell> 
                                                <asp:TableCell>  <asp:TextBox ID="phone" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell>  

                                  </asp:TableRow> 
                                  <asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Email" ForeColor="White"></asp:Label></asp:TableCell>
                                                <asp:TableCell><asp:TextBox ID="email" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell>

                                  </asp:TableRow>

                                  <asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Address" ForeColor="White"></asp:Label></asp:TableCell>
                                                <asp:TableCell><asp:TextBox ID="address" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell>

                                  </asp:TableRow><asp:TableRow><asp:TableCell><asp:Label runat="server" Text="Cash Type" ForeColor="White"></asp:Label></asp:TableCell>
                                                <asp:TableCell><asp:TextBox ID="stucash" runat="server" Width="190px" BorderStyle="Ridge"></asp:TextBox></asp:TableCell></asp:TableRow>
                                  
                                  </asp:Table>
                                <br />
                                </div>  
                                  </div>  
                                 <asp:Table ID="Table1" runat="server" align="center" ForeColor="#CC0099"> 
                                      <asp:TableRow><asp:TableCell> <asp:Button ID="gohome" runat="server" Text="Go Home" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell>
                                                    <asp:TableCell><asp:Button ID="showlist" runat="server" Text="Show List" Width="101px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TableCell> 
                                                    <asp:TableCell><asp:Button ID="display" runat="server" Text="Display" Width="101px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell> 
                                                    <asp:TableCell><asp:Button ID="clear" runat="server" Text="Clear" Width="101px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell> 
                                                    <asp:TableCell><asp:Button ID="exit" runat="server" Text="Exit" Width="101px" /></asp:TableCell>
                                   </asp:TableRow></asp:Table>
                                </form>
                            
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
</body>
</html>
