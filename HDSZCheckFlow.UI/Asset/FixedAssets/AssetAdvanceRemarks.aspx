<%@ Page language="c#" Codebehind="AssetAdvanceRemarks.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.FixedAssets.AssetAdvanceRemarks" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssetAdvanceRemarks</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<!--<script language="javascript" src="../../Style/My97DatePicker/WdatePicker.js"></script>--><LINK href="../Style/Style.css" type="text/css" rel="stylesheet"><LINK href="../AppSystem/common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="宋体">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr align="center">
									<td align="center" colSpan="4">
										<h3>预 付 款 备 注</h3>
									</td>
								</tr>
								<TR>
									<TD style="WIDTH: 93px; HEIGHT: 17px">表&nbsp;&nbsp; 单&nbsp;&nbsp;号</TD>
									<TD style="WIDTH: 506px; HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server" Width="336px"></asp:textbox>(以逗号分隔)</TD>
									<TD style="HEIGHT: 17px">是否以标注</TD>
									<TD style="HEIGHT: 17px"><asp:radiobutton id="rbtMark1" runat="server" Text="是" GroupName="IsMark"></asp:radiobutton><asp:radiobutton id="rbtMark2" runat="server" Text="否" GroupName="IsMark"></asp:radiobutton><asp:radiobutton id="rbtMark3" runat="server" Text="All" GroupName="IsMark" Checked="True"></asp:radiobutton></TD>
									<TD style="HEIGHT: 17px" align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px">项 目 名 称</TD>
									<TD style="WIDTH: 506px"><asp:textbox id="txtProduct" runat="server" Width="336px"></asp:textbox>(以逗号分隔)</TD>
									<TD></TD>
									<TD></TD>
									<TD align="center"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 93px">项目二级科目</TD>
									<TD style="WIDTH: 506px"><asp:textbox id="txtOrderNumber" runat="server" Width="160px"></asp:textbox></TD>
									<TD></TD>
									<TD><asp:button id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button></TD>
									<TD align="center"></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6">
						<div style="WIDTH: 100%"><asp:datagrid id="dgApply" runat="server" Width="1500px" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
								BackColor="White" AutoGenerateColumns="False">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ApplySheetBody_Purchase_pk" HeaderText="ID"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:Button id="btnMark" runat="server" Text="标注" CssClass="ButtonCss" CommandName="ReMark"></asp:Button>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<FONT face="宋体">
												<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox></FONT>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
										DataTextField="PriceCheckSheetNo" HeaderText="表单号"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="ItemNmae" HeaderText="项目名称"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyDeptClassCode" HeaderText="申请部门"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyPersonCode" HeaderText="申请人"></asp:BoundColumn>
									<asp:BoundColumn DataField="RequestDate" HeaderText="交货日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="BargainNo" HeaderText="合同号" DataFormatString="{0:n0}"></asp:BoundColumn>
									<asp:BoundColumn DataField="SubjectName" HeaderText="二级科目"></asp:BoundColumn>
									<asp:BoundColumn DataField="InventoryName" HeaderText="内容名称"></asp:BoundColumn>
									<asp:BoundColumn DataField="Offer" HeaderText="供应商"></asp:BoundColumn>
									<asp:BoundColumn DataField="Article" HeaderText="付款条件"></asp:BoundColumn>
									<asp:BoundColumn DataField="Base_Unit_id" HeaderText="单位"></asp:BoundColumn>
									<asp:BoundColumn DataField="Number" HeaderText="数量"></asp:BoundColumn>
									<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价"></asp:BoundColumn>
									<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
									<asp:BoundColumn DataField="FinallyPrice" HeaderText="单价"></asp:BoundColumn>
									<asp:BoundColumn DataField="Earnest" HeaderText="是否预付款(定金)"></asp:BoundColumn>
									<asp:BoundColumn DataField="EarnestSigner" HeaderText="预付款标注人员"></asp:BoundColumn>
									<asp:BoundColumn DataField="EarnestDatetime" HeaderText="预付款时间" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="EarnestRemark" HeaderText="预付款备注"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
							</asp:datagrid></div>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"><asp:checkbox id="chbSelectAll" runat="server" Text="全选" AutoPostBack="True"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" Text="批量更新"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label4" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT>
					</td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="宋体"><asp:panel id="Panel1" runat="server" BackColor="White" Visible="False">
								<TABLE id="Table2" borderColor="#003333" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 22px">内容名称：</TD>
										<TD style="HEIGHT: 22px">&nbsp;
											<asp:Label id="Label5" runat="server"></asp:Label></TD>
										<TD style="HEIGHT: 22px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 21px">供应商</TD>
										<TD style="HEIGHT: 21px">&nbsp;
											<asp:Label id="Label2" runat="server" Width="144px"></asp:Label></TD>
										<TD style="HEIGHT: 21px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 21px">付款条件：</TD>
										<TD style="HEIGHT: 21px">&nbsp;
											<asp:Label id="Label3" runat="server" Width="144px"></asp:Label></TD>
										<TD style="HEIGHT: 21px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">数 量：</TD>
										<TD>&nbsp;
											<asp:TextBox id="TextBox1" runat="server" Width="312px"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">原币单价：</TD>
										<TD>&nbsp;
											<asp:TextBox id="Textbox2" runat="server" Width="312px"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">总 金 额：</TD>
										<TD>&nbsp;
											<asp:TextBox id="Textbox3" runat="server" Width="312px"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">预付款标注人员：</TD>
										<TD>&nbsp;
											<asp:TextBox id="Textbox4" runat="server" Width="312px"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px; HEIGHT: 2px">预付款时间：</TD>
										<TD style="HEIGHT: 2px">&nbsp;
											<asp:TextBox id="Textbox5" runat="server" Width="304px"></asp:TextBox></TD>
										<TD style="HEIGHT: 2px"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">预付款备注：</TD>
										<TD>&nbsp;
											<asp:TextBox id="Textbox6" runat="server" Width="312px"></asp:TextBox></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 101px">&nbsp;</TD>
										<TD>&nbsp;
											<asp:button id="btnEnter" runat="server" Width="83px" Text="确定" CssClass="inputbutton"></asp:button>
											<asp:Label id="lblMessage" runat="server"></asp:Label></TD>
										<TD></TD>
									</TR>
								</TABLE>
							</asp:panel></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
