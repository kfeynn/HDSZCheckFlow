<%@ OutputCache Location="None" %>
<%@ Page language="c#" Codebehind="CleanCache.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.AppSystem.ReptSystem.CleanCache" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>请稍候...</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<Script Language="javascript" Src="../JsLib/MyScript.js"></Script>
		<base target="_self">
	</HEAD>
	<body onload="DelayCloseWin(1000);" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="lblWelAppName" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 16px"
					runat="server" Width="240px" Height="24px" CssClass="MessageLabel" Font-Size="10pt">感谢使用深圳赛格晶端Budget系统！</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 64px; POSITION: absolute; TOP: 40px" runat="server"
					Font-Size="10pt" CssClass="MessageLabel" Height="24px" Width="128px" ForeColor="Red">系统正在清除内存...</asp:Label></FONT>
		</form>
	</body>
</HTML>
