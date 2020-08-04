<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="FlowInCompany.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.BaseInfo.FlowInCompany"  EnableEventValidation="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FlowInCompany</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 80px" cellSpacing="1"
					cellPadding="1" width="80%" border="1">
					<TR>
						<TD>流程名:</TD>
						<TD>
							<asp:Button id="btnCheckValid" runat="server" Text="检测流程" CssClass="inputbutton"></asp:Button></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<gridwc:XPGrid id="XPFlowHead" runat="server" width="100%" AllowAdd="True" AllowDelete="True" AllowEdit="True"
								AllowPaging="True" AllowExportExcel="True" AllowPrint="True" AllowSort="True" SelectKind="SingleLine"></gridwc:XPGrid></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>具体流程定义</TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<gridwc:XPGrid id="XPFlowBody" runat="server" width="100%" AllowAdd="True" AllowDelete="True" AllowEdit="True"
								AllowExportExcel="True" AllowPrint="True" AllowSort="True" SelectKind="MulitLines" Visible="False"></gridwc:XPGrid></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="DataGrid1" runat="server" Width="100%" BorderColor="#999999" BorderStyle="None"
								BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
								<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#DCDCDC"></AlternatingItemStyle>
								<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
								<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
