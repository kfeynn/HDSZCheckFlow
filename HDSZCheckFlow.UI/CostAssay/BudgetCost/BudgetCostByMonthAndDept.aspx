<%@ Page language="c#" Codebehind="BudgetCostByMonthAndDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCostByMonthAndDept" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetCostByMonthAndDept</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT>
			<asp:label id="Label1" style="Z-INDEX: 104; POSITION: absolute; TOP: 24px; LEFT: 32px" runat="server">部门预实分析</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 107; POSITION: absolute; TOP: 104px; LEFT: 32px"
				runat="server" AutoGenerateColumns="False" Height="80px" Width="100%">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="Dispname" HeaderText="科目">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="oneQ" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="twoQ" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="oneH" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="changemoney" HeaderText="调整金额" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="localRealCost" HeaderText="发生金额" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="overspend" HeaderText="超支金额" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="costPY" HeaderText="实/预">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<TABLE id="Table1" style="Z-INDEX: 106; POSITION: absolute; WIDTH: 848px; HEIGHT: 40px; TOP: 48px; LEFT: 32px"
				cellSpacing="1" cellPadding="1" width="848" border="0">
				<TR>
					<TD><FONT face="宋体">帐&nbsp;&nbsp;&nbsp; 套：</FONT></TD>
					<TD>
						<asp:DropDownList style="Z-INDEX: 0" id="ddlAccBook" runat="server" Width="150px"></asp:DropDownList></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">查询月份：</FONT></TD>
					<TD><asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})" runat="server"
							Width="150px"></asp:textbox></TD>
					<TD><FONT face="宋体">部门</FONT></TD>
					<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
					<TD><asp:button id="btnQuery" runat="server" Width="64px" Text="查询" CssClass="inputbutton"></asp:button></TD>
					<TD><asp:label id="lblMessage" runat="server" Width="113px"></asp:label>
						<asp:Button id="Button1" runat="server" Width="84px" CssClass="inputbutton" Text="导出" Visible="False"></asp:Button>
						<asp:Button id="btnOutPrint" runat="server" Width="81px" CssClass="inputbutton" Text="打印" Visible="False"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
