<%@ Page language="c#" Codebehind="WebForm5.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.WebForm5" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm5</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<DIV style="DISPLAY: inline; Z-INDEX: 101; LEFT: 120px; WIDTH: 392px; POSITION: absolute; TOP: 40px; HEIGHT: 24px"
				ms_positioning="FlowLayout">导出到PDF打印 TEST</DIV>
			<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 528px; POSITION: absolute; TOP: 32px" runat="server"
				Text="Button"></asp:Button>
			<CR:CrystalReportViewer id="CrystalReportViewer1" style="Z-INDEX: 103; LEFT: 384px; POSITION: absolute; TOP: 80px"
				runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 104; LEFT: 88px; POSITION: absolute; TOP: 80px" runat="server"></asp:DataGrid>
			<asp:Button id="Button2" style="Z-INDEX: 105; LEFT: 616px; POSITION: absolute; TOP: 32px" runat="server"
				Text="Button2"></asp:Button>
		</form>
	</body>
</HTML>
