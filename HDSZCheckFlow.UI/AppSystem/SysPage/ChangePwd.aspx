<%@ Page Language="c#" AutoEventWireup="false" Codebehind="ChangePwd.aspx.cs" Inherits="HDSZCheckFlow.AppSystem.SysPage.ChangePwd" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ChangePwd</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="txtOld" runat="server" TextMode="Password" CssClass="frm" Height="19px" style="Z-INDEX: 103; LEFT: 296px; POSITION: absolute; TOP: 112px"
				Width="124px" tabIndex="1"></asp:TextBox>
			<asp:label id="Label5" style="Z-INDEX: 114; LEFT: 224px; POSITION: absolute; TOP: 80px" runat="server"
				Width="77px" Height="8px">当前用户：</asp:label>
			<asp:label id="LblUserName" style="Z-INDEX: 110; LEFT: 296px; POSITION: absolute; TOP: 80px"
				runat="server" Width="88px" Height="2px" CssClass="MessageLabel"></asp:label><asp:Label id="Label1" runat="server" style="Z-INDEX: 104; LEFT: 200px; POSITION: absolute; TOP: 120px">请输入旧密码：</asp:Label><asp:Label id="Label2" runat="server" style="Z-INDEX: 105; LEFT: 200px; POSITION: absolute; TOP: 152px">请输入新密码：</asp:Label><asp:Label id="Label3" runat="server" style="Z-INDEX: 106; LEFT: 200px; POSITION: absolute; TOP: 184px">请确认新密码：</asp:Label>
			<asp:TextBox id="txtNew" runat="server" TextMode="Password" CssClass="frm" Height="19px" style="Z-INDEX: 107; LEFT: 296px; POSITION: absolute; TOP: 144px"
				Width="124px" tabIndex="2"></asp:TextBox>
			<asp:TextBox id="txtNew2" runat="server" TextMode="Password" CssClass="frm" Height="19px" style="Z-INDEX: 109; LEFT: 296px; POSITION: absolute; TOP: 176px"
				Width="124px" tabIndex="3"></asp:TextBox>
			<asp:Label id="lblErr" runat="server" ForeColor="Red" style="Z-INDEX: 111; LEFT: 198px; POSITION: absolute; TOP: 208px"
				Width="208px" CssClass="TxtCenter"></asp:Label>
			<asp:Button id="btnSave" runat="server" Text="确定" CssClass="InputButton" Height="18px" style="Z-INDEX: 112; LEFT: 285px; POSITION: absolute; TOP: 224px"
				tabIndex="4"></asp:Button>
			<asp:panel id="Panel2" style="Z-INDEX: 102; LEFT: 192px; POSITION: absolute; TOP: 104px" runat="server"
				Height="33px" Width="240px" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray"></asp:panel>
			<asp:Label id="Label4" style="Z-INDEX: 113; LEFT: 250px; POSITION: absolute; TOP: 40px" runat="server"
				Width="104px" Height="8px" CssClass="Title">用户密码维护</asp:Label>
			<asp:panel id="Panel4" style="Z-INDEX: 100; LEFT: 192px; POSITION: absolute; TOP: 168px" runat="server"
				Height="33px" Width="240px" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray"></asp:panel>
			<asp:panel id="Panel3" style="Z-INDEX: 101; LEFT: 192px; POSITION: absolute; TOP: 136px" runat="server"
				Height="33px" Width="240px" BorderWidth="1px" BorderStyle="Solid" BorderColor="DarkGray"></asp:panel><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
		</form>
	</body>
</HTML>
