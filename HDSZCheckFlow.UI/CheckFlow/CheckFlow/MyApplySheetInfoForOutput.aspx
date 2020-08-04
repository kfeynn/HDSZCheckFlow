<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyApplySheetInfoForOutput.aspx.cs" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.MyApplySheetInfoForOutput" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html  >
<head runat="server">
    <title>无标题页</title>
    		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center"><FONT face="宋体">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="6"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 17px">部&nbsp; 门</TD>
									<TD style="HEIGHT: 17px">
										<asp:DropDownList id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:DropDownList></TD>
									<TD style="HEIGHT: 17px">起始日期</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtDateFrom" runat="server" onfocus="WdatePicker()" Width="90px"></asp:TextBox></TD>
									<TD align="left" style="HEIGHT: 17px">结束日期</TD>
									<TD style="HEIGHT: 17px">
										<FONT face="宋体"><asp:TextBox id="txtDateTo" runat="server" onfocus="WdatePicker()" Width="90px"></asp:TextBox></FONT></TD>
									<TD style="HEIGHT: 17px"><FONT face="宋体">
						&nbsp;申请类型</FONT></TD>
					                <td><FONT face="宋体">
							            <asp:DropDownList id="ddlType" runat="server" Width="90px">
                                            <asp:ListItem Value=""></asp:ListItem>
                                            <asp:ListItem Value="1">实物类</asp:ListItem>
                                            <asp:ListItem Value="2">费用类</asp:ListItem>
                                            <asp:ListItem Value="3">差旅类</asp:ListItem>
                                        </asp:DropDownList>
						</FONT>
					                </td>  <td></td> 
									<TD style="HEIGHT: 17px;width:40%" align="left" >
										<FONT face="宋体">
										<asp:button id="btnQuery" runat="server" Width="72px" Text="查询" 
                                            CssClass="redButtonCss" onclick="btnQuery_Click"></asp:button>
						                &nbsp;<asp:button id="btnOutPut" runat="server" Width="72px" Text="导出" 
                                            CssClass="redButtonCss" onclick="btnOutPut_Click"></asp:button>
						&nbsp;</FONT><asp:Label ID="lblMessage" runat="server"></asp:Label></TD>
								</TR>
								<TR>
								<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD align="center">&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD align="left">
										<FONT face="宋体">
										&nbsp;</FONT></TD>
								</TR>
								<tr>
									<td height="26" colspan="10">  <asp:GridView ID="GridView1" runat="server" 
                                            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                        <RowStyle BackColor="#EFF3FB" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle BackColor="White" />
        </asp:GridView></td>
								</tr>
							</TABLE>
						</FONT>
					</td>
				</tr>
			</table>
			
      
    
    </div>
    </form>
</body>
<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</html>
