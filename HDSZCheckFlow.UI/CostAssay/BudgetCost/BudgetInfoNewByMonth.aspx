<%@ Page language="c#" Codebehind="BudgetInfoNewByMonth.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CostAssay.BudgetCost.BudgetInfoNewByMonth" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BudgetInfoNew</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<style type="text/css">  
	.scrollRowThead { POSITION: relative; ; LEFT: expression(this.parentElement.parentElement.parentElement.parentElement.scrollLeft) }  
	.scrollColThead { Z-INDEX: 2; POSITION: relative; ; TOP: expression(this.parentElement.parentElement.parentElement.scrollTop) }  
	.scrollCR { Z-INDEX: 3 }  
	.scrollDiv { BORDER-BOTTOM: #eeeeee 1px solid; TEXT-ALIGN: center; BORDER-LEFT: #eeeeee 1px solid; WIDTH: 100%; HEIGHT: 200px; CLEAR: both; OVERFLOW: scroll; BORDER-TOP: #eeeeee 1px solid; BORDER-RIGHT: #eeeeee 1px solid }  
	.scrollColThead TD { TEXT-ALIGN: center }  
	.scrollColThead TH { TEXT-ALIGN: center }  
	.scrollRowThead { BACKGROUND-COLOR: #eeeeee }  
	.scrollColThead TD { BACKGROUND-COLOR: #eeeeee }  
	.scrollColThead TH { BACKGROUND-COLOR: #eeeeee }  
	.scrolltable { BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT: #cccccc 1px solid }  
	.scrolltable TD { BORDER-LEFT: #cccccc 1px solid; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; PADDING-TOP: 5px }  
	.scrolltable TH { BORDER-LEFT: #cccccc 1px solid; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; PADDING-TOP: 5px }  
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="1"
					cellPadding="1" width="90%" border="0">
					<TR>
						<TD style="Z-INDEX: 0; WIDTH: 108px; HEIGHT: 25px">部门:</TD>
						<TD style="WIDTH: 157px; HEIGHT: 25px">
							<asp:DropDownList style="Z-INDEX: 0" id="ddlDept" runat="server" Width="120px"></asp:DropDownList></TD>
						<TD style="WIDTH: 66px; HEIGHT: 25px">年份:</TD>
						<TD style="WIDTH: 149px; HEIGHT: 25px">
							<asp:TextBox id="txtDate" runat="server" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年'})"
								style="Z-INDEX: 0" Width="88px"></asp:TextBox></TD>
						<TD style="HEIGHT: 25px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 108px; HEIGHT: 27px">类型:</TD>
						<TD style="WIDTH: 157px; HEIGHT: 27px">
							<asp:DropDownList id="ddlType" runat="server" Width="120px">
								<asp:ListItem Value="1001" Selected="True">预算一览表</asp:ListItem>
								<asp:ListItem Value="1002">实算一览表</asp:ListItem>
								<asp:ListItem Value="1003">预实一览表</asp:ListItem>
								<asp:ListItem Value="1004">推算一览表</asp:ListItem>
							</asp:DropDownList></TD>
						<TD style="WIDTH: 66px; HEIGHT: 27px">起始月份:</TD>
						<TD style="WIDTH: 149px; HEIGHT: 27px">
							<asp:DropDownList style="Z-INDEX: 0" id="ddlStMonth" runat="server" Width="88px">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								<asp:ListItem Value="2">2</asp:ListItem>
								<asp:ListItem Value="3">3</asp:ListItem>
								<asp:ListItem Value="4">4</asp:ListItem>
								<asp:ListItem Value="5">5</asp:ListItem>
								<asp:ListItem Value="6">6</asp:ListItem>
								<asp:ListItem Value="7">7</asp:ListItem>
								<asp:ListItem Value="8">8</asp:ListItem>
								<asp:ListItem Value="9">9</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
							</asp:DropDownList></TD>
						<TD style="HEIGHT: 27px"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 108px; HEIGHT: 29px">帐套:</TD>
						<TD style="WIDTH: 157px; HEIGHT: 29px">
							<asp:DropDownList style="Z-INDEX: 0" id="ddlAccBook" runat="server" Width="120px"></asp:DropDownList></TD>
						<TD style="WIDTH: 66px; HEIGHT: 29px">截止月份:</TD>
						<TD style="WIDTH: 149px; HEIGHT: 29px">
							<asp:DropDownList style="Z-INDEX: 0" id="ddlEdMonth" runat="server" Width="88px">
								<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
								<asp:ListItem Value="2">2</asp:ListItem>
								<asp:ListItem Value="3">3</asp:ListItem>
								<asp:ListItem Value="4">4</asp:ListItem>
								<asp:ListItem Value="5">5</asp:ListItem>
								<asp:ListItem Value="6">6</asp:ListItem>
								<asp:ListItem Value="7">7</asp:ListItem>
								<asp:ListItem Value="8">8</asp:ListItem>
								<asp:ListItem Value="9">9</asp:ListItem>
								<asp:ListItem Value="10">10</asp:ListItem>
								<asp:ListItem Value="11">11</asp:ListItem>
								<asp:ListItem Value="12">12</asp:ListItem>
							</asp:DropDownList></TD>
						<TD style="HEIGHT: 29px">
							<asp:Button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" CssClass="inputbutton"
								Text="查询"></asp:Button>
							<asp:Button style="Z-INDEX: 0" id="Button1" runat="server" Width="84px" CssClass="inputbutton"
								Text="导出"></asp:Button>
							<asp:Label style="Z-INDEX: 0" id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR>
						<TD colspan="5"></TD>
					</TR>
				</TABLE>
			</FONT>
			<div class="scrollDiv" style="Z-INDEX: 103; POSITION: absolute; WIDTH: 1168px; HEIGHT: 456px; TOP: 104px; LEFT: 0px">
				<asp:DataGrid id="dgBudgetInfo" runat="server" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
					BackColor="White" CellPadding="3" Width="205%" Height="88px">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
					<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle HorizontalAlign="Center" ForeColor="#003399" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
					<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
			</div>
		</form>
	</body>
</HTML>
