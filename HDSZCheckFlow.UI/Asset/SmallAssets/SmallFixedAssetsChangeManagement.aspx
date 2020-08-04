<%@ Page language="c#" Codebehind="SmallFixedAssetsChangeManagement.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssetsChangeManagement"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>小额固定资产转移信息管理</title>
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
									<TD style="WIDTH: 59px; HEIGHT: 23px">编&nbsp;&nbsp;&nbsp; 码</TD>
									<TD style="WIDTH: 147px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtInv" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 58px; HEIGHT: 23px">类型分类</TD>
									<TD style="WIDTH: 139px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlType" runat="server" Width="120px"></asp:dropdownlist></TD>
									<TD style="Z-INDEX: 0; WIDTH: 85px; HEIGHT: 23px" align="center">转移前部门</TD>
									<TD style="WIDTH: 160px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlBDeptClass" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD style="WIDTH: 98px; HEIGHT: 23px">转移后部门</TD>
									<TD style="WIDTH: 176px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlAClassDept" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="Z-INDEX: 0; WIDTH: 59px">名&nbsp;&nbsp;&nbsp; 称</TD>
									<TD style="WIDTH: 147px"><asp:textbox style="Z-INDEX: 0" id="txtName" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 58px">转移日期</TD>
									<TD style="WIDTH: 139px"><asp:textbox style="Z-INDEX: 0" id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="120px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 85px" align="center">转移日期</TD>
									<TD style="WIDTH: 160px"><asp:textbox style="Z-INDEX: 0" id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="128px"></asp:textbox></TD>
									<TD style="WIDTH: 98px">录入员工号</TD>
									<TD style="WIDTH: 176px"><asp:textbox style="Z-INDEX: 0" id="txtImporterCode" runat="server" Width="128px"></asp:textbox></TD>
									<TD><asp:button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss"
											Text="查询"></asp:button></TD>
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
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" colSpan="6" align="center"><asp:datagrid id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
							BorderColor="#93BEE2" PageSize="20" AllowSorting="True">
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
								<asp:BoundColumn DataField="InvmanageCode" HeaderText="管理编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="invCode" HeaderText="品种编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="InvName" HeaderText="品种名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclassname" HeaderText="分类名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="Bdeptclassname" HeaderText="转移前部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="BDeptName" HeaderText="科室"></asp:BoundColumn>
								<asp:BoundColumn DataField="Adeptclassname" HeaderText="转移后部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="ADeptName" HeaderText="科室"></asp:BoundColumn>
								<asp:BoundColumn DataField="dutyName" HeaderText="责任人"></asp:BoundColumn>
								<asp:BoundColumn DataField="Datetime" HeaderText="日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Name" HeaderText="录入员"></asp:BoundColumn>
								<asp:BoundColumn DataField="Remark" HeaderText="备注"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="6" align="left"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">&nbsp;&nbsp;</FONT>
						<asp:button id="btnEdit" runat="server" CssClass="ButtonFlat" Text=" 编 辑 "></asp:button>&nbsp;&nbsp;
						<asp:button id="btnDel" runat="server" CssClass="ButtonFlat" Text=" 删 除 "></asp:button>&nbsp;&nbsp;
						<asp:button id="btnExport" runat="server" CssClass="ButtonFlat" Text=" 导 出 "></asp:button>&nbsp;&nbsp;
						<asp:label style="Z-INDEX: 0" id="lblMsg" runat="server" ForeColor="#ff0000"></asp:label>
					</TD>
				</TR>
				<tr>
				<tr>
					<td colspan="7"><asp:Label Runat="server" ID="lblID" Visible="False"></asp:Label><asp:Label Runat="server" ID="lblInvName">&nbsp;</asp:Label>
					</td>
				</tr>
				<tr>
					<TD style="WIDTH: 86px; HEIGHT: 23px" align="right">
						转移前部门
					</TD>
					<TD style="WIDTH: 230px; HEIGHT: 23px">
						<asp:Label Runat="server" ID="lblBApplyDeptClassCode"></asp:Label>
					</TD>
					<TD style="Z-INDEX: 0; WIDTH: 86px; HEIGHT: 23px" align="right">
						转移后部门
					</TD>
					<TD style="WIDTH: 149px; HEIGHT: 23px">
						<asp:dropdownlist style="Z-INDEX: 0" id="ddlClassDeptCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist>
					</TD>
					<TD style="Z-INDEX: 0; WIDTH: 41px" align="right">
						日期
					</TD>
					<TD style="WIDTH: 383px">
						<asp:textbox style="Z-INDEX: 0" id="txtDatetime" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
							runat="server" Width="128px" ReadOnly="True"></asp:textbox>
					</TD>
				</tr>
				<tr>
					<TD style="Z-INDEX: 0; WIDTH: 46px" align="right">
						备注
					</TD>
					<TD style="WIDTH: 230px">
						<asp:textbox style="Z-INDEX: 0" id="txtReMark" runat="server" Width="258px"></asp:textbox>
					</TD>
					<TD style="Z-INDEX: 0; WIDTH: 86px" align="right">
						转移后科室
					</TD>
					<TD>
						<asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist>
					</TD>
					<TD colspan="2" style="WIDTH: 383px" align="center">
						<asp:button style="Z-INDEX: 0" id="btnSubmit" runat="server" Width="72px" CssClass="redButtonCss"
							Text="提交"></asp:button>
					</TD>
				</tr>
				</tr>
			</table>
			<INPUT style="Z-INDEX: 104; POSITION: absolute; TOP: 592px; LEFT: 1192px" id="pagesIndex"
				value="0" type="hidden" name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 103; POSITION: absolute; TOP: 528px; LEFT: 1192px" id="HerdSort"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 504px; LEFT: 1208px" id="linkToPage"
				runat="server"></asp:linkbutton><INPUT style="Z-INDEX: 105; POSITION: absolute; TOP: 560px; LEFT: 1192px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server">
		</form>
	</body>
</HTML>
