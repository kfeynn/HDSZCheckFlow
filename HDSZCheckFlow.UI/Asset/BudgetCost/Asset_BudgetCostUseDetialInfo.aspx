<%@ Page language="c#" Codebehind="Asset_BudgetCostUseDetialInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetCostUseDetialInfo"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��ӪԤʵ������ձ�(��ԭ��ҳ����ʽ)</title>
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
		<style>
			.myCss { BACKGROUND-COLOR: #dee4f4 }
			.cssFooter
			{
			text-align:right;
			color:blue;
			}
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colspan="6"><FONT face="����">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD height="17" style="WIDTH: 46px"></TD>
									<TD style="WIDTH: 111px" height="17"></TD>
									<TD style="WIDTH: 111px" height="17"></TD>
								</TR>
								<TR>
									<td align="right" style="WIDTH: 46px; HEIGHT: 25px">���:</td>
									<td style="WIDTH: 111px; HEIGHT: 25px"><asp:textbox id="txtDate" onfocus="WdatePicker({dateFmt:'yyyy'})" runat="server" Width="93px"></asp:textbox></td>
									<td align="right" style="WIDTH: 93px; HEIGHT: 25px">��Ŀ����:</td>
									<td style="WIDTH: 151px; HEIGHT: 25px"><asp:dropdownlist id="ddlItemType" runat="server" Width="150px" AutoPostBack="True"></asp:dropdownlist></td>
									<TD style="WIDTH: 75px; HEIGHT: 25px" align="right" colSpan="1" rowSpan="1">��Ŀ����:</TD>
									<TD style="WIDTH: 263px; HEIGHT: 25px">
										<asp:dropdownlist id="ddlItemName" runat="server" Width="150px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 263px; HEIGHT: 25px">
										<asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss myCss" />&nbsp;&nbsp;&nbsp;
										<asp:Button id="btnOutput" runat="server" CssClass="redButtonCss myCss" Text="������Excel" /></TD>
									<TD style="WIDTH: 92px; HEIGHT: 25px"></TD>
									<TD style="WIDTH: 1px; HEIGHT: 25px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 46px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 111px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 93px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 151px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 75px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 263px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 263px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 92px; HEIGHT: 11px"></TD>
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
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6">
						<asp:datagrid id="dgApply" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
							Width="100%" PageSize="20" AllowSorting="True" ShowFooter="True">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#DEE4F4"></FooterStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="���" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="���" SortExpression="���" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="����" SortExpression="����" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="��Ŀ����" SortExpression="��Ŀ����" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="��Ŀ����" SortExpression="��Ŀ����" HeaderText="��Ŀ����"></asp:BoundColumn>
								<asp:BoundColumn DataField="����" SortExpression="����" HeaderText="����"></asp:BoundColumn>
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
			<asp:linkbutton id="linkToPage" runat="server" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"></asp:linkbutton><INPUT id="HerdSort" style="Z-INDEX: 103; LEFT: 200px; POSITION: absolute; TOP: 424px"
				type="hidden" name="Hidden3" runat="server"><INPUT id="FieldSort" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 448px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 105; LEFT: 248px; POSITION: absolute; TOP: 472px"
				type="hidden" value="0" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
