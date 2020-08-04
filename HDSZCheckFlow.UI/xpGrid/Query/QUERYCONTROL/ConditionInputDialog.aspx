<%@ Register TagPrefix="uc1" TagName="ConditionShowControl" Src="ConditionShowControl.ascx" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.CommonDialog.ConditionInputDialog" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>条件输入对话框</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
<!--
	function CloseWindow()
	{
		var sClose = "<%=_sClose%>";
		if (sClose != "1")
			return;
			
		var objReturn = new Array();
		objReturn[0] =  "<%=_sTableList%>";
		objReturn[1] = "<%=_sConExp%>";
		
		//alert (objReturn[0] + "\t" + objReturn[1]);
		window.returnValue = objReturn;
		window.close();
	}
//-->
		</script>
		<link rel="stylesheet" href="../../style.css" type="text/css">
	</HEAD>
	<body MS_POSITIONING="FlowLayout" onload="CloseWindow()">
		<form runat="server" method="post" name="ConditionInputDialog">
			<P>
				<uc1:ConditionShowControl id="ctlShow" runat="server"></uc1:ConditionShowControl></P>
		</form>
	</body>
</HTML>
