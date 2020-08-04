<%@ Page language="c#" Codebehind="BudgetCostByClassDept.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetCostByClassDept" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetCostByClassDept</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT>
			<asp:label id="Label1" style="Z-INDEX: 108; POSITION: absolute; TOP: 8px; LEFT: 8px" runat="server">���ŷ���ϼ�Ԥʵ����</asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 109; POSITION: absolute; TOP: 88px; LEFT: 8px" runat="server"
				AutoGenerateColumns="False" Height="80px" Width="100%">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="Dispname" HeaderText="��Ŀ">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="oneQ" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="twoQ" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="oneH" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="changemoney" HeaderText="�������" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="localRealCost" HeaderText="�������" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="overspend" HeaderText="��֧���" DataFormatString="{0:N2}">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="costPY" HeaderText="ʵ/Ԥ">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<TABLE id="Table1" style="Z-INDEX: 110; POSITION: absolute; WIDTH: 848px; HEIGHT: 40px; TOP: 32px; LEFT: 8px"
				cellSpacing="1" cellPadding="1" width="848" border="0">
				<TR>
					<TD style="HEIGHT: 26px"><FONT face="����">��&nbsp;&nbsp;&nbsp; �ף�</FONT></TD>
					<TD style="HEIGHT: 26px">
						<asp:DropDownList style="Z-INDEX: 0" id="ddlAccBook" runat="server" Width="150px"></asp:DropDownList></TD>
					<TD style="HEIGHT: 26px"></TD>
					<TD style="HEIGHT: 26px"></TD>
					<TD style="HEIGHT: 26px"></TD>
					<TD style="HEIGHT: 26px"></TD>
				</TR>
				<TR>
					<TD><FONT face="����">��ѯ���£�</FONT></TD>
					<TD>
						<asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy��MM��'})" runat="server"
							Width="150px"></asp:textbox></TD>
					<TD><FONT face="����">����</FONT></TD>
					<TD>
						<asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
					<TD>
						<asp:button id="btnQuery" runat="server" Width="64px" Text="��ѯ" CssClass="inputbutton"></asp:button></TD>
					<TD>
						<asp:label id="lblMessage" runat="server" Width="117px"></asp:label>
						<asp:Button id="Button1" runat="server" Width="84px" CssClass="inputbutton" Text="����" Visible="False"></asp:Button>
						<asp:Button id="btnOutPrint" runat="server" Width="81px" CssClass="inputbutton" Text="��ӡ" Visible="False"></asp:Button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
