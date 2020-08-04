<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page Language="c#" AutoEventWireup="false" Codebehind="FuncEdit.aspx.cs" Inherits="xpGridTest.UI.xpGrid.Admin.EditRoles.FuncEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>FuncEditNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../JsLib/MyScript.js"></SCRIPT>
	</HEAD>
	<body onmousemove="SetState();" onmousedown="SetState();" onkeydown="setenter();" onselectstart="NoSelect();"
		oncontextmenu="NoRightMenu();" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server" onclick="clean();">
			<P><FONT face="宋体"></FONT>&nbsp;</P>
			&nbsp;&nbsp;&nbsp;&nbsp;<h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;系统功能维护</h1>
			&nbsp;&nbsp;&nbsp;&nbsp;<gridwc:XpTreeView id="trvFunc" runat="server" AllowShowMenu="True" SelectExpands="True" ExpandLevel="1"></gridwc:XpTreeView>&nbsp;&nbsp;
		</FORM>
	</body>
</HTML>
