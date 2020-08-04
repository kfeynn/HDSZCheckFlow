<%@ Page AutoEventWireup="false" Inherits="XpGridFrame.Reports.ReportView" %>
<%@ Register TagPrefix="uc1" TagName="ParamInput" Src="ParamInput.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>xpGrid报表系统</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="grdRptList" runat="server" AutoGenerateColumns="False" BorderWidth="1px" BorderColor="#3366CC"
				BorderStyle="None" BackColor="White" CellPadding="4" HorizontalAlign="Center" Width="80%">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="执行" CommandName="Select">
						<HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
					</asp:ButtonColumn>
					<asp:BoundColumn DataField="Rpt_Name" HeaderText="报表名称">
						<HeaderStyle Width="80%"></HeaderStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:Panel id="pnlParamInput" runat="server">
				<DIV align="center">
					<UC1:PARAMINPUT id="uclParamInput" runat="server"></UC1:PARAMINPUT></DIV>
				<BR>
				<DIV align="center">
					<asp:Button id="btnOk" runat="server" Text="确  定"></asp:Button>&nbsp; <INPUT onclick="window.history.back();" type="button" value="返  回"></DIV>
			</asp:Panel>
		</form>
	</body>
</HTML>
