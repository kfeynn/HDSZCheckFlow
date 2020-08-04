<%@ Page language="c#" Codebehind="ApplySheetBodyInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheetBodyInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 0px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 0px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">基本信息</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">申请科目:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblSubject" runat="server"></asp:label></FONT></td>
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">申请类型:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblApplyType" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">提案部门及人员:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblDpteAndPerson" runat="server"></asp:label></FONT></td>
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">申请日期:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblApplyDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">交货日期:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblDeliveryDate" runat="server"></asp:label></FONT></td>
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">填单时间:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblSubmitDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">金额:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblMoney" runat="server"></asp:label></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">预算情况</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; HEIGHT: 16px; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label2">预算金额</SPAN>:</td>
					<td style="WIDTH: 30%; HEIGHT: 16px" colSpan="2"><FONT face="宋体"><asp:label id="lblBudget" runat="server"></asp:label></FONT></td>
					<td style="WIDTH: 19.67%; HEIGHT: 16px; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label24">推算金额</SPAN>:</td>
					<td style="WIDTH: 30%; HEIGHT: 16px" colSpan="2"><FONT face="宋体"><asp:label id="lblPushMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; HEIGHT: 23px; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label3">调整金额</SPAN>:</td>
					<td style="WIDTH: 30%; HEIGHT: 23px" colSpan="2"><FONT face="宋体"><asp:label id="lblChange" runat="server"></asp:label></FONT></td>
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label5">已经使用</SPAN>:</td>
					<td style="WIDTH: 30%" colSpan="2"><FONT face="宋体"><asp:label id="lblSumCheck" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; HEIGHT: 22px; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label7">本次使用</SPAN>:</td>
					<td style="WIDTH: 30%; HEIGHT: 22px" colSpan="2"><FONT face="宋体"><asp:label id="lblSheetMoney" runat="server"></asp:label></FONT></td>
					<TD style="WIDTH: 185px; HEIGHT: 23px; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label6">剩 
							余</SPAN>:</TD>
					<td style="HEIGHT: 23px" align="left" colSpan="2"><FONT face="宋体"></FONT><asp:label id="lblLeft" runat="server"></asp:label><A href="./AttachFiles/hilly/72691351/bug.txt" target="_blank"></A></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%; HEIGHT: 27px" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">详细表单</td>
				</tr>
				<tr style="HEIGHT: 22px" id="bodyInfo">
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>
									<asp:datagrid id="dgApplyBody" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
										AutoGenerateColumns="False">
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
											<asp:BoundColumn DataField="Number" HeaderText="数量" DataFormatString="{0:#,###.##}"></asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价" DataFormatString="{0:#,###.##}"></asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:#,###.##}"></asp:BoundColumn>
											<asp:BoundColumn DataField="RMBPrice" HeaderText="RMB单价" DataFormatString="{0:#,###.##}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB总价" DataFormatString="{0:#,###.##}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Memo" HeaderText="备注"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td>
									<asp:datagrid id="dgApplyBody_Pay" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
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
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币金额"></asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="汇率" DataFormatString="{0:#,###.##}"></asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB金额" DataFormatString="{0:f2}"></asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">附件(<%=NumOfAnnex%>)</td>
				</tr>
				<tr style="HEIGHT: 28px" id="AnnexInfo">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="宋体">
							<asp:Table id="tbAnnex" runat="server" Width="100%" Font-Size="12px"></asp:Table></FONT></td>
				</tr>
				<tr>
					<td style="WIDTH: 19.67%" vAlign="top" align="right"><FONT face="宋体"></FONT></td>
					<td align="left" colSpan="5"><FONT face="宋体"></FONT></td>
				</tr>
				<tr align="center" style="HEIGHT:22px">
					<td colspan="6">
						<INPUT class="redButtonCss" id="retrunBack" style="WIDTH: 66px; HEIGHT: 20px" type="button"
							value="返回" onclick="javascript:history.go(-1);"></td>
				</tr>
				<tr>
					<td align="left" colSpan="6" height="32"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
