<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.DatePicker" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ÈÕÆÚÑ¡Ôñ</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
<!--
	function CloseWindow()
	{
		var nClose =<%=nClose%>;
		if (nClose ==1 ) 
		{
			window.returnValue="<%=sReturnDate%>";
			window.close();
			//alert(window.returnValue);
		}
	}
//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout" onload="CloseWindow()">
		<form id="DatePicker" method="post" runat="server">
			<asp:Calendar id="cldPicker" runat="server" BackColor="White" Width="100%" ForeColor="Black" Height="100%" Font-Size="9pt" Font-Names="Verdana" BorderColor="Black" BorderStyle="Solid" NextPrevFormat="ShortMonth" CellSpacing="1">
				<TodayDayStyle ForeColor="White" BackColor="#999999"></TodayDayStyle>
				<DayStyle BackColor="#CCCCCC"></DayStyle>
				<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White"></NextPrevStyle>
				<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" ForeColor="#333333"></DayHeaderStyle>
				<SelectedDayStyle ForeColor="White" BackColor="#333399"></SelectedDayStyle>
				<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="#333399"></TitleStyle>
				<OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
			</asp:Calendar>
		</form>
	</body>
</HTML>
