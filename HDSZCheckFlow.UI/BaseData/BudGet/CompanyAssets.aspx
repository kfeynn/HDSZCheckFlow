<%@ Page language="c#" Codebehind="CompanyAssets.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.CompanyAssets" enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Style/BasicLayout.css">
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<LINK rel="stylesheet" type="text/css" href="../../AppSystem/common.css">
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
			<table style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				id="tabDispDocument" class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3">
				<tr style="HEIGHT: 28px">
					<td colSpan="7" align="center"><FONT face="����">
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 18px">��&nbsp; :</TD>
									<TD style="WIDTH: 129px; HEIGHT: 18px"><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="90px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px">��&nbsp;&nbsp;Ŀ:</TD>
									<TD style="HEIGHT: 18px"><asp:dropdownlist id="ddlSubject" runat="server" Width="229px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 18px">��Ŀ���:</TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="txtSubjectCode" runat="server" Width="90px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>��&nbsp; ��:</TD>
									<TD style="WIDTH: 129px"><asp:dropdownlist id="ddlBudgetDept" runat="server" Width="145px"></asp:dropdownlist></TD>
									<TD>ʣ����:</TD>
									<TD><asp:dropdownlist id="DropDownList1" runat="server">
											<asp:ListItem Value=""></asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
										</asp:dropdownlist><asp:textbox id="txtLeftMoney" runat="server"></asp:textbox></TD>
									<TD>��&nbsp;&nbsp;&nbsp; ��:</TD>
									<TD><asp:dropdownlist id="ddlQuarter" runat="server" Width="97px">
											<asp:ListItem Value="0" Selected="True">��</asp:ListItem>
											<asp:ListItem Value="1">��һ����</asp:ListItem>
											<asp:ListItem Value="2">�ڶ�����</asp:ListItem>
											<asp:ListItem Value="3">��������</asp:ListItem>
											<asp:ListItem Value="4">���ļ���</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD style="WIDTH: 129px"></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss" Text="��ѯ"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="7" align="right"><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</td>
				</tr>
				<tr style="DISPLAY: block; HEIGHT: 22px" id="bodyInfo">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" colSpan="7" align="center"><asp:datagrid id="dgBudgetInfo" runat="server" Width="100%" BorderColor="#93BEE2" BackColor="White"
							AutoGenerateColumns="False" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="budget_account_pk"></asp:BoundColumn>
								<asp:BoundColumn DataField="iyear" SortExpression="iyear" HeaderText="��"></asp:BoundColumn>
								<asp:BoundColumn DataField="imonth" SortExpression="imonth" HeaderText="��"></asp:BoundColumn>
								<asp:BoundColumn DataField="nc_deptname" SortExpression="nc_deptname" HeaderText="Ԥ�㲿��"></asp:BoundColumn>
								<asp:BoundColumn DataField="subjectname" SortExpression="subjectname" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="budgetmoney" SortExpression="budgetmoney" HeaderText="Ԥ����" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="planmoney" SortExpression="planmoney" HeaderText="������" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="changemoney" SortExpression="changemoney" HeaderText="�������" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalAllowOutMoney" HeaderText="Ԥ������"></asp:BoundColumn>
								<asp:BoundColumn DataField="readypay" HeaderText="��̯���" DataFormatString="{0:N}"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="budget_account_pk" DataNavigateUrlFormatString="UsedMoneyListInfo.aspx?budgetaccountpk={0}"
									DataTextField="checkmoney" SortExpression="checkmoney" HeaderText="ʹ�ý��" DataTextFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="alterMoney" HeaderText="���ݵ������" DataFormatString="{0:N2}">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="leftmoney" SortExpression="leftmoney" HeaderText="ʣ����" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">Ԥ����</FONT></td>
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">������</FONT></td>
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">�������</FONT></td>
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">Ԥ������</FONT></td>
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">��̯���</FONT></td>
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">ʹ�ý��</FONT></td>
					<td background="../../Style/Images/treetopbg.jpg" width="12%" align="center"><FONT face="����">ʣ����</FONT></td>
				</tr>
				<tr style="DISPLAY: block; HEIGHT: 26px" id="postail">
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><FONT face="����">�ϼ�:</FONT><asp:label id="lblBudget" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblPush" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblChange" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblOutMoney" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblReadypay" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblUsed" runat="server"></asp:label></td>
					<td style="BACKGROUND-COLOR: #e8f4ff" align="center"><asp:label id="lblLeft" runat="server"></asp:label></td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="7" align="center"><FONT face="����"></FONT></TD>
				</TR>
			</table>
			<INPUT style="Z-INDEX: 108; POSITION: absolute; TOP: 464px; LEFT: 80px" id="HerdSort" type="hidden"
				name="Hidden3" runat="server"><INPUT style="Z-INDEX: 106; POSITION: absolute; TOP: 480px; LEFT: 416px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server"><INPUT style="Z-INDEX: 107; POSITION: absolute; TOP: 472px; LEFT: 640px" id="pagesIndex"
				type="hidden" name="Hidden1" runat="server">
			<asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px" id="linkToPage"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
