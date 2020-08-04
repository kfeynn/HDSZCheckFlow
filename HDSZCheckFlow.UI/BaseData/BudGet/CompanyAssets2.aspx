<%@ Page language="c#" Codebehind="CompanyAssets2.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.CompanyAssets2" enableEventValidation="false" %>
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
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="7"><FONT face="����">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="26" style="WIDTH: 105px"></td>
								</tr>
								<TR>
									<TD style="WIDTH: 105px; HEIGHT: 18px" align="center">��&nbsp; :</TD>
									<TD style="WIDTH: 129px; HEIGHT: 18px"><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="90px"></asp:textbox></TD> <!--onfocus="WdatePicker({dateFmt:'yyyy��'})"-->
									<TD style="WIDTH: 72px; HEIGHT: 18px">��&nbsp;&nbsp; ��:</TD>
									<TD style="WIDTH: 176px; HEIGHT: 18px">
										<asp:DropDownList id="ddlQuarter" runat="server" Width="96px">
											<asp:ListItem Value="0" Selected="True">��</asp:ListItem>
											<asp:ListItem Value="1">��һ����</asp:ListItem>
											<asp:ListItem Value="2">�ڶ�����</asp:ListItem>
											<asp:ListItem Value="3">��������</asp:ListItem>
											<asp:ListItem Value="4">���ļ���</asp:ListItem>
										</asp:DropDownList></TD>
									<TD style="WIDTH: 2px; HEIGHT: 18px"></TD>
									<TD style="HEIGHT: 18px"><asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss"></asp:button></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 105px"></TD>
									<TD style="WIDTH: 129px"></TD>
									<TD style="WIDTH: 72px"></TD>
									<TD style="WIDTH: 176px"></TD>
									<TD style="WIDTH: 2px"></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="7"><FONT face="����"></FONT><FONT face="����"></FONT>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="7"><asp:datagrid id="dgBudgetInfo" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							BackColor="White" BorderColor="#93BEE2">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="iyear" SortExpression="iyear" HeaderText="��"></asp:BoundColumn>
								<asp:BoundColumn DataField="imonth" SortExpression="imonth" HeaderText="��"></asp:BoundColumn>
								<asp:BoundColumn DataField="nc_deptname" SortExpression="nc_deptname" HeaderText="Ԥ�㲿��"></asp:BoundColumn>
								<asp:BoundColumn DataField="budgetmoney" SortExpression="budgetmoney" HeaderText="Ԥ����" DataFormatString="{0:N2}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="planmoney" SortExpression="planmoney" HeaderText="������" DataFormatString="{0:N2}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="changemoney" SortExpression="changemoney" HeaderText="�������" DataFormatString="{0:N2}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalAllowOutMoney" HeaderText="Ԥ������" DataFormatString="{0:N2}"></asp:BoundColumn>
								<asp:BoundColumn DataField="readypay" HeaderText="��̯���" DataFormatString="{0:N2}"></asp:BoundColumn>
								<asp:BoundColumn DataField="checkmoney" HeaderText="ʹ�ý��" DataFormatString="{0:N2}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="alterMoney" HeaderText="���ݵ������" DataFormatString="{0:N2}">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="leftmoney" SortExpression="leftmoney" HeaderText="ʣ����" DataFormatString="{0:#,###.##}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����">Ԥ����</FONT></td>
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����">������</FONT></td>
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����">�������</FONT></td>
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����">Ԥ������</FONT></td>
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����">��̯���</FONT></td>
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����">ʹ�ý��</FONT></td>
					<td align="center" width="12%" background="../../Style/Images/treetopbg.jpg"><FONT face="����"><FONT face="����">ʣ����</FONT></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 26px">
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center">�ϼ�:<asp:label id="lblBudget" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblPush" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblChange" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblOutMoney" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblReadypay" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblUsed" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblLeft" runat="server"></asp:label></td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="7"><FONT face="����"></FONT></TD>
				</TR>
			</table>
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
