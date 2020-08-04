<%@ Page language="c#" Codebehind="AssetApplySheetState.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.CheckFlow.AssetApplySheetState" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>查询申请单状态</title>
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
		<style>.myCss {
	BACKGROUND-COLOR: #dee4f4
}
.cssFooter {
	COLOR: blue; TEXT-ALIGN: right
}
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="宋体">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 67px" height="17"></TD>
									<TD style="WIDTH: 137px" height="17"></TD>
									<TD style="WIDTH: 111px" height="17"></TD>
									<TD style="WIDTH: 111px" height="17"></TD>
									<TD style="WIDTH: 93px" height="17"></TD>
								</TR>
								<TR>
									<td style="WIDTH: 67px; HEIGHT: 18px" align="right">合同号:</td>
									<td style="WIDTH: 137px; HEIGHT: 18px"><asp:textbox id="txtBargainNo" runat="server" Width="93px"></asp:textbox></td>
									<td style="WIDTH: 93px; HEIGHT: 18px" align="right">项目类型:</td>
									<td style="WIDTH: 151px; HEIGHT: 18px"><asp:dropdownlist id="ddlItemType" runat="server" Width="150px" AutoPostBack="True"></asp:dropdownlist></td>
									<TD style="WIDTH: 93px; HEIGHT: 18px" align="right">项目名称:</TD>
									<TD style="WIDTH: 178px; HEIGHT: 18px"><asp:dropdownlist id="ddlItemName" runat="server" Width="150px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 88px; HEIGHT: 18px" align="right">物品名称:</TD>
									<TD style="WIDTH: 123px; HEIGHT: 18px"><asp:textbox id="txtInventoryName" runat="server" Width="93px"></asp:textbox></TD>
									<TD style="WIDTH: 263px; HEIGHT: 18px"><asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss myCss" Text="查询"></asp:button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnOutput" runat="server" CssClass="redButtonCss myCss" Text="导出到Excel"></asp:button></TD>
									<TD style="WIDTH: 1px; HEIGHT: 18px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 67px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 137px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 93px; HEIGHT: 11px" align="right"></TD>
									<TD style="WIDTH: 151px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 93px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 178px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 88px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 123px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 263px; HEIGHT: 11px"></TD>
									<TD style="WIDTH: 1px; HEIGHT: 11px"></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</TD>
				</TR>
				<TR id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<SelectedItemStyle ForeColor="#0000C0" BackColor="LightGray"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#DEE4F4"></FooterStyle>
							<Columns>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:LinkButton ID="lbSelect" Runat="server" Width="40" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.BargainNo") %>' CommandName="SELECT"> 选 择 </asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ApplySheetNo" HeaderText="单据号"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="Id" DataNavigateUrlFormatString="../PriceCheck/FinallyCheckApplyForOneApply.aspx?FinallyCheckId={0}"
									DataTextField="BargainNo" HeaderText="合同号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="项目类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="SubjectName" SortExpression="SubjectName" HeaderText="项目内容"></asp:BoundColumn>
								<asp:BoundColumn DataField="InventoryName" SortExpression="InventoryName" HeaderText="物品名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="单据状态"></asp:BoundColumn>

							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; HEIGHT: 29px; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="宋体">
							<div>
								<asp:datagrid id="dgStateBody" runat="server" Width="100%"  BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<SelectedItemStyle ForeColor="#0000C0" BackColor="LightGray"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							
							<Columns>
								<asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="项目类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="SubjectName" SortExpression="SubjectName" HeaderText="项目内容"></asp:BoundColumn>
								<asp:BoundColumn DataField="InventoryName" SortExpression="InventoryName" HeaderText="物品名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="Number" SortExpression="Number" HeaderText="数量"></asp:BoundColumn>
								<asp:BoundColumn DataField="IsArrived" SortExpression="IsArrived" HeaderText="是否到货"></asp:BoundColumn>
								<asp:BoundColumn DataField="IsPayFor" SortExpression="IsPayFor" HeaderText="是否付款"></asp:BoundColumn>
								<asp:BoundColumn DataField="IsInStore" SortExpression="IsInStore" HeaderText="是否入库"></asp:BoundColumn>
								<asp:BoundColumn DataField="Earnest" SortExpression="Earnest" HeaderText="是否预付款"></asp:BoundColumn>
								<asp:BoundColumn DataField="EarnestRemark" SortExpression="EarnestRemark" HeaderText="预付款备注"></asp:BoundColumn>
								<asp:BoundColumn DataField="Offer" SortExpression="Offer" HeaderText="供应商"></asp:BoundColumn>
							</Columns>
							
						</asp:datagrid>
							</div>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
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
