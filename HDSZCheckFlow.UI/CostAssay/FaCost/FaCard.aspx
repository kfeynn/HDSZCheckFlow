<%@ Page language="c#" Codebehind="FaCard.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.FaCost.FaCard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FaCard</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR height="35">
					<TD style="WIDTH: 45px"></TD>
					<TD style="WIDTH: 103px">
						<asp:Label id="Label1" runat="server" ForeColor="Navy" Font-Size="Larger">固定资产折旧</asp:Label></TD>
					<TD style="WIDTH: 350px"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 45px">年月:</TD>
					<TD style="WIDTH: 103px">
						<asp:TextBox id="txtStDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})" runat="server"></asp:TextBox></TD>
					<TD>
						<asp:Button id="btnEnter" runat="server" Text="确 定" CssClass="inputbutton" Width="80px" style="Z-INDEX: 0"></asp:Button>
						<asp:Button id="btnOut" runat="server" CssClass="inputbutton" Text="导出" Width="88px" style="Z-INDEX: 0"></asp:Button>
						<asp:Label id="lblMessage" runat="server" ForeColor="Red" style="Z-INDEX: 0"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 45px"></TD>
					<TD style="WIDTH: 103px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 45px"></TD>
					<TD style="WIDTH: 103px"></TD>
					<TD></TD>
				</TR>
				<TR height="20">
					<TD style="WIDTH: 45px"></TD>
					<TD style="WIDTH: 103px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:DataGrid id="dgInvStore" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px"
							BorderStyle="None" BorderColor="#3366CC">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
							<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
