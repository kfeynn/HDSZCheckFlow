<%@ Page language="c#" Codebehind="ApplyNC_BudgetPurchasePrice.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.Apply.ApplyNC_BudgetPurchasePrice" %>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" borderColor="#0066cc">
				<tr>
					<td height="26" style="WIDTH: 80px"></td>
				</tr>
				<TR>
					<TD style="Z-INDEX: 0; WIDTH: 80px; HEIGHT: 24px">存货分类</TD>
					<TD style="Z-INDEX: 0; WIDTH: 179px; HEIGHT: 24px">
						<asp:DropDownList style="Z-INDEX: 0" id="ddlInvClass" runat="server" Width="120px"></asp:DropDownList></TD>
					<TD style="Z-INDEX: 0; WIDTH: 107px; HEIGHT: 24px">存货编码</TD>
					<TD style="WIDTH: 266px; HEIGHT: 24px">
						<asp:TextBox id="txtInvCode" runat="server" Width="120px"></asp:TextBox></TD>
					<TD style="HEIGHT: 24px" align="center"></TD>
					<TD style="HEIGHT: 24px">
						<asp:button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button>
						<asp:Button style="Z-INDEX: 0" id="btnOutput" runat="server" Text="导出" CssClass="redButtonCss"
							Width="76px"></asp:Button>
						<asp:Label id="lblMessage" runat="server"></asp:Label></TD>
					<TD style="HEIGHT: 24px"></TD>
					<TD style="HEIGHT: 24px"></TD>
				</TR>
				<TR>
					<TD style="Z-INDEX: 0; WIDTH: 80px; HEIGHT: 20px">起始日期</TD>
					<TD style="WIDTH: 179px; HEIGHT: 20px"><!--WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})-->
						<asp:textbox style="Z-INDEX: 0" id="txtDateFrom" onfocus="WdatePicker({startDate:'%y-{%M-5}-01',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:false})"
							runat="server"  maxdate="#F{$('txtDateTo').value}" Width="120px"></asp:textbox></TD>
					<TD style="Z-INDEX: 0; WIDTH: 107px; HEIGHT: 20px">结束日期</TD>
					<TD style="WIDTH: 266px; HEIGHT: 20px">
						<asp:textbox style="Z-INDEX: 0" id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
							runat="server" Width="120px" mindate="#F{$('txtDateFrom').value}"></asp:textbox></TD>
					<TD style="HEIGHT: 20px" align="center"></TD>
					<TD style="HEIGHT: 20px"></TD>
					<TD style="HEIGHT: 20px"></TD>
					<TD style="HEIGHT: 21px"></TD>
				</TR>
			</TABLE>
			<table class="GbText" id="tabDispDocument" borderColor="#0066cc" cellPadding="3" rules="all"
				width="100%" border="0">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="宋体"> </FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" PageSize="20" BorderColor="#93BEE2" BackColor="White"
							EnableViewState="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
