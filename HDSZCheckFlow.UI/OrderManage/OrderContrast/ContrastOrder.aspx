<%@ Page language="c#" Codebehind="ContrastOrder.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.OrderManage.OrderContrast.ContrastOrder"  EnableEventValidation="false" %>
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
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="����">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 17px">���޲���</TD>
									<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlIsDifference" runat="server" Width="90px" AutoPostBack="True">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="1">��</asp:ListItem>
											<asp:ListItem Value="0">��</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="HEIGHT: 17px">��ʼ����</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})" runat="server" Width="90px"
										></asp:textbox></TD>
									<TD style="HEIGHT: 17px" align="center">��������</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})" runat="server" Width="90px"
											></asp:textbox></TD>
									<TD style="HEIGHT: 17px">������</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>�Ƿ���</TD>
									<TD><asp:dropdownlist id="ddlIsDone" runat="server" Width="90px">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="1">��</asp:ListItem>
											<asp:ListItem Value="0">��</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD>��������</TD>
									<TD>
										<asp:dropdownlist id="ddlDiffType" runat="server" AutoPostBack="True" Width="90px">
											<asp:ListItem Selected="True"></asp:ListItem>
											<asp:ListItem Value="1">Nc��Bud��</asp:ListItem>
											<asp:ListItem Value="0">Nc��Bud��</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD align="center"></TD>
									<TD></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" BackColor="White" BorderColor="#93BEE2"
							PageSize="20" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="����">
											<asp:Button id="btnLook" runat="server" Width="76px" CssClass="redButtonCss" Text="��ע" CommandName="look"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="AOrderNo" HeaderText="���ݺ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="OrderDate" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="AinventoryCode" HeaderText="���ϱ���"></asp:BoundColumn>
								<asp:BoundColumn DataField="invName" HeaderText="Ʒ��"></asp:BoundColumn>
								<asp:BoundColumn DataField="Invtype" HeaderText="���͹��"></asp:BoundColumn>
								<asp:BoundColumn DataField="number" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="money" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="�������" HeaderText="NC�������"></asp:BoundColumn>
								<asp:BoundColumn DataField="��������" HeaderText="NC��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="�������ҽ��" HeaderText="NC�������ҽ��"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="����"><asp:panel id="Panel1" runat="server" BackColor="White" Visible="False">
								<TABLE id="Table2" borderColor="#003333" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 22px">�� ��&nbsp;�ţ�</TD>
										<TD style="HEIGHT: 22px">&nbsp;
											<asp:Label id="Label5" runat="server"></asp:Label>
											<asp:Label id="lblHidden" runat="server"></asp:Label>
											<asp:Label id="lblHidden2" runat="server"></asp:Label></TD>
										<TD style="HEIGHT: 22px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 21px">��Ʒ���ƣ�</TD>
										<TD style="HEIGHT: 21px">&nbsp;
											<asp:Label id="Label2" runat="server" Width="144px"></asp:Label></TD>
										<TD style="HEIGHT: 21px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">�Ƿ��Ѵ���</TD>
										<TD>&nbsp;
											<asp:CheckBox id="CheckBox1" runat="server" Text="��/��"></asp:CheckBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">��&nbsp;&nbsp;&nbsp; ע��</TD>
										<TD>&nbsp;
											<asp:TextBox id="TextBox1" runat="server" Width="232px" TextMode="MultiLine"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">&nbsp;</TD>
										<TD>&nbsp;
											<asp:button id="btnEnter" runat="server" Width="83px" CssClass="inputbutton" Text="ȷ��"></asp:button>
											<asp:Label id="lblMessage" runat="server"></asp:Label></TD>
										<TD></TD>
									</TR>
								</TABLE>
							</asp:panel></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
			</table>
			<INPUT id="FieldSort" style="Z-INDEX: 106; LEFT: 416px; POSITION: absolute; TOP: 480px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 105; LEFT: 632px; POSITION: absolute; TOP: 496px"
				type="hidden" value="0" name="Hidden1" runat="server"><INPUT id="HerdSort" style="Z-INDEX: 104; LEFT: 248px; POSITION: absolute; TOP: 488px"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
