<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="ApplySheetGetBack.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheetGetBack"  EnableEventValidation="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApplySheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 40px; LEFT: 20px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<tr height="28">
						<td align="center">
							<asp:Label id="lblMsg" runat="server"></asp:Label>
							<asp:Label id="Label1" runat="server">被驳回的单据(用于取回和取回后保存)</asp:Label></td>
					</tr>
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="200" align="left" border="0">
								<TR>
									<td><asp:button id="btnGetBack" runat="server" Enabled="False" Text="取回单据" Width="80px"></asp:button></td>
									<TD>
										<asp:Button id="btnKeep" runat="server" Enabled="False" Text="封存单据" Width="80px"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD height="17" style="HEIGHT: 17px"></TD>
					</TR>
					<TR>
						<TD><gridwc:xpgrid id="XPGrid1" runat="server" SelectKind="SingleLine" AllowSort="True" AllowPrint="True"
								AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="False" width="100%" PageSize="10"></gridwc:xpgrid></TD>
					</TR>
					<tr height="28">
						<td>
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#6600cc"
								border="1">
								<TR>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label2" runat="server" Visible="False">推算金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label3" runat="server" Visible="False">调整金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label5" runat="server" Visible="False">已经使用</asp:label>
										<asp:label id="Label4" runat="server" Visible="False">追加金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label6" runat="server" Visible="False">剩   余</asp:label></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblChange" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblSumCheck" runat="server"></asp:label>
										<asp:label id="lblAdd" runat="server" Visible="False"></asp:label></TD>
									<TD>
										<asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr height="28">
						<td></td>
					</tr>
					<TR>
						<TD>
							<gridwc:XPGrid id="XPGrid2" runat="server" width="100%" SelectKind="MulitLines" AllowSort="True"
								AllowPrint="True" AllowExportExcel="True" AllowEdit="False" AllowDelete="False" AllowAdd="False"
								Visible="False"></gridwc:XPGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
