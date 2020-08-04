<%@ Page language="c#" Codebehind="PrintPage.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PrintApply.PrintPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="dgRecord" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 432px" runat="server"></asp:DataGrid>
			<asp:DataGrid id="dgBody" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 160px" runat="server"></asp:DataGrid>
			<asp:DataGrid id="dgHead" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 8px" runat="server"></asp:DataGrid>
			<asp:DataGrid id="dgBudget" style="Z-INDEX: 104; LEFT: 24px; POSITION: absolute; TOP: 296px" runat="server"></asp:DataGrid></form>
	</body>
</HTML>
