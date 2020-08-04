<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page Language="c#" AutoEventWireup="false" Codebehind="TableTypeEdit.aspx.cs" Inherits="xpGridTest.UI.xpGrid.Admin.EditDbStruct.TableTypeEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TableTypeEdit</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../JsLib/MyScript.js"></SCRIPT>
	</HEAD>
	<body onload="FirstInputCtrl();" onkeydown="setenter();" ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<gridwc:XPGrid id="XPGrid1" runat="server" CommandText="select * from xpGrid_TableType" AllowAdd="True"
				AllowDelete="True" AllowEdit="True" AllowPaging="True" AllowQuery="True" RightControl="False"
				style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 56px" SelectKind="MulitLines" AllowExportExcel="True"
				AllowPrint="True" AllowSort="True"></gridwc:XPGrid>
			<asp:Label id="Label4" style="Z-INDEX: 113; LEFT: 160px; POSITION: absolute; TOP: 16px" runat="server"
				CssClass="Title" Height="8px" Width="104px">表类型维护</asp:Label>
		</form>
	</body>
</HTML>
