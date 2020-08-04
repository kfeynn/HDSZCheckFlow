<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page Language="c#" AutoEventWireup="false" Codebehind="MyReptViewer.aspx.cs" Inherits="HDSZCheckFlow.AppSystem.ReptSystem.MyReptViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>BaseReportWebForm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<SCRIPT LANGUAGE="Javascript">
			<!--
			// detection for Netscape
			var useAcrobat = navigator.mimeTypes &&
			navigator.mimeTypes["application/pdf"]
			//-->
		</SCRIPT>
		<SCRIPT LANGUAGE="VBScript">
			<!--
			on error resume next
			useAcrobat = not IsNull(CreateObject("AcroExch.Document"))
			'                can be CreateObject("PDF.PdfCtrl.1") too!
			//-->
		</SCRIPT>
		<SCRIPT LANGUAGE="Javascript">
			<!--
			function HaveAcrobat()
				{
					if (useAcrobat)
						return true
					else
						{
						alert("对不起，打印之前请先安装PDF阅读器(Acrobat)！");
						return false
						}
				}
			//-->
		</SCRIPT>
	</HEAD>
	<body onclick="SetCleanFlag();" onunload="CleanCache();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT>
			<asp:button id="btnPrint" style="Z-INDEX: 108; LEFT: 576px; POSITION: absolute; TOP: 32px" tabIndex="7"
				runat="server" Height="20" CssClass="InputButton" ToolTip="打印到打印机" Text="打印"></asp:button><asp:button id="btnLastPage" style="Z-INDEX: 107; LEFT: 376px; POSITION: absolute; TOP: 32px"
				tabIndex="4" runat="server" Height="19" CssClass="InputButton" ToolTip="查看最后一页报表" Text="最后一页"></asp:button><asp:button id="btnGotoPage" style="Z-INDEX: 105; LEFT: 504px; POSITION: absolute; TOP: 32px"
				tabIndex="6" runat="server" Height="19" CssClass="InputButton" Text="到指定页" Width="60px"></asp:button><asp:textbox id="txtGotoPage" style="Z-INDEX: 104; LEFT: 456px; POSITION: absolute; TOP: 32px"
				tabIndex="5" runat="server" CssClass="frm" Width="40px"></asp:textbox><asp:button id="btnFirstPage" style="Z-INDEX: 112; LEFT: 176px; POSITION: absolute; TOP: 32px"
				tabIndex="1" runat="server" Height="20" CssClass="InputButton" ToolTip="查看第一页报表" Text="第一页" Width="56px"></asp:button><asp:button id="btnPrevPage" style="Z-INDEX: 102; LEFT: 248px; POSITION: absolute; TOP: 32px"
				tabIndex="2" runat="server" Height="19" CssClass="InputButton" ToolTip="检视上一页报表" Text="上一页"></asp:button><asp:button id="btnNextPage" style="Z-INDEX: 103; LEFT: 312px; POSITION: absolute; TOP: 32px"
				tabIndex="3" runat="server" Height="19" CssClass="InputButton" ToolTip="查看下一页报表" Text="下一页"></asp:button></FONT>
			<HR style="Z-INDEX: 106; LEFT: 32px; POSITION: absolute; TOP: 56px; HEIGHT: 4px" width="800"
				color="#009900" SIZE="4">
			<INPUT class="frm" id="GoStep" style="Z-INDEX: 101; LEFT: 192px; WIDTH: 16px; POSITION: absolute; TOP: 32px; HEIGHT: 19px"
				type="text" size="1" value="-1" runat="server">
			<cr:crystalreportviewer id="MyViewer" style="Z-INDEX: 109; LEFT: 24px; POSITION: absolute; TOP: 64px" runat="server"
				Height="50px" Width="350px" DisplayToolbar="False" DisplayGroupTree="False"></cr:crystalreportviewer><INPUT class="frm" id="CacheName" style="Z-INDEX: 110; LEFT: 200px; WIDTH: 16px; POSITION: absolute; TOP: 32px; HEIGHT: 19px"
				type="text" size="1" name="Text1" runat="server"><INPUT class="frm" id="NeedCleanCache" style="Z-INDEX: 111; LEFT: 208px; WIDTH: 16px; POSITION: absolute; TOP: 32px; HEIGHT: 19px"
				type="text" size="1" value="1" name="Text1" runat="server">
			<asp:label id="Message" style="Z-INDEX: 113; LEFT: 160px; POSITION: absolute; TOP: 112px" runat="server"
				Height="16px" Width="501px" Visible="False" Font-Size="12pt" ForeColor="Red">对不起此页面已经失效，请重新点击左边菜单进入相关功能 ，谢谢！</asp:label><asp:button id="BtnBack2About" style="Z-INDEX: 114; LEFT: 704px; POSITION: absolute; TOP: 32px"
				tabIndex="7" runat="server" Height="19" CssClass="InputButton" Text="返回首页" Width="62px" Visible="False"></asp:button></form>
		<INPUT class="inputbutton" id="ExportToExcel" style="Z-INDEX: 115; LEFT: 632px; WIDTH: 66px; POSITION: absolute; TOP: 32px; HEIGHT: 20px"
			onclick="Export2Excel();" type="button" value="导出Excel" name="ExportToExcel">
	</body>
</HTML>
