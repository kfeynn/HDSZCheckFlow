<%@ Page language="c#" Codebehind="TestFCK.aspx.cs" AutoEventWireup="false" Inherits="TradeWWW.FCK.Test.TestFCK" %>

<%@ Register TagPrefix="uc1" TagName="wuFCK" Src="../wuFCK.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>TestFCK</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body  >
		<form id="Form1" method="post" runat="server">
			<uc1:wuFCK id="WuFCK1" runat="server"></uc1:wuFCK>
		</form>
	</body>
</HTML>
