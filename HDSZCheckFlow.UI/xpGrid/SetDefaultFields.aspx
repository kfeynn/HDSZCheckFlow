<%@ Page AutoEventWireup="false" Inherits="XPGrid.XpGridScript.SetDefaultFields" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>设置默认显示字段</title>
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<meta http-equiv=Pragma content=no-cache>
		<base target="_self">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1 align="center">默认显示字段设置</h1>
			<table>
				<tr>
					<td>
						<asp:CheckBoxList id="cblFields" runat="server" Width="300px"></asp:CheckBoxList></td>
				</tr>
				<tr>
					<td align="center">
						<asp:Button id="btnSave" runat="server" CssClass="InputButton" Text="保存"></asp:Button>
						&nbsp; <INPUT type="button" value="取消" Class="InputButton" onclick="window.close();"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
