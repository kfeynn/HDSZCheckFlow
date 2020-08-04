<%@ Page language="c#" Codebehind="EditPriceCheckApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.EditPriceCheckApply"  EnableEventValidation="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddAssetApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style/Style.css">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function showDisplay(type)
		{
			//չ��������ʾ����
			if(document.all(type).style.display=='none')
			{
				document.all(type).style.display='block';
			}
			else
			{
				document.all(type).style.display='none';
			}
		} 
		
		function CheckForm()
		{
			return true;
		}
		
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblToolBar" border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080"
				align="center">
				<tr>
					<td class="tdButtonBar">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="90%">ά���۸�þ�����<asp:label id="lbMsg" runat="server" ForeColor="Red"></asp:label></td>
								<TD style="PADDING-RIGHT: 5px" width="10%" align="right">
									<asp:hyperlink style="Z-INDEX: 0" id="hyLindToAnnex" runat="server" Visible="False">��Ӹ���</asp:hyperlink></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--��������������-->
			<table style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td height="5" align="left"><asp:button style="Z-INDEX: 0" id="btnInBudget" runat="server" Text="�ύ�۸�þ�" CssClass="ButtonFlat"></asp:button><FONT face="����">&nbsp;&nbsp;&nbsp;
						</FONT>
					</td>
				</tr>
			</table>
			<!---->
			<table id="tblSearch" class="TableSearch2" border="0" cellSpacing="1" cellPadding="0" width="100%"
				align="center">
				<TR>
					<TD style="Z-INDEX: 0" align="right"><FONT face="����">
							<asp:datagrid style="Z-INDEX: 0" id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowSorting="True" PageSize="20" BorderColor="#93BEE2" BackColor="White">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="Id" HeaderText="ID"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="����">
												<asp:Button id="btnLook" runat="server" Width="56px" CssClass="ButtonFlat" Text="ѡ��" CommandName="look"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="����">
												<asp:Button id="btnDel" Width="56px" runat="server" Text="ɾ��" CommandName="delete" CssClass="ButtonFlat"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="Id" DataNavigateUrlFormatString="FinallyCheckApplyForOneApply.aspx?FinallyCheckId={0}"
										DataTextField="BargainNo" HeaderText="��ͬ��"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="ApplySheetNo" SortExpression="ApplyTypeName" HeaderText="���ݺ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="���벿��"></asp:BoundColumn>
									<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="������"></asp:BoundColumn>
									<asp:BoundColumn DataField="Price" SortExpression="SheetRmbMoney" HeaderText="���" DataFormatString="{0:N}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="����״̬"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
							</asp:datagrid></FONT></TD>
				</TR>
				<tr height="5">
					<td height="5" align="right">
						<!--<hr style="COLOR: lightgrey">--><FONT face="����"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</td>
				</tr>
				<TR style="PADDING-BOTTOM: 15px">
					<td align="center"></td>
				</TR>
			</table>
			<!--XPGrid ������ӱ���-->
			<p style="MARGIN-TOP: 8px"><asp:panel style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px"
					id="pAddItem" runat="server" Visible="true">
<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080" align="center">
						<TR>
							<TD class="tdButtonBar">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD width="100%">�þ�������ϸ��</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="aliceblue">
									<TBODY>
										<TR style="DISPLAY: none" id="tbAddBody">
											<TD><FONT face="����"></FONT></TD>
										</TR>
						</TR>
					</TABLE></TD></TR></TD></TR>
  <TR>
						<TD bgColor="infobackground" width="100%"><FONT face="����">
								<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApplyBody" runat="server" BackColor="White"
									BorderColor="#93BEE2" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" Width="99%">
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="FBID" HeaderText="FBID"></asp:BoundColumn>
										<asp:BoundColumn DataField="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
										<asp:BoundColumn DataField="InventoryName" HeaderText="��Ʒ����"></asp:BoundColumn>
										<asp:BoundColumn DataField="InvType" HeaderText="����ͺ�"></asp:BoundColumn>
										<asp:BoundColumn DataField="UnitName" HeaderText="��λ"></asp:BoundColumn>
										<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
										<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҵ���">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="originalMoney" HeaderText="ԭ�ҽ��">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ExchangeRate" HeaderText="��׼����">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RmbPrice" HeaderText="���ҵ���">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Number" HeaderText="����">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CheckNumber" HeaderText="�Ѳþ�����">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RmbMoney" HeaderText="���ҽ��">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FNumber" HeaderText="�þ�����">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FinallyPrice" HeaderText="�þ��۸�">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Offer" HeaderText="��Ӧ��"></asp:BoundColumn>
									</Columns>
									<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
								</asp:datagrid></FONT></TD>
					</TR></TBODY></TABLE><FONT face="����"></FONT>&nbsp; </asp:panel></p>
			<INPUT id="hideApplyCheckHead" runat="server" value="0" type="hidden" name="hideApplyCheckHead">
			<INPUT id="FieldSort" type="hidden" name="Hidden2" runat="server"> <INPUT id="pagesIndex" value="0" type="hidden" name="Hidden1" runat="server">
			<INPUT id="HerdSort" type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" runat="server"></asp:linkbutton>
		</form>
	</body>
</HTML>
