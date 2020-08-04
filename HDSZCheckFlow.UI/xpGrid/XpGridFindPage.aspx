<%@ Page AutoEventWireup="false" Inherits="XPGrid.XpGridScript.XpGridFindPage" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>通用辅助输入查询</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Pragma" content="no-cache">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<base target="_self">
		<script language="javascript">
	          //this.width = grdCond.clientWidth;
	          parent.dialogWidth= "550px";
	          //parent.dialogWidth=document.getElementById("grdCond").clientWidth;
	          	var sec=0;
				function TimeCounter()
				 {
					sec=sec+1;	
					if(sec>=480){window.close();};
					window.setTimeout("TimeCounter();",1000); 
				  }
				  function ReSetCounter()
				  {
				    sec=0;
				  }
				  
				 /*开始计时*/
				  window.setTimeout("TimeCounter();",1000); 
				  
		</script>
	</HEAD>
	<body >
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td><gridwc:xpquery id="XPQuery1" runat="server" RepeatColumns="2" RightControl="False"></gridwc:xpquery></td>
					<td><asp:button id="btnQuery" runat="server" Text="查询" CssClass="InputButton"></asp:button></td>
				</tr>
			</table>
			<gridwc:xpgrid id="grdCond" runat="server" AllowQuery="False" PageSize="10" AutoGenerateColumns="False"
				SelectKind="SingleLine" RightControl="False" AllowSort="True"></gridwc:xpgrid></form>
	</body>
</HTML>
