<%@ Page language="c#" Codebehind="SmallFixedAssets.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssets"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>小额固定资产管理页</title>
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
					<td style="BORDER-BOTTOM: 0px solid; BORDER-LEFT: 0px solid; WIDTH: 56px; BORDER-TOP: 0px solid; BORDER-RIGHT: 0px solid"
						height="6"></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td colSpan="8" align="center"><FONT face="宋体">
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="WIDTH: 86px; HEIGHT: 23px">编&nbsp;&nbsp;&nbsp; 码</TD>
									<TD style="WIDTH: 176px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtInv" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 116px; HEIGHT: 23px">类型分类</TD>
									<TD style="WIDTH: 156px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlType" runat="server" Width="120px"></asp:dropdownlist></TD>
									<TD style="Z-INDEX: 0; WIDTH: 154px; HEIGHT: 23px" align="center">
										管理编码</TD>
									<TD style="WIDTH: 193px; HEIGHT: 23px">
										<asp:textbox style="Z-INDEX: 0" id="txtManageCode" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="HEIGHT: 23px">管理部门</TD>
									<TD style="HEIGHT: 23px">
										<asp:dropdownlist style="Z-INDEX: 0" id="ddlClassDeptCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 23px"></TD>
									<TD style="HEIGHT: 23px"></TD>
								</TR>
								<TR>
									<TD style="Z-INDEX: 0; WIDTH: 86px">名&nbsp;&nbsp;&nbsp; 称</TD>
									<TD style="WIDTH: 176px"><asp:textbox style="Z-INDEX: 0" id="txtName" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 116px">订单日期</TD>
									<TD style="WIDTH: 156px"><asp:textbox style="Z-INDEX: 0" id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="120px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 154px" align="center">订单日期</TD>
									<TD style="WIDTH: 193px"><asp:textbox style="Z-INDEX: 0" id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="128px"></asp:textbox></TD>
									<TD>管理科室</TD>
									<TD>
										<asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptentCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD><asp:button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="8" align="right"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</TD>
				</TR>
				<TR style="DISPLAY: block; HEIGHT: 22px" id="bodyInfo">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" colSpan="8" align="center"><asp:datagrid id="dgApply" runat="server" Width="100%" AllowSorting="True" PageSize="20" BorderColor="#93BEE2"
							BackColor="White" AutoGenerateColumns="False">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<asp:CheckBox id="chbAll" runat="server" AutoPostBack="True"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<FONT face="宋体">
											<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="Id" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="InvManageCode" HeaderText="管理编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="invCode" SortExpression="invCode" HeaderText="品种编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="InvName" HeaderText="品种名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclasscode" HeaderText="分类"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclassname" HeaderText="分类名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="ClassDeptName" HeaderText="管理部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" HeaderText="科室"></asp:BoundColumn>
								<asp:BoundColumn DataField="managerName" HeaderText="责任人"></asp:BoundColumn>
								<asp:BoundColumn DataField="dbizdate" SortExpression="dbizdate" HeaderText="领用日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Price" HeaderText="价格"></asp:BoundColumn>
								<asp:BoundColumn DataField="CurrTypeCode_New" HeaderText="原币"></asp:BoundColumn>
								<asp:BoundColumn DataField="period" HeaderText="预计使用月"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="是否报废">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem,"IsRetire").ToString().Trim()=="0"?"否":"是"%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="RetireDate" HeaderText="报废日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="inum" HeaderText="起始数量"></asp:BoundColumn>
								<asp:BoundColumn DataField="RetireNum" HeaderText="报废数量"></asp:BoundColumn>
								<asp:BoundColumn DataField="LeftNum" HeaderText="剩余数量"></asp:BoundColumn>
								<asp:BoundColumn DataField="storage" HeaderText="存放地点"></asp:BoundColumn>
								<asp:BoundColumn DataField="ReMark" HeaderText="备注"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="8" align="left"><FONT face="宋体"></FONT><FONT face="宋体"></FONT>&nbsp;&nbsp;
						<asp:button id="btnEdit" runat="server" Text=" 编 辑 " CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnDel" runat="server" Text=" 删 除 " CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp;
						<asp:button id="btnExport" runat="server" Text=" 导 出 " CssClass="ButtonFlat"></asp:button>&nbsp;&nbsp; 
						&nbsp;&nbsp; <FONT face="宋体">
							<asp:label style="Z-INDEX: 0" id="lblMsg" runat="server" ForeColor="#ff0000">&nbsp;</asp:label></FONT></TD>
				</TR>
				<tr>
				<tr>
					<td colSpan="8">&nbsp;<asp:label id="lblID" Visible="False" Runat="server"></asp:label><asp:label id="lblInvName" Runat="server"></asp:label>
					</td>
				</tr>
				<tr>
					<TD style="WIDTH: 56px; HEIGHT: 23px" align="right">价&nbsp;&nbsp;格
					</TD>
					<TD style="WIDTH: 209px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtPrice" runat="server" Width="128px"></asp:textbox></TD>
					<TD style="Z-INDEX: 0; WIDTH: 52px; HEIGHT: 23px" align="right">币&nbsp;&nbsp;种
					</TD>
					<TD style="WIDTH: 145px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtCurrTypeCode" runat="server" Width="128px"></asp:textbox></TD>
					<TD style="Z-INDEX: 0; WIDTH: 84px; HEIGHT: 23px" align="right">预计使用月
					</TD>
					<TD style="WIDTH: 155px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtPeriod" runat="server" Width="128px"></asp:textbox></TD>
					<td align="center">管理编码</td>
					<td><asp:textbox style="Z-INDEX: 0" id="txtInvManageCode" runat="server" Width="128px"></asp:textbox></td>
				</tr>
				<tr>
					<TD style="Z-INDEX: 0; WIDTH: 56px" align="right">库存数量
					</TD>
					<TD style="WIDTH: 209px"><asp:textbox style="Z-INDEX: 0" id="txtNoutnum" runat="server" Width="128px"></asp:textbox></TD>
					<TD style="Z-INDEX: 0; WIDTH: 52px" align="right">报废日期
					</TD>
					<TD style="WIDTH: 145px"><asp:textbox style="Z-INDEX: 0" id="txtRetireDate" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
							runat="server" Width="128px" ReadOnly="True"></asp:textbox></TD>
					<TD style="Z-INDEX: 0; WIDTH: 84px" align="right">报废数量
					</TD>
					<TD style="WIDTH: 155px"><asp:textbox style="Z-INDEX: 0" id="txtRetireNum" runat="server" Width="128px"></asp:textbox></TD>
					<td></td>
				</tr>
				<tr>
					<TD style="Z-INDEX: 0; WIDTH: 56px" align="right">报废备注
					</TD>
					<TD style="WIDTH: 209px"><asp:textbox style="Z-INDEX: 0" id="txtReMark" runat="server" Width="128px"></asp:textbox></TD>
					<td style="WIDTH: 52px" align="right">部门</td>
					<td style="WIDTH: 145px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptClassCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="WIDTH: 84px" align="right">科组</td>
					<td style="WIDTH: 155px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></td>
					<td>&nbsp;</td>
					<TD style="WIDTH: 383px" align="center"><asp:button style="Z-INDEX: 0" id="btnSubmit" runat="server" Width="72px" Text="提交" CssClass="redButtonCss"></asp:button></TD>
				</tr>
				</tr></table>
			<INPUT style="Z-INDEX: 104; POSITION: absolute; TOP: 592px; LEFT: 1192px" id="pagesIndex"
				value="0" type="hidden" name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 103; POSITION: absolute; TOP: 528px; LEFT: 1192px" id="HerdSort"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 504px; LEFT: 1208px" id="linkToPage"
				runat="server"></asp:linkbutton><INPUT style="Z-INDEX: 105; POSITION: absolute; TOP: 560px; LEFT: 1192px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server">
		</form>
	</body>
</HTML>
