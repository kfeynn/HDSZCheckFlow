<%@ Page language="c#" Codebehind="Asset_BudgetCost_Contrast.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetCost_Contrast" EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Asset_BudgetCost_Contrast</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
		</script>
		<style>
			.myCss { BACKGROUND-COLOR: #dee4f4 }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colspan="6"><FONT face="宋体">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="17" style="WIDTH: 39px"></TD>
									<TD style="WIDTH: 39px" height="17"></TD>
								</TR>
								<TR>
									<td align="right" style="WIDTH: 39px">年份:</td>
									<td style="WIDTH: 78px"><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="50px"></asp:textbox></td>
									<td align="right" style="WIDTH: 38px">部门:</td>
									<td style="WIDTH: 185px"><asp:dropdownlist id="ddlDeptClass" runat="server" Width="144px"></asp:dropdownlist></td>
									<td align="right" style="WIDTH: 54px">项目名称:</td>
									<td style="WIDTH: 209px"><asp:dropdownlist id="ddlItemName" runat="server" Width="150px"></asp:dropdownlist></td>
									<TD style="WIDTH: 233px">
										<asp:button id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss myCss" />&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnOutput" runat="server" CssClass="redButtonCss myCss" Text="导出到Excel" /></TD>
									<TD style="WIDTH: 130px"></TD>
									<TD style="WIDTH: 1px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD style="WIDTH: 1px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 39px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 78px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 38px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 185px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 54px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 209px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 233px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 130px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 1px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 1px; HEIGHT: 11px"></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</TD>
				</TR>
				<TR id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
							Width="100%" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="年份" SortExpression="年份" HeaderText="年份"></asp:BoundColumn>
								<asp:BoundColumn DataField="部门名称" SortExpression="部门名称" HeaderText="部门名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="项目类型" SortExpression="项目类型" HeaderText="项目类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="项目内容" SortExpression="项目内容" HeaderText="项目内容"></asp:BoundColumn>
								<asp:BoundColumn DataField="审批金额" SortExpression="审批金额" HeaderStyle-HorizontalAlign="Right" HeaderText="审批金额"
									DataFormatString="{0:N}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="财务付款金额" SortExpression="财务付款金额" HeaderStyle-HorizontalAlign="Right" HeaderText="财务付款金额"
									DataFormatString="{0:N}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; HEIGHT: 29px; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
			<asp:linkbutton id="linkToPage" runat="server" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"></asp:linkbutton><INPUT id="HerdSort" style="Z-INDEX: 103; LEFT: 200px; POSITION: absolute; TOP: 424px"
				type="hidden" name="Hidden3" runat="server"><INPUT id="FieldSort" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 448px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 105; LEFT: 248px; POSITION: absolute; TOP: 472px"
				type="hidden" value="0" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
