<%@ Page language="c#" Codebehind="AddBanquet.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.Evection.AddBanquet" %>
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
//		function ShowUserName(useCode)
//		{
//			var userName=HDSZCheckFlow.UI.CheckFlow.Evection.AddEvection.GetUserNameByCode(useCode.value);
//			if(userName.length==0)
//			{}
//			else
//			{
//				document.getElementById("txtPersonName").innerText=userName.value;
//			}
		    //		}

		    $(function() {
		        $("#txtPerson").keyup(function() {
		            // alert(document.getElementById('txtPerson').value);
		            $.post("AJAX.asmx/GetUserNameByCode",
						{
						    useCode: document.getElementById('txtPerson').value
						},
						function(data, status) {
						    //alert("Data: " + data.text + "\nStatus: " + status);
						    document.getElementById("txtPersonName").innerText = data.text;

						    //alert(data.text);

						    //						    $("#txtPersonName").css({
						    //						        "ForeColor": "red"
						    //						    });

						});
		        });
		    });
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table2" style="Z-INDEX: 101; POSITION: absolute; TOP: 40px; LEFT: 40px" cellSpacing="1"
					cellPadding="1" width="90%" border="0">
					<TBODY>
						<tr>
							<td align="center"><asp:label id="lblMsg" runat="server"></asp:label></td>
						</tr>
						<tr>
							<td style="HEIGHT: 13px">
								<TABLE id="Table3" cellSpacing="1" cellPadding="1" align="left" border="0">
									<TR>
										<TD></TD>
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
										<TD align="right" width="90%">&nbsp;
											<asp:label id="lblAnnexMsg" runat="server"></asp:label></TD>
										<TD width="10%"><asp:hyperlink id="hyLindToAnnex" runat="server" Visible="False">��Ӹ���</asp:hyperlink></TD>
									</TR>
								</TABLE>
								<asp:dropdownlist id="ddlEvection" runat="server" Width="138px"></asp:dropdownlist><asp:button id="btnEditEvection" runat="server" Text="�޸ĵ���"></asp:button></td>
						</tr>
						<TR>
							<TD>&nbsp;
								<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TBODY>
										<TR>
											<TD colSpan="3">
												<P style="FONT-SIZE: 14px">������뵥��</P>
											</TD>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
											<TD style="WIDTH: 99px">&nbsp;</TD>
											<TD colSpan="3"><asp:label id="lblMessage" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD style="COLOR: #ff9966">��������</TD>
											<TD><asp:dropdownlist id="ddlApplyType" runat="server" AutoPostBack="True" ForeColor="Transparent" BackColor="White"></asp:dropdownlist></TD>
											<TD style="WIDTH: 68px; COLOR: #ff9966">��������</TD>
											<TD><asp:textbox id="txtDate" onfocus="WdatePicker()" runat="server" Width="80px"></asp:textbox></TD>
											<TD style="COLOR: #ff9966">���벿��</TD>
											<TD style="WIDTH: 99px"><asp:dropdownlist id="ddlDeptClass" runat="server" Width="80px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD style="COLOR: #ff9966">�������</TD>
											<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
											<td>&nbsp;</td>
										</TR>
										<TR>
											<td style="COLOR: #ff9966">һ����Ŀ</td>
											<td><asp:dropdownlist id="ddlFirstSubject" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
											<TD style="COLOR: #ff9966">�����Ŀ</TD>
											<TD colspan="3" style="WIDTH: 330px"><asp:dropdownlist id="ddlSubject" runat="server" Width="306px"></asp:dropdownlist></TD>
			</FONT>
			<TD>&nbsp;</TD>
			<TD>&nbsp;</TD>
			<TD>&nbsp;</TD>
			</TR>
			<TR><%--onkeyup="javascript:ShowUserName(this)"--%>
				<TD style="HEIGHT: 16px">&nbsp;<FONT face="Times New Roman" color="#ff9966">�����˹���</FONT></TD>
				<TD style="HEIGHT: 16px">
					<asp:textbox id="txtPerson"  runat="server" Width="80px"></asp:textbox></TD>
				<TD style="HEIGHT: 16px">��&nbsp;&nbsp;&nbsp; ��</TD>
				<TD style="HEIGHT: 16px">
					<asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px" ForeColor="Red"></asp:textbox></TD>
				<TD style="WIDTH: 67px; HEIGHT: 16px">�� �� ��</TD>
				<TD style="WIDTH: 99px; HEIGHT: 16px">&nbsp;
					<asp:label id="Label9" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 16px">&nbsp;�ύ����</TD>
				<TD style="HEIGHT: 16px">&nbsp;<asp:label id="Label10" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 16px">&nbsp;</TD>
			</TR>
			<TR>
				<TD>&nbsp;
				</TD>
				<TD>&nbsp;
				</TD>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD style="WIDTH: 67px">&nbsp;</TD>
				<TD style="WIDTH: 99px"><asp:button id="btnAdd" runat="server" Text="���" Width="72px" CssClass="inputButton"></asp:button></TD>
				<TD><asp:button id="btnEdit" runat="server" Text="�޸�" Width="72px" CssClass="inputButton"></asp:button></TD>
				<TD><asp:button id="btnSave" runat="server" Text="����" Width="72px" CssClass="inputButton"></asp:button></TD>
				<TD>&nbsp;</TD>
			</TR>
			</TBODY></TABLE></TD></TR>
			<TR>
				<td height="100">
					<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
						<TR>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label2" runat="server" Visible="False">Ԥ����(����)</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label8" runat="server" Visible="False">������(����)</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label3" runat="server" Visible="False">�������(����)</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label5" runat="server" Visible="False">�Ѿ�ʹ��</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label4" runat="server" Visible="False">��̯���</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label11" runat="server" Visible="False">Ԥ������</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label7" runat="server" Visible="False">����ʹ��</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label style="Z-INDEX: 0" id="Label13" runat="server" Visible="False">���ݵ���</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label6" runat="server" Visible="False">ʣ   ��</asp:label></TD>
						</TR>
						<TR>
							<TD>
								<asp:label id="lblBudget" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblPush" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblChange" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblSumCheck" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblready" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblOutMoney" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
							<TD>
								<asp:Label style="Z-INDEX: 0" id="lblAlterMoney" runat="server"></asp:Label></TD>
							<TD>
								<asp:label id="lblLeft" runat="server"></asp:label></TD>
						</TR>
					</TABLE>
				</td>
			</TR>
			<TR>
				<TD><a name="p"></a><asp:label id="Label1" runat="server" Visible="False" Font-Size="16px">��ӵ�����ϸ��</asp:label></TD>
			</TR>
			<TR>
				<TD>
					<P><asp:panel id="panel1" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
							Visible="False" Width="100%" Runat="server" Height="521"></P>
					<P><BR>
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="15">
								<TD align="center" width="15%">��Ŀ</TD>
								<TD align="center" style="WIDTH: 433px">�ƻ��ճ�</TD>
								<TD align="center">��ע</TD>
							</TR>
							<TR>
								<TD style="COLOR: #ff9966">
									<P>�д�ʱ��</P>
								</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtDateFrom" runat="server" onfocus="WdatePicker({skin:'whyGreen', maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"></asp:textbox>��
									<asp:textbox id="txtDateTo" runat="server" onfocus="WdatePicker({skin:'whyGreen', minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px; COLOR: #ff9966">�д���λ</TD>
								<TD style="WIDTH: 433px; HEIGHT: 14px"><asp:textbox id="txtVisitCompany" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 14px">��ע�����</TD>
							</TR>
							<TR>
								<TD style="Z-INDEX: 0; COLOR: #ff9966">������Ա����</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtCallinPerson" runat="server" Width="344px"></asp:textbox></TD>
								<TD>�ٽ��ʷѵ�ʹ�ñ�����ǰ���롣�ر��ǻ������Ľ��ʷѵ�ʹ�ã�������ǰ����������档</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px">����Ŀ��</TD>
								<TD style="WIDTH: 433px; HEIGHT: 12px"><asp:textbox id="txtCallinMemo" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 12px">��δ����ǰ����ʱ������������ı�ע����д��ԭ���º��������롣</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 15px">��̸�ص�</TD>
								<TD style="WIDTH: 433px; HEIGHT: 15px"><asp:textbox id="txtTalkPlace" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 15px">�����ÿ����������Ӵ���Ա������ȫԱ���롣��ϯ��Ա�϶�Ļ���������������</TD>
							</TR>
							<TR>
								<TD>�Ӵ�����</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtVisitDept" runat="server" Width="344px"></asp:textbox></TD>
								<TD>��ֻ��JDI�ڲ���Ա�μӵĻ�͵ȣ�ԭ���ϸ��˳е����á�</TD>
							</TR>
							<TR>
								<TD>�Ӵ���Ա</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtVisitPerson" runat="server" Width="344px"></asp:textbox></TD>
								<TD>�����ͽӴ�ʱ�Ļ�ͳ�ϯ��Ա��ԭ��������1������˾�Ӵ���Ա1������ԭ���Ϲ�˾�Ӵ���Ա���ܶ�������������</TD>
							</TR>
							<TR>
								<TD>�Ӵ�������ϵ��ʽ</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtvisitphone" runat="server" Width="344px"></asp:textbox></TD>
								<TD>�޽�ֹʹ�ö��λᣨ����OK�ȣ����ʷѡ�</TD>
							</TR>
							<TR>
								<TD>��ز���</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtRelationDept" runat="server" Width="344px"></asp:textbox></TD>
								<TD>�������κ����ɣ���ֹ�Ӵ���������������������Ա��</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px">��ˮ׼��</TD>
								<TD style="WIDTH: 433px; HEIGHT: 20px"><asp:checkbox id="chbTea" runat="server" Text="��Ҫ/����Ҫ"></asp:checkbox></TD>
								<TD style="HEIGHT: 20px"></TD>
							</TR>
							<TR>
								<TD>�ι۹���</TD>
								<TD style="WIDTH: 433px"><asp:checkbox id="chblookFactory" runat="server" Text="��/��"></asp:checkbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px">�ι�����</TD>
								<TD style="WIDTH: 433px; HEIGHT: 14px"><asp:textbox id="txtLookNum" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 14px"></TD>
							</TR>
							<TR>
								<TD>��Ͱ���</TD>
								<TD style="WIDTH: 433px"><asp:checkbox id="chbLunch" runat="server" Text="ʳ����/��"></asp:checkbox></TD>
								<TD>ʳ����� ���������ò������</TD>
							</TR>
							<TR>
								<TD>��������</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtOtherNeed" runat="server" Width="344px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px">��������</TD>
								<TD style="WIDTH: 433px; HEIGHT: 14px">��˾�ɳ���
									<asp:radiobutton id="RadioButton1" runat="server" Text="��" GroupName="carplan"></asp:radiobutton><asp:radiobutton id="RadioButton2" runat="server" Text="��" GroupName="carplan"></asp:radiobutton><asp:radiobutton id="RadioButton3" runat="server" Text="����" GroupName="carplan"></asp:radiobutton><asp:radiobutton id="RadioButton4" runat="server" Text="��" GroupName="carplan" Checked="True"></asp:radiobutton></TD>
								<TD style="HEIGHT: 14px">�ó� �����ó����絥��</TD>
							</TR>
							<TR>
								<TD>����Ҫ��</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtEspecialRequest" runat="server" Width="344px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD style="WIDTH: 433px"><asp:button id="btnCCSave" runat="server" Text="����" Width="64px" CssClass="inputbutton"></asp:button><asp:label id="Label12" runat="server" Width="248px" ForeColor="#0000C0" BackColor="White"></asp:label></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<BR>
						<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</P>
					<P><asp:panel id="Panel3" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
							runat="server">
							<gridwc:xpgrid id="XpGrid1" runat="server" Height="2px" width="100%" AllowSort="True" AllowPrint="True"
								AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="True" SelectKind="MulitLines"></gridwc:xpgrid>
						</asp:panel></P>
					<P>&nbsp;</P>
					<P>&nbsp;</P>
					</asp:panel>
					<P>&nbsp;</P>
				</TD>
			</TR>
			</TBODY></TABLE><INPUT id="HiddenLeft" style="Z-INDEX: 104; POSITION: absolute; TOP: 0px; LEFT: 320px"
				type="hidden" value="0" name="Hidden2" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 103; POSITION: absolute; TOP: 0px; LEFT: 160px" type="hidden"
				name="Hidden2" runat="server"> <INPUT id="Hidden1" style="Z-INDEX: 102; POSITION: absolute; TOP: 0px; LEFT: 0px" type="hidden"
				value="0" name="Hidden1" runat="server"> </FONT></form>
	</body>
</HTML>
