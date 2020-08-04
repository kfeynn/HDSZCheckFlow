<%@ Page language="c#" Codebehind="CheckFlowInDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.BaseInfo.CheckFlowInDept"  EnableEventValidation="false"  %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CheckFlowInDept</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 96px; POSITION: absolute; TOP: 80px" cellSpacing="1"
				cellPadding="1" width="80%" border="0">
				<TR>
					<TD>
						<gridwc:XPGrid id="XPGrid1" runat="server" Width="100%" AllowAdd="True" AllowDelete="True" AllowEdit="True"
							AllowExportExcel="True" AllowPrint="True" AllowSort="True" SelectKind="MulitLines"></gridwc:XPGrid></TD>
				</TR>
				<TR>
					<TD>
						<asp:DataGrid id="DataGrid1" runat="server" Width="100%" BorderColor="#CCCCCC" BorderStyle="None"
							BorderWidth="1px" BackColor="White" CellPadding="3">
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
							<ItemStyle ForeColor="#000066"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
			<asp:Button id="btnCheckValid" style="Z-INDEX: 102; LEFT: 616px; POSITION: absolute; TOP: 94px"
				runat="server" CssClass="inputbutton" Text="¼ì²âÁ÷³Ì"></asp:Button>
		</form>
	</body>
</HTML>
