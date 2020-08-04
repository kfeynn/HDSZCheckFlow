<%@ Page language="c#" Codebehind="SmallFixedAssetsFlag.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssetsFlag"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Style/BasicLayout.css">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<LINK rel="stylesheet" type="text/css" href="../../AppSystem/common.css">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				id="tabDispDocument" class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3">
				<tr>
					<td style="BORDER-BOTTOM: 0px solid; BORDER-LEFT: 0px solid; BORDER-TOP: 0px solid; BORDER-RIGHT: 0px solid"
						height="6"></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td colSpan="6" align="center"><FONT face="宋体">
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="WIDTH: 86px; HEIGHT: 23px">编&nbsp;&nbsp;&nbsp; 码</TD>
									<TD style="WIDTH: 176px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtInv" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 116px; HEIGHT: 23px">类型分类</TD>
									<TD style="WIDTH: 156px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlType" runat="server" Width="120px"></asp:dropdownlist></TD>
									<TD style="Z-INDEX: 0; WIDTH: 154px; HEIGHT: 23px" align="center">部&nbsp;&nbsp;&nbsp; 
										门</TD>
									<TD style="WIDTH: 193px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptClass" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 23px"></TD>
									<TD style="HEIGHT: 23px"></TD>
								</TR>
								<TR>
									<TD style="Z-INDEX: 0; WIDTH: 86px">名&nbsp;&nbsp;&nbsp; 称</TD>
									<TD style="WIDTH: 176px">
										<asp:TextBox style="Z-INDEX: 0" id="txtName" runat="server" Width="128px"></asp:TextBox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 116px">订单日期</TD>
									<TD style="WIDTH: 156px">
										<asp:TextBox style="Z-INDEX: 0" id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="120px"></asp:TextBox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 154px" align="center">订单日期</TD>
									<TD style="WIDTH: 193px">
										<asp:TextBox style="Z-INDEX: 0" id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="128px"></asp:TextBox></TD>
									<TD>
										<asp:button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="6" align="right"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</TD>
				</TR>
				<TR style="DISPLAY: block; HEIGHT: 22px" id="bodyInfo">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" colSpan="6" align="center">
						<asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:Button id="btnMark" runat="server" Text=" 取 消 " CssClass="ButtonFlat" CommandName="ReMark"></asp:Button>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
									DataTextField="invCode" HeaderText="品种编码"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="InvName" HeaderText="品种名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclasscode" HeaderText="分类"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclassname" HeaderText="分类名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="nc_deptname" HeaderText="部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="dbizdate" HeaderText="领用日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="noutnum" HeaderText="数量" DataFormatString="{0:N2}"></asp:BoundColumn>
								<asp:BoundColumn DataField="rmbprice" HeaderText="rmb价格"></asp:BoundColumn>
								<asp:BoundColumn DataField="currtypecode" HeaderText="原币"></asp:BoundColumn>
								<asp:BoundColumn DataField="Originalcurprice" HeaderText="原价格"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="6" align="left"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
							<asp:checkbox id="chbSelectAll" runat="server" AutoPostBack="True" Text="全选"></asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" Text="批量取消" CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:label id="Label4" runat="server"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT>
					</TD>
				</TR> <!--<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><FONT face="宋体"></FONT></td>
				</tr>--></table>
			<INPUT style="Z-INDEX: 104; POSITION: absolute; TOP: 456px; LEFT: 656px" id="pagesIndex"
				value="0" type="hidden" name="Hidden1" runat="server"><INPUT style="Z-INDEX: 103; POSITION: absolute; TOP: 456px; LEFT: 200px" id="HerdSort"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px" id="linkToPage"
				runat="server"></asp:linkbutton><INPUT style="Z-INDEX: 105; POSITION: absolute; TOP: 456px; LEFT: 424px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server"></form>
	</body>
</HTML>
