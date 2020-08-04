<%@ Page AutoEventWireup="false" Inherits="XpGridFrame.Menu.LeftMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>xpGrid Left Menu</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="default.css" type="text/css" rel="stylesheet">
		<script>
		var saveOpen="";
		var tdHeight=0;
		function expand(objid)
		{
			if(tdHeight==0)
			{
				var tb = document.getElementById('menuTable');
				var tr = tb.rows
				var len = tr[0].cells.length / 3;
				tdHeight=document.getElementById('kk').style.pixelHeight-16-document.getElementById('menuTable').offsetHeight;
			}
			var idd = 'e' + arguments[0];
			if(saveOpen!="")
			{
				document.getElementById('e'+saveOpen).style.display='none';
			}
			document.getElementById(idd).style.display='';
			document.getElementById(idd).style.height=tdHeight+'px';
			
			document.getElementById(idd).filters[0].apply();
			document.getElementById(idd).filters[0].play();
			saveOpen=arguments[0];
		}
		//连接具体页面
		function linkUrl()
		{
			window.parent.mainFrame.location.href=arguments[0];
		}
		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			
		</form>
	</body>
</HTML>
