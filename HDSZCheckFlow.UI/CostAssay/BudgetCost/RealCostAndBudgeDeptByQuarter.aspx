<%@ Page language="c#" Codebehind="RealCostAndBudgeDeptByQuarter.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.RealCostAndBudgeDeptByQuarter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>����Ԥʵ���Ȳ�ѯ</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT>
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 24px" runat="server">����Ԥʵ���Ȳ�ѯ</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 103; LEFT: 16px; POSITION: absolute; TOP: 96px" runat="server"
				Height="80px" Width="100%">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
			</asp:datagrid>
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 32px; WIDTH: 848px; POSITION: absolute; TOP: 48px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="848" border="0">
				<TR>
					<TD><FONT face="����">�����ѯ��ݣ�</FONT></TD>
					<TD><asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy��'})" runat="server"></asp:textbox></TD>
					<TD><FONT face="����">����</FONT></TD>
					<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
					<TD><asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ" CssClass="inputbutton"></asp:button></TD>
					<TD><asp:label id="lblMessage" runat="server" Width="113px"></asp:label>
						<asp:Button id="Button1" runat="server" Width="84px" CssClass="inputbutton" Text="����" Visible="False"></asp:Button>
						<asp:Button id="btnOutPrint" runat="server" Width="81px" CssClass="inputbutton" Text="��ӡ" Visible="False"></asp:Button></TD>
				</TR>
				<tr>
					<td colspan="6"><asp:LinkButton ID="lbOneQuarter" Runat="server">����һ���ȡ�</asp:LinkButton>
						<asp:LinkButton ID="lbTwoQuarter" Runat="server">���ڶ����ȡ�</asp:LinkButton>
						<asp:LinkButton ID="lbThirdQuarter" Runat="server">���������ȡ�</asp:LinkButton>
						<asp:LinkButton ID="lbFourQuarter" Runat="server">�����ļ��ȡ�</asp:LinkButton></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
