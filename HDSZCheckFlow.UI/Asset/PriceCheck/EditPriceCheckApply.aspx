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
			//展开收起显示区域
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
								<td width="90%">维护价格裁决单：<asp:label id="lbMsg" runat="server" ForeColor="Red"></asp:label></td>
								<TD style="PADDING-RIGHT: 5px" width="10%" align="right">
									<asp:hyperlink style="Z-INDEX: 0" id="hyLindToAnnex" runat="server" Visible="False">添加附件</asp:hyperlink></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--导航工具条结束-->
			<table style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td height="5" align="left"><asp:button style="Z-INDEX: 0" id="btnInBudget" runat="server" Text="提交价格裁决" CssClass="ButtonFlat"></asp:button><FONT face="宋体">&nbsp;&nbsp;&nbsp;
						</FONT>
					</td>
				</tr>
			</table>
			<!---->
			<table id="tblSearch" class="TableSearch2" border="0" cellSpacing="1" cellPadding="0" width="100%"
				align="center">
				<TR>
					<TD style="Z-INDEX: 0" align="right"><FONT face="宋体">
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
											<FONT face="宋体">
												<asp:Button id="btnLook" runat="server" Width="56px" CssClass="ButtonFlat" Text="选择" CommandName="look"></asp:Button></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="宋体">
												<asp:Button id="btnDel" Width="56px" runat="server" Text="删除" CommandName="delete" CssClass="ButtonFlat"></asp:Button></FONT>
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
							</asp:datagrid></FONT></TD>
				</TR>
				<tr height="5">
					<td height="5" align="right">
						<!--<hr style="COLOR: lightgrey">--><FONT face="宋体"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</td>
				</tr>
				<TR style="PADDING-BOTTOM: 15px">
					<td align="center"></td>
				</TR>
			</table>
			<!--XPGrid 单据添加表体-->
			<p style="MARGIN-TOP: 8px"><asp:panel style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px"
					id="pAddItem" runat="server" Visible="true">
<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080" align="center">
						<TR>
							<TD class="tdButtonBar">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD width="100%">裁决单据明细：</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="aliceblue">
									<TBODY>
										<TR style="DISPLAY: none" id="tbAddBody">
											<TD><FONT face="宋体"></FONT></TD>
										</TR>
						</TR>
					</TABLE></TD></TR></TD></TR>
  <TR>
						<TD bgColor="infobackground" width="100%"><FONT face="宋体">
								<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApplyBody" runat="server" BackColor="White"
									BorderColor="#93BEE2" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" Width="99%">
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="FBID" HeaderText="FBID"></asp:BoundColumn>
										<asp:BoundColumn DataField="SubjectName" HeaderText="项目名称"></asp:BoundColumn>
										<asp:BoundColumn DataField="InventoryName" HeaderText="物品名称"></asp:BoundColumn>
										<asp:BoundColumn DataField="InvType" HeaderText="规格型号"></asp:BoundColumn>
										<asp:BoundColumn DataField="UnitName" HeaderText="单位"></asp:BoundColumn>
										<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
										<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="originalMoney" HeaderText="原币金额">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ExchangeRate" HeaderText="基准汇率">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RmbPrice" HeaderText="本币单价">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Number" HeaderText="数量">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CheckNumber" HeaderText="已裁决数量">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="RmbMoney" HeaderText="本币金额">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FNumber" HeaderText="裁决数量">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FinallyPrice" HeaderText="裁决价格">
											<ItemStyle HorizontalAlign="Right"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="Offer" HeaderText="供应商"></asp:BoundColumn>
									</Columns>
									<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
								</asp:datagrid></FONT></TD>
					</TR></TBODY></TABLE><FONT face="宋体"></FONT>&nbsp; </asp:panel></p>
			<INPUT id="hideApplyCheckHead" runat="server" value="0" type="hidden" name="hideApplyCheckHead">
			<INPUT id="FieldSort" type="hidden" name="Hidden2" runat="server"> <INPUT id="pagesIndex" value="0" type="hidden" name="Hidden1" runat="server">
			<INPUT id="HerdSort" type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" runat="server"></asp:linkbutton>
		</form>
	</body>
</HTML>
