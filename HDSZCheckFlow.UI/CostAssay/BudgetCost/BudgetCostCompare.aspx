<%@ Page language="c#" Codebehind="BudgetCostCompare.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCostCompare" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetCostCompare</title>
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
			<FONT face="����">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<TR>
						<TD>Ԥʵ������ѯ��&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>���:
									</TD>
									<TD>
										<asp:TextBox id="txtYear"  runat="server" Width="88px" onfocus="WdatePicker({dateFmt:'yyyy'})"></asp:TextBox></TD>
									<TD>����:</TD>
									<TD>
										<asp:DropDownList id="ddlQuarter" runat="server">
											<asp:ListItem Value=""></asp:ListItem>
											<asp:ListItem Value="1">һ����</asp:ListItem>
											<asp:ListItem Value="2">������</asp:ListItem>
											<asp:ListItem Value="3">������</asp:ListItem>
											<asp:ListItem Value="4">�ļ���</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>����:</TD>
									<TD>
										<asp:DropDownList id="ddlType" runat="server">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="0">��������ϸ</asp:ListItem>
											<asp:ListItem Value="1">��ʾ��Ԥ���Ŀ��ϸ</asp:ListItem>
											<asp:ListItem Value="2">��ʾѡ�в���������ϸ</asp:ListItem>
											<asp:ListItem Value="3">��ʾѡ�в��ų�Ԥ���Ŀ��ϸ</asp:ListItem>
											<asp:ListItem Value="4">��ʾ���Ż���</asp:ListItem>
											<asp:ListItem Value="5">��ʾ��˾����</asp:ListItem>
										</asp:DropDownList></TD>
									<TD>����:&nbsp;</TD>
									<TD>
										<asp:DropDownList id="ddlDept" runat="server"></asp:DropDownList></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnButton" runat="server" Width="72px" Text="��ѯ"></asp:Button></TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="DataGrid1" runat="server" Width="100%">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
