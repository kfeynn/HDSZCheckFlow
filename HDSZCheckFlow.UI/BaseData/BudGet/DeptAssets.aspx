<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="DeptAssets.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.DeptAssets"  enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
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
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 18px">��&nbsp; :</TD>
									<TD style="WIDTH: 129px; HEIGHT: 18px"><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="90px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px">��&nbsp;&nbsp;Ŀ:</TD>
									<TD style="HEIGHT: 18px"><asp:dropdownlist id="ddlSubject" runat="server" Width="229px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 18px" align="center">��Ŀ���:</TD>
									<TD style="HEIGHT: 18px"><asp:textbox id="txtSubjectCode" runat="server" Width="90px"></asp:textbox></TD>
									<TD style="HEIGHT: 18px"><asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss" Text="��ѯ"></asp:button></TD>
									<TD style="HEIGHT: 18px"></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD style="WIDTH: 129px"></TD>
									<TD>ʣ����:</TD>
									<TD>
										<asp:DropDownList id="DropDownList1" runat="server">
											<asp:ListItem Value=""></asp:ListItem>
											<asp:ListItem Value="=">=</asp:ListItem>
											<asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
											<asp:ListItem Value="&gt;">&gt;</asp:ListItem>
											<asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
											<asp:ListItem Value="&lt;">&lt;</asp:ListItem>
										</asp:DropDownList>
										<asp:TextBox id="txtLeftMoney" runat="server"></asp:TextBox></TD>
									<TD align="center">��&nbsp;&nbsp;&nbsp; ��:</TD>
									<TD>
										<asp:DropDownList id="ddlQuarter" runat="server" Width="96px">
											<asp:ListItem Value="0" Selected="True">��</asp:ListItem>
											<asp:ListItem Value="1">��һ����</asp:ListItem>
											<asp:ListItem Value="2">�ڶ�����</asp:ListItem>
											<asp:ListItem Value="3">��������</asp:ListItem>
											<asp:ListItem Value="4">���ļ���</asp:ListItem>
										</asp:DropDownList></TD>
									<TD></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="7"><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="7"><asp:datagrid id="dgBudgetInfo" runat="server" Width="100%" BorderColor="#93BEE2" BackColor="White"
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
								<asp:BoundColumn DataField="alterMoney" HeaderText="���ݵ������">
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
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">Ԥ����</FONT></td>
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">������</FONT></td>
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">�������</FONT></td>
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">Ԥ������</FONT></td>
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">��̯���</FONT></td>
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">ʹ�ý��</FONT></td>
					<td width="12%" background="../../Style/Images/treetopbg.jpg" align="center"><FONT face="����">ʣ����</FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 26px">
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">�ϼ�:
						<asp:Label id="lblBudget" runat="server"></asp:Label></td>
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">
						<asp:Label id="lblPush" runat="server"></asp:Label></td>
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">
						<asp:Label id="lblChange" runat="server"></asp:Label></td>
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">
						<asp:Label id="lblOutMoney" runat="server"></asp:Label></td>
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">
						<asp:Label id="lblReadypay" runat="server"></asp:Label></td>
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">
						<asp:Label id="lblUsed" runat="server"></asp:Label></td>
					<td style=" BACKGROUND-COLOR: #e8f4ff" align="center">
						<asp:Label id="lblLeft" runat="server"></asp:Label></td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="7"><FONT face="����"></FONT></TD>
				</TR>
			</table>
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px"
				runat="server"></asp:linkbutton><INPUT id="HerdSort" style="Z-INDEX: 103; POSITION: absolute; TOP: 400px; LEFT: 128px"
				type="hidden" name="Hidden3" runat="server"><INPUT id="FieldSort" style="Z-INDEX: 104; POSITION: absolute; TOP: 392px; LEFT: 296px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 105; POSITION: absolute; TOP: 408px; LEFT: 472px"
				type="hidden" value="0" name="Hidden1" runat="server"></form>
	</body>
</HTML>
