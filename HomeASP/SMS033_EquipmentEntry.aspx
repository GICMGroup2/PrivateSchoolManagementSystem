<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SMS033_EquipmentEntry.aspx.cs" Inherits="HomeASP.SMS033" %>

<!-- Layout -->
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Equipment Entry </title>
    <link rel="stylesheet" href="styles/layout.css" type="text/css" />
    <link rel="stylesheet" href="styles/custom.css" type="text/css" />
    <link rel="stylesheet" href="styles/font-awesome.css" type="text/css" />
    <link rel="stylesheet" href="styles/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="styles/style.css" type="text/css" />
    <link rel="stylesheet" href="styles/booking.css" type="text/css" />
    <link rel="stylesheet" href="styles/BgImage.css" type="text/css" />
    <link rel="stylesheet" href="http://localhost:59463/code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>
</head>

<body>
    <div>
        <div id="logoimg" runat="server">
            <table>
                <tr>
                    <th style="background-color: #358A90">
                        <asp:Image ID="logoImage" runat="server" Height="105px" Width="150px" /></th>
                    <%--<asp:Image ID="logoImage" runat="server" class="ressize"/></th>--%>
                    <th width="1200px" style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; text-align: center; height: 50px; color: #7AE995; background-color: #358A90; line-height: 50px;">
                        <asp:Label ID="labtitle" runat="server" Style="font-family: 'Times New Roman', Times, serif; font-size: xx-large; font-weight: normal; font-style: normal; font-variant: normal; text-transform: none; text-align: center; height: 50px; color: #7AE995; background-color: #358A90; line-height: 50px;">Student Management System</asp:Label></th>
                </tr>
            </table>
        </div>
    </div>

    <div class="wrapper col2">

        <div style="background-color: #b1f2eb">
            <div id="topnav" style="background-color: #b1f2eb">
                <div class="noneimageli" style="background-color: #b1f2eb">
                    <ul>
                        <li class="active">
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="stdInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Student Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS003_StudentEntry.aspx">Student Entry</a></li>
                                <li><a href="SMS004_StudentList.aspx">Student List</a></li>
                                <li><a href="SMS017_StudentCashDetail.aspx">Payment</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="attendanceInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Attendance Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS009_AttendanceEntry.aspx">Attendance Entry</a></li>
                                <li><a href="SMS010_AttendanceList.aspx">Attendance List</a></li>
                                <li><a href="SMS022_ClassTimetableDisplay.aspx">Class Timetable</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="examInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Exam Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS006_StudentResultEntry.aspx">Exam Result Entry</a></li>
                                <li><a href="SMS007_StudentResultList.aspx">Exam Result</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="teacherInfo" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="Teacher Information" /><br />
                            </a>
                            <ul>
                                <%--<li><a href="#">Account Creation</a></li>--%>
                                <li style="opacity: 0.5"><a href="SMS023_StaffEntry.aspx">Staff Entry</a></li>
                                <li style="opacity: 0.5"><a href="SMS024_StaffList.aspx">Staff List</a></li>
                                <li style="opacity: 0.5"><a href="SMS030_SalaryCalculation.aspx">Salary Calculation</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="#" style="background-color: #b1f2eb">
                                <asp:Image ID="system" runat="server" Style="border-radius: 7px 7px" Height="100px" Width="150px" BackColor="#1A74BA" ToolTip="System Information" /><br />
                            </a>
                            <ul>
                                <li><a href="SMS028_ExpenseList.aspx">Expense List</a></li>
                                <li><a href="SMS034_EquipmentDisplay.aspx">Equipment List</a></li>
                                <li><a href="SMS032_OfficialDocDisplay.aspx">Official Doc</a></li>
                                <li><a href="SMS026_EventsNewsEntry.aspx">Events and News Entry</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <br class="clear" />
        </div>
    </div>
    <div id="Div1" class="wrapper col1" runat="server" height="561px" style="background-color: #b1f2eb">
        <div style="width: 150px; height: 550px; color: #FFFFFF; background-color: #1A7EBA; padding: 0px; border-spacing: 0px;">
            <%-- <br />--%>
            <div class="sidebar-collapse">
                <ul class="nav" id="main-menu" style="width: 150px">
                    <li>
                        <a href="Default.aspx">Home</a>
                    </li>
                    <li>
                        <a href="Contact.aspx">Logout</a>
                    </li>
                    <li>
                        <a href="index.html">Exit</a>

                    </li>
                </ul>

                <div id="page-separate" style="background-color: #b1f2eb">
                    <div id="no-padding">
                        <form id="cashFrm" runat="server">
                            <div style="float: left; padding: 20px 20px 20px 20px">
                                <table id="cashTbl" style="padding: 20px 20px 20px 20px" runat="server">
                                    <tr class="spaceUnder">
                                        <td>
                                            <asp:Label ID="Label3" CssClass="Lab-format" runat="server">Year*</asp:Label></td>
                                        <td><span style="margin-left: 2em">:</span></td>
                                        <td>
                                            <asp:DropDownList ID="CoboYear1" CssClass="Txtbox-format" runat="server" AutoPostBack="true" Width="198px">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>2010-2011</asp:ListItem>
                                                <asp:ListItem>2011-2012</asp:ListItem>
                                                <asp:ListItem>2012-2013</asp:ListItem>
                                                <asp:ListItem>2013-2014</asp:ListItem>
                                                <asp:ListItem>2014-2015</asp:ListItem>
                                                <asp:ListItem>2015-2016</asp:ListItem>
                                                <asp:ListItem>2016-2017</asp:ListItem>
                                                <asp:ListItem>2017-2018</asp:ListItem>
                                                <asp:ListItem>2018-2019</asp:ListItem>
                                                <asp:ListItem>2019-2020</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="LabDate" CssClass="Lab-format" runat="server">Date*</asp:Label></td>
                                        <td>
                                            <asp:TextBox CssClass="datepicker" ID="EqpDate" Style="color: black" runat="server" Width="140px" /></td>
                                    </tr>
                                    <tr class="spaceUnder">
                                        <td>
                                            <asp:Label ID="LabEqpName" CssClass="Lab-format" runat="server">Equipment Name</asp:Label></td>
                                        <td><span style="margin-left: 2em">:</span></td>
                                        <td>
                                            <asp:DropDownList ID="CoboEquipName" CssClass="Txtbox-format" AutoPostBack="true" AppendDataBoundItems="true" runat="server">
                                                
                                            </asp:DropDownList>
                                        </td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="LabQty" CssClass="Lab-format" runat="server">Quantity</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TxtQty" CssClass="Txtbox-format" runat="server" ForeColor="Black" Width="200px"></asp:TextBox></td>
                                    </tr>
                                    <tr class="spaceUnder">
                                        <td>
                                            <asp:Label ID="LabType" CssClass="Lab-format" runat="server">Type</asp:Label></td>
                                        <td><span style="margin-left: 2em">:</span></td>
                                        <td>
                                            <asp:TextBox ID="TxtType" CssClass="Txtbox-format" Style="color: black" runat="server" Width="198px" /></td>
                                        <td><span style="margin-left: 2em"></span></td>
                                        <td>
                                            <asp:Label ID="LabRemark" CssClass="Lab-format" runat="server">Remark</asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="TxtRemark" CssClass="Txtbox-format" runat="server" ForeColor="Black" Width="199px"></asp:TextBox></td>
                                    </tr>
                                </table>
                                <div>
                                    <asp:Button ID="ButSave" Text="Save" runat="server" Style="text-align: center; color: black; border-radius: 3px 3px; margin: 4px 100px 2px 4px; float: right" OnClick="btnSave_Click" />
                                    <asp:Button ID="BtnConfirm" runat="server" Text="Confirm" Style="text-align: center; color: black; border-radius: 3px 3px; margin: 4px 100px 2px 4px; float: right; float: right" OnClick="BtnConfirm_Click" />
                                </div>
                            </div>

                            <div id="dd" style="float: right; padding: 5px 5px 0px 0px; margin: 0px 0px 0px 0px;">
                                <asp:Panel ID="EqmMstEntPannel" runat="server" CssClass="mst-entry-format" GroupingText="Equipment Name Entry" Visible="true">
                                    <asp:Label ID="LabEquipId" CssClass="Lab-format" runat="server">ID*</asp:Label>
                                    <span style="margin-left: 1em; color: black" />:<span style="margin-left: 1em" />
                                    <asp:TextBox ID="TxtEquipID" CssClass="Txtbox-format" runat="server" ForeColor="Black"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Label ID="LabEquipName" CssClass="Lab-format" runat="server">Name*</asp:Label>
                                    <span style="margin-left: 2em"></span>
                                    <asp:TextBox ID="TxtEqpName" CssClass="Txtbox-format" Style="color: black" runat="server" Width="198px" /></td>
                                    <br />
                                    <br />
                                    <asp:Label ID="LabYear" CssClass="Lab-format" runat="server">Year*</asp:Label>
                                    <span style="margin-left: 2em"></span>
                                    <asp:DropDownList ID="CoboYear" CssClass="Txtbox-format" runat="server" AutoPostBack="true">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>2010-2011</asp:ListItem>
                                        <asp:ListItem>2011-2012</asp:ListItem>
                                        <asp:ListItem>2012-2013</asp:ListItem>
                                        <asp:ListItem>2013-2014</asp:ListItem>
                                        <asp:ListItem>2014-2015</asp:ListItem>
                                        <asp:ListItem>2015-2016</asp:ListItem>
                                        <asp:ListItem>2016-2017</asp:ListItem>
                                        <asp:ListItem>2017-2018</asp:ListItem>
                                        <asp:ListItem>2018-2019</asp:ListItem>
                                        <asp:ListItem>2019-2020</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Button ID="BtnEquipSave" Text="Save" runat="server" Style="text-align: center; border-radius: 3px 3px; margin: 4px 50px 2px 4px; float: right" OnClick="save_Click" />
                                </asp:Panel>
                            </div>
                            <div id="Div2" runat="server" style="padding:10px 10px 10px 10px">

                                <asp:GridView ID="EqpList" class="cashList-Frm" Width="100%" runat="server" CellPadding="4" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellSpacing="3">
                                    <AlternatingRowStyle Wrap="False" />
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>

                            </div>
                            <div id="btnDiv" style="float:right; padding: 10px 70px 0px 0px;">
                                <asp:button ID="BtnUpdate" Text="Update" BackColor="White" ForeColor="Black" runat="server" OnClick="Update_Click"></asp:button>&nbsp&nbsp
                                <asp:button ID="BtnDelete" Text="Delete" BackColor="White" ForeColor="Black" runat="server" OnClick="Delete_Click"></asp:button>
                            </div>
                        </form>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
