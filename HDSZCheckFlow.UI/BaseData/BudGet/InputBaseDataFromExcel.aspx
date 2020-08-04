<%@ Page language="c#" Codebehind="InputBaseDataFromExcel.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.InputBaseDataFromExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InputBaseDataFromExcel</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="80%" border="1" style="Z-INDEX: 101; POSITION: absolute; TOP: 48px; LEFT: 80px">
				<TR>
					<TD><FONT face="宋体">选择本地excel文件。先预览，确认无误后再确认入库</FONT><a href="InputBudgetExcelFormat.aspx" title="查看导入Excel格式" style="COLOR: gray">查看导入格式</a></TD>
					<TD></TD>
					<TD>
						<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px"><INPUT id="File1" style="WIDTH: 400px; HEIGHT: 21px" type="file" size="47" name="File1"
							runat="server"></TD>
					<TD style="HEIGHT: 16px">
						<asp:Button id="btnLook" runat="server" Text="预览" CssClass="InputButton"></asp:Button></TD>
					<TD style="HEIGHT: 16px">
						<asp:DropDownList id="DropDownList1" runat="server">
							<asp:ListItem Value="0" Selected="True">选择入库类型</asp:ListItem>
							<asp:ListItem Value="1">经费预算</asp:ListItem>
							<asp:ListItem Value="2">经费推算</asp:ListItem>
							<asp:ListItem Value="3">新营预算</asp:ListItem>
						</asp:DropDownList></TD>
					<TD>
						<asp:Button id="btnAdd" runat="server" Text="确认入库" CssClass="InputButton"></asp:Button></TD>
				</TR>
				<TR>
					<TD colspan="3">
						<asp:DataGrid id="dgGrid" runat="server" Width="100%" BorderColor="#CCCCCC" BorderStyle="None"
							BorderWidth="1px" BackColor="White" CellPadding="3">
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
							<ItemStyle ForeColor="#000066"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
