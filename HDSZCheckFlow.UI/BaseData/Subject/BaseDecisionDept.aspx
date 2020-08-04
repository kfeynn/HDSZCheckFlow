<%@ Page language="c#" Codebehind="BaseDecisionDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Subject.BaseDecisionDept" enableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BaseDecisionDept</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌו">
				<gridwc:XPGrid style="Z-INDEX: 101; POSITION: absolute; TOP: 80px; LEFT: 96px" id="XPGrid1" runat="server"
					Width="80%" AllowAdd="True" AllowDelete="True" AllowEdit="True" AllowExportExcel="True" AllowPrint="True"
					AllowSort="True" SelectKind="MulitLines" Height="8px"></gridwc:XPGrid></FONT>
		</form>
	</body>
</HTML>
