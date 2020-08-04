<%@ Page language="c#" Codebehind="PriceCheckApplyList_ForFinance.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.PriceCheckApplyList_ForFinance"  EnableEventValidation="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Style/BasicLayout.css">
		<!--<script language="javascript" src="../../Style/My97DatePicker/WdatePicker.js"></script>-->
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<LINK rel="stylesheet" type="text/css" href="../../AppSystem/common.css">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				id="tabDispDocument" class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3">
				<tr style="HEIGHT: 28px">
					<td colSpan="6" align="center"><FONT face="宋体">
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 17px">申请部门</TD>
									<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlDeptClass" runat="server" AutoPostBack="True" Width="90px"></asp:dropdownlist></TD>
									<TD style="Z-INDEX: 0; HEIGHT: 17px">单 据 号</TD>
									<TD style="HEIGHT: 17px"><asp:textbox style="Z-INDEX: 0" id="txtApplyNo" runat="server"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; HEIGHT: 17px" align="center">起始日期</TD>
									<TD style="HEIGHT: 17px"><asp:textbox style="Z-INDEX: 0" id="txtDateFrom" onfocus="WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="90px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; HEIGHT: 17px">结束日期</TD>
									<TD style="HEIGHT: 17px"><asp:textbox style="Z-INDEX: 0" id="txtDateTo" onfocus="WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="90px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>申请科组</TD>
									<TD><asp:dropdownlist id="ddlDept" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD>合 同 号</TD>
									<TD><asp:textbox style="Z-INDEX: 0" id="txtBargan" runat="server"></asp:textbox></TD>
									<TD align="center">单据状态</TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss" Text="查询"></asp:button>
										<asp:button style="Z-INDEX: 0" id="btnOutput" runat="server" Width="72px" Text="导出" CssClass="redButtonCss"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="6" align="right"><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</td>
				</tr>
				<tr style="DISPLAY: block; HEIGHT: 22px" id="bodyInfo">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" colSpan="6" align="center"><asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="FinallyPriceCheck_Id" HeaderText="FinallyPriceCheck_Id"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnLook" runat="server" Width="76px" CssClass="redButtonCss" Text="查看进度" CommandName="look"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="FinallyPriceCheck_Id" DataNavigateUrlFormatString="FinallyCheckApplyForOneApply.aspx?FinallyCheckId={0}"
									DataTextField="BargainNo" HeaderText="合同号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplySheetNo" SortExpression="ApplyTypeName" HeaderText="单据号"></asp:BoundColumn>
								<asp:BoundColumn DataField="MakeDate" SortExpression="MakeDate" HeaderText="申请日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
								<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率"></asp:BoundColumn>
								<asp:BoundColumn DataField="Number" HeaderText="数量"></asp:BoundColumn>
								<asp:BoundColumn DataField="FinallyPrice" SortExpression="FinallyPrice" HeaderText="单价" DataFormatString="{0:N}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SubjectName" HeaderText="物品"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="单据状态"></asp:BoundColumn>
								<asp:BoundColumn DataField="Checkdate" HeaderText="最后审批日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="deptname" HeaderText="申请部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="requestdate" HeaderText="到货日期"></asp:BoundColumn>
								<asp:BoundColumn DataField="isArrivedC" HeaderText="标注到货"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><FONT face="宋体"></FONT></td>
				</tr>
				<tr style="DISPLAY: block; HEIGHT: 28px" id="postail">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" colSpan="6" align="center"><FONT face="宋体"><asp:datagrid id="dgPostail" runat="server" Width="100%" BorderColor="#93BEE2" BackColor="White"
								AutoGenerateColumns="False">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="批阅人">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="角色" DataField="CheckRoleName">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Checkdate" HeaderText="批阅时间">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IsAgree" HeaderText="批阅类型">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CheckComment" HeaderText="意见">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
			<INPUT style="Z-INDEX: 106; POSITION: absolute; TOP: 480px; LEFT: 416px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server"><INPUT style="Z-INDEX: 105; POSITION: absolute; TOP: 496px; LEFT: 632px" id="pagesIndex"
				value="0" type="hidden" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 104; POSITION: absolute; TOP: 488px; LEFT: 248px" id="HerdSort"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px" id="linkToPage"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
