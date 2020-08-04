<%@ Page language="c#" Codebehind="ChangeOneApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.BudGet.ChangeOneApply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src=".../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute" cellSpacing="0" cellPadding="0"
				width="100%" border="0">
				<TR>
					<TD width="20%"><FONT face="宋体">此单简要信息:</FONT></TD>
					<TD width="20%"></TD>
					<TD width="20%"></TD>
					<TD width="20%"></TD>
					<TD width="20%"></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体"></FONT></TD>
					<TD></TD>
					<TD><FONT face="宋体"></FONT></TD>
					<TD></TD>
					<TD width="20%"></TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">调整年份:</FONT></TD>
					<TD><FONT face="宋体"><asp:textbox id="textYear" runat="server"></asp:textbox></FONT></TD>
					<TD><FONT face="宋体">调整月份</FONT></TD>
					<TD width="25%"><asp:textbox id="txtMonth" runat="server"></asp:textbox></TD>
					<TD><asp:button id="btnEnter" runat="server" Text="确定"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="5">
						<P><FONT face="宋体">&nbsp;</P>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD style="HEIGHT: 16px"><asp:label id="Label2" runat="server" Visible="False">预算金额</asp:label>(季度)</TD>
								<TD style="HEIGHT: 16px"><asp:label id="Label8" runat="server" Visible="False">推算金额</asp:label>(季度)</TD>
								<TD style="HEIGHT: 16px"><asp:label id="Label3" runat="server" Visible="False">调整金额</asp:label>(季度)</TD>
								<TD style="HEIGHT: 16px"><asp:label id="Label5" runat="server" Visible="False">已经使用</asp:label>(季度)</TD>
								<TD style="HEIGHT: 16px">单据调整金额</TD>
								<TD style="HEIGHT: 16px">预算外金额</TD>
								<TD style="HEIGHT: 16px">待摊金额</TD>
								<TD style="HEIGHT: 16px"><asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
								<TD style="HEIGHT: 16px"><asp:label id="Label6" runat="server" Visible="False">剩   余</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblBudget" runat="server"></asp:label></TD>
								<TD><asp:label id="lblPush" runat="server"></asp:label></TD>
								<TD><asp:label id="lblChange" runat="server"></asp:label></TD>
								<TD><asp:label id="lblSumCheck" runat="server"></asp:label></TD>
								<TD>
									<asp:Label style="Z-INDEX: 0" id="lblAlterMoney" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label style="Z-INDEX: 0" id="lblOutMoney" runat="server"></asp:Label></TD>
								<TD>
									<asp:Label style="Z-INDEX: 0" id="lblready" runat="server"></asp:Label></TD>
								<TD><asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
								<TD><asp:label id="lblLeft" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
						<P></FONT><FONT face="宋体"></FONT>&nbsp;</P>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="宋体">调整金额:</FONT></TD>
					<TD><asp:textbox id="txtChangeMoney" runat="server"></asp:textbox></TD>
					<TD></TD>
					<TD width="25%"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><FONT face="宋体">备注:</FONT></TD>
					<TD style="HEIGHT: 24px" colSpan="4"><asp:textbox id="txtPosital" runat="server" TextMode="MultiLine" Height="100px" Width="70%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5"><asp:button id="btnSubmit" runat="server" Text="提交" Enabled="False" Width="69px"></asp:button><INPUT type="button" value="返回" style="WIDTH: 67px; HEIGHT: 24px" id="Button1" name="Button1"
							runat="server"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
