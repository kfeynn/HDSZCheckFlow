<%@ Page Language="c#" AutoEventWireup="false" Codebehind="MyShowImage.aspx.cs" Inherits="xpGridTest.UI.xpGrid.HenryAdd.MyShowImage" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>图片查看器</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../AppSystem/Style.css" type="text/css" rel="stylesheet">
		<base target="_self">
		<script language="javascript" type="text/javascript">
			/*以下函数用于判断图片大小并且让弹出框自动适应大小*/
			function FitPictureSize()
				{
					var ScreenWidth=parent.screen.availWidth;
					var ScreenHeight=parent.screen.availHeight;
					var winWidth=document.getElementById("xpGridImg").width;
					var winHeight=document.getElementById("xpGridImg").height+20;
					
					var winLeft=(ScreenWidth-winWidth)/2;
					var winTop=(ScreenHeight-winHeight)/2;
					
					parent.dialogHeight = winHeight+"px";
					parent.dialogWidth = winWidth+"px";
					
					parent.dialogLeft = winLeft+"px";
					parent.dialogTop =  winTop+"px";
				}
				
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
	<body scroll="no" onload="FitPictureSize();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Image id="xpGridImg" runat="server" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"></asp:Image>
		</form>
	</body>
</HTML>
