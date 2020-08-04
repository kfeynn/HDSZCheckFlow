<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.BrowseTable" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BrowseTable</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body topmargin="0" leftmargin="0" marginheight="0" marginwidth="0" bgcolor="#ffffff">
		<form id="BrowseTable" method="post" runat="server">
			<table cellpadding="3" cellspacing="0" width="100%">
				<tr>
					<td class="GridColumnHeadingLeft"><font size=3>≤È—Ø</font></td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td>
									<img src="images/large_icons_query.gif" align="left">
								</td>
								<td align="right">
									<asp:button id="btnRun" text="÷¥ –– ≤È —Ø" runat="server"></asp:button>
								</td>
							</tr>
						</table>
						<img src="images/spacer.gif" height="90" width="1" align="right"> <img src="images/spacer.gif" height="90" width="1" align="left">
						<asp:textbox id="txtSTMT" width="100%" height="100px" text="" runat="server" textmode="MultiLine"
							></asp:textbox>
						<br>
					</td>
				</tr>
			</table>
			<br>
			<br>
			<asp:datagrid id="dgQueury" cssclass="TableStyle" cellspacing="0" cellpadding="3" runat="server">
				<headerstyle cssclass="GridColumnHeading"></headerstyle>
				<itemstyle cssclass="GridItemCell" verticalalign="Top"></itemstyle>
			</asp:datagrid>
		</form>
	</body>
</HTML>
