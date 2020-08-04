<%@ Page Language="c#" AutoEventWireup="false" Codebehind="Banner.aspx.cs" Inherits="HDSZCheckFlow.AppSystem.SysPage.Banner" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Banner</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<SCRIPT language="JavaScript" src="../JsLib/MyScript.js"></SCRIPT>
		<SCRIPT language="Javascript">
			/*以下代码用于统计在线的秒数*/	
			
			var sec=0;
			
			idt=window.setTimeout("update();",1000);
			function update(){
				sec++;
				document.getElementById("TxtSecond").value=sec;
				idt=window.setTimeout("update();",1000); 
				//parent.time--;
   			  //  if (parent.time<=0){parent.document.location.href = top.SystemRootPath+"CheckFlowsystem.aspx";};
			  //  if ((parent.time<180) && (parent.time>=60)){window.status=parent.AppName+"(系统将在"+parseInt(""+(parent.time/60))+"分钟后自动退出！"+")";};
			  //  if ((parent.time>0) && (parent.time<60)){window.status=parent.AppName+"(请注意，一分钟之内系统将自动退出！)"};
							}
							
							
			function logout(){
							if(confirm("确定要退出吗?"))
								{
									var userid=parent.userid ;
									//parent.document.location.href = top.SystemRootPath+"xpGrid/LogOut.aspx";
									CloseWin2(userid);
									
									// 再转向 
									parent.document.location.href = top.SystemRootPath+"CheckFlowsystem.aspx" ;
									
								}
							 }
						
		</SCRIPT>
	</HEAD>
	<body onkeydown="setenter();" oncontextmenu="NoRightMenu();" onselectstart="NoSelect();"
		topmargin="0" rightmargin="0" leftmargin="0" bottommargin="0" scroll="no" ms_positioning="GridLayout"
		bgcolor="whitesmoke">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体" id="FONT1" color="buttonface"><IMG style="Z-INDEX: 109; POSITION: absolute; WIDTH: 200px; HEIGHT: 64px; TOP: 0px; LEFT: 0px"
					height="64" width="200" src="../Images/suanpan1.gif"><FONT id="lblSystemRootPath" style="Z-INDEX: 110; POSITION: absolute; TEXT-ALIGN: center; WIDTH: 120px; HEIGHT: 16px; FONT-SIZE: 12px; TOP: 40px; LEFT: -144px"
					face="Tahoma, Arial, Helvetica" color="white" size="6" runat="server"><STRONG>系统根目录</STRONG></FONT><FONT id="lblUserId" style="Z-INDEX: 107; POSITION: absolute; TEXT-ALIGN: center; WIDTH: 120px; HEIGHT: 16px; FONT-SIZE: 12px; TOP: 24px; LEFT: -144px"
					face="Tahoma, Arial, Helvetica" color="white" size="6" runat="server"><STRONG>用户工号</STRONG></FONT>
				<asp:TextBox id="starttime" style="Z-INDEX: 106; POSITION: absolute; TOP: -48px; LEFT: 40px"
					runat="server" MaxLength="20" ForeColor="White" BorderStyle="None" Width="168px" Height="16px">March 1,2006 00:00:00</asp:TextBox>&nbsp;&nbsp;&nbsp;
				<asp:TextBox id="TxtSecond" style="Z-INDEX: 101; POSITION: absolute; TOP: -80px; LEFT: 72px"
					runat="server" Height="16px" Width="80px" BorderStyle="None" ForeColor="White" MaxLength="20">0</asp:TextBox><FONT id="lblAppName" style="Z-INDEX: 111; POSITION: absolute; TEXT-ALIGN: right; HEIGHT: 43px; TOP: 0px; LEFT: 200px"
					face="Tahoma, Arial, Helvetica" color="black" size="5" runat="server"><STRONG>赛格晶端经费预实算系统</STRONG></FONT></FONT>
			<asp:Label id="TxtLoginTime" style="Z-INDEX: 102; POSITION: absolute; TOP: 24px; LEFT: 712px"
				runat="server" Height="8px" Width="142px" ForeColor="OliveDrab" Font-Size="10pt"></asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 103; POSITION: absolute; TOP: 24px; LEFT: 608px" runat="server"
				Width="104px" Height="24px" ForeColor="Black" Font-Size="10pt">您登录的时间为：</asp:Label>
			<asp:Label id="Label1" style="Z-INDEX: 104; POSITION: absolute; TOP: 24px; LEFT: 864px" runat="server"
				Width="44px" Height="8px" Font-Size="10pt" ForeColor="Black">退出：</asp:Label>
			<IMG id="ImgLogout" style="Z-INDEX: 105; BORDER-BOTTOM: yellow 1px solid; POSITION: absolute; BORDER-LEFT: yellow 1px solid; BORDER-TOP: yellow 1px solid; TOP: 20px; CURSOR: hand; BORDER-RIGHT: yellow 1px solid; LEFT: 904px"
				onclick="logout();" height="20" src="../Images/SCDCNCLL.ICO" width="20" runat="server">&nbsp;&nbsp;
		</form>
	</body>
</HTML>
