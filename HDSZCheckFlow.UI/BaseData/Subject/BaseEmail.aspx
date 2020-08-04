<%@ Page language="c#" Codebehind="BaseEmail.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Subject.BaseEmail" enableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BaseEmail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌå">
				<gridwc:XPGrid id="XPGrid1" style="Z-INDEX: 101; POSITION: absolute; TOP: 56px; LEFT: 64px" runat="server"
					Width="80%" AllowAdd="True" AllowDelete="True" AllowEdit="True" AllowExportExcel="True" AllowPrint="True"
					AllowSort="True" SelectKind="MulitLines" Height="8px"></gridwc:XPGrid></FONT>
		</form>
	</body>
</HTML>
