<%@ Page language="c#" Codebehind="ChangeMyFlowRole_J.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ChangeMyFlowRole_J" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeMyFlowRole</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function ShowUserName(useCode)
		{
			var userName=HDSZCheckFlow.UI.CheckFlow.CheckFlow.ChangeMyFlowRole.GetUserNameByCode(useCode.value);
			if(userName.length==0)
			{}
			else
			{
				document.getElementById("txtPersonName").innerText=userName.value;
			}
		}
		</script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; BORDER-LEFT-COLOR: #0066cc; TOP: 64px; LEFT: 88px"
					cellSpacing="0" cellPadding="0" width="80%" border="1" borderColor="#0066cc">
					<TR height="52">
						<TD align="left" bgcolor="#ccccff" colspan="2">出張者の権限移転方式：1.他人に委譲する；2.暫く権限を断念する。両方も出張して戻ってから、権限を再び得ることができる。</TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">私の審批権限:</TD>
						<TD><asp:Table id="tblMyRole" runat="server" Width="100%"></asp:Table></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">権限状態:
						</TD>
						<TD><asp:Label id="lblRoleState" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">権限委譲:
						</TD>
						<TD><asp:textbox id="txtPerson" onkeyup="javascript:ShowUserName(this)" runat="server" Width="80px"></asp:textbox>
							<asp:textbox id="txtPersonName" runat="server" Width="80px" Enabled="False" BackColor="#E0E0E0"></asp:textbox>
							<asp:Button id="btnSure" runat="server" Width="72px" Text="確定" CssClass="redButtonCss"></asp:Button>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">一時審批を断念する:</TD>
						<TD>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnGiveUp" runat="server" CssClass="redButtonCss" Text="一時審批を断念する"></asp:Button></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">権限取戻す:
						</TD>
						<TD><asp:Button id="btnGetBackRole" runat="server" Text="権限取戻す" CssClass="inputbutton"></asp:Button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
