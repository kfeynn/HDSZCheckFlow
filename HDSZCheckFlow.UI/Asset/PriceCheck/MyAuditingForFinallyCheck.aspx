<%@ Page language="c#" Codebehind="MyAuditingForFinallyCheck.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.MyAuditingForFinallyCheck" EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MyAuditing</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 88px; LEFT: 8px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<TR>
						<TD>我的审批：
							<asp:Label id="lblMessage" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="None"
								BorderColor="#93BEE2" BackColor="White" AllowPaging="True" PageSize="20">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID" HeaderText="FinallyCheckId"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ApplySheetHeadPk"></asp:BoundColumn>
									<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../Asset/CheckFlow/AssetApplyForOneApply.aspx?applyHeadPK={0}"
										DataTextField="ApplySheetNo" HeaderText="申请单号"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="DeptName" HeaderText="申请部门"></asp:BoundColumn>
									<asp:BoundColumn DataField="ItemName" HeaderText="项目名称"></asp:BoundColumn>
									<asp:BoundColumn DataField="BargainNo" HeaderText="合同号"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DisplaysPerson" HeaderText="DisplaysCode"></asp:BoundColumn>
									<asp:BoundColumn DataField="Name" HeaderText="替谁审批"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:Button id="btnApply" runat="server" Text="进入审批" CssClass="inputbutton" CommandName="Apply"></asp:Button>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
					cellPadding="0" width="100%" border="0">
					<TR>
						<TD height="26"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px">申请部门</TD>
						<TD style="HEIGHT: 17px">
							<asp:DropDownList id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:DropDownList></TD>
						<TD style="HEIGHT: 17px">起始日期</TD>
						<TD style="HEIGHT: 17px">
							<asp:TextBox id="txtDateFromD" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
								runat="server" Width="90px" maxdate="#F{$('txtDateTo').value}"></asp:TextBox></TD>
						<TD style="HEIGHT: 17px" align="center">结束日期</TD>
						<TD style="HEIGHT: 17px">
							<asp:TextBox id="txtDateToD" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
								runat="server" Width="90px" mindate="#F{$('txtDateFrom').value}"></asp:TextBox></TD>
						<TD style="HEIGHT: 17px">单据号</TD>
						<TD style="HEIGHT: 17px">
							<asp:TextBox id="txtApplyNo" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>申请科组</TD>
						<TD><asp:DropDownList id="ddlDept" runat="server" Width="90px"></asp:DropDownList></TD>
						<TD>申请类型</TD>
						<TD><asp:DropDownList id="ddlType" runat="server" Width="90px"></asp:DropDownList></TD>
						<TD align="center">单据状态</TD>
						<TD>
							<asp:dropdownlist id="ddlApplyType" runat="server" Width="90px"></asp:dropdownlist>
						</TD>
						<TD>
						</TD>
						<TD>
							<asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss" Text="查询"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD colspan="8"><hr>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
