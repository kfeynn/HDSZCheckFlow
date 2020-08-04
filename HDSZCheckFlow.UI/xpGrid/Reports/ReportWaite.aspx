<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Reports.ReportWaite" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>正在生成报表结果，请等待...</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
	function window_onload()
	{
		OpenReport();   
	}
		</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="ReportWaite" method="post" runat="server">
			<asp:panel id="Panel1" runat="server" Width="576px" Height="68px" Font-Size="Medium" Font-Names="幼圆" ForeColor="Maroon">正在生成报表结果文件，这可能需要一些时间，请您耐心等待...</asp:panel>
		</form>
	</body>
</HTML>
