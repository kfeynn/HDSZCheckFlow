<%@ Page language="c#" Codebehind="BudgetCostByYear.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCostByYear" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>部门实算年度查询</title>
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
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 24px" runat="server">部门实算年度查询</asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 104px"
				runat="server" Height="80px" Width="100%" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="科目名称" HeaderText="科目名称">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="1月份" HeaderText="1月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="2月份" HeaderText="2月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="3月份" HeaderText="3月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="1Q平均" HeaderText="1Q平均"></asp:BoundColumn>
					<asp:BoundColumn DataField="4月份" HeaderText="4月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="5月份" HeaderText="5月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="6月份" HeaderText="6月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="2Q平均" HeaderText="2Q平均"></asp:BoundColumn>
					<asp:BoundColumn DataField="7月份" HeaderText="7月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="8月份" HeaderText="8月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="9月份" HeaderText="9月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="3Q平均" HeaderText="3Q平均"></asp:BoundColumn>
					<asp:BoundColumn DataField="10月份" HeaderText="10月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="11月份" HeaderText="11月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="12月份" HeaderText="12月份"></asp:BoundColumn>
					<asp:BoundColumn DataField="4Q平均" HeaderText="4Q平均"></asp:BoundColumn>
					<asp:BoundColumn DataField="合计" HeaderText="合计"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			
			<div  style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 84px;width=100%">
			<table border="1" cellpadding="0" cellspacing="0" width="850px">
				<asp:Repeater ID="repDataBind" Runat="server">
					<HeaderTemplate>
						<tr align="center">
							<td style="width=80px;">科目名称</td>
							<td>1月份</td>
							<td>2月份</td>
							<td>3月份</td>
							<td>1Q平均</td>
							<td>4月份</td>
							<td>5月份</td>
							<td>6月份</td>
							<td>2Q平均</td>
							<td>7月份</td>
							<td>8月份</td>
							<td>9月份</td>
							<td>3Q平均</td>
							<td>10月份</td>
							<td>11月份</td>
							<td>12月份</td>
							<td>4Q平均</td>
							<td>合计</td>
						</tr>
					</HeaderTemplate>
					<ItemTemplate>
						<tr>
							<td><%# DataBinder.Eval(Container.DataItem, "科目名称") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "1月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "2月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "3月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "1Q平均") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "4月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "5月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "6月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "2Q平均") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "7月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "8月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "9月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "3Q平均") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "10月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "11月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "12月份") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "4Q平均") %></td>
							<td><%# DataBinder.Eval(Container.DataItem, "合计") %></td>
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
					<TD><FONT face="宋体">输入查询年份：</FONT></TD>
					<TD><asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年'})" runat="server"></asp:textbox></TD>
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
