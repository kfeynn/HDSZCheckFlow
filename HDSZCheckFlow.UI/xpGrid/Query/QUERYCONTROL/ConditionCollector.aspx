<%@ Register TagPrefix="uc1" TagName="ConditionShowControl" Src="ConditionShowControl.ascx" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.ConditionCollector" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConditionCollector</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<script language=javascript>
<!--
	function CloseWindow()
	{
		var hidConSqlExp = document.all('<%=hidConSqlExp.ClientID%>');
		if (hidConSqlExp.value.length !=0)
		{
			window.returnValue = hidConSqlExp.value;
			window.close();
		}
	}
//-->
</script>
		
	</HEAD>
	<body MS_POSITIONING="FlowLayout" onload = "CloseWindow()">
		<form id="ConditionCollector" method="post" runat="server">
			<P>
				<uc1:ConditionShowControl id="ctlConditionShow" runat="server"></uc1:ConditionShowControl></P>
			<P><FONT face="ËÎÌו"> <INPUT id="hidConSqlExp" type="hidden" name="Hidden1" runat="server" value=""></FONT></P>
		</form>
	</body>
</HTML>
