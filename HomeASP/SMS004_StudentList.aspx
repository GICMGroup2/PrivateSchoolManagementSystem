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

       
         .auto-style2
        {
            width: 93px;
        }

       
         .auto-style3
        {
            width: 126px;
        }

       
         .auto-style9
        {
            height: 29px;
            width: 173px;
        }
        
       
         .auto-style12
        {
            width: 89px;
            height: 29px;
        }
        .auto-style15
        {
            height: 29px;
            width: 126px;
        }
        .auto-style16
        {
            width: 69px;
            height: 29px;
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
                            <div> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:Label ID="errgrade" runat="server" Text="Please Select Grade!" ForeColor="Red" Font-Size="Medium"></asp:Label>

                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;

                            <asp:Label ID="erreducation"  runat ="server" Text="Please Select Education Year!" ForeColor="Red" Font-Size="Medium"></asp:Label></div>
                            <table style="width:85%; color: #FFFFFF; height: 59px;">
                                <tr>
                                    <td class="auto-style16"><asp:Label ID="namesearch" runat="server" Text="Name"> </asp:Label>&nbsp; &nbsp; &nbsp; </td>
                                    <td class="auto-style15"><asp:TextBox ID="searchstuname" runat="server" Width="168px" ForeColor="Black"></asp:TextBox></td>

                                   
                                    <td class="auto-style12"> &nbsp; &nbsp; <asp:Label ID="Label1" runat="server" Text="Grade"></asp:Label></td>   
                                    <td class="auto-style9"><asp:DropDownList ID="stulistgrade" runat="server" Height="33px" Width="168px" ForeColor="Black"> 
                                                            <asp:ListItem>Select </asp:ListItem>
                                                            <asp:ListItem>Grade1</asp:ListItem>
                                                            <asp:ListItem>Grade2</asp:ListItem>
                                                            <asp:ListItem>Grade3</asp:ListItem>
                                                            <asp:ListItem>Grade4</asp:ListItem>
                                                            <asp:ListItem>Grade5</asp:ListItem>
                                                            <asp:ListItem>Grade6</asp:ListItem>
                                                            <asp:ListItem>Grade7</asp:ListItem>
                                                            <asp:ListItem>Grade8</asp:ListItem>
                                                            <asp:ListItem>Grade9</asp:ListItem>
                                                            <asp:ListItem>Grade10</asp:ListItem>
                                                            </asp:DropDownList>
                                    </td>
                                     <td class="auto-style2"> <asp:Label ID="Label6" runat="server" Text="Class Year"></asp:Label>&nbsp; </td>
                                    <td class="auto-style3"><asp:DropDownList ID="comboYear" runat="server" Height="33px" Width="163px" ForeColor="Black"> 
                                                           
                                                            <asp:ListItem>Select Year</asp:ListItem>
                                                           
                                                            <asp:ListItem>2001 - 2002</asp:ListItem>
                                                            <asp:ListItem>2003-2004</asp:ListItem>
                                                            <asp:ListItem>2005-2006</asp:ListItem>
                                                            <asp:ListItem>2007-2008</asp:ListItem>
                                                            <asp:ListItem>2009-2010</asp:ListItem>
                                                            <asp:ListItem>2010-2011</asp:ListItem>
                                                            <asp:ListItem>2011-2012</asp:ListItem>
                                                            <asp:ListItem>2012-2013</asp:ListItem>
                                                            <asp:ListItem>2013-2014</asp:ListItem>
                                                            <asp:ListItem>2014-2015</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                                        
                                 </tr>
                                
                        </table>
                        <br />
                                <div>
                                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="103px" ForeColor="#FF0066" OnClick="btnSearch_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDetail" runat="server" Text="Detail" Width="103px" ForeColor="#FF0066" OnClientClick="window.open('SMS005_StudentDetail.aspx','OtherPage');" OnClick="btnDetail_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="103px" ForeColor="#FF0066" OnClientClick="window.open('SMS003_StudentEntry.aspx','OtherPage');" OnClick="btnAdd_Click1"/> &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="103px" ForeColor="#FF0066" OnClick="btnEdit_Click" OnClientClick="window.open('SMS003_StudentEntry.aspx','OtherPage');" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="103px" ForeColor="#FF0066" OnClick="btnDelete_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;
                                     &nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                  
                                </div>
                                 <br />
                                <%-- <asp:TextBox ID="showdata" runat="server" TextMode="MultiLine" Height="400" Width="800"></asp:TextBox>
                        <script type="text/javascript">
                         window.onload = function () {
                         var textarea = document.getElementById('<%=TextBox2.ClientID %>');
                         textarea.scrollTop = textarea.scrollHeight;
                            }
                        </script>
                                --%>


                           <asp:Label ID="errorSeach" ForeColor="Red" Font-Size="Medium" style="float:left" runat ="server"></asp:Label>
                           &nbsp;
                           <asp:Label ID="showerror" Font-Size="Medium" ForeColor="Red" runat="server" />
                                
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Height="222px" Width="802px">
                                    <AlternatingRowStyle BackColor="#DCDCDC" />
                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#000065" />
                                </asp:GridView>

                                

                                </form>
                        </div>
                    </div>
            </div>           
        </div>        
    </div>    
</body>
</html>

