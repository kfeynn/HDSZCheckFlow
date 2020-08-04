<%@ Page language="c#" Codebehind="ApplyNC_BudgetPurchase.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.Apply.ApplyNC_BudgetPurchase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExpenseStates</title>
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
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="宋体">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="26" style="WIDTH: 80px"></td>
								</tr>
								<TR>
									<TD style="Z-INDEX: 0; WIDTH: 80px; HEIGHT: 24px">起始日期</TD>
									<TD style="Z-INDEX: 0; WIDTH: 147px; HEIGHT: 24px"><asp:textbox id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="90px" maxdate="#F{$('txtDateTo').value}" style="Z-INDEX: 0"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; HEIGHT: 24px">结束日期</TD>
									<TD style="HEIGHT: 24px"><asp:textbox id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="90px" mindate="#F{$('txtDateFrom').value}" style="Z-INDEX: 0"></asp:textbox></TD>
									<TD style="HEIGHT: 24px" align="center"></TD>
									<TD style="HEIGHT: 24px">
										<asp:button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button></TD>
									<TD style="HEIGHT: 24px"></TD>
									<TD style="HEIGHT: 24px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 80px; HEIGHT: 20px"></TD>
									<TD style="WIDTH: 147px; HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 20px" align="center"></TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 21px"></TD>
								</TR>
								<TR height="20">
									<TD style="WIDTH: 80px"></TD>
									<TD style="WIDTH: 147px"></TD>
									<TD></TD>
									<TD></TD>
									<TD align="center"></TD>
									<TD>
										<asp:Button style="Z-INDEX: 0" id="btnOutput" runat="server" Text="导出到Excel" CssClass="inputbutton"></asp:Button></TD>
									<TD></TD>
									<TD></TD>
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
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" EnableViewState="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6">
						<P><FONT face="宋体"></FONT>&nbsp;</P>
						<P><FONT face="宋体"><FONT face="宋体"></FONT></FONT></P>
						<P><FONT face="宋体"></FONT>&nbsp;</P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
