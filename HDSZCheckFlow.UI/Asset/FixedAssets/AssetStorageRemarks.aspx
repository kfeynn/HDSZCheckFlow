<%@ Page language="c#" Codebehind="AssetStorageRemarks.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.FixedAssets.AssetStorageRemarks" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssetStorageRemarks</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" width="95%" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="����">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr align="center">
									<td align="center" colSpan="4">
										<h3>�� �� &nbsp;�� ע</h3>
									</td>
								</tr>
								<TR>
									<TD style="WIDTH: 93px; HEIGHT: 17px" align="right">��&nbsp;&nbsp; ��&nbsp;&nbsp;�ţ�</TD>
									<TD style="WIDTH: 432px; HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server" Width="336px"></asp:textbox>(�Զ��ŷָ�)</TD>
									<TD style="WIDTH: 92px; HEIGHT: 17px" align="right">�Ƿ��Ա�ע���</TD>
									<TD style="HEIGHT: 17px"><asp:radiobutton id="rbtMark1" runat="server" GroupName="IsMark" Text="��"></asp:radiobutton><asp:radiobutton id="rbtMark2" runat="server" GroupName="IsMark" Text="��"></asp:radiobutton><asp:radiobutton id="rbtMark3" runat="server" GroupName="IsMark" Text="All" Checked="True"></asp:radiobutton></TD>
									<TD style="HEIGHT: 17px" align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px" align="right">�� Ŀ �� �ƣ�</TD>
									<TD style="WIDTH: 432px"><asp:textbox id="txtProduct" runat="server" Width="336px"></asp:textbox>(�Զ��ŷָ�)</TD>
									<TD align="right" style="WIDTH: 92px"><asp:checkbox id="CheckBox2" runat="server" Text="�Ƿ�����"></asp:checkbox></TD>
									<TD><asp:radiobutton id="rbtChiceYes" runat="server" Text="��" GroupName="rbtChice"></asp:radiobutton><asp:radiobutton id="rbtChiceNo" GroupName="rbtChice" runat="server" Text="��"></asp:radiobutton>
										<asp:RadioButton id="rbtChiceAll" runat="server" Text="ALL" GroupName="rbtChice" Checked="True"></asp:RadioButton></TD>
									<TD align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px" align="right">��&nbsp; &nbsp;ͬ&nbsp; �ţ�</TD>
									<TD style="WIDTH: 432px"><asp:textbox id="txtOrderNumber" runat="server" Width="160px"></asp:textbox></TD>
									<TD style="WIDTH: 92px"></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="ButtonFlat"></asp:button></TD>
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
					<td style="WIDTH: 600px; HEIGHT: 190px; BACKGROUND-COLOR: #e8f4ff" align="left" colSpan="6">
						<div id="DIV2" style="BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; OVERFLOW: auto; BORDER-LEFT: 0px; WIDTH: 100%; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; HEIGHT: 25px"
							align="right"><asp:label id="lblPage" runat="server"></asp:label>&nbsp;&nbsp;
							<asp:button id="btnFrist" runat="server" Width="40px" Text="�� ҳ" CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnPageShi" runat="server" Width="70px" Text="�� ʮ ҳ " CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnShang" runat="server" Width="40px" Text="��ҳ" CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnXia" runat="server" Width="40px" Text="��ҳ" CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnTuiShi" runat="server" Width="70px" Text="ǰ ʮ ҳ" CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
							<asp:button id="btnMo" runat="server" Width="40px" Text="ĩ ҳ" CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
							<asp:label id="lblTiao" runat="server">
								<FONT face="����" size="3px">��ת</FONT></asp:label><asp:textbox id="txtPage" runat="server" Width="32px" Height="18px"></asp:textbox><asp:button id="btnGo" runat="server" Width="35px" Text="GO" CssClass="ButtonFlat" Font-Size="10PX"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</div>
						<div id="DIV1" style="BORDER-RIGHT: 0px; PADDING-RIGHT: 0px; BORDER-TOP: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; OVERFLOW: auto; BORDER-LEFT: 0px; WIDTH: 900px; PADDING-TOP: 0px; BORDER-BOTTOM: 0px; HEIGHT: 200px"><asp:datagrid id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
								BorderColor="#93BEE2" AllowSorting="True" DataKeyField="Id">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width="30px">
										<ItemTemplate>
											<FONT face="����">
												<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="50px">
										<ItemTemplate>
											<asp:Button id="btnMark" runat="server" Text="��ע" CssClass="ButtonFlat" CommandName="ReMark" CommandArgument='<%# DataBinder.Eval( Container.DataItem,"Id") %>'>
											</asp:Button>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-Width="50px" HeaderText="���">
										<ItemTemplate>
											<asp:Label id = "lblyfk" Runat = "server" Text = '<%# int.Parse(DataBinder.Eval( Container.DataItem,"IsInStore").ToString()) == 1 ? "��" : "��" %>'>
											</asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="aid" DataNavigateUrlFormatString="../PriceCheck/FinallyCheckApplyForOneApply.aspx?FinallyCheckId={0}"
										DataTextField="BargainNo" HeaderText="��ͬ��"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="ItemName" HeaderText="��Ŀ����"></asp:BoundColumn>
									<asp:BoundColumn DataField="Asset_ApplySheet_Body_Id" HeaderText="��Ʒ����"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplySheetHead_Pk" HeaderText="������"></asp:BoundColumn>
									<asp:BoundColumn DataField="InStoreSigner" HeaderText="����ע��Ա" ItemStyle-Width="100px"></asp:BoundColumn>
									<asp:BoundColumn DataField="InStoreDatetime" HeaderText="���ʱ��" DataFormatString="{0:yyyy-MM-dd}"
										ItemStyle-Width="100px"></asp:BoundColumn>
									<asp:BoundColumn DataField="MakeDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></div>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"><asp:checkbox id="chbSelectAll" runat="server" Text="ȫѡ" AutoPostBack="True"></asp:checkbox>&nbsp;
							<asp:button id="btnUpdateShuju" runat="server" Width="70px" Text="�� ��" CssClass="ButtonFlat"
								Font-Size="15px"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label4" runat="server" Font-Size="18px" ForeColor="#ff0000"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT>
					</td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="����"><asp:panel id="Panel1" runat="server" BackColor="White" Visible="False">
								<TABLE id="Table2" borderColor="#003333" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 2px" align="right">�Ƿ� ��</TD>
										<TD style="HEIGHT: 2px">&nbsp;
											<asp:CheckBox id="CheckBox3" runat="server" Text="���"></asp:CheckBox>
										<TD style="HEIGHT: 2px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 2px" align="right">����ע��Ա��</TD>
										<TD style="HEIGHT: 2px">&nbsp;
											<asp:TextBox id="TextBox1" runat="server" Width="136px" Enabled="False"></asp:TextBox></TD>
										<TD style="HEIGHT: 2px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 2px" align="right">���ʱ�䣺</TD>
										<TD style="HEIGHT: 2px">&nbsp;
											<asp:TextBox id="txtDateTo" onfocus="WdatePicker({startData:'2020-10-01'})" runat="server" Width="136px"
												Enabled="False"></asp:TextBox></TD>
										<TD style="HEIGHT: 2px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">&nbsp;</TD>
										<TD>&nbsp;
											<asp:button id="btnEnter" runat="server" Width="83px" Text="ȷ��" CssClass="ButtonFlat"></asp:button>
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
		</form>
	</body>
</HTML>
