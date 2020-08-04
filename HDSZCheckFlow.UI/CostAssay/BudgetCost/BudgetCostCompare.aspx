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
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 16px; POSITION: absolute; TOP: 40px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<TR>
						<TD>预实算差异查询：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>年份:
									</TD>
									<TD>
										<asp:TextBox id="txtYear"  runat="server" Width="88px" onfocus="WdatePicker({dateFmt:'yyyy'})"></asp:TextBox></TD>
									<TD>季度:</TD>
									<TD>
										<asp:DropDownList id="ddlQuarter" runat="server">
											<asp:ListItem Value=""></asp:ListItem>
											<asp:ListItem Value="1">一季度</asp:ListItem>
											<asp:ListItem Value="2">二季度</asp:ListItem>
											<asp:ListItem Value="3">三季度</asp:ListItem>
											<asp:ListItem Value="4">四季度</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD>类型:</TD>
									<TD>
										<asp:DropDownList id="ddlType" runat="server">
											<asp:ListItem></asp:ListItem>
											<asp:ListItem Value="0">显所有明细</asp:ListItem>
											<asp:ListItem Value="1">显示超预算科目明细</asp:ListItem>
											<asp:ListItem Value="2">显示选中部门所有明细</asp:ListItem>
											<asp:ListItem Value="3">显示选中部门超预算科目明细</asp:ListItem>
											<asp:ListItem Value="4">显示部门汇总</asp:ListItem>
											<asp:ListItem Value="5">显示公司汇总</asp:ListItem>
										</asp:DropDownList></TD>
									<TD>部门:&nbsp;</TD>
									<TD>
										<asp:DropDownList id="ddlDept" runat="server"></asp:DropDownList></TD>
								</TR>
							</TABLE>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnButton" runat="server" Width="72px" Text="查询"></asp:Button></TD>
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
