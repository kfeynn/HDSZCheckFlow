<%@ Page language="c#" Codebehind="BudgetCostByYear.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCostByYear" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>����ʵ����Ȳ�ѯ</title>
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
			<FONT face="����"></FONT>
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 24px" runat="server">����ʵ����Ȳ�ѯ</asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 104px"
				runat="server" Height="80px" Width="100%" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="��Ŀ����" HeaderText="��Ŀ����">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="1�·�" HeaderText="1�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="2�·�" HeaderText="2�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="3�·�" HeaderText="3�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="1Qƽ��" HeaderText="1Qƽ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="4�·�" HeaderText="4�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="5�·�" HeaderText="5�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="6�·�" HeaderText="6�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="2Qƽ��" HeaderText="2Qƽ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="7�·�" HeaderText="7�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="8�·�" HeaderText="8�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="9�·�" HeaderText="9�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="3Qƽ��" HeaderText="3Qƽ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="10�·�" HeaderText="10�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="11�·�" HeaderText="11�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="12�·�" HeaderText="12�·�"></asp:BoundColumn>
					<asp:BoundColumn DataField="4Qƽ��" HeaderText="4Qƽ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="�ϼ�" HeaderText="�ϼ�"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			
			<div  style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 84px;width=100%">
			<table border="1" cellpadding="0" cellspacing="0" width="850px">
				<asp:Repeater ID="repDataBind" Runat="server">
					<HeaderTemplate>
						<tr align="center">
							<td style="width=80px;">��Ŀ����</td>
							<td>1�·�</td>
							<td>2�·�</td>
							<td>3�·�</td>
							<td>1Qƽ��</td>
							<td>4�·�</td>
							<td>5�·�</td>
							<td>6�·�</td>
							<td>2Qƽ��</td>
							<td>7�·�</td>
							<td>8�·�</td>
							<td>9�·�</td>
							<td>3Qƽ��</td>
							<td>10�·�</td>
							<td>11�·�</td>
							<td>12�·�</td>
							<td>4Qƽ��</td>
							<td>�ϼ�</td>
						</tr>
					</HeaderTemplate>
					<ItemTemplate>
						<tr>
							<td><%# DataBinder.Eval(Container.DataItem, "��Ŀ����") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "1�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "2�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "3�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "1Qƽ��") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "4�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "5�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "6�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "2Qƽ��") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "7�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "8�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "9�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "3Qƽ��") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "10�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "11�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "12�·�") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "4Qƽ��") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "�ϼ�") %></td>
						</tr>
					</ItemTemplate>
					<FooterTemplate>
					</FooterTemplate>
				</asp:Repeater>
			</table>
			
			</div>
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 32px; WIDTH: 848px; POSITION: absolute; TOP: 48px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="848" border="0">
				<TR>
					<TD><FONT face="����">�����ѯ��ݣ�</FONT></TD>
					<TD><asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy��'})" runat="server"></asp:textbox></TD>
					<TD><FONT face="����">����</FONT></TD>
					<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
					<TD><asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ" CssClass="inputbutton"></asp:button></TD>
					<TD><asp:label id="lblMessage" runat="server" Width="113px"></asp:label>
						<asp:Button id="Button1" runat="server" Width="84px" CssClass="inputbutton" Text="����" Visible="False"></asp:Button>
						<asp:Button id="btnOutPrint" runat="server" Width="81px" CssClass="inputbutton" Text="��ӡ" Visible="False"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
