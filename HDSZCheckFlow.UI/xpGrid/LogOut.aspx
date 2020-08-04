<%@ OutputCache Location="None"  %>
<%@ Page language="c#" Codebehind="LogOut.aspx.cs" AutoEventWireup="false" Inherits="xpGridTest.UI.xpGrid.LogOut" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>请稍候...</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META HTTP-EQUIV="pragma" CONTENT="no-cache">
		<META HTTP-EQUIV="Cache-Control" CONTENT="no-cache, must-revalidate">
		<META HTTP-EQUIV="expires" CONTENT="0">
		<LINK href="..\AppSystem\style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="JsLib/MyScript.js"></SCRIPT>
		<script language="javascript">
		 window.setTimeout("TryToCloseWin();",1000);
		 function TryToCloseWin()
				{
				 //alert("OK");
				 if(document.getElementById("LoadFlag").value=1){DelayCloseWin(1000);}
			    }
		 function CleanFlag()
				{
				document.getElementById("LoadFlag").value=0
				}
		</script>
		<base target="_self">
	</HEAD>
	<body onunload="CleanFlag();" scroll="no" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:Label id="lblWelAppName" style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 16px"
					runat="server" Width="240px" Height="24px" CssClass="MessageLabel" Font-Size="10pt">感谢使用深圳赛格晶端Budget系统！</asp:Label>
				<asp:Label id="Label2" style="Z-INDEX: 112; LEFT: 64px; POSITION: absolute; TOP: 40px" runat="server"
					Font-Size="10pt" CssClass="MessageLabel" Height="24px" Width="104px" ForeColor="Red">系统正在关闭...</asp:Label>
				<asp:TextBox id="LoadFlag" style="Z-INDEX: 100; LEFT: 104px; POSITION: absolute; TOP: 80px" runat="server"
					Width="16px" Enabled="False">0</asp:TextBox></FONT>
		</form>
	</body>
</HTML>
