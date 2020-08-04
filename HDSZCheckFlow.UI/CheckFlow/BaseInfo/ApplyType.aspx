<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="ApplyType.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.BaseInfo.ApplyType"  EnableEventValidation="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApplyType</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<gridwc:XPGrid id="XPGrid1" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 80px" runat="server"
				Width="80%" AllowAdd="True" AllowDelete="True" AllowEdit="True" AllowExportExcel="True" AllowPrint="True"
				AllowSort="True" SelectKind="MulitLines"></gridwc:XPGrid>
			<asp:Button id="btnCheckValid" style="Z-INDEX: 102; LEFT: 608px; POSITION: absolute; TOP: 88px"
				runat="server" Width="72px" Text="¼ì²âµ¥¾Ý" CssClass="inputbutton"></asp:Button>
		</form>
	</body>
</HTML>
