<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Query.QueryExecute" %>
<%@ Register TagPrefix="uc1" TagName="QueryResultControl" Src="QueryControl/QueryResultControl.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>QueryExecute</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:QueryResultControl id="ctlResult" runat="server"></uc1:QueryResultControl>
		</form>
	</body>
</HTML>
