<%@ Page language="c#" Codebehind="ExpenseStates.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.ExpenseStates" enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExpenseStates</title>
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
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colSpan="6"><FONT face="����">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td height="26"></td>
								</tr>
								<TR>
									<TD style="HEIGHT: 17px">���벿��</TD>
									<TD style="HEIGHT: 17px"><asp:dropdownlist id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 17px">��ʼ����</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="90px" maxdate="#F{$('txtDateTo').value}"></asp:textbox></TD>
									<TD style="HEIGHT: 17px" align="center">��������</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="90px" mindate="#F{$('txtDateFrom').value}"></asp:textbox></TD>
									<TD style="HEIGHT: 17px">���ݺ�</TD>
									<TD style="HEIGHT: 17px"><asp:textbox id="txtApplyNo" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 20px">��������</TD>
									<TD style="HEIGHT: 20px"><asp:dropdownlist id="ddlType" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 20px">�������</TD>
									<TD style="HEIGHT: 20px"><asp:dropdownlist id="ddlDept" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 20px" align="center">�� �� ��</TD>
									<TD style="HEIGHT: 20px"><asp:dropdownlist id="ddlExpense" runat="server" Width="90px">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="1">��</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">��</asp:ListItem>
										</asp:dropdownlist></TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD style="HEIGHT: 21px">
										<asp:button id="btnQuery" runat="server" Width="72px" Text="��ѯ" CssClass="redButtonCss"></asp:button></TD>
								</TR>
								<TR height="20">
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD align="center"></TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" Width="90px" Visible="False"></asp:dropdownlist></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD align="center"></TD>
									<TD></TD>
									<TD></TD>
									<TD>
										<asp:Button id="btnOutput" runat="server" Text="������Excel" CssClass="inputbutton" Visible="False"></asp:Button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
							BorderColor="#93BEE2" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ApplyTypeCode" HeaderText="ApplyTypeCode"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="���ݺ�"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplyTypeName" SortExpression="ApplyTypeName" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" SortExpression="ApplyDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="���벿��"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" SortExpression="Name" HeaderText="������"></asp:BoundColumn>
								<asp:BoundColumn DataField="SheetMoney" SortExpression="SheetMoney" HeaderText="���" DataFormatString="{0:#,####.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SubmitType" SortExpression="SubmitType" HeaderText="���"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyProcessTypeName" SortExpression="ApplyProcessTypeName" HeaderText="����״̬"></asp:BoundColumn>
								<asp:BoundColumn DataField="Cisexpense" HeaderText="�Ƿ���"></asp:BoundColumn>
								<asp:BoundColumn DataField="expensedate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6"><FONT face="����">
							<asp:datagrid id="Datagrid1" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
								BorderColor="#93BEE2" PageSize="20">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="ApplySheetNo" HeaderText="���ݺ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyTypeName" HeaderText="��������"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="DeptName" HeaderText="���벿��"></asp:BoundColumn>
									<asp:BoundColumn DataField="Name" HeaderText="������"></asp:BoundColumn>
									<asp:BoundColumn DataField="SheetMoney" HeaderText="���" DataFormatString="{0:#,####.##}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SubmitType" HeaderText="���"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyProcessTypeName" HeaderText="����״̬"></asp:BoundColumn>
									<asp:BoundColumn DataField="Cisexpense" HeaderText="�Ƿ���"></asp:BoundColumn>
									<asp:BoundColumn DataField="expensedate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="item" HeaderText="����"></asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6">
						<P><FONT face="����"></FONT>&nbsp;</P>
						<P><FONT face="����"></FONT>&nbsp;</P>
						<P><FONT face="����"><INPUT id="HerdSort" type="hidden" name="Hidden3" runat="server"><INPUT id="FieldSort" type="hidden" name="Hidden2" runat="server"><FONT face="����"><INPUT id="pagesIndex" type="hidden" value="0" name="Hidden1" runat="server"></FONT></FONT></P>
					</td>
				</tr>
			</table>
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px"
				runat="server"></asp:linkbutton></form>
	</body>
</HTML>
