<%@ Page language="c#" Codebehind="Asset_BudgetCostDetialInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetCostDetialInfo"  EnableEventValidation="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��ӪԤʵ������ձ�</title>
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
			<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
			<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
				<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<div style="PADDING-RIGHT: 10px; PADDING-LEFT: 10px; PADDING-BOTTOM: 10px; PADDING-TOP: 10px">
				<table>
					<tr>
						<td>���:</td>
						<td><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="50px"></asp:textbox></td>
						<td>&nbsp;</td>
						<td>����:</td>
						<td><asp:dropdownlist id="ddlDeptClass" runat="server" Width="90px"></asp:dropdownlist></td>
						<td>&nbsp;</td>
						<td>��Ŀ����:</td>
						<td><asp:dropdownlist id="ddlItemName" runat="server" Width="150px"></asp:dropdownlist></td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
						<td>&nbsp;</td>
						<td><asp:ImageButton ID="imgBtnQuery" Runat="server" ImageUrl="../../AppSystem/Images/btnQuery.gif" Height="24" /></td>
					</tr>
				</table>
			</div>
			<div><asp:datagrid id="dgBudetInfo" runat="server" Width="1224px" AllowSorting="True" PageSize="10"
					BorderColor="#336666" BackColor="White" AutoGenerateColumns="False" AllowPaging="True" BorderStyle="Double"
					BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
					<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center"></AlternatingItemStyle>
					<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#333333" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
						BackColor="#336666"></HeaderStyle>
					<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
						<asp:BoundColumn DataField="����" SortExpression="����" HeaderText="����"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Ŀ����" SortExpression="��Ŀ����" HeaderText="��Ŀ����"></asp:BoundColumn>
						<asp:BoundColumn DataField="��Ŀ����" SortExpression="��Ŀ����" HeaderText="��Ŀ����"></asp:BoundColumn>
						<asp:BoundColumn DataField="Ԥ���ڽ��" SortExpression="Ԥ���ڽ��" HeaderStyle-HorizontalAlign="Right" HeaderText="Ԥ���ڽ��"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Ԥ������" SortExpression="Ԥ������" HeaderStyle-HorizontalAlign="Right" HeaderText="Ԥ������"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="�������" SortExpression="�������" HeaderStyle-HorizontalAlign="Right" HeaderText="�������"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="������" SortExpression="������" HeaderStyle-HorizontalAlign="Right" HeaderText="������"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="������Ԥ����" SortExpression="������Ԥ����" HeaderStyle-HorizontalAlign="Right"
							HeaderText="������Ԥ����" DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="ʹ�ý��" SortExpression="ʹ�ý��" HeaderStyle-HorizontalAlign="Right" HeaderText="ʹ�ý��"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="ʣ����" SortExpression="ʣ����" HeaderStyle-HorizontalAlign="Right" HeaderText="ʣ����"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></div>
		</form>
	</body>
</HTML>
