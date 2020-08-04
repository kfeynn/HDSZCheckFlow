<%@ Page language="c#" Codebehind="OneOrderInfo.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.OrderManage.OrderInfo.OneOrderInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApplySheetBodyInfo2</title>
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
					<td style="WIDTH: 100%" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">
						<asp:Button id="btnPrint" runat="server" Width="74px" Text="打印" CssClass="redButtonCss"></asp:Button></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">定&nbsp;&nbsp;单 
						号:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblOrderNo" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">制 单 人:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblPerson" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">定单日期:</td>
					<td style="WIDTH: 20.33%" colSpan="2"><FONT face="宋体"><asp:label id="lblApplyDate" runat="server"></asp:label></FONT></td>
					<td style="WIDTH: 12.67%; BACKGROUND-COLOR: #e8f4ff" align="right">交货日期:</td>
					<td style="WIDTH: 18.21%" colSpan="1"><FONT face="宋体"><asp:label id="lblDeliveryDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right">金额(RMB):</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblMoney" runat="server"></asp:label></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"></td>
				</tr>
				<tr>
					<td style="WIDTH: 20%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6">
						<asp:datagrid id="dgOrder" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
							AutoGenerateColumns="False" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ApplySheetBody_Purchase_pk" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="seqNum" HeaderText="序号"></asp:BoundColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../CheckFlow/CheckFlow/ApplySheetBodyInfo2.aspx?applyHeadPK={0}"
									DataTextField="ApplySheetNo" HeaderText="单据号"></asp:HyperLinkColumn>
								<asp:BoundColumn DataField="DeptName" HeaderText="部门"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyTypeName" HeaderText="单据类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="ApplyDate" HeaderText="单据日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="InventoryCode" HeaderText="产品编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="invName" HeaderText="产品名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="Number" HeaderText="数量" DataFormatString="{0:n0}"></asp:BoundColumn>
								<asp:BoundColumn DataField="currTypeCode" HeaderText="币种"></asp:BoundColumn>
								<asp:BoundColumn DataField="originalcurrPrice" HeaderText="原币单价"></asp:BoundColumn>
								<asp:BoundColumn DataField="RMBPrice" HeaderText="rmb单价"></asp:BoundColumn>
								<asp:BoundColumn DataField="money" HeaderText="总价"></asp:BoundColumn>
								<asp:BoundColumn DataField="OrderNo" HeaderText="定单号"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk"></asp:BoundColumn>
								<asp:BoundColumn DataField="memo" HeaderText="备注"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td align="left" colSpan="6"><FONT face="宋体"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td colSpan="6"><INPUT class="redButtonCss" id="retrunBack" style="WIDTH: 66px; HEIGHT: 20px" onclick="javascript:history.go(-1);"
							type="button" value="返回" name="retrunBack"></td>
				</tr>
				<tr>
					<td align="left" colSpan="6" height="32"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
