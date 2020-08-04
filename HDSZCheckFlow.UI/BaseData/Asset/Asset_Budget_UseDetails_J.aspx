<%@ Page language="c#" Codebehind="Asset_Budget_UseDetails_J.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Asset.Asset_Budget_UseDetails_J" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>新营预算使用明细表</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">基本情報</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%" align="right">
						予算部門:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblBudgetDept" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%" align="right">
						年&nbsp;&nbsp;&nbsp;&nbsp;份:</td>
					<td style="WIDTH: 86.53%" colSpan="5"><FONT face="宋体"><asp:label id="lblYear" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%" align="right">項目名称:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblItemName" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%" align="right">予算金額:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblBudgetMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%" align="right"><FONT face="宋体" style="Z-INDEX: 0">予算外金額:</FONT></TD>
					<TD style="WIDTH: 80%" colSpan="5">
						<asp:label id="lblOutMoney" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%" align="right">前払金額:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblReadypay" runat="server"></asp:label></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 18.96%; HEIGHT: 16px" align="right">すでに使用:</td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="宋体"><asp:label id="lblCheckedMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td style="WIDTH: 171px; HEIGHT: 23px" align="right"><SPAN id="Label6"> 剰余</SPAN>:</td>
					<td style="HEIGHT: 23px" align="left" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblLeft" runat="server"></asp:label><A href="./AttachFiles/hilly/72691351/bug.txt" target="_blank"></A></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">使用明細</td>
				</tr>
				<tr style=" HEIGHT: 22px" id="bodyInfo">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>
									<asp:datagrid id="dgApply" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
										AutoGenerateColumns="False" PageSize="20" AllowSorting="True">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ID"></asp:BoundColumn>
											<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../Asset/CheckFlow/AssetApplyForOneApply_J.aspx?applyHeadPK={0}"
												DataTextField="ApplySheetNo" HeaderText="書類番号">
												<HeaderStyle Font-Size="13px"></HeaderStyle>
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:HyperLinkColumn>
											<asp:BoundColumn DataField="ApplyTypeName" SortExpression="ApplyTypeName" HeaderText="申請類型">
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="申請日付" DataFormatString="{0:yyyy-MM-dd}">
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="申請部門">
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="申請者">
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SheetRmbMoney" SortExpression="SheetRmbMoney" HeaderText="金額" DataFormatString="{0:N}">
												<ItemStyle Font-Size="13px" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SubmitType" SortExpression="SubmitType" HeaderText="類別">
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="書類状態">
												<ItemStyle Font-Size="13px"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<FONT face="宋体">
														<asp:Button id="btnLook" runat="server" CommandName="look" CssClass="redButtonCss" Text="調整検索"></asp:Button></FONT>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style=" HEIGHT: 28px" id="postail">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="宋体">
							<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Width="100%">
								<SelectedItemStyle Font-Size="13px"></SelectedItemStyle>
								<EditItemStyle Font-Size="13px"></EditItemStyle>
								<AlternatingItemStyle Font-Size="13px"></AlternatingItemStyle>
								<ItemStyle Font-Size="13px"></ItemStyle>
								<HeaderStyle Font-Size="14px"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="SheetDate" HeaderText="日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="firstSubjectCode" HeaderText="一级科目"></asp:BoundColumn>
									<asp:BoundColumn DataField="SubjectCode" HeaderText="科目"></asp:BoundColumn>
									<asp:BoundColumn DataField="BudgetDept" HeaderText="部门编号"></asp:BoundColumn>
									<asp:BoundColumn DataField="alterYear" HeaderText="调整年份"></asp:BoundColumn>
									<asp:BoundColumn DataField="alterMonth" HeaderText="调整月份"></asp:BoundColumn>
									<asp:BoundColumn DataField="alterMoney" HeaderText="调整金额"></asp:BoundColumn>
									<asp:BoundColumn DataField="Memo" HeaderText="备注"></asp:BoundColumn>
									<asp:BoundColumn DataField="IsSubmit" HeaderText="提交"></asp:BoundColumn>
									<asp:BoundColumn DataField="MarkerCode" HeaderText="制单人"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr>
					<td style="WIDTH: 18.96%" align="right"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT></td>
					<td align="left" colSpan="5"><FONT face="宋体">
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></FONT></td>
				</tr>
				<tr align="center" style="HEIGHT:22px">
					<td colspan="6"><INPUT class="redButtonCss" id="retrunBack" style="WIDTH: 66px; HEIGHT: 20px" onclick="javascript:history.go(-1);"
							type="button" value="戻り" name="retrunBack"></td>
				</tr>
				<tr>
					<td align="left" colSpan="6" height="32"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
