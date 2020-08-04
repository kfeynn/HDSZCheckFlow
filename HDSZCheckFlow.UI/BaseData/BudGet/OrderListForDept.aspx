<%@ Page language="c#" Codebehind="OrderListForDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.OrderListForDept" enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		
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
									<td style="WIDTH: 93px" height="26"></td>
								</tr>
								<TR>
									<TD style="WIDTH: 93px; HEIGHT: 17px">��&nbsp;&nbsp; ��&nbsp;&nbsp;��</TD>
									<TD style="WIDTH: 506px; HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server" Width="336px"></asp:textbox>(�Զ��ŷָ�)</TD>
									<TD style="HEIGHT: 17px">�Ƿ����¶���</TD>
									<TD style="HEIGHT: 17px"><asp:radiobutton id="rbtMark1" runat="server" GroupName="IsMark" Text="��"></asp:radiobutton><asp:radiobutton id="rbtMark2" runat="server" GroupName="IsMark" Text="��"></asp:radiobutton><asp:radiobutton id="rbtMark3" runat="server" GroupName="IsMark" Text="All" Checked="True"></asp:radiobutton></TD>
									<TD style="HEIGHT: 17px" align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px">�� Ʒ �� ��</TD>
									<TD style="WIDTH: 506px"><asp:textbox id="txtProduct" runat="server" Width="336px"></asp:textbox>(�Զ��ŷָ�)</TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss"></asp:button></TD>
									<TD align="center"></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
							BorderColor="#93BEE2" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ApplySheetBody_Purchase_pk" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:Button id="btnMark" runat="server" Text="�鿴" CssClass="ButtonCss" CommandName="ReMark"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="���ݺ�"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplyTypeName" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="InventoryCode" HeaderText="��Ʒ���"></asp:BoundColumn>
								<asp:BoundColumn DataField="invName" HeaderText="��Ʒ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="Number" HeaderText="����" DataFormatString="{0:n0}"></asp:BoundColumn>
								<asp:BoundColumn DataField="RMBPrice" HeaderText="rmb����"></asp:BoundColumn>
								<asp:BoundColumn DataField="money" HeaderText="�ܼ�"></asp:BoundColumn>
								<asp:BoundColumn DataField="IsOrder" HeaderText="��ע"></asp:BoundColumn>
								<asp:BoundColumn DataField="orderDate" HeaderText="��עʱ��"></asp:BoundColumn>
								<asp:BoundColumn DataField="OrderNo" HeaderText="������"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT>
					</td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
			</table>
			<INPUT id="pagesIndex" style="Z-INDEX: 104; LEFT: 624px; POSITION: absolute; TOP: 528px"
				type="hidden" value="0" name="Hidden1" runat="server"><INPUT id="HerdSort" style="Z-INDEX: 103; LEFT: 160px; POSITION: absolute; TOP: 520px"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"
				runat="server"></asp:linkbutton><INPUT id="FieldSort" style="Z-INDEX: 105; LEFT: 504px; POSITION: absolute; TOP: 528px"
				type="hidden" name="Hidden2" runat="server"></form>
	</body>
</HTML>
