<%@ Page language="c#" Codebehind="Asset_BudgetCostDetialInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetCostDetialInfo"  EnableEventValidation="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>新营预实情况对照表</title>
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
						<td>年份:</td>
						<td><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="50px"></asp:textbox></td>
						<td>&nbsp;</td>
						<td>部门:</td>
						<td><asp:dropdownlist id="ddlDeptClass" runat="server" Width="90px"></asp:dropdownlist></td>
						<td>&nbsp;</td>
						<td>项目名称:</td>
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
						<asp:BoundColumn DataField="年份" SortExpression="年份" HeaderText="年份"></asp:BoundColumn>
						<asp:BoundColumn DataField="部门" SortExpression="部门" HeaderText="部门"></asp:BoundColumn>
						<asp:BoundColumn DataField="项目类型" SortExpression="项目类型" HeaderText="项目类型"></asp:BoundColumn>
						<asp:BoundColumn DataField="项目内容" SortExpression="项目内容" HeaderText="项目内容"></asp:BoundColumn>
						<asp:BoundColumn DataField="预算内金额" SortExpression="预算内金额" HeaderStyle-HorizontalAlign="Right" HeaderText="预算内金额"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="预算外金额" SortExpression="预算外金额" HeaderStyle-HorizontalAlign="Right" HeaderText="预算外金额"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="调出金额" SortExpression="调出金额" HeaderStyle-HorizontalAlign="Right" HeaderText="调出金额"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="调入金额" SortExpression="调入金额" HeaderStyle-HorizontalAlign="Right" HeaderText="调入金额"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="调整后预算金额" SortExpression="调整后预算金额" HeaderStyle-HorizontalAlign="Right"
							HeaderText="调整后预算金额" DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="使用金额" SortExpression="使用金额" HeaderStyle-HorizontalAlign="Right" HeaderText="使用金额"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="剩余金额" SortExpression="剩余金额" HeaderStyle-HorizontalAlign="Right" HeaderText="剩余金额"
							DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></div>
		</form>
	</body>
</HTML>
