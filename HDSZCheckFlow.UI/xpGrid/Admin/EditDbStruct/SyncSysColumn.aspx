<%@ Page AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.SyncSysColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SyncSysColumn</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>
						<asp:RadioButtonList id="rbType" runat="server" RepeatColumns="1" AutoPostBack="True">
							<asp:ListItem Value="1" Selected="True">��ѯ�����ӻ�δ��ϵͳ�����ֵ��еǼǵ��ֶ�</asp:ListItem>
							<asp:ListItem Value="2">��ѯʵ����ɾ�����������ֵ��л����ڵ��ֶ�</asp:ListItem>
							<asp:ListItem Value="3">��ѯ�������ͱ仯������ֶ�</asp:ListItem>
						</asp:RadioButtonList></td>
					<td><asp:Button id="btnImport" runat="server" CssClass="InputButton" Text="���뵽ϵͳ�����ֵ�"></asp:Button></td>
				</tr>
			</table>
			<br>
			<asp:DataGrid id="grdList" runat="server" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
				BackColor="White" CellPadding="4">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
