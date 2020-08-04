<%@ Page Language="c#" AutoEventWireup="false" Codebehind="MyErrorPage.aspx.cs" Inherits="HDSZCheckFlow.AppSystem.SysPage.MyErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MyError</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"><IMG id="ImgLogout" style="BORDER-RIGHT: yellow 1px; BORDER-TOP: yellow 1px; Z-INDEX: 101; LEFT: 248px; BORDER-LEFT: yellow 1px; WIDTH: 64px; CURSOR: hand; BORDER-BOTTOM: yellow 1px; POSITION: absolute; TOP: 144px; HEIGHT: 56px"
					height="56" src="../Images/MSGBOX01.ICO" width="64" runat="server">
				<asp:panel id="Panel" style="Z-INDEX: 105; LEFT: 240px; POSITION: absolute; TOP: 208px" runat="server"
					Width="388px" Height="25px" BorderStyle="Solid" BorderWidth="1px" BorderColor="DarkGray">
					<FONT face="宋体"></FONT>
				</asp:panel>
				<asp:Button id="btnSave" style="Z-INDEX: 104; LEFT: 384px; POSITION: absolute; TOP: 248px" tabIndex="4"
					runat="server" Height="18px" CssClass="InputButton" Text="返回首页"></asp:Button>
				<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 328px; POSITION: absolute; TOP: 160px" runat="server"
					Width="284px" Height="24px" CssClass="MessageLabel" Font-Size="20pt" Font-Names="楷体_GB2312">对不起，系统出错啦！</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 100; LEFT: 248px; POSITION: absolute; TOP: 216px" runat="server"
					Width="405px" Height="8px">温馨提示：此错误已自动报告给系统管理员！我们会即时处理！抱歉！</asp:Label></FONT>
		</form>
	</body>
</HTML>
