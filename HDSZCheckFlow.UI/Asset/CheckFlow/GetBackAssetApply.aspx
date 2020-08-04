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
						<asp:button style="Z-INDEX: 0" id="btnKeep" runat="server" CssClass="ButtonFlat" Text="封存单据"></asp:button></td>
				</tr>
			</table>
			<!--查询条件开始-->
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
											<FONT face="宋体">
												<asp:Button style="Z-INDEX: 0" id="btnSelect" runat="server" Text="选择" CssClass="ButtonFlat"
													Width="50px" CommandName="select"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="宋体">
												<asp:Button id="btnDelete" runat="server" Text="删除" CssClass="ButtonFlat" Width="50px" CommandName="delete"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="AssetApplyForOneApply.aspx?applyHeadPK={0}"
										DataTextField="ApplySheetNo" HeaderText="单据号"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="ApplyTypeName" HeaderText="申请类型"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyDate" HeaderText="申请日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeptName" HeaderText="申请部门"></asp:BoundColumn>
									<asp:BoundColumn DataField="Name" HeaderText="申请人"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyProcessTypeName" HeaderText="申请进程"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeliveryDate" HeaderText="交货日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyMakerCode" HeaderText="操作员"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
							</asp:datagrid>
						</P>
					</td>
				</tr>
				<TR>
					<td style="MARGIN-TOP: 5px; PADDING-TOP: 8px; MARGIN-botton: 5px" colSpan="10" align="center"><asp:panel id="PBudgetInfo" runat="server" Visible="False">
							<TABLE border="0" cellSpacing="0" cellPadding="0" width="80%">
								<TR style="COLOR: #339966">
									<TD style="HEIGHT: 19px">
										<asp:label id="lbBudget" runat="server">预算金额</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbOutMoney" runat="server">预算外金额</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbSumCheck" runat="server">已经使用</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbready" runat="server">待摊金额</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbSheetMoney" runat="server">本次使用</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbLeft" runat="server">剩   余</asp:label></TD>
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
			<!--XPGrid 单据添加表体-->
			<p style="MARGIN-TOP: 8px"><asp:panel style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px"
					id="pAddItem" runat="server" Visible="false">
<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080" align="center">
						<TR>
							<TD class="tdButtonBar">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD width="100%">单据明细：</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="aliceblue">
									<TR id="tbAddBody">
										<TD><FONT face="宋体"></FONT></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD bgColor="infobackground" width="100%"><FONT face="宋体">
									<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApply" runat="server" PageSize="20" AutoGenerateColumns="False"
										AllowSorting="True" BorderColor="#93BEE2" BackColor="White" Width="99%" Visible="False">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
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
									</asp:datagrid></FONT></TD>
						</TR>
					</TABLE><FONT face="宋体"><INPUT style="Z-INDEX: 0" id="hideApplyHead" value="0" type="hidden" name="Hidden1" runat="server"></FONT>&nbsp; 
				</asp:panel></p>
		</form>
	</body>
</HTML>
