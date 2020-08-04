<%@ Page language="c#" Codebehind="updateBaseInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Subject.updateBaseInfo" enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>updateBaseInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<!--<script language="javascript" src="../../Style/My97DatePicker/WdatePicker.js"></script>-->
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
					cellPadding="1" width="100%" border="0">
					<TR>
						<TD>更新年月：</TD>
						<TD>
							<asp:TextBox onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})" id="txtData" runat="server"></asp:TextBox></TD>
						<TD>
							<asp:Button id="btnInputCost" runat="server" Text="导入实际发生费用"></asp:Button></TD>
						<TD>
							<asp:Label id="lblMessage" runat="server"></asp:Label></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 14px"></TD>
						<TD style="HEIGHT: 14px"></TD>
						<TD style="HEIGHT: 14px">
							<asp:Button id="btnUpdateRate" runat="server" Text="更新汇率" Width="157px"></asp:Button></TD>
						<TD style="HEIGHT: 14px"></TD>
						<TD style="HEIGHT: 14px"></TD>
						<TD style="HEIGHT: 14px"></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
