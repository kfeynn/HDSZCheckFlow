<%@ Page language="c#" Codebehind="PickPurchase.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.OrderManage.BaseInfo.PickPurchase"  EnableEventValidation="false" %>
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
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<TBODY>
					<tr style="HEIGHT: 28px">
						<td align="center" colSpan="6"><FONT face="����">
								<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<tr>
										<td style="WIDTH: 93px" height="26"></td>
									</tr>
									<TR>
										<TD style="WIDTH: 93px; HEIGHT: 17px">��&nbsp;&nbsp; ��&nbsp;&nbsp;��</TD>
										<TD style="WIDTH: 397px; HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server" Width="296px"></asp:textbox>(�Զ��ŷָ�)</TD>
										<TD style="HEIGHT: 17px">�� �� �� ��</TD>
										<TD style="HEIGHT: 17px">
											<asp:dropdownlist id="ddlDeptClass" runat="server" Width="166px" AutoPostBack="True"></asp:dropdownlist>
											<asp:dropdownlist id="ddlDept" runat="server" Width="166px"></asp:dropdownlist></TD>
										<TD style="HEIGHT: 17px" align="center"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 93px">�� Ʒ �� ��</TD>
										<TD style="WIDTH: 397px"><asp:textbox id="txtProduct" runat="server" Width="296px"></asp:textbox>(�Զ��ŷָ�)</TD>
										<TD>�������</TD>
										<TD>
											<asp:DropDownList id="ddlInvClass" runat="server" Width="168px"></asp:DropDownList></TD>
										<TD align="center"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 93px; HEIGHT: 24px">��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ��</TD>
										<TD style="WIDTH: 397px; HEIGHT: 24px">
											<asp:textbox id="txtDateFrom" runat="server" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"></asp:textbox>��
											<asp:textbox id="txtDateTo" runat="server" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"></asp:textbox></TD>
										<TD style="HEIGHT: 24px"></TD>
										<TD style="HEIGHT: 24px">
											<asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss"></asp:button></TD>
										<TD style="HEIGHT: 24px" align="center"></TD>
									</TR>
								</TABLE>
							</FONT>
						</td>
					</tr>
					<TR style="HEIGHT: 28px">
						<TD style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
							colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
							<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
						</TD>
					</TR>
					<tr id="bodyInfo" style="HEIGHT: 22px">
						<td style="WIDTH: 100%; HEIGHT: 161px; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
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
											<FONT face="����">
												<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
										DataTextField="ApplySheetNo" HeaderText="���ݺ�"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="DeptName" HeaderText="����"></asp:BoundColumn>
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
									<asp:BoundColumn DataField="IsGiveUp" HeaderText="�Ƿ����"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk"></asp:BoundColumn>
									<asp:BoundColumn DataField="memo" HeaderText="��ע"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<tr style="HEIGHT: 26px">
						<td style="WIDTH: 10%; HEIGHT: 28px" align="left" background="../../Style/Images/treetopbg.jpg"
							colSpan="1"><FONT face="����"><asp:checkbox id="chbSelectAll" runat="server" Text="ȫѡ" AutoPostBack="True"></asp:checkbox></FONT></td>
						<td style="WIDTH: 40%; HEIGHT: 28px" align="center" background="../../Style/Images/treetopbg.jpg"
							colSpan="2"><FONT face="����"><asp:imagebutton id="imgBtnUp" runat="server" Width="25px" Height="26px" ImageUrl="../../Style/Images/up.jpg"></asp:imagebutton></FONT></td>
						<td style="WIDTH: 50%; HEIGHT: 28px" align="center" background="../../Style/Images/treetopbg.jpg"
							colSpan="3"><asp:imagebutton id="imgBtnDown" runat="server" Width="24px" Height="24px" ImageUrl="../../Style/Images/down.jpg"></asp:imagebutton><asp:label id="lblMessage" runat="server"></asp:label></td>
					</tr>
					<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
						<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:panel id="Panel1" runat="server" BackColor="White" Visible="true">
								<asp:datagrid id="dgOrder" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
									BackColor="White" AutoGenerateColumns="False">
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="ApplySheetBody_Purchase_pk" HeaderText="ID"></asp:BoundColumn>
										<asp:TemplateColumn>
											<ItemTemplate>
												<FONT face="����">
													<asp:CheckBox id="Checkbox1" runat="server"></asp:CheckBox></FONT>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
											DataTextField="ApplySheetNo" HeaderText="���ݺ�"></asp:HyperLinkColumn>
										<asp:BoundColumn DataField="DeptName" HeaderText="����"></asp:BoundColumn>
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
										<asp:BoundColumn DataField="IsGiveUp" HeaderText="�Ƿ����"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk"></asp:BoundColumn>
										<asp:BoundColumn DataField="memo" HeaderText="��ע"></asp:BoundColumn>
									</Columns>
									<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
								</asp:datagrid>
							</asp:panel></td>
					</tr>
					<tr style="HEIGHT: 28px">
						<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
							colSpan="6"><FONT face="����">
								<asp:Button id="btnSaveOrder" runat="server" Text="���ɶ���"></asp:Button></FONT></td>
					</tr>
				</TBODY>
			</table>
			<INPUT id="pagesIndex" style="Z-INDEX: 104; LEFT: 624px; POSITION: absolute; TOP: 528px"
				type="hidden" value="0" name="Hidden1" runat="server"><INPUT id="HerdSort" style="Z-INDEX: 103; LEFT: 160px; POSITION: absolute; TOP: 520px"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"
				runat="server"></asp:linkbutton><INPUT id="FieldSort" style="Z-INDEX: 105; LEFT: 504px; POSITION: absolute; TOP: 528px"
				type="hidden" name="Hidden2" runat="server"></form>
	</body>
</HTML>
