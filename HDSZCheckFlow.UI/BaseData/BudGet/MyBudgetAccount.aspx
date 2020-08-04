<%@ Page language="c#" Codebehind="MyBudgetAccount.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.MyBudgetAccount" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MyBudgetAccount</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<gridwc:XPGrid id="XPGrid1" style="Z-INDEX: 102; LEFT: 96px; POSITION: absolute; TOP: 80px" runat="server"
					Width="80%" AllowAdd="False" AllowEdit="False" AllowDelete="False" AllowExportExcel="True"
					AllowPrint="True" AllowSort="True" SelectKind="None"></gridwc:XPGrid>
				<DIV style="DISPLAY: inline; Z-INDEX: 103; LEFT: 88px; WIDTH: 136px; POSITION: absolute; TOP: 32px; HEIGHT: 24px"
					ms_positioning="FlowLayout"><font size="+1">部门预算情况</font></DIV>
			</FONT>
		</form>
	</body>
</HTML>
