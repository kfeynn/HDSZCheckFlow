<%@ Page language="c#" Codebehind="GetBackPriceCheckApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.GetBackPriceCheckApply"  EnableEventValidation="false"%>
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
		<!--<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<LINK rel="stylesheet" type="text/css" href="../../AppSystem/common.css">--><LINK rel="stylesheet" type="text/css" href="../../Style/BasicLayout.css"><LINK rel="stylesheet" type="text/css" href="../../Style/Style.css"><LINK rel="stylesheet" type="text/css" href="../../AppSystem/common.css">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT style="Z-INDEX: 105; POSITION: absolute; TOP: 432px; LEFT: 64px" id="hideApplyHead"
				value="0" type="hidden" name="Hidden1" runat="server">
			<table id="tblToolBar" border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080"
				align="center">
				<tr>
					<td class="tdButtonBar">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="90%">取回单据：<asp:label id="lbMsg" runat="server" ForeColor="Red"></asp:label></td>
								<TD style="PADDING-RIGHT: 5px" width="10%" align="right"></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--导航工具条结束-->
			<table style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td height="5" align="center"><asp:button style="Z-INDEX: 0" id="btnGetBack" runat="server" CssClass="ButtonFlat" Text="取回单据"></asp:button><FONT face="宋体">&nbsp;&nbsp;&nbsp;
						</FONT>
						<asp:button style="Z-INDEX: 0" id="btnKeep" runat="server" CssClass="ButtonFlat" Text="封存单据"
							Visible="False"></asp:button></td>
				</tr>
			</table>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101;   BORDER-BOTTOM-COLOR: #0066cc;   BORDER-TOP-COLOR: #0066cc;   WIDTH: 100%;   BORDER-COLLAPSE: collapse;   HEIGHT: 36px;   BORDER-RIGHT-COLOR: #0066cc;   BORDER-LEFT-COLOR: #0066cc;   TOP: 0px;   LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
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
								<asp:BoundColumn Visible="False" DataField="Id" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnLook" runat="server" Width="56px" CssClass="ButtonFlat" Text="选择" CommandName="look"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="Id" DataNavigateUrlFormatString="FinallyCheckApplyForOneApply.aspx?FinallyCheckId={0}"
									DataTextField="BargainNo" HeaderText="合同号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplySheetNo" SortExpression="ApplyTypeName" HeaderText="单据号"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="申请日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="申请部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="申请人"></asp:BoundColumn>
								<asp:BoundColumn DataField="Price" SortExpression="SheetRmbMoney" HeaderText="金额" DataFormatString="{0:N}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="单据状态"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<!--<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><FONT face="宋体"></FONT></td>
				</tr>-->
				<tr>
					<td class="tdButtonBar"></td>
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
				<!--<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><FONT face="宋体"></FONT></td>
				</tr>-->
			</table>
			<INPUT style="Z-INDEX: 104; POSITION: absolute; TOP: 480px; LEFT: 416px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server"><INPUT style="Z-INDEX: 103; POSITION: absolute; TOP: 496px; LEFT: 632px" id="pagesIndex"
				value="0" type="hidden" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 102; POSITION: absolute; TOP: 488px; LEFT: 248px" id="HerdSort"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton style="Z-INDEX: 101; POSITION: absolute; TOP: 512px; LEFT: 400px" id="linkToPage"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
