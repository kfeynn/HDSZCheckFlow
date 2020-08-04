<%@ Page Language="c#" AutoEventWireup="false" Codebehind="Login.aspx.cs" Inherits="HDSZCheckFlow.Login" enableViewState="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>系统登录</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<STYLE type="text/css">.TD { FONT-SIZE: 12px }
	.frm { BORDER-BOTTOM: #0066cc 1px solid; BORDER-LEFT: #0066cc 1px solid; BORDER-TOP: #0066cc 1px solid; BORDER-RIGHT: #0066cc 1px solid }
		</STYLE>
		<SCRIPT language="JavaScript" src="AppSystem/JsLib/MyScript.js"></SCRIPT>
		<SCRIPT language="JavaScript">
			/*以下代码用于解决页面久未操作后同时出现几个登录界面的情况*/
			if (top.location != self.location ) 
				{
					top.location.reload();
				}	
			/*窗口最大化*/
			maxwin();	
			/*重置整个页面*/
			function resetform(formname)
				{
					document.getElementById("edtUserName").value="";
					document.getElementById("edtPassWord").value="";
					document.getElementById("Message").value="";
					UserNameFocus();
				
				}
			function UserNameFocus()
				{
					document.getElementById("edtUserName").focus();
				}
	
		</SCRIPT>
		<base target="_self">
	</HEAD>
	<body oncontextmenu="NoRightMenu();" onselectstart="NoSelect();" onkeydown="setenter();"
		onfocus="UserNameFocus();" bgColor="white" onload="ShowState();FirstInputCtrl();"
		MS_POSITIONING="GridLayout">
		<form id="Form1" onfocus="UserNameFocus();" method="post" runat="server">
			<IMG id="IMG1" style="Z-INDEX: 102; POSITION: absolute; WIDTH: 24px; HEIGHT: 430px; TOP: 120px; LEFT: 208px"
				height="433" src="xpGrid/Images/loginleft.gif" width="24" runat="server">
			<asp:label id="Message" style="Z-INDEX: 116; POSITION: absolute; TOP: 392px; LEFT: 272px" runat="server"
				Font-Size="10pt" ForeColor="Red" Width="200px" Height="30px"></asp:label>&nbsp;<IMG style="Z-INDEX: 109; POSITION: absolute; TOP: 432px; CURSOR: hand; LEFT: 392px"
				onclick="resetform(document.form1)" height="32" src="xpGrid/Images/reset.gif" width="115">
			<asp:imagebutton id="ImgBtnLogin" style="Z-INDEX: 108; POSITION: absolute; TOP: 432px; LEFT: 264px"
				tabIndex="3" runat="server" ImageUrl="xpGrid/Images/login.gif"></asp:imagebutton><IMG style="Z-INDEX: 107; POSITION: absolute; TOP: 360px; LEFT: 536px" height="177" src="xpGrid/Images/loginlock.gif"
				width="216">
			<asp:textbox id="edtPassWord" style="Z-INDEX: 114; POSITION: absolute; TOP: 344px; LEFT: 328px"
				tabIndex="2" runat="server" Width="100px" Height="19px" CssClass="frm" TextMode="Password"></asp:textbox><asp:textbox id="edtUserName" style="Z-INDEX: 115; POSITION: absolute; TOP: 304px; LEFT: 328px"
				tabIndex="1" runat="server" Width="100px" Height="19px" CssClass="frm"></asp:textbox><IMG style="Z-INDEX: 106; POSITION: absolute; TOP: 256px; LEFT: 528px" height="83" src="xpGrid/Images/loginfont.gif"
				width="225"><FONT id="lblAppName" style="Z-INDEX: 119; POSITION: absolute; TEXT-ALIGN: center; HEIGHT: 54px; FONT-SIZE: 25pt; TOP: 160px; LEFT: 256px"
				face="Tahoma, Arial, Helvetica" color="#ffffff" size="2" runat="server"> 深圳赛格晶端经费预实算系统</FONT><IMG id="IMG4" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 520px; HEIGHT: 302px; TOP: 248px; LEFT: 232px"
				height="302" src="xpGrid/Images/loginmid.gif" width="520" runat="server"><IMG id="IMG2" style="Z-INDEX: 118; POSITION: absolute; WIDTH: 520px; HEIGHT: 129px; TOP: 120px; LEFT: 232px"
				height="130" src="xpGrid/Images/logintop.gif" width="520" runat="server"><IMG id="IMG3" style="Z-INDEX: 103; POSITION: absolute; WIDTH: 22px; HEIGHT: 430px; TOP: 120px; LEFT: 752px"
				height="430" src="xpGrid/Images/loginright.gif" width="22" runat="server">
			<DIV style="Z-INDEX: 112; POSITION: absolute; WIDTH: 41px; HEIGHT: 16px; FONT-SIZE: 10pt; TOP: 312px; LEFT: 288px"
				ms_positioning="FlowLayout">
				<DIV align="center"><FONT color="#0099cc"><STRONG>工号:</STRONG></FONT></DIV>
			</DIV>
			<DIV style="Z-INDEX: 113; POSITION: absolute; WIDTH: 41px; HEIGHT: 16px; FONT-SIZE: 10pt; TOP: 352px; LEFT: 288px"
				ms_positioning="FlowLayout">
				<DIV align="center"><FONT color="#0099cc"><STRONG>密码:</STRONG></FONT></DIV>
			</DIV>
			<asp:label id="Label2" style="Z-INDEX: 110; POSITION: absolute; TOP: 488px; LEFT: 232px" runat="server"
				Font-Size="10pt" ForeColor="DodgerBlue" Width="318px" Height="8px">版权：深圳赛格晶端显示器有限公司 Version: C#3.0</asp:label><asp:panel id="Panel" style="Z-INDEX: 111; POSITION: absolute; TOP: 288px; LEFT: 280px" runat="server"
				Width="248px" Height="96px" BorderColor="WhiteSmoke" BorderStyle="None" BorderWidth="0px"><FONT face="宋体"></FONT></asp:panel>
		</form>
	</body>
</HTML>
