<%@ Page AutoEventWireup="false" Inherits="XPGrid.XpGridScript.SetDefaultFields" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>����Ĭ����ʾ�ֶ�</title>
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<meta http-equiv=Pragma content=no-cache>
		<base target="_self">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<h1 align="center">Ĭ����ʾ�ֶ�����</h1>
			<table>
				<tr>
					<td>
						<asp:CheckBoxList id="cblFields" runat="server" Width="300px"></asp:CheckBoxList></td>
				</tr>
				<tr>
					<td align="center">
						<asp:Button id="btnSave" runat="server" CssClass="InputButton" Text="����"></asp:Button>
						&nbsp; <INPUT type="button" value="ȡ��" Class="InputButton" onclick="window.close();"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
