<%@ Page language="c#" Codebehind="Asset_BudgetCostGeneralInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetCostGeneralInfo" EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��ӪԤ��ʹ�øſ�</title>
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
		<style>.myCss { BACKGROUND-COLOR: #dee4f4 }
	.cssFooter { COLOR: blue; TEXT-ALIGN: right }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="����">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 55px" height="17"></TD>
									<TD style="WIDTH: 130px" height="17"></TD>
									<TD style="WIDTH: 74px" height="17"></TD>
									<TD style="WIDTH: 195px" height="17"></TD>
									<TD style="WIDTH: 107px" height="17"></TD>
								</TR>
								<TR>
									<td style="WIDTH: 55px; HEIGHT: 31px" align="right">���:</td>
									<td style="WIDTH: 130px; HEIGHT: 31px"><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="93px"></asp:textbox></td>
									<TD style="WIDTH: 74px; HEIGHT: 31px" align="right">����:</TD>
									<TD style="WIDTH: 195px; HEIGHT: 31px" align="left"><asp:dropdownlist id="ddlDeptClass" runat="server" Width="144px"></asp:dropdownlist></TD>
									<td style="WIDTH: 107px; HEIGHT: 31px" align="right" colSpan="" rowSpan="">��Ŀ����:</td>
									<td style="WIDTH: 241px; HEIGHT: 31px" align="left"><asp:dropdownlist id="ddlItemType" runat="server" Width="150px"></asp:dropdownlist></td>
									<TD style="WIDTH: 263px; HEIGHT: 31px"><asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss myCss" Text="��ѯ"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnOutput" runat="server" CssClass="redButtonCss myCss" Text="������Excel"></asp:button></TD>
									<TD style="WIDTH: 1px; HEIGHT: 31px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 55px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 130px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 74px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 195px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 107px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 241px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 263px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 1px; HEIGHT: 11px"></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</TD>
				</TR>
				<TR id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" ShowFooter="True" AllowSorting="True" PageSize="20"
							BorderColor="#93BEE2" BackColor="White" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#DEE4F4"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="true" DataField="���" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="����" SortExpression="����" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="��Ŀ����" SortExpression="��Ŀ����" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="Ԥ���ڽ��" SortExpression="Ԥ���ڽ��" HeaderText="Ԥ���ڽ��" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Ԥ������" SortExpression="Ԥ������" HeaderText="Ԥ������" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="�������" SortExpression="�������" HeaderText="�������" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="������" SortExpression="������" HeaderText="������" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="������Ԥ����" SortExpression="������Ԥ����" HeaderText="������Ԥ����" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="���" DataNavigateUrlFormatString="../../BaseData/Asset/Asset_Budget_UseDetails.aspx?AssetBudgetPk={0}"
									DataTextField="ʹ�ý��" HeaderText="ʹ�ý��" DataTextFormatString="{0:N}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ʣ����" SortExpression="ʣ����" HeaderText="ʣ����" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; HEIGHT: 29px; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
			</table>
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"
				runat="server"></asp:linkbutton><INPUT id="HerdSort" style="Z-INDEX: 103; LEFT: 200px; POSITION: absolute; TOP: 424px"
				type="hidden" name="Hidden3" runat="server"><INPUT id="FieldSort" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 448px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 105; LEFT: 248px; POSITION: absolute; TOP: 472px"
				type="hidden" value="0" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
