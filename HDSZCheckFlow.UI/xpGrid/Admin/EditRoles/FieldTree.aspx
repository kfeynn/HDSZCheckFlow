<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditRoles.FieldTree" %>
<%@ OutputCache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FieldTree</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../JsLib/MyScript.js"></SCRIPT>
	</HEAD>
	<Body onmousemove="SetState();" onmousedown="SetState();" onkeydown="setenter();" onselectstart="NoSelect();"
		oncontextmenu="NoRightMenu();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<iewc:TreeView id="trvField" runat="server" SelectExpands="True" ExpandLevel="1" Height="460px"
				style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 72px" Width="250px" AutoSelect="True"></iewc:TreeView>
			<asp:Label id="Label4" style="Z-INDEX: 105; LEFT: 96px; POSITION: absolute; TOP: 40px" runat="server"
				Height="8px" Width="72px" CssClass="Title">数据授权</asp:Label>
			<asp:Button id="lnkViewRight" runat="server" Text="授权查看" CssClass="InputButton" style="Z-INDEX: 102; LEFT: 104px; POSITION: absolute; TOP: 472px"
				Width="60px"></asp:Button>
			<asp:Button id="lnkEditRight" runat="server" Text="授权修改" CssClass="InputButton" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 472px"
				Width="60px"></asp:Button>
			<asp:Button id="lnkRevoke" runat="server" Text="回收" CssClass="InputButton" style="Z-INDEX: 104; LEFT: 184px; POSITION: absolute; TOP: 472px"></asp:Button>
			<img src="../../../AppSystem/Images/gradtop.jpg" border="0" style="Z-INDEX:999;LEFT:10px;WIDTH:250px;BORDER-TOP-STYLE:none;BORDER-RIGHT-STYLE:none;BORDER-LEFT-STYLE:none;POSITION:absolute;TOP:8px;HEIGHT:7px;BORDER-BOTTOM-STYLE:none">
			<img src="../../../AppSystem/Images/gradleft.jpg" style="Z-INDEX:998;LEFT:7px;WIDTH:7px;BORDER-TOP-STYLE:none;BORDER-RIGHT-STYLE:none;BORDER-LEFT-STYLE:none;POSITION:absolute;TOP:8px;HEIGHT:500px;BORDER-BOTTOM-STYLE:none">
		</form>
	</Body>
</HTML>
