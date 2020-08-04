<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="AddAssetApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.CheckFlow.AddAssetApply"  enableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddAssetApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style/Style.css">
		<script language="javascript">
		function ShowUserName(useCode)
		{
			//获取姓名
			var userName=HDSZCheckFlow.UI.Asset.CheckFlow.AddAssetApply.GetUserNameByCode(useCode.value);
			if(userName.length==0)
			{}
			else
			{
				document.getElementById("lblName").innerText=userName.value;
			}
		}
		function showDisplay(type)
		{
			//展开收起显示区域
			if(document.all(type).style.display=='none')
			{
				document.all(type).style.display='block';
			}
			else
			{
				document.all(type).style.display='none';
			}
		} 
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblToolBar" border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080"
				align="center">
				<tr>
					<td class="tdButtonBar">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="90%">新营审批单：<asp:label id="lbMsg" runat="server" ForeColor="Red"></asp:label></td>
								<TD style="PADDING-RIGHT: 5px" width="10%" align="right"></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--导航工具条结束-->
			<table style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td height="5" align="center"><asp:button style="Z-INDEX: 0" id="btnInBudget" runat="server" CssClass="ButtonFlat" Text="预算内提交"></asp:button><FONT face="宋体">&nbsp;&nbsp;&nbsp;
						</FONT>
						<asp:button style="Z-INDEX: 0" id="btnOutBudget" runat="server" CssClass="ButtonFlat" Text="预算外提交"></asp:button></td>
				</tr>
			</table>
			<!--查询条件开始-->
			<table id="tblSearch" class="TableSearch2" border="0" cellSpacing="1" cellPadding="0" width="100%"
				align="center">
				<tr>
					<td width="8%" align="right">类&nbsp;&nbsp;&nbsp;&nbsp;型：</td>
					<td width="15%"><asp:dropdownlist id="ddlType" runat="server" Enabled="False" Width="98%"></asp:dropdownlist></td>
					<td width="8%" align="right">申请日期：</td>
					<td width="15%"><asp:textbox id="tbApplyDate" onfocus="WdatePicker({minDate:'%y-%M-{01}'})" runat="server" Enabled="False"
							Width="98%"></asp:textbox></td>
					<td style="PADDING-LEFT: 3px" width="8%" align="left">申请部门：</td>
					<td width="15%"><asp:dropdownlist id="ddlClassDept" runat="server" Enabled="False" Width="98%" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="PADDING-LEFT: 3px" width="8%" align="left">申请科组：</td>
					<td colSpan="2"><asp:dropdownlist id="ddlDept" runat="server" Width="98%" AutoPostBack="True"></asp:dropdownlist></td>
					<td align="right"><FONT face="宋体"></FONT></td>
				</tr>
				<tr>
					<td align="right">项目类别：</td>
					<td><asp:dropdownlist id="ddlFirstSubject" runat="server" Enabled="False" Width="98%" AutoPostBack="True"></asp:dropdownlist></td>
					<td align="right"><!--申请科目：--><FONT face="宋体" style="Z-INDEX: 0">交货日期：</FONT></td>
					<td><FONT face="宋体"><asp:textbox id="tbDeliveryDate" onfocus=" WdatePicker()" runat="server" Enabled="False" Width="98%"
								style="Z-INDEX: 0"></asp:textbox></FONT></td>
					<td><FONT face="宋体"></FONT></td>
					<td><FONT face="宋体"></FONT></td>
					<td style="PADDING-LEFT: 3px" width="90" align="left"><FONT face="宋体">申 请 人：</FONT></td>
					<td><FONT color="#336666" face="宋体"><asp:textbox id="tbPerson" onkeyup="javascript:ShowUserName(this)" runat="server" Enabled="False"
								Width="100px"></asp:textbox><asp:label id="lblName" runat="server"></asp:label></FONT></td>
					<td><FONT color="#336666" face="宋体"></FONT></td>
					<td></td>
				</tr>
				<tr>
					<td align="right" rowspan="2"><FONT face="宋体">理由及效果(中文)：</FONT></td>
					<td colspan="3" rowspan="2"><FONT face="宋体"><asp:TextBox style="Z-INDEX: 0" id="tbReasonForAsset" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox></FONT></td>
					<td style="PADDING-LEFT: 3px" colSpan="2"><FONT color="#336666" face="宋体">单 据 号：
							<asp:label style="Z-INDEX: 0" id="lblApplyNo" runat="server" Width="64px"></asp:label></FONT></td>
					<td style="PADDING-LEFT: 3px"><FONT color="#336666" face="宋体">制单日期：</FONT></td>
					<td colSpan="3"><FONT color="#336666" face="宋体"><asp:label style="Z-INDEX: 0" id="lblMakeDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr height="25">
					<td><FONT color="#336666" face="宋体"></FONT></td>
					<td align="right"><FONT style="MARGIN-RIGHT: 15px" face="宋体"><asp:button id="btnAdd" runat="server" CssClass="inputbutton" Text="添  加"></asp:button></FONT></td>
					<td align="center"><FONT face="宋体"><asp:button id="btnEdit" runat="server" CssClass="inputbutton" Text="修  改" Visible="False"></asp:button></FONT></td>
					<td><FONT style="MARGIN-LEFT: 15px" face="宋体"><asp:button id="btnSave" runat="server" CssClass="inputbutton" Text="保  存"></asp:button></FONT></td>
					<td><FONT face="宋体"></FONT></td>
					<td><FONT color="#336666" face="宋体"></FONT></td>
				</tr>
				<TR>
					<TD align="right"><FONT face="宋体" style="Z-INDEX: 0"><FONT face="宋体">理由及效果</FONT>(日文)：</FONT></TD>
					<TD colSpan="3">
						<asp:TextBox style="Z-INDEX: 0" id="tbEffect" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox></TD>
					<TD></TD>
					<TD align="right"></TD>
					<TD align="center"></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<td style="MARGIN-TOP: 5px; MARGIN-botton: 5px" colSpan="10" align="center"><asp:panel id="PBudgetInfo" runat="server" Visible="False">
							<TABLE border="0" cellSpacing="0" cellPadding="0" width="80%">
								<TR style="COLOR: #339966">
									<TD style="HEIGHT: 19px">
										<asp:label id="lbBudget" runat="server">预算金额</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbOutMoney" runat="server">预算外金额</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbSumCheck" runat="server">已经使用</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbready" runat="server">待摊金额</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbSheetMoney" runat="server">本次使用</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbLeft" runat="server">剩   余</asp:label></TD>
								</TR>
								<TR style="COLOR: #333333">
									<TD>
										<asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblOutMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblSumCheck" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblready" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblSheetMoney" runat="server" Visible="False"></asp:label></TD>
									<TD>
										<asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</TR>
			</table>
			<!--XPGrid 单据添加表体-->
			<p style="MARGIN-TOP: 8px"><asp:panel style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px"
					id="pAddItem" runat="server" Visible="False">
					<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080" align="center">
						<TR>
							<TD class="tdButtonBar">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD width="100%">添加单据明细：</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="aliceblue">
									<TR>
										<TD style="PADDING-RIGHT: 5px" align="right"><A style="CURSOR: hand" onclick="javascript:showDisplay('tbAddBody')" href="#"><FONT color="#003300">收起/展开</FONT></A>
										</TD>
									</TR>
									<TR id="tbAddBody">
										<TD>
											<TABLE style="LINE-HEIGHT: 15px" class="TableSearch2" border="0" cellSpacing="1" cellPadding="0"
												width="100%" align="center">
												<TR>
													<TD width="8%" align="right">项目内容：</TD>
													<TD width="38%" colSpan="3">
														<asp:dropdownlist id="ddlSubjectCode" runat="server" Width="98%"></asp:dropdownlist></TD>
													<TD width="8%" align="right">物品名称：</TD>
													<TD width="15%">
														<asp:textbox id="tbInvName" runat="server" Width="98%"></asp:textbox></TD>
													<TD style="PADDING-LEFT: 3px" width="8%" align="left">规格型号：</TD>
													<TD width="20%" colSpan="2">
														<asp:textbox style="Z-INDEX: 0" id="tbInvType" onkeyup="javascript:ShowUserName(this)" runat="server"
															Width="98%"></asp:textbox></TD>
													<TD style="PADDING-LEFT: 3px" width="8%" align="left"></TD>
												</TR>
												<TR>
													<TD align="right">数&nbsp;&nbsp;&nbsp; 量：</TD>
													<TD width="15%">
														<asp:textbox style="Z-INDEX: 0" id="tbNumber" runat="server" Width="98%"></asp:textbox></TD>
													<TD width="8%" align="right"><!--申请科目：--> 单&nbsp;&nbsp;&nbsp; 价：</TD>
													<TD width="15%"><FONT face="宋体">
															<asp:textbox style="Z-INDEX: 0" id="tbOriginalcurrPrice" runat="server" Width="98%"></asp:textbox></FONT></TD>
													<TD style="Z-INDEX: 0" align="right">单&nbsp;&nbsp;&nbsp; 位：</TD>
													<TD><FONT face="宋体">
															<asp:dropdownlist style="Z-INDEX: 0" id="ddlUnit" runat="server" Width="98%"></asp:dropdownlist></FONT></TD>
													<TD style="PADDING-LEFT: 3px" width="90" align="left"><FONT style="Z-INDEX: 0" face="宋体">币&nbsp;&nbsp;&nbsp; 
															种：</FONT></TD>
													<TD><FONT color="#336666" face="宋体">
															<asp:dropdownlist style="Z-INDEX: 0" id="ddlcurrTypeCode" runat="server" Width="98%"></asp:dropdownlist></FONT></TD>
													<TD><FONT color="#336666" face="宋体"></FONT></TD>
													<TD></TD>
												</TR>
												<TR height="25">
													<TD style="PADDING-LEFT: 3px" colSpan="2"><FONT face="宋体"></FONT><FONT face="宋体">
															<asp:hyperlink style="Z-INDEX: 0" id="hyLindToAnnex" runat="server" ForeColor="Red" Visible="False"
																Font-Bold="True" Font-Size="14px" Font-Underline="True">添加附件</asp:hyperlink></FONT></TD>
													<TD align="right"><FONT face="宋体"></FONT></TD>
													<TD><FONT face="宋体"></FONT></TD>
													<TD><FONT color="#336666" face="宋体"></FONT></TD>
													<TD align="right"><FONT style="MARGIN-RIGHT: 15px" face="宋体"></FONT></TD>
													<TD align="center"><FONT face="宋体">
															<asp:button style="Z-INDEX: 0" id="btnAddBody" runat="server" Text="添  加" CssClass="inputbutton"></asp:button></FONT></TD>
													<TD><FONT style="MARGIN-LEFT: 15px" face="宋体">
															<asp:button id="btnCancel" runat="server" Text="取  消" CssClass="inputbutton"></asp:button></FONT></TD>
													<TD><FONT face="宋体"></FONT></TD>
													<TD><FONT color="#336666" face="宋体"></FONT></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD bgColor="infobackground" width="100%"><FONT face="宋体">
									<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApply" runat="server" Width="99%" Visible="False"
										AutoGenerateColumns="False" AllowSorting="True" PageSize="20" BorderColor="#93BEE2" BackColor="White">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<FONT face="宋体">
														<asp:Button id="btnDelete" runat="server" Text="删除" CssClass="ButtonFlat" Width="50px" CommandName="delete"></asp:Button></FONT>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="SubjectName" HeaderText="项目名称"></asp:BoundColumn>
											<asp:BoundColumn DataField="InventoryName" HeaderText="物品名称"></asp:BoundColumn>
											<asp:BoundColumn DataField="InvType" HeaderText="规格型号"></asp:BoundColumn>
											<asp:BoundColumn DataField="unitName" HeaderText="单位"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="数量"></asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalMoney" HeaderText="原币金额"></asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="基准汇率"></asp:BoundColumn>
											<asp:BoundColumn DataField="RmbPrice" HeaderText="本币单价"></asp:BoundColumn>
											<asp:BoundColumn DataField="RmbMoney" HeaderText="本币金额"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
									</asp:datagrid></FONT></TD>
						</TR>
					</TABLE>
					<FONT face="宋体"><INPUT style="Z-INDEX: 0" id="hideApplyHead" value="0" type="hidden" name="Hidden1" runat="server"></FONT>
					<INPUT style="Z-INDEX: 0" id="HiddenLeft" value="0" type="hidden" name="Hidden1" runat="server">
				</asp:panel></p>
		</form>
	</body>
</HTML>
