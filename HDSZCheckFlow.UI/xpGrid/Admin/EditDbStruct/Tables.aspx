<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.Tables" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Tables</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="GridColumnHeadingLeft"><font size="3">Êý¾Ý×ÖµäÐÞ¸Ä</font></TD>
				</TR>
				<TR>
					<TD>
						<iewc:TreeView id="trvTables" runat="server" SelectExpands="True" ExpandLevel="1"></iewc:TreeView>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
