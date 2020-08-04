<%@ Page AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.xpGridInit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>xpGridInit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<h1 align="center">xpGrid 初始化</h1>
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td align="right"><asp:Button id="btnDo" runat="server" Text="确认开始初始化" CssClass="InputButton"></asp:Button></td>
				</tr>
				<tr>
					<td>
						<asp:TextBox id="txtInitScript" ReadOnly="True" runat="server" Columns="80" Rows="30" TextMode="MultiLine"></asp:TextBox></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
