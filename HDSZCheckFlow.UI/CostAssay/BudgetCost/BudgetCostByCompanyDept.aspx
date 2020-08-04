<%@ Page language="c#" Codebehind="BudgetCostByCompanyDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCostByCompanyDept" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetCostByCompanyDept</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT>
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 24px" runat="server">公司合计预实分析</asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 104px"
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
			<TABLE id="Table1" style="Z-INDEX: 103; LEFT: 16px; WIDTH: 848px; POSITION: absolute; TOP: 48px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="848" border="0">
				<TR>
					<TD><FONT face="宋体">输入查询月份：</FONT></TD>
					<TD>
						<asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})" runat="server"></asp:textbox></TD>
					<TD>
						<asp:button id="btnQuery" runat="server" Width="64px" Text="查询" CssClass="inputbutton"></asp:button></TD>
					<TD>
						<asp:label id="lblMessage" runat="server" Width="164px"></asp:label>
						<asp:Button id="Button1" runat="server" Width="84px" CssClass="inputbutton" Text="导出" Visible="False"></asp:Button>
						<asp:Button id="btnOutPrint" runat="server" Text="打印" Width="81px" CssClass="inputbutton" Visible="False"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
