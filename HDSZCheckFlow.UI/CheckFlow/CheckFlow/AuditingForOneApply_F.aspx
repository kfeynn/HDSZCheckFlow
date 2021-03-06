<%@ Page language="c#" Codebehind="AuditingForOneApply_F.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.AuditingForOneApply_F" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function showDisplay(type)
		{
			if(document.all(type).style.display=='none')
			{
				//document.all(type).style.display='block';
				
				//以下解决谷歌浏览器显示错误
				document.all(type).style.display='';   
				document.all(type).style.display='table-row';
			}
			else
			{
				document.all(type).style.display='none';
			}
		} 
		</script>
		<style type="text/css">
			 
			#txtPosital { resize: none }
			 
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">基本信息</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">单 据 号:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblSheetNo" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">审批类别:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体">
							<asp:Label id="lblBudgetType" runat="server" Width="112px"></asp:Label></FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">申请科目:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblSubject" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">申请类型:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblApplyType" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">提案部门及人员:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblDpteAndPerson" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">申请日期:</td>
					<td style="WIDTH: 30%"><FONT face="宋体"><asp:label id="lblApplyDate" runat="server"></asp:label></FONT></td>
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 10%" align="right">交货日期:</td>
					<td style="WIDTH: 12.21%"><FONT face="宋体"><asp:label id="lblDeliveryDate" runat="server"></asp:label></FONT></td>
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 10%" align="right">填单时间:</td>
					<td style="WIDTH: 20%"><FONT face="宋体"><asp:label id="lblSubmitDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">金额(RMB):</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblMoney" runat="server"></asp:label></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">预算情况</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 16px" align="right"><SPAN id="Label2">预算金额(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="宋体"><asp:label id="lblBudget" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 16px" align="right"><SPAN id="Label2">推算金额(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="宋体"><asp:label id="lblPushMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Label3">调整金额(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><FONT face="宋体"><asp:label id="lblChange" runat="server"></asp:label></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label4">//追加金额</SPAN>:</td>
					<td style="WIDTH: 80%" colSpan="5"></td>
				</tr>-->
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Span1">预算外金额(RMB)</SPAN>:</TD>
					<TD style="WIDTH: 80%; HEIGHT: 23px" colSpan="5">
						<asp:label id="lblOutMoney" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right"><SPAN id="Label5">已经使用(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体">
							<asp:HyperLink id="hlSumCheck" runat="server"></asp:HyperLink></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Label3">待摊金额(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><FONT face="宋体"><asp:label id="lblready" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 22px" align="right"><SPAN id="Label7">本次使用(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 22px" colSpan="5"><FONT face="宋体"><asp:label id="lblSheetMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 22px" align="right">剩 
						余(RMB)</SPAN>:</td>
					<td style="HEIGHT: 23px" align="left" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblLeft" runat="server"></asp:label><A href="./AttachFiles/hilly/72691351/bug.txt" target="_blank"></A></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('bodyInfo')" href="javascript:void(0)">详细表单</A><FONT face="宋体">(点击查看明细)</FONT></td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: none; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:datagrid style="Z-INDEX: 0" id="dgLBBody" runat="server" Width="100%" AutoGenerateColumns="False"
										BackColor="White" BorderColor="#93BEE2">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="序号"></asp:BoundColumn>
											<asp:BoundColumn DataField="invCode" HeaderText="材料编码"></asp:BoundColumn>
											<asp:BoundColumn DataField="invName" HeaderText="品名"></asp:BoundColumn>
											<asp:BoundColumn DataField="INVSPEC" HeaderText="规格"></asp:BoundColumn>
											<asp:BoundColumn DataField="MEASNAME" HeaderText="单位"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="数量" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RMBPrice" HeaderText="RMB单价" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB总价" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Memo" HeaderText="备注"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<asp:datagrid style="Z-INDEX: 0" id="dgApplyBody" runat="server" Width="100%" AutoGenerateColumns="False"
										BackColor="White" BorderColor="#93BEE2">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="序号"></asp:BoundColumn>
											<asp:BoundColumn DataField="invCode" HeaderText="材料编码"></asp:BoundColumn>
											<asp:BoundColumn DataField="invName" HeaderText="品名"></asp:BoundColumn>
											<asp:BoundColumn DataField="INVSPEC" HeaderText="规格"></asp:BoundColumn>
											<asp:BoundColumn DataField="MEASNAME" HeaderText="单位"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="数量" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RMBPrice" HeaderText="RMB单价" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB总价" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Memo" HeaderText="备注"></asp:BoundColumn>
											<asp:BoundColumn DataField="Dnoutnum" HeaderText="科室已有数量">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cnoutnum" HeaderText="部门已有数量">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgApplyBody_Pay" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
										AutoGenerateColumns="False">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="序号"></asp:BoundColumn>
											<asp:BoundColumn DataField="Item" HeaderText="事项"></asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币金额" DataFormatString="{0:N}"></asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB金额" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<P><asp:panel id="panel1" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
											Width="100%" Height="521" Runat="server" Visible="False"></P>
									<P><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><BR>
										&nbsp;&nbsp;&nbsp;&nbsp;<FONT color="#ff9966">开始日期：</FONT>
										<asp:textbox id="txtDateFrom" onfocus="WdatePicker({skin:'whyGreen', maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="88px" Enabled="False"></asp:textbox>&nbsp;<FONT color="#ff9966">结束日期：</FONT>
										<asp:textbox id="txtDateTo" onfocus="WdatePicker({skin:'whyGreen', minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="88px" Enabled="False"></asp:textbox>&nbsp;<FONT color="#ff9966">出差城市：</FONT>
										<asp:textbox id="txtGocity" runat="server" Width="200px" Enabled="False"></asp:textbox>&nbsp;<BR>
										<BR>
										&nbsp;&nbsp;&nbsp;&nbsp;出差类型：&nbsp;
										<asp:dropdownlist id="ddlCCType" runat="server" Enabled="False">
											<asp:ListItem Value="国内">国内</asp:ListItem>
											<asp:ListItem Value="国外">国外</asp:ListItem>
										</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;差旅费等级:&nbsp;&nbsp;
										<asp:textbox id="txtAppclass" runat="server" Width="80px" Enabled="False"></asp:textbox>&nbsp;&nbsp; 
										同行人数：&nbsp;
										<asp:textbox id="txtwithapps" runat="server" Width="80px" Enabled="False"></asp:textbox>&nbsp;
									</P>
									<P>&nbsp;&nbsp;&nbsp; 同 行 人：&nbsp;&nbsp;
										<asp:textbox id="txtWithwho" runat="server" Width="576px" Enabled="False"></asp:textbox></P>
									<P>&nbsp;&nbsp;&nbsp;&nbsp; 出差理由：
										<asp:textbox id="txtCCMemo" runat="server" Width="432px" Height="82px" TextMode="MultiLine" Enabled="False"></asp:textbox></P>
									<P>&nbsp;&nbsp;&nbsp;<FONT color="green">注意:以上褐色项目为必填项目。以下为国外出差的项目，国内出差无须填写</FONT>
									</P>
									<P><asp:panel id="Panel2" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
											runat="server" Height="164px">
											<P>&nbsp; 前次出国日期：
												<asp:TextBox id="txtPreabound" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
													runat="server" Width="112px" Enabled="False"></asp:TextBox>前次回国日期：
												<asp:TextBox id="txtPreback" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
													Width="112px" Enabled="False"></asp:TextBox>&nbsp;VIsa：
												<asp:CheckBox id="chbVisa" runat="server" Enabled="False" Text="有/无"></asp:CheckBox>&nbsp;VIsa有效期：
												<asp:TextBox id="txtVisaDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
													Width="112px" Enabled="False"></asp:TextBox></P>
											<P></P>
											<P>&nbsp; 护照：
												<asp:CheckBox id="chkPassport" runat="server" Enabled="False" Text="有/无"></asp:CheckBox>&nbsp;护照号：&nbsp;
												<asp:TextBox id="txtPassportno" runat="server" Width="184px" Enabled="False"></asp:TextBox>&nbsp;护照有效期：
												<asp:TextBox id="txtpassportdate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
													runat="server" Enabled="False"></asp:TextBox></P>
											<P>&nbsp;疫苗注射：
												<asp:CheckBox id="chbbacterin" runat="server" Enabled="False" Text="有/无"></asp:CheckBox>疫苗有效期：
												<asp:TextBox id="txtbacterindate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
													runat="server" Enabled="False"></asp:TextBox></P>
											<P>&nbsp;备注事项：
												<asp:TextBox id="txtabountMemo" runat="server" Width="552px" Height="92px" Enabled="False" TextMode="MultiLine"></asp:TextBox></P>
											<P>&nbsp;是否携带限制物品:
												<asp:CheckBox id="chblimit" runat="server" Enabled="False" Text="有/无"></asp:CheckBox>是否提供限制技术(程序、资料等)：
												<asp:CheckBox id="chblimits" runat="server" Enabled="False" Text="有/无"></asp:CheckBox>出港前体检:
												<asp:CheckBox id="chbcheckup" runat="server" Enabled="False" Text="要/否"></asp:CheckBox></P>
											<P>是否符合出口限制条件:
												<asp:CheckBox id="chbmeet" runat="server" Enabled="False" Text="符合/不符合"></asp:CheckBox>体检日期(计划):
												<asp:TextBox id="txtcheckupplan" runat="server" Width="168px" Enabled="False"></asp:TextBox></P>
											<P><FONT color="green">&nbsp;&nbsp; 注意:1、出差时间一个月以上者须体检。2、出差时间超过31天者停止发放通勤补贴。</FONT></P>
											<P>
										</asp:panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
									<P><asp:panel id="Panel3" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
											runat="server">
											<asp:datagrid id="dgCCBodyInfo" runat="server" Width="100%" BorderColor="#93BEE2" BackColor="White"
												AutoGenerateColumns="False" Visible="False">
												<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
												<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
												<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
												<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
													BackColor="#337FB2"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="seqNum" HeaderText="序号"></asp:BoundColumn>
													<asp:BoundColumn DataField="CodeName" HeaderText="费用事项"></asp:BoundColumn>
													<asp:BoundColumn DataField="currcode" HeaderText="币种"></asp:BoundColumn>
													<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:N}">
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Money" HeaderText="金额" DataFormatString="{0:N}">
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="memo" HeaderText="备注"></asp:BoundColumn>
												</Columns>
											</asp:datagrid>
										</asp:panel></P>
									<P><FONT face="宋体"></FONT>&nbsp;</P>
									</asp:panel>
									<asp:panel id="Panel5" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
										Width="100%" Visible="False" Runat="server" Height="521">
										<P></P>
										<P><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><BR>
											<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
												<TR height="15">
													<TD width="15%" align="center">项目</TD>
													<TD style="WIDTH: 481px" align="center">计划日程</TD>
													<TD align="center">备注</TD>
												</TR>
												<TR>
													<TD style="COLOR: #ff9966">招待时间</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="Textbox2" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
															Enabled="False"></asp:textbox>至
														<asp:textbox id="Textbox1" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
															Enabled="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px; COLOR: #ff9966">招待单位</TD>
													<TD style="WIDTH: 481px; HEIGHT: 14px">
														<asp:textbox id="txtVisitCompany" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 14px">【注意事项】</TD>
												</TR>
												<TR>
													<TD style="COLOR: #ff9966">招待人员</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtCallinPerson" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>①交际费的使用必须事前申请。特别是会餐以外的交际费的使用，必须事前完成审批报告。</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 12px">来访目的</TD>
													<TD style="WIDTH: 481px; HEIGHT: 12px">
														<asp:textbox id="txtCallinMemo" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 12px">②未能事前申请时，需在申请书的备注栏中写明原因，事后立即申请。</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 15px">会谈地点</TD>
													<TD style="WIDTH: 481px; HEIGHT: 15px">
														<asp:textbox id="txtTalkPlace" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 15px">③来访客人姓名、接待人员姓名需全员记入。出席人员较多的话请添附具体名单。</TD>
												</TR>
												<TR>
													<TD>接待部门</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtVisitDept" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>④只有JDI内部人员参加的会餐等，原则上个人承担费用。</TD>
												</TR>
												<TR>
													<TD>接待人员</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtVisitPerson" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>⑤来客接待时的会餐出席人员，原则上来客1名，公司接待人员1名。（原则上公司接待人员不能多于来客人数）</TD>
												</TR>
												<TR>
													<TD>接待部门联系方式</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtvisitphone" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>⑥禁止使用二次会（卡拉OK等）交际费。</TD>
												</TR>
												<TR>
													<TD>相关部门</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtRelationDept" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>⑦无论任何理由，禁止接待或馈赠反社会团体相关人员。</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 20px">茶水准备</TD>
													<TD style="WIDTH: 481px; HEIGHT: 20px">
														<asp:checkbox id="chbTea" runat="server" Enabled="False" Text="需要/不需要"></asp:checkbox></TD>
													<TD style="HEIGHT: 20px"></TD>
												</TR>
												<TR>
													<TD>参观工厂</TD>
													<TD style="WIDTH: 481px">
														<asp:checkbox id="chblookFactory" runat="server" Enabled="False" Text="是/否"></asp:checkbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px">参观人数</TD>
													<TD style="WIDTH: 481px; HEIGHT: 14px">
														<asp:textbox id="txtLookNum" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 14px"></TD>
												</TR>
												<TR>
													<TD>午餐安排</TD>
													<TD style="WIDTH: 481px">
														<asp:checkbox id="chbLunch" runat="server" Enabled="False" Text="食堂内/外"></asp:checkbox></TD>
													<TD>附《来宾用餐申请表》</TD>
												</TR>
												<TR>
													<TD>其他需求</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtOtherNeed" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px">车辆安排</TD>
													<TD style="WIDTH: 481px; HEIGHT: 14px">公司派车：
														<asp:radiobutton id="RadioButton1" runat="server" Enabled="False" Text="接" GroupName="carplan"></asp:radiobutton>
														<asp:radiobutton id="RadioButton2" runat="server" Enabled="False" Text="送" GroupName="carplan"></asp:radiobutton>
														<asp:radiobutton id="RadioButton3" runat="server" Enabled="False" Text="往返" GroupName="carplan"></asp:radiobutton>
														<asp:radiobutton id="RadioButton4" runat="server" Enabled="False" Text="无" GroupName="carplan" Checked="True"></asp:radiobutton></TD>
													<TD style="HEIGHT: 14px">附《用车联络单》</TD>
												</TR>
												<TR>
													<TD>特殊要求</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtEspecialRequest" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD></TD>
													<TD style="WIDTH: 481px"><FONT face="宋体"></FONT></TD>
													<TD></TD>
												</TR>
											</TABLE>
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</P>
										<P>
											<asp:panel style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
												id="Panel4" runat="server">
												<asp:datagrid id="dgYQInfo" runat="server" Width="100%" BorderColor="#93BEE2" BackColor="White"
													AutoGenerateColumns="False" Visible="False">
													<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
													<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
													<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
													<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
														BackColor="#337FB2"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="seqNum" HeaderText="序号"></asp:BoundColumn>
														<asp:BoundColumn DataField="Item" HeaderText="事项"></asp:BoundColumn>
														<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
														<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币金额" DataFormatString="{0:N}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:N}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Money" HeaderText="RMB金额" DataFormatString="{0:N}"></asp:BoundColumn>
													</Columns>
												</asp:datagrid>
											</asp:panel></P>
										<BR>
									</asp:panel>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('postail')" href="javascript:void(0)">审批意见</A><FONT face="宋体">(点击查看明细)</FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: none; HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="宋体"><asp:datagrid id="dgPostail" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
								AutoGenerateColumns="False">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
									BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="批阅人">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Checkdate" HeaderText="批阅时间">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IsAgree" HeaderText="批阅类型">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CheckComment" HeaderText="意见">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('AnnexInfo')" href="javascript:void(0)">附件(<%=NumOfAnnex%>)</A><FONT face="宋体">(点击查看明细)</FONT></td>
				</tr>
				<tr id="AnnexInfo" style="DISPLAY: none; HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="宋体"><asp:table id="tbAnnex" runat="server" Width="100%" Font-Size="12px"></asp:table></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px; BACKGROUND-COLOR: #e8f4ff">
					<td style="WIDTH: 19.67%" align="center">批阅人</td>
					<td style="WIDTH: 20%" align="center">批阅时间</td>
					<td style="WIDTH: 10%" align="center">批阅类型</td>
					<td style="WIDTH: 50%" align="left" colspan="3">批阅内容</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%" align="center"><FONT face="宋体">zyq</FONT></td>
					<td style="WIDTH: 20%" align="center"><FONT face="宋体">审核后立即更新此记录</FONT></td>
					<td style="WIDTH: 10%" align="center"><FONT face="宋体">tongyi/fandui</FONT></td>
					<td style="WIDTH: 50%" align="left" colspan="3"><FONT face="宋体">这次买的东西太多！</FONT></td>
				</tr>-->
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">审批意见</td>
				</tr>
				<tr>
					<td style="WIDTH: 19.67%" vAlign="top" align="right">审批意见:</td>
					<td align="left" colSpan="5"><asp:textbox id="txtPosital" runat="server" Width="70%" Height="100px" TextMode="MultiLine" Rows="8"
							Columns="100"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 19.67%" align="right"><FONT face="宋体"></FONT></td>
					<td align="left" colSpan="5"><FONT face="宋体"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td colSpan="6"><asp:button id="btnAgree" runat="server" Width="72px" CssClass="redButtonCss" Text="同意"></asp:button><asp:button id="btnRefuse" runat="server" Width="72px" CssClass="redButtonCss" Text="拒绝"></asp:button><asp:button id="btnGoBack" runat="server" Width="72px" CssClass="redButtonCss" Text="返回"></asp:button>
						<asp:button style="Z-INDEX: 0" id="btnPass" runat="server" Width="84px" Text="弃审" CssClass="redButtonCss"></asp:button></td>
				</tr>
				<tr>
					<td align="left" colSpan="6" height="32"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
