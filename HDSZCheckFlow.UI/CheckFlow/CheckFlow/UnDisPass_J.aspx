<%@ Page language="c#" Codebehind="UnDisPass_J.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.UnDisPass_J"  EnableEventValidation="false"  %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td align="center" colspan="6"><FONT face="����">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 17px">��Ո���T</TD>
									<TD style="HEIGHT: 17px">
										<asp:DropDownList id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:DropDownList></TD>
									<TD style="HEIGHT: 17px">��Ո�ո�</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtDateFrom" runat="server" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											Width="90px"></asp:TextBox>
										<asp:TextBox id="txtDateTo" runat="server" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											Width="90px"></asp:TextBox></TD>
									<TD align="center" style="HEIGHT: 17px">�����</TD>
									<TD style="HEIGHT: 17px">
										<asp:TextBox id="txtApplyNo" runat="server" Width="90px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>��Ո�ƽM</TD>
									<TD><asp:DropDownList id="ddlDept" runat="server" Width="90px"></asp:DropDownList></TD>
									<TD>��Ո���</TD>
									<TD><asp:DropDownList id="ddlType" runat="server" Width="90px"></asp:DropDownList></TD>
									<TD></TD>
									<TD>
										<asp:button id="btnQuery" runat="server" Width="72px" Text="����" CssClass="redButtonCss"></asp:button></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"></td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
							Width="100%">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="���ݱ�ͷ����"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="����">
											<asp:Button id="btnLook" runat="server" Width="60px" CssClass="redButtonCss" Text="������" CommandName="cmd"></asp:Button></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="ApplyTypeName" HeaderText="��Ո���"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ApplySheetNo" HeaderText="�����"></asp:BoundColumn>
								<asp:HyperLinkColumn DataTextField="ApplySheetNo" HeaderText="�����"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="ApplyDate" HeaderText="��Ո�ո�" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" HeaderText="��Ո���T"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" HeaderText="��Ո��"></asp:BoundColumn>
								<asp:BoundColumn DataField="SheetMoney" HeaderText="���~" DataFormatString="{0:#,###.##}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SubmitType" HeaderText="��������"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6"><FONT face="����"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="����"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
