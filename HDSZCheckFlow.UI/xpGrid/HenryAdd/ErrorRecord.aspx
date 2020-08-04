<%@ Page Language="c#" AutoEventWireup="false" Codebehind="ErrorRecord.aspx.cs" Inherits="xpGridTest.UI.xpGrid.HenryAdd.ErrorRecord" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ErrorRecord</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../AppSystem/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">&nbsp;
				<asp:Label id="Label4" style="Z-INDEX: 102; LEFT: 352px; POSITION: absolute; TOP: 40px" runat="server"
					Width="168px" Height="8px" CssClass="Title">系统出错记录维护</asp:Label>
				<gridwc:XPGrid id="XPGrid1" style="Z-INDEX: 101; LEFT: 48px; POSITION: absolute; TOP: 80px" runat="server"
					Width="730px" Height="8px" PageSize="1" CommandText="Select * From xpGrid_ErrorRecord ORDER BY Id Desc"
					AllowAdd="True" AllowEdit="True" AllowExportExcel="True" AllowPrint="True" AllowSort="True"
					AllowDelete="True"></gridwc:XPGrid></FONT>
		</form>
	</body>
</HTML>
