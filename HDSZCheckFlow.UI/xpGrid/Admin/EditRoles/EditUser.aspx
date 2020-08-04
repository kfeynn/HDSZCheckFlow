<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="cc1" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page Language="c#" AutoEventWireup="false" Codebehind="EditUser.aspx.cs" Inherits="xpGridTest.UI.xpGrid.Admin.EditRoles.EditUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>EditUserNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../../../AppSystem/Style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../JsLib/MyScript.js"></SCRIPT>
	</HEAD>
	<body onload="FirstInputCtrl();SetFormSize();" onkeydown="setenter();" onmousemove="SetState();"
		onmousedown="SetState();" onselectstart="NoSelect();" oncontextmenu="NoRightMenu();"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Button id="btnSaveUsrInfo" style="Z-INDEX: 101; LEFT: 584px; POSITION: absolute; TOP: 8px"
				runat="server" CssClass="InputButton" Text="保存用户信息" Width="88px" Visible="False"></asp:Button>
			<cc1:xpgrid id="grdUser" style="Z-INDEX: 100; LEFT: 40px; POSITION: absolute; TOP: 80px" runat="server"
				SelectKind="SingleLine" RightControl="True" AllowEdit="True" AllowAdd="True" AllowDelete="True"
				PageSize="15" Width="810px" PageText="第{CurrentPageIndex}页 共{PageCount}页 总用户数{RecordCount}"
				AllowSort="True" AllowPrint="True" AllowExportExcel="True" CommandText="Select * From xpGrid_User Where UserName<>'Admin'  Order By deleted,Online Desc,LastOprtnDateTime Desc,LoginTimes Desc"></cc1:xpgrid>
			<iewc:treeview id="trvRoleTree" style="Z-INDEX: 1003; LEFT: 616px; POSITION: absolute; TOP: 120px"
				runat="server" ExpandLevel="1" SelectExpands="True"></iewc:treeview>
			<asp:button id="btnSave" style="Z-INDEX: 1004; LEFT: 744px; POSITION: absolute; TOP: 48px" runat="server"
				Width="56px" Text="保存" CssClass="InputButton" Visible="False"></asp:button>
			<asp:Label id="Label4" style="Z-INDEX: 113; LEFT: 352px; POSITION: absolute; TOP: 40px" runat="server"
				Width="168px" CssClass="Title" Height="8px">系统用户清单</asp:Label>&nbsp;
		</form>
	</body>
</HTML>
