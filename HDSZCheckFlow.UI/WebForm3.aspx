<%@ Page language="c#" Codebehind="WebForm3.aspx.cs" AutoEventWireup="false" validateRequest=false Inherits="HDSZCheckFlow.UI.WebForm3" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Register TagPrefix="fckeditorv2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm3</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌו">
				<FCKeditorV2:FCKeditor id="FCKContent" runat="server" Height="400px"></FCKeditorV2:FCKeditor>
				<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 408px; POSITION: absolute; TOP: 440px" runat="server"
					Text="Button"></asp:Button>
				<asp:TextBox id="TextBox1" style="Z-INDEX: 102; LEFT: 560px; POSITION: absolute; TOP: 432px"
					runat="server" Height="112px" TextMode="MultiLine" Width="280px"></asp:TextBox></FONT></form>
	</body>
</HTML>
