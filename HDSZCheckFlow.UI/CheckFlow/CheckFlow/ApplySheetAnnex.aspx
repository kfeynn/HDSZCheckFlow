<%@ Page language="c#" Codebehind="ApplySheetAnnex.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheetAnnex"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApplySheetAnnex</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">   
			function   adjustwindow()   
			{   
			window.resizeTo(500,500);   
			xoffset=(screen.width-500)/2;   
			yoffset=(screen.height-500)/2;   
			window.moveTo(xoffset,yoffset);   
			//window.document.toolbar='no', menubar='no', scrollbars=no, resizable=no, location=no, status=no;
			}   
		</script>
	</HEAD>
	<body bgColor="lightgrey" onload="adjustwindow()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 488px; HEIGHT: 128px; TOP: 20px; LEFT: 0px"
					cellSpacing="1" cellPadding="1" width="488" align="center" border="0">
					<TR bgColor="#ffff66">
						<TD colSpan="3"><font size="-1">提醒：文件名不能包含 # @ . ~ 等特殊字符。</font></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 52px">选择附件</TD>
						<TD><INPUT id="file1" type="file" name="File1" runat="server"></TD>
						<TD><asp:button id="btnUpLoad" runat="server" Width="90px" Text="上    传" CssClass="greenButtonCss"></asp:button><asp:label id="lblUploadMsg" runat="server" Width="104px"></asp:label></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 52px"></TD>
						<TD>
						</TD>
						<TD></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 52px"></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
			<TABLE id="Table2" style="Z-INDEX: 102; POSITION: absolute; WIDTH: 484px; HEIGHT: 95px; TOP: 184px; LEFT: 0px"
				cellSpacing="1" cellPadding="1" width="484" align="center" border="0">
				<TR bgColor="#9999ff">
					<TD align="center" colSpan="3">附件</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:table id="tbAnnex" runat="server" Width="100%"></asp:table></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center"><asp:linkbutton id="LinkButton1" runat="server" Font-Size="16px" Visible="False">返回</asp:linkbutton>&nbsp;
					</TD>
					<TD><FONT face="宋体"></FONT></TD>
				</TR>
			</TABLE>
			<asp:LinkButton id="LinkButton2" style="Z-INDEX: 103; POSITION: absolute; TOP: 432px; LEFT: 160px"
				runat="server"></asp:LinkButton></form>
	</body>
</HTML>
