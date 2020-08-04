<%@ Page language="c#" Codebehind="GetStepInfoApplySheet.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.GetStepInfoApplySheet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GetStepInfoApplySheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 40px" cellSpacing="1"
					cellPadding="1" width="80%" border="0">
					<TR>
						<TD><font size="+1"> 流程步骤:</font></TD>
					</TR>
					<TR>
						<TD>
							<asp:table id="tabFlowStep" style="BORDER-COLLAPSE: collapse" runat="server" CssClass="GbText"
								Width="80%" Height="36px" GridLines="Both" BorderColor="#0066CC" CellPadding="3" EnableViewState="False"></asp:table></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
