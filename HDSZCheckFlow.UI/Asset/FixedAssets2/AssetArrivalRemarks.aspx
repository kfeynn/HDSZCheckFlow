<%@ Page language="c#" Codebehind="AssetArrivalRemarks.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.FixedAssets2.AssetArrivalRemarks"  EnableEventValidation="false"%>
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
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
					<td align="center" colSpan="6"><FONT face="����">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td style="WIDTH: 93px" height="26"><STRONG>����</STRONG></td>
								</tr>
								<TR>
									<TD style="WIDTH: 93px; HEIGHT: 17px">��&nbsp;&nbsp; ��&nbsp;&nbsp;��</TD>
									<TD style="WIDTH: 506px; HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server" Width="336px"></asp:textbox>(�Զ��ŷָ�)</TD>
									<TD style="HEIGHT: 17px">�Ƿ��ѱ�ע</TD>
									<TD style="HEIGHT: 17px">
										<asp:RadioButton id="rbtMark1" runat="server" Text="��" GroupName="IsMark"></asp:RadioButton>
										<asp:RadioButton id="rbtMark2" runat="server" Text="��" GroupName="IsMark"></asp:RadioButton>
										<asp:RadioButton id="rbtMark3" runat="server" Text="All" GroupName="IsMark" Checked="True"></asp:RadioButton></TD>
									<TD style="HEIGHT: 17px" align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px">��&nbsp;&nbsp; ͬ&nbsp;&nbsp;��</TD>
									<TD style="WIDTH: 506px"><asp:textbox id="txtBargainNo" runat="server" Width="336px"></asp:textbox>(ģ����ѯ)</TD>
									<TD></TD>
									<TD></TD>
									<TD align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px">�� �� �� ��</TD>
									<TD style="WIDTH: 506px">
										<asp:textbox style="Z-INDEX: 0" id="txtDateFrom" runat="server" Width="128px" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											maxdate="#F{$('txtDateTo').value}"></asp:textbox>��
										<asp:textbox style="Z-INDEX: 0" id="txtDateTo" runat="server" Width="128px" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											mindate="#F{$('txtDateFrom').value}"></asp:textbox></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss"></asp:button>
										<asp:button style="Z-INDEX: 0" id="Button1" runat="server" Width="72px" Text="����" CssClass="redButtonCss"></asp:button></TD>
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
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="id" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:Button id="btnMark" runat="server" Text="��ע" CssClass="ButtonCss" CommandName="ReMark"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../Asset/CheckFlow/AssetApplyForOneApply.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="���ݺ�"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="FinallyPriceCheck_Id" DataNavigateUrlFormatString="../../Asset/PriceCheck/FinallyCheckApplyForOneApply.aspx?FinallyCheckId={0}"
									DataTextField="BargainNo" HeaderText="��ͬ��"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="deptname" HeaderText="���벿��"></asp:BoundColumn>
								<asp:BoundColumn DataField="makedate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="InventoryName" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="IsArrived" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="ArriveSigner" HeaderText="��ע��Ա"></asp:BoundColumn>
								<asp:BoundColumn DataField="ArriveDatetime" HeaderText="����ʱ��"></asp:BoundColumn>
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
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6"><FONT face="����">
							<asp:Panel id="Panel1" runat="server" BackColor="White" Visible="False">
								<TABLE id="Table2" border="1" cellSpacing="0" borderColor="#003333" cellPadding="0" width="100%">
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 22px">�� ͬ �ţ�</TD>
										<TD style="HEIGHT: 22px">&nbsp;
											<asp:Label id="Label5" runat="server"></asp:Label>
											<asp:Label id="lblHidden" runat="server"></asp:Label></TD>
										<TD style="HEIGHT: 22px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 21px">����ʱ�䣺</TD>
										<TD style="HEIGHT: 21px">&nbsp;
											<asp:TextBox id="txtDate" onfocus="WdatePicker()" runat="server" Width="120px"></asp:TextBox></TD>
										<TD style="HEIGHT: 21px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">�Ƿ񵽻���</TD>
										<TD>&nbsp;
											<asp:CheckBox id="CheckBox1" runat="server" Text="��/��"></asp:CheckBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px"></TD>
										<TD>&nbsp;
										</TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">&nbsp;</TD>
										<TD>&nbsp;
											<asp:button id="btnEnter" runat="server" Width="83px" Text="ȷ��" CssClass="inputbutton"></asp:button>
											<asp:Label id="lblMessage" runat="server"></asp:Label></TD>
										<TD></TD>
									</TR>
								</TABLE>
							</asp:Panel></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
			</table>
			<INPUT id="pagesIndex" style="Z-INDEX: 104; POSITION: absolute; TOP: 528px; LEFT: 624px"
				type="hidden" value="0" name="Hidden1" runat="server"><INPUT id="HerdSort" style="Z-INDEX: 103; POSITION: absolute; TOP: 520px; LEFT: 160px"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px"
				runat="server"></asp:linkbutton><INPUT id="FieldSort" type="hidden" name="Hidden2" runat="server" style="Z-INDEX: 105; POSITION: absolute; TOP: 528px; LEFT: 504px"></form>
	</body>
</HTML>
