<%@ Page Language="c#" AutoEventWireup="false" Codebehind="Abouts.aspx.cs" Inherits="HDSZCheckFlow.AppSystem.SysPage.Abouts" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>首页</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="Javascript">
					 /*以下代码用于时钟 */
			function setLights(){
				var sx=Math.cos(slightDir)*slightr;
				var sy=Math.sin(slightDir)*slightr;
				var mx=Math.cos(mlightDir)*mlightr;
				var my=Math.sin(mlightDir)*mlightr;
				var hx=Math.cos(hlightDir)*hlightr;
				var hy=Math.sin(hlightDir)*hlightr;
				//sconDiv.filters.Light.clear();
				//sconDiv.filters.Light.addCone(sx+72,sy+72,1,73,72,215,255,5,20,1);
				//sconDiv.filters.Light.addCone(mx+72,my+72,1,73,72,255,10,0,20,2);
				//sconDiv.filters.Light.addCone(hx+72,hy+72,1,73,72,15,100,255,20,4);
				//sconDiv.filters.Light.addAmbient(155,155,155,100);
			}
			
			function timeGo(){
				var servertime=parent.Banner.document.getElementById("starttime").value;
			//	alert(servertime);
				
				var tt=new Date(servertime);
				var alltime=parent.Banner.document.getElementById("TxtSecond").value;
				tt.setMilliseconds(alltime*1000)
				
				slightDir=(tt.getSeconds())/60*6.28-1.57;
				mlightDir=(tt.getMinutes())/60*6.28-1.57;
				hlightDir=(tt.getHours())/12*6.28-1.57+mlightDir/6.28*0.52+0.05;
				//dateDiv.innerText=tt.getMonth()+1+"-"+tt.getDate();
				setLights();
				/*生成星期并显示日期
				var myday=""
				if(tt.getDay()==1){myday="星期一"};
				if(tt.getDay()==2){myday="星期二"};
				if(tt.getDay()==3){myday="星期三"};
				if(tt.getDay()==4){myday="星期四"};
				if(tt.getDay()==5){myday="星期五"};
				if(tt.getDay()==6){myday="星期六"};
				if(tt.getDay()==0){myday="星期日"};*/
				//dateDiv.innerText=tt.getFullYear()+"-"+(tt.getMonth()+1)+"-"+tt.getDate()+" "+ myday;				
				
			}

			function InitClock(){
				slightr=110;
				mlightr=90;
				hlightr=60;
				//timeGo();
				//setInterval("timeGo()",1000);
			}
						
		/*以下代码用于统计在线时长 ;*/
			function StartDate()
				 {
					var sec=0;
					var min=0;
					var hou=0;
					var alltime=parent.Banner.document.getElementById("TxtSecond").value;
					sec=alltime % 60 ;
					min=getint((alltime % 3600),60) ;
					hou=getint(alltime,3600) ;
					document.getElementById("Message").value=hou+"时"+min+"分"+sec+"秒" ;
					document.getElementById("Message").disabled=false ;
					window.setTimeout("StartDate();",1000); 
				  }
		/*1秒后启动时钟及在线计时*/

			//window.setTimeout("InitClock()",1000);
			window.setTimeout("StartDate()",1000);
			
		</SCRIPT>
		<LINK href="../../Style/BasicLayout.css " type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 75%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">消息中心</td>
				</tr>
				<tr style="HEIGHT: 100px">
					<td style="WIDTH: 100%" align="center" colSpan="6">
						<marquee id="affiche" align="left" direction="up" width="100%" hspace="10" vspace="10" loop="-1"
							scrollamount="1" scrolldelay="100" onMouseOut="this.start()" onMouseOver="this.stop()">
							<div id="MessageDiv" runat="server"></div>
						</marquee>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体">提醒事物</FONT></td>
				</tr>
				<tr style="  HEIGHT: 100px" id="bodyInfo">
					<td style="WIDTH: 20%" align="center" colSpan="6">
						<div id="RemindAffair" runat="server"><FONT face="宋体"></FONT></div>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px" id="AnnexInfo">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="宋体">
							<asp:label id="Label1" runat="server" Width="64px" Height="8px">操作人员：</asp:label>
							<asp:label id="LblUserName" runat="server" Width="56px" Height="2px" CssClass="MessageLabel"
								ForeColor="Blue"></asp:label>
							<asp:label id="Label3" runat="server" Width="64px" Height="8px">角色类型：</asp:label>
							<asp:label id="LblRoleName" runat="server" Width="88px" Height="2px" CssClass="MessageLabel"
								ForeColor="Blue"></asp:label><asp:label id="Label4" runat="server" Width="64px" Height="10px">在线人数：</asp:label><asp:label id="LblUserNumber" runat="server" Width="60px" Height="2px" CssClass="MessageLabel"
								ForeColor="Blue"></asp:label><asp:label id="Label5" runat="server" Width="64px" Height="2px">在线时间：</asp:label><asp:textbox id="Message" runat="server" BackColor="#F2FBED" BorderStyle="None" Width="104px"
								Height="16px" CssClass="MessageLabel" ReadOnly="True" ForeColor="Blue" Enabled="False">0时0分0秒</asp:textbox></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
