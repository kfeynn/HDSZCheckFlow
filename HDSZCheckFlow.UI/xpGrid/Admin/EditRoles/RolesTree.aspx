<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditRoles.RolesTree" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RolesTree</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../JsLib/MyScript.js"></SCRIPT>
	</HEAD>
	<body onmousemove="SetState();" onmousedown="SetState();" onkeydown="setenter();" onselectstart="NoSelect();"
		oncontextmenu="NoRightMenu();" scroll="no" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 48px; POSITION: absolute; TOP: 416px" runat="server"
				Width="80px" Height="14px">角色说明：</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 110; LEFT: 80px; POSITION: absolute; TOP: 40px" runat="server"
				Height="8px" Width="72px" CssClass="Title">角色清单</asp:Label>
			<iewc:TreeView id="trvRoleTree" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 72px"
				runat="server" ExpandLevel="1" AutoPostBack="True" AutoSelect="True" SelectExpands="True" Width="230px"
				Height="460px"></iewc:TreeView>
			<asp:Label id="Label1" style="Z-INDEX: 107; LEFT: 48px; POSITION: absolute; TOP: 376px" runat="server"
				Width="80px" Height="14px">角色名称：</asp:Label><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoleName" ErrorMessage="**"
				style="Z-INDEX: 111; LEFT: 120px; POSITION: absolute; TOP: 376px">*</asp:RequiredFieldValidator><asp:textbox id="txtRoleName" runat="server" Width="160px" style="Z-INDEX: 109; LEFT: 48px; POSITION: absolute; TOP: 392px"></asp:textbox>
			<asp:textbox id="txtRoleDesc" runat="server" Width="160px" Height="54px" TextMode="MultiLine"
				style="Z-INDEX: 108; LEFT: 48px; POSITION: absolute; TOP: 432px"></asp:textbox>
			<asp:Button id="btnDel" runat="server" CssClass="InputButton" Text="删除" style="Z-INDEX: 102; LEFT: 48px; POSITION: absolute; TOP: 496px"></asp:Button>
			<asp:Button id="btnEdit" runat="server" CssClass="InputButton" Text="修改" style="Z-INDEX: 101; LEFT: 168px; POSITION: absolute; TOP: 496px"></asp:Button>
			<asp:Button id="btnAdd" runat="server" CssClass="InputButton" Text="新增" style="Z-INDEX: 100; LEFT: 112px; POSITION: absolute; TOP: 496px"></asp:Button>
			<img src="../../../AppSystem/Images/gradtop.jpg" border="0" style="Z-INDEX:999;LEFT:10px;WIDTH:250px;BORDER-TOP-STYLE:none;BORDER-RIGHT-STYLE:none;BORDER-LEFT-STYLE:none;POSITION:absolute;TOP:8px;HEIGHT:7px;BORDER-BOTTOM-STYLE:none">
			<img src="../../../AppSystem/Images/gradleft.jpg" style="Z-INDEX:998;LEFT:7px;WIDTH:7px;BORDER-TOP-STYLE:none;BORDER-RIGHT-STYLE:none;BORDER-LEFT-STYLE:none;POSITION:absolute;TOP:8px;HEIGHT:500px;BORDER-BOTTOM-STYLE:none">
		</form>
	</body>
</HTML>
