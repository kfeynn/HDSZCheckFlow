<%@ Page language="c#" Codebehind="BudgetAccount.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.BudgetAccount" enableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetAccount</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../AppSystem/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		
		
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体" size="3">
				<gridwc:XPGrid id="XPGrid1" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 80px" runat="server"
					Width="95%" AllowAdd="True" AllowEdit="True" AllowDelete="True" AllowExportExcel="True" AllowPrint="True"
					AllowSort="True" SelectKind="MulitLines"></gridwc:XPGrid>
				<asp:Button id="btnQuery" style="Z-INDEX: 104; LEFT: 656px; POSITION: absolute; TOP: 48px" runat="server"
					Width="60px" CssClass="inputbutton" Text="查询"></asp:Button>
				<asp:TextBox id="txtData" style="Z-INDEX: 103; LEFT: 472px; POSITION: absolute; TOP: 48px" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})"
					runat="server"></asp:TextBox>
				<DIV style="DISPLAY: inline; Z-INDEX: 102; LEFT: 96px; WIDTH: 344px; POSITION: absolute; TOP: 32px; HEIGHT: 36px"
					ms_positioning="FlowLayout">公司预算情况</DIV>
				<asp:Label id="lblMessage" style="Z-INDEX: 105; LEFT: 760px; POSITION: absolute; TOP: 56px"
					runat="server"></asp:Label>
			</FONT>
		</form>
	</body>
</HTML>
