<%@ Page language="c#" Codebehind="ApplySheetEdit.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheetEdit" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApplySheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script language="javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<script language="javascript">
		function ShowUserName(useCode)
		{
			var userName=HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheet.GetUserNameByCode(useCode.value);
			if(userName.length==0)
			{}
			else
			{
				document.getElementById("txtPersonName").innerText=userName.value;
			}
		}
		

		
		function showDisplay(trName)   
		{
			if(document.all(trName).style.display=='none')
			{
				document.all(trName).style.display='block';

			}
			else
			{
				document.all(trName).style.display='none';
			}				

		} 
		</script>
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 40px; LEFT: 20px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<tr height="28">
						<td align="center"><asp:label id="lblMsg" runat="server"></asp:label><asp:label id="Label1" runat="server">表单维护页(可修改的表单)</asp:label></td>
					</tr>
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="200" align="left" border="0">
								<TR>
									<TD><asp:button id="btnPress" runat="server" CssClass="inputbutton" Text="紧急审批" Enabled="False"
											Visible="False"></asp:button></TD>
									<TD><asp:button id="btnInConrt" runat="server" Text="预算内提交" Enabled="False"></asp:button></TD>
									<TD><asp:button id="btnOutConrt" runat="server" Text="预算外提交" Enabled="False"></asp:button></TD>
								</TR>
							</TABLE>
							<asp:label id="lblMessage" runat="server"></asp:label>
						</TD>
					</TR>
					<TR style="DISPLAY: none">
						<TD>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px" height="17">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD width="90%" align="right"><a target="_blank" href="BaseSubjecQuery.aspx">查询产品价格</a>
										<asp:Label id="lblAnnexMsg" runat="server"></asp:Label></TD>
									<TD width="10%">
										<asp:HyperLink id="hyLindToAnnex" runat="server" Visible="False">添加附件</asp:HyperLink></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD><gridwc:xpgrid id="XPGrid1" runat="server" PageSize="10" width="100%" AllowAdd="False" AllowDelete="True"
								AllowEdit="True" AllowExportExcel="True" AllowPrint="True" AllowSort="True" SelectKind="SingleLine"></gridwc:xpgrid></TD>
					</TR>
					<tr height="28">
						<td>
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD style="HEIGHT: 16px"><asp:label id="Label2" runat="server" Visible="False">预算金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label8" runat="server" Visible="False">推算金额</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label3" runat="server" Visible="False">调整金额</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label5" runat="server" Visible="False">已经使用</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label4" runat="server" Visible="False">待摊金额</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label9" runat="server" Visible="False">预算外金额</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label style="Z-INDEX: 0" id="Label12" runat="server" Visible="False">单据调整</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label6" runat="server" Visible="False">剩   余</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblPush" runat="server"></asp:label></TD>
									<TD><asp:label id="lblChange" runat="server"></asp:label></TD>
									<TD><asp:label id="lblSumCheck" runat="server"></asp:label></TD>
									<TD><asp:label id="lblready" runat="server"></asp:label></TD>
									<TD><asp:label id="lblOutMoney" runat="server"></asp:label></TD>
									<TD><asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:Label style="Z-INDEX: 0" id="lblAlterMoney" runat="server"></asp:Label></TD>
									<TD><asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr height="28">
						<td></td>
					</tr>
					<TR>
						<TD><gridwc:xpgrid id="XPGrid2" runat="server" width="100%" AllowAdd="True" AllowDelete="True" AllowEdit="True"
								AllowExportExcel="True" AllowPrint="True" AllowSort="True" SelectKind="MulitLines" Visible="False"></gridwc:xpgrid></TD>
					</TR>
					<tr height="28">
						<td></td>
					</tr>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
