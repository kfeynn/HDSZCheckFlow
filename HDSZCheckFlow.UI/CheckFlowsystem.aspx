<%@ Page %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<HTML>
	<HEAD>
		<TITLE>请稍候，系统登录中。。。</TITLE>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="Shortcut Icon" href="favicon.ico">
		<SCRIPT language="JavaScript" src="AppSystem/JsLib/MyScript.js"></SCRIPT>
		<script language="javascript">
			self.moveTo(0,0);
			self.resizeTo(screen.availWidth,screen.availHeight);
			var userid="";
			//var time=7200; /*60分种未操作自动重新登录*/
			var AppName=""
			var SystemRootPath
			function SetMyStates()
				{
					window.status=window.frames("Banner").document.getElementById("lblAppName").innerText;
					userid=window.frames("Banner").document.getElementById("lblUserId").innerText
					SystemRootPath=window.frames("Banner").document.getElementById("lblSystemRootPath").innerText
					document.title=window.status 
					AppName=window.status;
				}
			function CloseOpen(event) 
				{ 
					if(event.clientX<=0 && event.clientY<0) 
					{ 
						//alert("关闭浏览器"); 
						CloseWin();
						
					} 
					else 
					{ 
						//alert("刷新或离开"); 
					} 
				}
			//window.onunload=CloseWin;
			
			
			
			
		</script>
	</HEAD>
	<FRAMESET onload="SetMyStates();" onunload="CloseOpen(event)" ROWS="50,*" BORDER="0" frameSpacing="0"
		frameBorder="0">
		<FRAME noresize NAME="Banner" SRC="AppSystem\SysPage\Banner.aspx">
		<FRAMESET COLS="180,8,86%" BORDER="0" onload="SetMyStates();" id="frame" onunload="CloseOpen(event)">
			<FRAME noresize NAME="LeftTree"   SRC="AppSystem\SysPage\LeftTreeMenuNew.Aspx">
			<FRAME noresize NAME="pageline" scrolling="no" SRC="frameline.html">
			<FRAME noresize NAME="RightContent" scrolling="auto" SRC="AppSystem\SysPage\Abouts.Aspx">
		</FRAMESET>
	</FRAMESET>
</HTML>
