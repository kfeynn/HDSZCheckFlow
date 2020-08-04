<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="ChangeApplyOfCompanyOverBudget.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.ChangeApplyOfCompanyOverBudget" enableEventValidation="false" %>
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
			
			function checklogo()
			{
				//转到框只能输入正整数
				var exp = /^[+-]?\d+(\.\d+)?$/;    //    /^[0-9]*[1-9][0-9]*$/;
				
				//alert(document.getElementById('tbxOverMoney').value);
				
				if(!exp.test( document.getElementById('tbxOverMoney').value))
				{
					alert('请输入正确的数字!');
					return false;
				}
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
										<asp:TextBox id="txtDateFrom" runat="server" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											Width="90px"></asp:TextBox></TD>
									<TD align="center" style="HEIGHT: 17px">结束日期</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtDateTo" runat="server" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											Width="90px"></asp:TextBox></TD>
									<TD style="HEIGHT: 17px">单据号</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtApplyNo" runat="server"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>申请类型</TD>
									<TD>
										<asp:DropDownList id="ddlType" runat="server" Width="90px"></asp:DropDownList></TD>
									<TD>申请科组</TD>
									<TD>
										<asp:DropDownList id="ddlDept" runat="server" Width="90px"></asp:DropDownList></TD>
									<TD align="center">单据状态</TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD></TD>
									<TD>
										<asp:button id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss" style="Z-INDEX: 0"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server">
						</DIV>
					</td>
				</tr>
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
											<asp:Button id="btnLook" runat="server" Width="50px" CssClass="redButtonCss" Text="查看" CommandName="look"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<FONT face="宋体"></FONT>
									</HeaderTemplate>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button id="btnOver" runat="server" CssClass="inputbutton" Text="预算外可用" CommandName="OverBudget"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:Button style="Z-INDEX: 0" id="btnCanclOver" runat="server" CssClass="buttonCss" Text="取消预算外"
												CommandName="CanclOverBudget"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="单据号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplyTypeName" SortExpression="ApplyTypeName" HeaderText="申请类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="申请日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="申请部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="申请人"></asp:BoundColumn>
								<asp:BoundColumn DataField="SheetMoney" SortExpression="SheetMoney" HeaderText="金额" DataFormatString="{0:#,####.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SubmitType" SortExpression="SubmitType" HeaderText="类别"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="单据状态"></asp:BoundColumn>
								<asp:BoundColumn DataField="IsOverBudget" HeaderText="可预算外提交"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6"><FONT face="宋体"><asp:datagrid id="dgPostail" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
								Width="100%" Visible="False">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="批阅人">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CheckRoleName" HeaderText="角色">
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
							</asp:datagrid>
							<P>
								<asp:Panel style="Z-INDEX: 0" id="Panel1" runat="server" Height="65px" Visible="False">
									<TABLE style="Z-INDEX: 101; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
										class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3" width="100%">
										<TR>
											<TD style="WIDTH: 98px" align="right">单&nbsp; 据&nbsp; 号：</TD>
											<TD>
												<asp:Label style="Z-INDEX: 0" id="lblApplyNo" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 98px" align="right">单 据 金额：</TD>
											<TD>
												<asp:Label style="Z-INDEX: 0" id="lblApplyMoney" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 98px" align="right">预算外金额：</TD>
											<TD>
												<asp:TextBox id="tbxOverMoney" runat="server"></asp:TextBox>
												<asp:Label style="Z-INDEX: 0" id="lblMessage" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 98px"></TD>
											<TD>
												<asp:Button style="Z-INDEX: 0" id="btnEnter" runat="server" CssClass="inputbutton" Text="确定"></asp:Button></TD>
										</TR>
									</TABLE>
								</asp:Panel>
						</FONT></P></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
			<INPUT id="FieldSort" style="Z-INDEX: 103; POSITION: absolute; TOP: 576px; LEFT: 424px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="HerdSort" style="Z-INDEX: 104; POSITION: absolute; TOP: 576px; LEFT: 224px"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton id="linkToPage" runat="server" style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px"></asp:linkbutton>
			<INPUT id="pagesIndex" style="Z-INDEX: 105; POSITION: absolute; TOP: 576px; LEFT: 624px"
				type="hidden" value="0" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
