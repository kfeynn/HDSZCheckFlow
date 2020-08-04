<%@ Register TagPrefix="uc1" TagName="QuerySuiteControl" Src="QueryControl/QuerySuiteControl.ascx" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Query.QueryEdit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>QueryEdit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:QuerySuiteControl id="ctlQuerySuite" runat="server"></uc1:QuerySuiteControl>
		</form>
	</body>
</HTML>
