<%@ Page language="c#" Codebehind="BudgetCost.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCost" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetCost</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../Style/My97DatePicker/WdatePicker.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����">
				<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 40px" runat="server">Ԥʵ����</asp:Label>
				<asp:DataGrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 128px"
					runat="server" Width="864px" Height="80px" AutoGenerateColumns="False">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
					<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="iyear" HeaderText="���"></asp:BoundColumn>
						<asp:BoundColumn DataField="imonth" HeaderText="�·�"></asp:BoundColumn>
						<asp:BoundColumn DataField="budget_DeptName" HeaderText="����"></asp:BoundColumn>
						<asp:BoundColumn DataField="Dispname" HeaderText="��Ŀ"></asp:BoundColumn>
						<asp:BoundColumn DataField="budgetMoney" HeaderText="Ԥ����"></asp:BoundColumn>
						<asp:BoundColumn DataField="PlanMoney" HeaderText="������"></asp:BoundColumn>
						<asp:BoundColumn DataField="changeMoney" HeaderText="�������"></asp:BoundColumn>
						<asp:BoundColumn DataField="localRealCost" HeaderText="�������"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid></FONT>
			<TABLE id="Table1" style="Z-INDEX: 103; LEFT: 24px; WIDTH: 640px; POSITION: absolute; TOP: 64px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="640" border="0">
				<TR>
					<TD><FONT face="����">�����ѯ�·ݣ�</FONT></TD>
					<TD>
						<asp:TextBox id="txtDate" runat="server" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy��MM��'})"></asp:TextBox></TD>
					<TD>
						<asp:Button id="btnQuery" runat="server" Width="64px" Text="��ѯ" CssClass="inputbutton"></asp:Button></TD>
					<TD>
						<asp:Label id="lblMessage" runat="server" Width="164px"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
