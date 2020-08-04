<%@ Page language="c#" Codebehind="RealCostAndExplanation.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.RealCostAndExplanation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>部门实算摘要查询</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<script type="text/javascript">
			function toExcel() { 
			
				window.clipboardData.setData("Text",document.all("tab").outerHTML);
				try
				{
				var ExApp = new ActiveXObject("Excel.Application")
				var ExWBk = ExApp.workbooks.add()
				var ExWSh = ExWBk.worksheets(1)
				ExApp.DisplayAlerts = false
				ExApp.visible = true
				}  
				catch(e)
				{
				alert("您的电脑没有安装Microsoft Excel软件！")
				return false
				} 
				ExWBk.worksheets(1).Paste;	
			}

		</script>
		<style>
			#tab { BORDER-RIGHT: #4785c2 2px solid; WIDTH: 100%; BORDER-BOTTOM: #4785c2 2px solid }
			#tab TR TD { BORDER-RIGHT: #4785c2 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #4785c2 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; BORDER-LEFT: #4785c2 1px solid; PADDING-TOP: 5px; BORDER-BOTTOM: #4785c2 1px solid }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT>
			<asp:label id="Label1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 24px" runat="server">部门实算年度查询</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 104px"
				runat="server" Height="80px" Width="100%">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
			</asp:datagrid>
			<TABLE id="Table1" style="Z-INDEX: 102; LEFT: 32px; WIDTH: 848px; POSITION: absolute; TOP: 48px; HEIGHT: 40px"
				cellSpacing="1" cellPadding="1" width="848" border="0">
				<TR>
					<TD><FONT face="宋体">输入查询年份：</FONT></TD>
					<TD><asp:textbox id="txtDate" Width="90" class="Wdate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年MM月'})"
							runat="server"></asp:textbox></TD>
					<TD><FONT face="宋体">部门</FONT></TD>
					<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
					<TD><asp:button id="btnQuery" runat="server" Width="64px" Text="查询" CssClass="inputbutton"></asp:button></TD>
					<TD><asp:label id="lblMessage" runat="server" Width="113px"></asp:label>
						<asp:Button id="Button1" runat="server" Width="84px" CssClass="inputbutton" Text="导出" Visible="False"></asp:Button>
						<a href="#" onclick="toExcel()" style="PADDING-RIGHT: 3px; PADDING-LEFT: 3px; PADDING-BOTTOM: 3px; VERTICAL-ALIGN: baseline; COLOR: #ffffff; PADDING-TOP: 3px; BACKGROUND-COLOR: #6699cc; TEXT-ALIGN: center">
							导出Excle</a>
						<asp:Button id="btnOutPrint" runat="server" Width="81px" CssClass="inputbutton" Text="打印" Visible="False"></asp:Button></TD>
				</TR>
			</TABLE>
			<div style="Z-INDEX: 101; LEFT: 32px; WIDTH: 100%; POSITION: absolute; TOP: 84px">
				<table id="tab" border="1" cellpadding="0" cellspacing="0" width="850">
					<asp:Repeater ID="repDataBind" Runat="server">
						<HeaderTemplate>
							<tr align="center" bgcolor="#dabf9d">
								<td style="width=80px;">科目名称</td>
								<td>实算金额</td>
								<td>摘要信息</td>
							</tr>
						</HeaderTemplate>
						<ItemTemplate>
							<tr style="TEXT-ALIGN: left">
								<td><%# DataBinder.Eval(Container.DataItem, "科目名称") %></td>
								<td><%# DataBinder.Eval(Container.DataItem, "实算金额") %></td>
								<td><%# DataBinder.Eval(Container.DataItem, "摘要信息") %></td>
							</tr>
						</ItemTemplate>
						<FooterTemplate>
						</FooterTemplate>
					</asp:Repeater>
				</table>
			</div>
		</form>
	</body>
</HTML>
