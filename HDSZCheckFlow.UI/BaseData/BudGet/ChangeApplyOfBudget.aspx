<%@ Page language="c#" Codebehind="ChangeApplyOfBudget.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.ChangeApplyOfBudget" enableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<!--<script language="javascript" src="../../Style/My97DatePicker/WdatePicker.js"></script>-->
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="宋体">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 17px">申请部门</TD>
									<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlDeptClass" runat="server" AutoPostBack="True" Width="90px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 17px">起始日期</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})" runat="server" Width="90px"
											maxdate="#F{$('txtDateTo').value}"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" align="center">结束日期</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})" runat="server" Width="90px"
											mindate="#F{$('txtDateFrom').value}"></asp:textbox></TD>
									<TD style="HEIGHT: 17px">单据号</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>申请类型</TD>
									<TD><asp:dropdownlist id="ddlType" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD>申请科组</TD>
									<TD><asp:dropdownlist id="ddlDept" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD align="center">单据状态</TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss" Text="查询"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ApplyTypeCode" HeaderText="ApplyTypeCode"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnLook" runat="server" Width="50px" Text="查看" CssClass="redButtonCss" CommandName="look"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="单据号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplyTypeName" SortExpression="ApplyTypeName" HeaderText="申请类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="申请日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="申请部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="申请人"></asp:BoundColumn>
								<asp:BoundColumn DataField="SheetMoney" SortExpression="SheetMoney" HeaderText="金额" DataFormatString="{0:#,####.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SubmitType" SortExpression="SubmitType" HeaderText="类别"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="单据状态"></asp:BoundColumn>
								<asp:BoundColumn DataField="Cisexpense" HeaderText="是否报销"></asp:BoundColumn>
								<asp:BoundColumn DataField="expensedate" HeaderText="报销日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnExpense" runat="server" Text="报销" CssClass="inputbutton" CommandName="expense"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnChange" runat="server" Width="53px" Text="调整"  CssClass="inputbutton"  CommandName="btnChange"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="宋体"><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False">
								<Columns>
									<asp:BoundColumn DataField="SheetDate" HeaderText="日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="firstSubjectCode" HeaderText="一级科目"></asp:BoundColumn>
									<asp:BoundColumn DataField="SubjectCode" HeaderText="科目"></asp:BoundColumn>
									<asp:BoundColumn DataField="BudgetDept" HeaderText="部门编号"></asp:BoundColumn>
									<asp:BoundColumn DataField="alterYear" HeaderText="调整年份"></asp:BoundColumn>
									<asp:BoundColumn DataField="alterMonth" HeaderText="调整月份"></asp:BoundColumn>
									<asp:BoundColumn DataField="alterMoney" HeaderText="调整金额"></asp:BoundColumn>
									<asp:BoundColumn DataField="Memo" HeaderText="备注"></asp:BoundColumn>
									<asp:BoundColumn DataField="IsSubmit" HeaderText="提交"></asp:BoundColumn>
									<asp:BoundColumn DataField="MarkerCode" HeaderText="制单人"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6">
						<P><FONT face="宋体"></FONT>&nbsp;</P>
						<P><FONT face="宋体"></FONT>&nbsp;</P>
						<P><FONT face="宋体"><INPUT id="pagesIndex" type="hidden" name="Hidden1" runat="server" value="0"><INPUT id="FieldSort" type="hidden" name="Hidden2" runat="server"><INPUT id="HerdSort" type="hidden" name="Hidden3" runat="server"></FONT></P>
					</td>
				</tr>
			</table>
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
