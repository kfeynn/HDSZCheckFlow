<%@ Page language="c#" Codebehind="ApplySheet.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheet" %>
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
		<script language="javascript" src="../../Style/My97DatePicker/WdatePicker.js"></script>
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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 40px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<tr height="28">
						<td>
							<asp:dropdownlist id="ddlSubmitType" runat="server" AutoPostBack="True" Visible="False"></asp:dropdownlist></td>
					</tr>
					<TR>
						<TD>
							<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="300" align="left" border="0">
								<TR>
									<TD><asp:button id="btnPress" runat="server" Enabled="False" Text="紧急审批" CssClass="inputbutton"
											Visible="False"></asp:button></TD>
									<TD><asp:button id="btnInConrt" runat="server" Enabled="False" Text="预算内提交"></asp:button></TD>
									<TD><asp:button id="btnOutConrt" runat="server" Enabled="False" Text="预算外提交"></asp:button></TD>
									<td><asp:button id="btnGetBack" runat="server" Enabled="False" Text="取回单据"></asp:button></td>
									<TD>
										<asp:Button id="btnKeep" runat="server" Enabled="False" Text="封存单椐"></asp:Button></TD>
									<td><asp:Label id="lblMsg" runat="server"></asp:Label></td>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR style="DISPLAY: none">
						<TD>&nbsp;
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#000000"
								border="1">
								<TR>
									<TD>
										<P style="FONT-SIZE: 14px">添加申请单：</P>
									</TD>
									<TD></TD>
									<TD style="WIDTH: 68px"></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>申请类型</TD>
									<TD>
										<asp:dropdownlist id="ddlApplyType" runat="server"></asp:dropdownlist></TD>
									<TD style="WIDTH: 68px">申请日期</TD>
									<TD>
										<asp:textbox id="txtDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server" Width="80px"></asp:textbox></TD>
									<TD>申请部门</TD>
									<TD>
										<asp:dropdownlist id="ddlDeptClass" runat="server" Width="80px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD>申请科组</TD>
									<TD>
										<asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD>申请科目</TD>
									<TD>
										<asp:dropdownlist id="ddlSubject" runat="server" Width="90px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 67px">申 请 人</TD>
									<TD>
										<asp:textbox id="txtPerson" onkeyup="javascript:ShowUserName(this)" runat="server" Width="80px"></asp:textbox></TD>
									<TD>姓&nbsp;&nbsp;&nbsp; 名</TD>
									<TD>
										<asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px"></asp:textbox></TD>
									<TD colSpan="2">
										<asp:button id="btnAdd" runat="server" Text="添加" CssClass="inputButton" Width="72px"></asp:button>
										<asp:label id="lblMessage" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD height="17" style="HEIGHT: 17px"></TD>
					</TR>
					<TR>
						<TD><gridwc:xpgrid id="XPGrid1" runat="server" SelectKind="SingleLine" AllowSort="True" AllowPrint="True"
								AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="False" width="100%" PageSize="10"></gridwc:xpgrid></TD>
					</TR>
					<tr height="28">
						<td>
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" borderColorLight="#6600cc"
								border="1">
								<TR>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label2" runat="server" Visible="False">推算金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label3" runat="server" Visible="False">调整金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label5" runat="server" Visible="False">已经使用</asp:label>
										<asp:label id="Label4" runat="server" Visible="False">追加金额</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label6" runat="server" Visible="False">剩   余</asp:label></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblChange" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblSumCheck" runat="server"></asp:label>
										<asp:label id="lblAdd" runat="server" Visible="False"></asp:label></TD>
									<TD>
										<asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr height="28">
						<td></td>
					</tr>
					<TR>
						<TD>
							<gridwc:XPGrid id="XPGrid2" runat="server" width="100%" SelectKind="MulitLines" AllowSort="True"
								AllowPrint="True" AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="True"
								Visible="False"></gridwc:XPGrid></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
