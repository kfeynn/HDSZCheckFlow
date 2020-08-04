<%@ Page language="c#" Codebehind="GetBackAssetApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.CheckFlow.GetBackAssetApply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblToolBar" border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080"
				align="center">
				<tr>
					<td class="tdButtonBar">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="90%">ȡ�ص��ݣ�<asp:label id="lbMsg" runat="server" ForeColor="Red"></asp:label></td>
								<TD style="PADDING-RIGHT: 5px" width="10%" align="right"></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--��������������-->
			<table style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td height="5" align="center"><asp:button style="Z-INDEX: 0" id="btnGetBack" runat="server" CssClass="ButtonFlat" Text="ȡ�ص���"></asp:button><FONT face="����">&nbsp;&nbsp;&nbsp;
						</FONT>
						<asp:button style="Z-INDEX: 0" id="btnKeep" runat="server" CssClass="ButtonFlat" Text="��浥��"></asp:button></td>
				</tr>
			</table>
			<!--��ѯ������ʼ-->
			<table id="tblSearch" class="TableSearch2" border="0" cellSpacing="1" cellPadding="0" width="100%"
				align="center">
				<tr>
					<td>
						<P style="MARGIN-TOP:3px">
							<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApplyHead" runat="server" Width="99%" BackColor="White"
								BorderColor="#93BEE2" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" PageSize="5">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle ForeColor="#003399"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ID"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="����">
												<asp:Button style="Z-INDEX: 0" id="btnSelect" runat="server" Text="ѡ��" CssClass="ButtonFlat"
													Width="50px" CommandName="select"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="����">
												<asp:Button id="btnDelete" runat="server" Text="ɾ��" CssClass="ButtonFlat" Width="50px" CommandName="delete"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="AssetApplyForOneApply.aspx?applyHeadPK={0}"
										DataTextField="ApplySheetNo" HeaderText="���ݺ�"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="ApplyTypeName" HeaderText="��������"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeptName" HeaderText="���벿��"></asp:BoundColumn>
									<asp:BoundColumn DataField="Name" HeaderText="������"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyProcessTypeName" HeaderText="�������"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeliveryDate" HeaderText="��������"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyMakerCode" HeaderText="����Ա"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
							</asp:datagrid>
						</P>
					</td>
				</tr>
				<TR>
					<td style="MARGIN-TOP: 5px; PADDING-TOP: 8px; MARGIN-botton: 5px" colSpan="10" align="center"><asp:panel id="PBudgetInfo" runat="server" Visible="False">
							<TABLE border="0" cellSpacing="0" cellPadding="0" width="80%">
								<TR style="COLOR: #339966">
									<TD style="HEIGHT: 19px">
										<asp:label id="lbBudget" runat="server">Ԥ����</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbOutMoney" runat="server">Ԥ������</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbSumCheck" runat="server">�Ѿ�ʹ��</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbready" runat="server">��̯���</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbSheetMoney" runat="server">����ʹ��</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbLeft" runat="server">ʣ   ��</asp:label></TD>
								</TR>
								<TR style="COLOR: #333333">
									<TD>
										<asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblOutMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblSumCheck" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblready" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblSheetMoney" runat="server" Visible="False"></asp:label></TD>
									<TD>
										<asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</TR>
			</table>
			<!--XPGrid ������ӱ���-->
			<p style="MARGIN-TOP: 8px"><asp:panel style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px"
					id="pAddItem" runat="server" Visible="false">
<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080" align="center">
						<TR>
							<TD class="tdButtonBar">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD width="100%">������ϸ��</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="aliceblue">
									<TR id="tbAddBody">
										<TD><FONT face="����"></FONT></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD bgColor="infobackground" width="100%"><FONT face="����">
									<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApply" runat="server" PageSize="20" AutoGenerateColumns="False"
										AllowSorting="True" BorderColor="#93BEE2" BackColor="White" Width="99%" Visible="False">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:BoundColumn DataField="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InventoryName" HeaderText="��Ʒ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InvType" HeaderText="����ͺ�"></asp:BoundColumn>
											<asp:BoundColumn DataField="Base_Unit_id" HeaderText="��λ"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҵ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalMoney" HeaderText="ԭ�ҽ��"></asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="��׼����"></asp:BoundColumn>
											<asp:BoundColumn DataField="RmbPrice" HeaderText="���ҵ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="RmbMoney" HeaderText="���ҽ��"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
									</asp:datagrid></FONT></TD>
						</TR>
					</TABLE><FONT face="����"><INPUT style="Z-INDEX: 0" id="hideApplyHead" value="0" type="hidden" name="Hidden1" runat="server"></FONT>&nbsp; 
				</asp:panel></p>
		</form>
	</body>
</HTML>
