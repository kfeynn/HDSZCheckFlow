<%@ Page language="c#" Codebehind="AddPriceCheckApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.AddPriceCheckApply"  EnableEventValidation="false"  %>
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
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
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
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colspan="6"><FONT face="宋体">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 17px">申请部门</TD>
									<TD style="HEIGHT: 17px">
										<asp:DropDownList id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:DropDownList></TD>
									<TD style="HEIGHT: 17px">起始日期</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtDateFrom" runat="server" onfocus="WdatePicker({skin:'whyGreen',maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											Width="90px"></asp:TextBox></TD>
									<TD align="center" style="HEIGHT: 17px">结束日期</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtDateTo" runat="server" onfocus="WdatePicker({skin:'whyGreen',minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											Width="90px"></asp:TextBox></TD>
									<TD style="HEIGHT: 17px">单据号</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtApplyNo" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>申请科组</TD>
									<TD><asp:DropDownList id="ddlDept" runat="server" Width="90px"></asp:DropDownList>
									</TD>
									<TD>申请类型</TD>
									<TD><asp:DropDownList id="ddlType" runat="server" Width="90px"></asp:DropDownList>
									</TD>
									<TD align="center">单据状态</TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD></TD>
									<TD>
										<asp:button id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr>
					<td class="tdButtonBar2" colspan="6">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr height="18">
								<td width="10%">新营审批单：</td>
								<TD style="PADDING-RIGHT: 5px" width="90%" align="right"><DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
								</TD>
							</tr>
						</table>
					</td>
				</tr>
				<!--<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
					</td>
				</tr>-->
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
							Width="100%" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnLook" runat="server" Width="56px" CssClass="ButtonFlat" Text="选择" CommandName="look"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../Asset/CheckFlow/AssetApplyForOneApply.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="单据号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplyTypeName" SortExpression="ApplyTypeName" HeaderText="申请类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="申请日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="申请部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="申请人"></asp:BoundColumn>
								<asp:BoundColumn DataField="SheetRmbMoney" SortExpression="SheetRmbMoney" HeaderText="金额" DataFormatString="{0:N}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SubmitType" SortExpression="SubmitType" HeaderText="类别"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="单据状态"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td class="tdButtonBar2" colspan="6">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>
									<asp:panel id="PShow" runat="server" Visible="False">
										<TABLE width="100%">
											<TR>
												<TD width="20%">新营单具体内容：</TD>
												<TD style="PADDING-RIGHT: 5px" width="90%" align="right">
													<asp:Label style="Z-INDEX: 0" id="lbMsg" runat="server" ForeColor="Red"></asp:Label>
													<asp:Button style="Z-INDEX: 0" id="btnMakeCheck" runat="server" CssClass="ButtonFlat" Text="制作裁决单"></asp:Button></TD>
											</TR>
										</TABLE>
									</asp:panel>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6"><FONT face="宋体">
							<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApplyBody" runat="server" Width="99%" AllowSorting="True"
								PageSize="20" BorderColor="#93BEE2" BackColor="White" AutoGenerateColumns="False" Visible="true">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderTemplate>
											选择
										</HeaderTemplate>
										<ItemTemplate>
											<FONT face="宋体">
												<asp:CheckBox id="cbCheck" runat="server" Checked="True"></asp:CheckBox></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SubjectName" HeaderText="项目名称"></asp:BoundColumn>
									<asp:BoundColumn DataField="InventoryName" HeaderText="物品名称"></asp:BoundColumn>
									<asp:BoundColumn DataField="InvType" HeaderText="规格型号"></asp:BoundColumn>
									<asp:BoundColumn DataField="Base_Unit_id" HeaderText="单位"></asp:BoundColumn>
									<asp:BoundColumn DataField="Number" HeaderText="数量"></asp:BoundColumn>
									<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
									<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价"></asp:BoundColumn>
									<asp:BoundColumn DataField="originalMoney" HeaderText="原币金额"></asp:BoundColumn>
									<asp:BoundColumn DataField="ExchangeRate" HeaderText="基准汇率"></asp:BoundColumn>
									<asp:BoundColumn DataField="RmbPrice" HeaderText="本币单价"></asp:BoundColumn>
									<asp:BoundColumn DataField="RmbMoney" HeaderText="本币金额"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
			<INPUT id="FieldSort" style="Z-INDEX: 105; POSITION: absolute; TOP: 480px; LEFT: 416px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 104; POSITION: absolute; TOP: 496px; LEFT: 632px"
				type="hidden" name="Hidden1" runat="server" value="0"><INPUT id="HerdSort" style="Z-INDEX: 103; POSITION: absolute; TOP: 488px; LEFT: 248px"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" runat="server" style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px"></asp:linkbutton>
		</form>
	</body>
</HTML>
