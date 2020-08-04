<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.Code._default" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>default</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0"
				height="100%">
				<TR>
					<TD valign="top">
						<iewc:TreeView id="trvBMList" runat="server" ExpandLevel="1" AutoPostBack="True"></iewc:TreeView></TD>
					<TD><FONT face="ËÎÌו">&nbsp;</FONT></TD>
					<TD valign="top">
						<gridwc:XPGrid id="XPGrid2" runat="server" AllowAdd="True" AllowDelete="True" RightControl="False"
							AllowEdit="True" AllowQuery="False" EditMode="BatchEdit"></gridwc:XPGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
