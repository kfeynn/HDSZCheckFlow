<%@ Page language="c#" Codebehind="Base_DecisionDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Asset.Base_DecisionDept" enableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>合议部门表</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</head>
	<body>
		<div style="margin-left:50px;margin-top:20px;">
			<form id="Form1" method="post" runat="server">
				<gridwc:XPGrid id="XPGrid1" style="" runat="server" Width="95%" AllowAdd="True" AllowEdit="True"
					AllowDelete="True" AllowExportExcel="True" AllowPrint="True" AllowSort="True" SelectKind="MulitLines"></gridwc:XPGrid>
			</form>
		</div>
	</body>
</html>
