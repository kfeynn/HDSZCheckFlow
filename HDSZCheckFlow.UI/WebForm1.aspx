<%@ Page language="c#" Codebehind="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.WebForm1" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="AppSystem/Style.css" type="text/css" rel="stylesheet">
		<LINK href="AppSystem/common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌו">
				<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 64px; POSITION: absolute; TOP: 16px" runat="server"
					Text="LogTest"></asp:Button>
				<asp:Button id="Button2" style="Z-INDEX: 102; LEFT: 168px; POSITION: absolute; TOP: 16px" runat="server"
					Text="DBAccessTest"></asp:Button>
				<asp:Button id="Button3" style="Z-INDEX: 103; LEFT: 336px; POSITION: absolute; TOP: 16px" runat="server"
					Text="CastleTest" Width="104px"></asp:Button>
				<asp:Button id="Button4" style="Z-INDEX: 104; LEFT: 488px; POSITION: absolute; TOP: 16px" runat="server"
					Text="xpGridTest"></asp:Button></FONT>
			<TABLE id="Table1" style="Z-INDEX: 105; LEFT: 72px; WIDTH: 744px; POSITION: absolute; TOP: 56px; HEIGHT: 488px"
				cellSpacing="1" cellPadding="1" width="90%" border="0">
				<TR>
					<TD valign="top">
						<gridwc:XPGrid id="XPGrid1" runat="server" AllowAdd="True" AllowDelete="True" AllowEdit="True"
							AllowExportExcel="True" AllowPrint="True" AllowSort="True" width="100%" SelectKind="MulitLines"></gridwc:XPGrid></TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
