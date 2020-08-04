<%@ Page Language="c#" AutoEventWireup="false" Codebehind="Progress.aspx.cs" Inherits="HDSZCheckFlow.AppSystem.SysPage.Progress" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>数据处理中...</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<base target="_self">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblPercent" runat="server" ForeColor="Blue" style="Z-INDEX: 101; LEFT: 128px; POSITION: absolute; TOP: 56px"
				Width="80px"></asp:label><asp:panel id="panelBarSide" runat="server" Height="8px" ForeColor="Green" BorderWidth="1px"
				BorderStyle="Solid" Width="300px" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 32px">
				<asp:Label id="lblProgress" runat="server" Width="8px" ForeColor="Green" Height="8px" BackColor="Green">a</asp:Label>
			</asp:panel>
			<asp:label id="lblMessages" runat="server" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 16px"
				Width="248px" ForeColor="Blue"></asp:label></form>
	</body>
</HTML>
