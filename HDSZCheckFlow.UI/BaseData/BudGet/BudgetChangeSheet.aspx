<%@ Page language="c#" Codebehind="BudgetChangeSheet.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.BudgetChangeSheet" enableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetChangeSheet</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<gridwc:xpgrid style="Z-INDEX: 101; POSITION: absolute; TOP: 80px; LEFT: 96px" id="XPGrid1" runat="server"
					SelectKind="MulitLines" AllowSort="True" AllowExportExcel="True" AllowEdit="False" AllowDelete="True"
					AllowAdd="True" Width="80%"></gridwc:xpgrid>
				<DIV style="Z-INDEX: 102; POSITION: absolute; WIDTH: 344px; DISPLAY: inline; HEIGHT: 36px; TOP: 24px; LEFT: 96px">公司预算调整情况</DIV>
			</FONT>
		</form>
	</BODY>
</HTML>
