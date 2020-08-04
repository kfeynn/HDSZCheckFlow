<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.CommonDialog.ConditionEditorDialog"  EnableEventValidation="false" %>
<%@ Register TagPrefix="uc1" TagName="QuerySaverEditControl" Src="QuerySaverEditControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>条件编辑对话框</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
<!--
	function CloseWindow()
	{
		var sClose = <%= ctlSaverEditor.btnSearchSelected%>;
		 
		
		if (sClose == 1)
		{
			var aReturn = new Array();
			aReturn[0] = <%= ctlSaverEditor.Updated%>;
			aReturn[1] = <%=ctlSaverEditor.SaverID%>;
			aReturn[2] = "<%=ctlSaverEditor.ConExp%>";
			
			//alert(aReturn[2]);
			
			window.returnValue = aReturn;
			window.close();
		}
		
	}
//-->
		</script>
		<link rel="stylesheet" href="../../style.css" type="text/css">
	</HEAD>
	<body MS_POSITIONING="FlowLayout" onload="CloseWindow();" onunload="ReturnResult();">
		<form id="ConditionEditorDialog" method="post" runat="server">
			<P>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD width="3"></TD>
						<TD>
							<uc1:QuerySaverEditControl id="ctlSaverEditor" runat="server"></uc1:QuerySaverEditControl></TD>
					</TR>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
