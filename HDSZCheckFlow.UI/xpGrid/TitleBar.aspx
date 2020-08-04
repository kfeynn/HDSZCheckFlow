<%@ Page AutoEventWireup="false" Inherits="XpGridFrame.Menu.HeaderMenu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:v>
	<HEAD>
		<title>xpGrid 系统管理</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Style.css" type="text/css" rel="stylesheet">
		<script>
		function barClick()
		{
			window.parent.contents.location.href='<%=PageName%>.aspx?FunID='+arguments[0];
		}
		 function Td_Over(Element1){
			Element1.className = 'TdOver';
		 }
		 function Td_Out(obj)
		 {
			obj.className = 'TdOut';
		 }
		 function Td_Down(obj)
		 {
			obj.className = 'TdDown';
		 }
		</script>
	</HEAD>
	<body leftmargin="0" rightmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<table class="FrameTable" align="center" height="128" cellpadding="7" cellspacing="0" border="0"
				width="730" style="WIDTH: 730px; HEIGHT: 128px">
				<tr width="100%" valign="top" id="titleBar">
					<td colspan="2" align="center" valign="middle" style="FONT-SIZE:30px;COLOR:blue;HEIGHT:53px;text-shadow:0px 0px 20px yellow, 0px 0px 10px orange, red 5px -5px">
						<b>XpGrid 系统管理</b>
					</td>
				</tr>
				<tr valign="top">
					<td width="40" style="WIDTH: 40px">
						<table>
							<tr>
								<td>
									<DIV id="HideLogo"><IMG title="隐藏标题" onclick="hidelogo();" alt="" src="Images/up.gif" width="16" cursor="hand"></DIV>
									<DIV id="ShowLogo" style="DISPLAY: none"><IMG title="显示标题" onclick="showlogo();" alt="" src="Images/down.gif" width="16" cursor="hand"></DIV>
								</td>
								<td>
									<DIV id="HideGuid"><IMG title="隐藏导航条" onclick="hidetoc();" alt="" src="Images/left.gif" cursor="hand"></DIV>
									<DIV id="ShowGuid" style="DISPLAY: none"><IMG title="显示导航条" onclick="showtoc();" src="Images/right.gif" cursor="hand"></DIV>
								</td>
							</tr>
						</table>
					</td>
					<td height="25" align="left" valign="top">
						<div id="HeadBar" runat="server"><FONT face="宋体"></FONT></div>
					</td>
				</tr>
			</table>
			<script language="javascript">
<!--
function hidelogo()
  {
  parent.document.all.tags('FRAMESET')[0].setAttribute('rows','38,*');
  titleBar.style.display = "none";
  HideLogo.style.display = "none";
  ShowLogo.style.display = "";
  }

function showlogo()
  {
  parent.document.all.tags('FRAMESET')[0].setAttribute('rows','125,*');
  titleBar.style.display = "";
  HideLogo.style.display = "";
  ShowLogo.style.display = "none";
  }

// 对于菜单的控制
var strColumns_Current = "141,25,*";

function hidetoc()
  {
  strColumns_Current = parent.document.all.tags('FRAMESET')[1].getAttribute('cols');
  parent.document.all.tags('FRAMESET')[1].setAttribute('cols','1,*');
  HideGuid.style.display = "none";
  ShowGuid.style.display = "";
  }

function showtoc()
  {
  parent.document.all.tags('FRAMESET')[1].setAttribute('cols',"141,*");
  HideGuid.style.display = "";
  ShowGuid.style.display = "none";
  }
function exitSystem()
{
	if(confirm("确定要退出系统吗？"))
	{
		parent.document.location.href = "LogOut.aspx";
	}
}
//-->
			</script>
		</form>
	</body>
</HTML>
