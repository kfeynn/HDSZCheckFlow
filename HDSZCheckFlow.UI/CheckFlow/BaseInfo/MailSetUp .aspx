<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="MailSetUp .aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.BaseInfo.MailSetUp_"  EnableEventValidation="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MailSetUp </title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body style="PADDING-RIGHT: 50px; MARGIN-TOP: 100px; PADDING-LEFT: 50px; LEFT: 10px; MARGIN-LEFT: 50px; VERTICAL-ALIGN: baseline; LINE-HEIGHT: normal; MARGIN-RIGHT: 10px; PADDING-TOP: 100px; LETTER-SPACING: normal; TOP: 100px; BACKGROUND-COLOR: transparent; TEXT-ALIGN: center"
		MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div id="UpShow" runat="server">
				<table style="WIDTH: 505px; HEIGHT: 104px" border="1">
					<tr align="left">
						<td>
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">人员工号</DIV>
						</td>
						<td><asp:textbox id="txtCode1" runat="server" Enabled="False"></asp:textbox></td>
						<td>
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">姓名</DIV>
						</td>
						<td colSpan="2"><asp:textbox id="txtName1" runat="server" Enabled="False" Width="105px"></asp:textbox></td>
					</tr>
					<tr>
						<td style="HEIGHT: 38px">
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">邮件地址</DIV>
						</td>
						<td style="HEIGHT: 38px"><asp:textbox id="txtAddress1" runat="server" Enabled="False"></asp:textbox></td>
						<td style="HEIGHT: 38px">
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">昵称</DIV>
						</td>
						<td style="HEIGHT: 38px"><asp:textbox id="txtNickName1" runat="server" Enabled="False" Width="104px"></asp:textbox></td>
						<td style="HEIGHT: 38px" align="center"><asp:checkbox id="Checkbox2" style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: 12px; LINE-HEIGHT: normal; FONT-STYLE: normal; FONT-VARIANT: normal"
								runat="server" ms_positioning="FlowLayout" Enabled="False" Text="是否发送"></asp:checkbox></td>
					</tr>
					<tr align="center">
						<td colSpan="5"><asp:button id="btnUpdate" runat="server" Text="修  改" ForeColor="#8080FF"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:Label id="lblMessage" runat="server" Enabled="true" ForeColor="#ff0000" Font-Size="18px"></asp:Label></td>
					</tr>
				</table>
			</div>
			<div id="Up" runat="server">
				<table style="WIDTH: 505px; HEIGHT: 104px" border="1">
					<tr align="left">
						<td>
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">人员工号</DIV>
						</td>
						<td><asp:textbox id="txtCode" runat="server" Enabled="False"></asp:textbox></td>
						<td>
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">姓名</DIV>
						</td>
						<td colSpan="2"><asp:textbox id="txtName" runat="server" Width="105px"></asp:textbox></td>
					</tr>
					<tr>
						<td style="HEIGHT: 38px">
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">邮件地址</DIV>
						</td>
						<td style="HEIGHT: 38px"><asp:textbox id="txtAddress" runat="server"></asp:textbox></td>
						<td style="HEIGHT: 38px">
							<DIV style="DISPLAY: inline" ms_positioning="FlowLayout">昵称</DIV>
						</td>
						<td style="HEIGHT: 38px"><asp:textbox id="txtNickName" runat="server" Width="104px"></asp:textbox></td>
						<td style="HEIGHT: 38px" align="center"><asp:checkbox id="CheckBox1" style="DISPLAY: inline; FONT-WEIGHT: normal; FONT-SIZE: 12px; LINE-HEIGHT: normal; FONT-STYLE: normal; FONT-VARIANT: normal"
								runat="server" ms_positioning="FlowLayout" Text="是否发送"></asp:checkbox></td>
					</tr>
					<tr align="center">
						<td colSpan="5"><asp:button id="btnDetermine" runat="server" Text="确  定" ForeColor="#8080FF"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="btnClose" runat="server" Text="取  消" ForeColor="#8080FF"></asp:button></td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
