<%@ Page language="c#" Codebehind="AddApplySheet.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.AddApplySheet" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddApplySheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<script language="javascript">
		function ShowUserName(useCode)
		{
			var userName=HDSZCheckFlow.UI.CheckFlow.CheckFlow.AddApplySheet.GetUserNameByCode(useCode.value);
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
			<FONT face="����">
				<TABLE id="Table2" style="Z-INDEX: 100; POSITION: absolute; TOP: 40px; LEFT: 40px" cellSpacing="1"
					cellPadding="1" width="90%" border="0">
					<tr>
						<td align="center">
							<asp:Label id="lblMsg" runat="server"></asp:Label></td>
					</tr>
					<tr>
						<td style="HEIGHT: 13px">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" align="left" border="0">
								<TR>
									<TD><asp:button id="btnPress" runat="server" Text="���������ύ" Enabled="False" Visible="False"></asp:button></TD>
									<TD><asp:button id="btnInConrt" runat="server" Text="Ԥ�����ύ" Enabled="False"></asp:button></TD>
									<TD><asp:button id="btnOutConrt" runat="server" Text="Ԥ�����ύ" Enabled="False"></asp:button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td align="center">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD align="right" width="90%"><a target="_blank" href="BaseSubjecQuery.aspx">��ѯ��Ʒ�۸�</a>
										<asp:Label id="lblAnnexMsg" runat="server"></asp:Label></TD>
									<TD width="10%">
										<asp:HyperLink id="hyLindToAnnex" runat="server" Visible="False">��Ӹ���</asp:HyperLink></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD>&nbsp;
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD colspan="3">
										<P style="FONT-SIZE: 14px">������뵥��</P>
									</TD>
									<TD style="WIDTH: 142px">&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD colspan="3">
										<asp:label id="lblMessage" runat="server"></asp:label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>��������</TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" AutoPostBack="True" ForeColor="Transparent" BackColor="White"></asp:dropdownlist></TD>
									<TD style="WIDTH: 68px">��������</TD>
									<TD style="WIDTH: 142px"><asp:textbox id="txtDate" onfocus="WdatePicker({minDate:'%y-%M-{01}'})" runat="server" Width="80px"></asp:textbox></TD>
									<TD>���벿��</TD>
									<TD><asp:dropdownlist id="ddlDeptClass" runat="server" Width="80px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD>�������</TD>
									<TD><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									<td>&nbsp;</td>
								</TR>
								<TR>
									<td>һ����Ŀ</td>
									<td>
										<asp:DropDownList id="ddlFirstSubject" runat="server" AutoPostBack="True"></asp:DropDownList></td>
									<TD>�����Ŀ</TD>
									<TD style="WIDTH: 142px" colspan="3"><asp:dropdownlist id="ddlSubject" runat="server" Width="296px"></asp:dropdownlist></TD>
									<TD>�� �� ��</TD>
									<TD><asp:textbox id="txtPerson" onkeyup="javascript:ShowUserName(this)" runat="server" Width="80px"></asp:textbox></TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD>��&nbsp;&nbsp;&nbsp; ��</TD>
									<TD><asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px" ForeColor="Red"></asp:textbox></TD>
									<TD>
										��������</TD>
									<TD style="WIDTH: 142px">
										<asp:textbox id="txtDeliveryDate" onfocus=" WdatePicker()" runat="server" Width="93px"></asp:textbox></TD>
									<TD style="WIDTH: 67px">�� �� ��</TD>
									<TD>&nbsp;
										<asp:Label id="Label9" runat="server" Width="64px"></asp:Label></TD>
									<TD>&nbsp;�ύ����</TD>
									<TD>&nbsp;
										<asp:Label id="Label10" runat="server" Width="64px"></asp:Label></TD>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD style="WIDTH: 142px">&nbsp;</TD>
									<TD style="WIDTH: 67px">&nbsp;</TD>
									<TD><asp:button id="btnAdd" runat="server" Text="���" CssClass="inputButton" Width="72px"></asp:button></TD>
									<TD>
										<asp:button id="btnEdit" runat="server" Text="�޸�" Width="72px" CssClass="inputButton"></asp:button></TD>
									<TD>
										<asp:button id="btnSave" runat="server" Text="����" Width="72px" CssClass="inputButton"></asp:button></TD>
									<TD>&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<td height="100">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD style="HEIGHT: 16px"><asp:label id="Label2" runat="server" Visible="False">Ԥ����(����)</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label8" runat="server" Visible="False">������(����)</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label3" runat="server" Visible="False">�������(����)</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label5" runat="server" Visible="False">�Ѿ�ʹ��</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label4" runat="server" Visible="False">��̯���</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label11" runat="server" Visible="False">Ԥ������</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label7" runat="server" Visible="False">����ʹ��</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label style="Z-INDEX: 0" id="Label12" runat="server" Visible="False">���ݵ���</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label6" runat="server" Visible="False">ʣ   ��</asp:label></TD>
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
					</TR>
					<TR>
						<TD><asp:label id="Label1" runat="server" Visible="False" Font-Size="16px">��ӵ�����ϸ��</asp:label></TD>
					</TR>
					<TR>
						<TD><gridwc:xpgrid id="XPGrid1" runat="server" width="100%" AllowSort="True" AllowPrint="True" AllowExportExcel="True"
								AllowEdit="True" AllowDelete="True" AllowAdd="True" SelectKind="MulitLines"></gridwc:xpgrid></TD>
					</TR>
				</TABLE>
				<INPUT id="HiddenLeft" style="Z-INDEX: 104; POSITION: absolute; TOP: 0px; LEFT: 320px"
					type="hidden" value="0" name="Hidden2" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 103; POSITION: absolute; TOP: 0px; LEFT: 160px" type="hidden"
					name="Hidden2" runat="server"> <INPUT id="Hidden1" style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 0px" type="hidden"
					name="Hidden1" runat="server"> </FONT>
		</form>
	</body>
</HTML>
