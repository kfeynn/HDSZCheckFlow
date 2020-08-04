<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="BaseaccontInBudgetSubject.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Subject.BaseaccontInBudgetSubject" enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BaseaccontInBudgetSubject</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../xpGrid/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT>&nbsp;
			<gridwc:XPGrid id="XPGrid1" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 80px" runat="server"
				Width="80%" AllowAdd="True" AllowDelete="True" AllowEdit="True" AllowExportExcel="True" AllowSort="True"
				SelectKind="MulitLines" AllowPrint="True"></gridwc:XPGrid>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 88px; POSITION: absolute; TOP: 48px" runat="server">统计科目分类</asp:Label>
		</form>
	</body>
</HTML>
