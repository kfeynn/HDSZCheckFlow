<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="AddEvection.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.Evection.AddEvection" %>
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
//        }


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
				<TABLE id="Table2" style="Z-INDEX: 100; POSITION: absolute; TOP: 40px; LEFT: 40px" cellSpacing="1"
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
								<asp:DropDownList id="ddlEvection" runat="server" Width="138px"></asp:DropDownList>
								<asp:Button id="btnEditEvection" runat="server" Text="�޸ĵ���"></asp:Button>
							</td>
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
											<TD>&nbsp;</TD>
											<TD colSpan="3"><asp:label id="lblMessage" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD style="COLOR: #ff9966">��������</TD>
											<TD><asp:dropdownlist id="ddlApplyType" runat="server" AutoPostBack="True" ForeColor="Transparent" BackColor="White"></asp:dropdownlist></TD>
											<TD style="WIDTH: 68px; COLOR: #ff9966">��������</TD>
											<TD><asp:textbox id="txtDate" onfocus="WdatePicker()" runat="server" Width="80px"></asp:textbox></TD>
											<TD style="COLOR: #ff9966">���벿��</TD>
											<TD><asp:dropdownlist id="ddlDeptClass" runat="server" AutoPostBack="True" Width="80px"></asp:dropdownlist></TD>
											<TD style="COLOR: #ff9966">�������</TD>
											<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
											<td>&nbsp;</td>
										</TR>
										<TR>
											<td style="COLOR: #ff9966">һ����Ŀ</td>
											<td><asp:dropdownlist id="ddlFirstSubject" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
											<TD style="COLOR: #ff9966">�����Ŀ</TD>
											<TD colspan="3"><asp:dropdownlist id="ddlSubject" runat="server" Width="303px"></asp:dropdownlist></TD>
			</FONT>
			<TD></TD>
			<TD></TD>
			<TD>&nbsp;</TD>
			</TR>
			<TR><%--onkeyup="javascript:ShowUserName(this)"--%>
				<TD style="HEIGHT: 18px"><FONT face="����" color="#ff9966"><FONT face="Times New Roman" color="#ff9966">����</FONT>�˹���</FONT></TD>
				<TD style="HEIGHT: 18px"><asp:textbox id="txtPerson"  runat="server" Width="80px"></asp:textbox></TD>
				<TD style="HEIGHT: 18px">��&nbsp;&nbsp;&nbsp; ��</TD>
				<TD style="HEIGHT: 18px"><asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px"></asp:textbox></TD>
				<TD style="WIDTH: 67px; HEIGHT: 18px">�� �� ��</TD>
				<TD style="HEIGHT: 18px">&nbsp;<asp:label id="Label9" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 18px">&nbsp;�ύ����</TD>
				<TD style="HEIGHT: 18px">&nbsp;<asp:label id="Label10" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 18px">&nbsp;</TD>
			</TR>
			<TR>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD style="WIDTH: 67px">&nbsp;</TD>
				<TD><asp:button id="btnAdd" runat="server" Text="���" Width="72px" CssClass="inputButton"></asp:button></TD>
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
								<asp:label id="Label13" runat="server" Visible="False">Ԥ������</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label7" runat="server" Visible="False">����ʹ��</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:Label style="Z-INDEX: 0" id="Label14" runat="server">���ݵ���</asp:Label></TD>
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
				<TD>
					<asp:label id="Label1" runat="server" Visible="False" Font-Size="16px">��ӵ�����ϸ��</asp:label>
				</TD>
			</TR>
			<TR>
				<TD>
					<P><asp:panel id="panel1" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
							Visible="False" Width="100%" Runat="server" Height="521"></P>
					<P><BR>
						&nbsp;&nbsp;&nbsp;&nbsp;<FONT color="#ff9966">��ʼ���ڣ�</FONT>
						<asp:textbox id="txtDateFrom" onfocus="WdatePicker({skin:'whyGreen', maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
							runat="server" Width="88px"></asp:textbox>&nbsp;<FONT color="#ff9966">�������ڣ�</FONT>
						<asp:textbox id="txtDateTo" onfocus="WdatePicker({skin:'whyGreen', minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
							runat="server" Width="88px"></asp:textbox>&nbsp;<FONT color="#ff9966">������У�</FONT>
						<asp:textbox id="txtGocity" runat="server" Width="200px"></asp:textbox>&nbsp;<BR>
						<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;�������ͣ�&nbsp;
						<asp:dropdownlist id="ddlCCType" runat="server">
							<asp:ListItem Value="����">����</asp:ListItem>
							<asp:ListItem Value="����">����</asp:ListItem>
						</asp:dropdownlist>
						<asp:Label id="Label11" runat="server">Label</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���÷ѵȼ�:&nbsp;&nbsp;
						<asp:textbox id="txtAppclass" runat="server" Width="80px"></asp:textbox>&nbsp;&nbsp; 
						ͬ��������&nbsp;
						<asp:textbox id="txtwithapps" runat="server" Width="80px"></asp:textbox>&nbsp;
					</P>
					<P>&nbsp;&nbsp;&nbsp; ͬ �� �ˣ�&nbsp;&nbsp;
						<asp:textbox id="txtWithwho" runat="server" Width="576px"></asp:textbox></P>
					<P>&nbsp;&nbsp;&nbsp;&nbsp; �������ɣ�
						<asp:textbox id="txtCCMemo" runat="server" Width="432px" Height="82px" TextMode="MultiLine"></asp:textbox></P>
					<P>&nbsp;&nbsp;&nbsp;<FONT color="green">ע��:���Ϻ�ɫ��ĿΪ������Ŀ������Ϊ����������Ŀ�����ڳ���������д</FONT>
					</P>
					<P><asp:panel id="Panel2" runat="server" Height="164px" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px">
							<P>&nbsp; ǰ�γ������ڣ�
								<asp:TextBox id="txtPreabound" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
									runat="server" Width="112px"></asp:TextBox>ǰ�λع����ڣ�
								<asp:TextBox id="txtPreback" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
									Width="112px"></asp:TextBox>&nbsp;VIsa��
								<asp:CheckBox id="chbVisa" runat="server" Text="��/��"></asp:CheckBox>&nbsp;VIsa��Ч�ڣ�
								<asp:TextBox id="txtVisaDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
									Width="112px"></asp:TextBox></P>
							<P></P>
							<P>&nbsp; ���գ�
								<asp:CheckBox id="chkPassport" runat="server" Text="��/��"></asp:CheckBox>&nbsp;���պţ�&nbsp;
								<asp:TextBox id="txtPassportno" runat="server" Width="184px"></asp:TextBox>&nbsp;������Ч�ڣ�
								<asp:TextBox id="txtpassportdate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
									runat="server"></asp:TextBox></P>
							<P>&nbsp;����ע�䣺
								<asp:CheckBox id="chbbacterin" runat="server" Text="��/��"></asp:CheckBox>������Ч�ڣ�
								<asp:TextBox id="txtbacterindate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
									runat="server"></asp:TextBox></P>
							<P>&nbsp;��ע���
								<asp:TextBox id="txtabountMemo" runat="server" Width="552px" Height="92px" TextMode="MultiLine"></asp:TextBox></P>
							<P>&nbsp;�Ƿ�Я��������Ʒ:
								<asp:CheckBox id="chblimit" runat="server" Text="��/��"></asp:CheckBox>�Ƿ��ṩ���Ƽ���(�������ϵ�)��
								<asp:CheckBox id="chblimits" runat="server" Text="��/��"></asp:CheckBox>����ǰ���:
								<asp:CheckBox id="chbcheckup" runat="server" Text="Ҫ/��"></asp:CheckBox></P>
							<P>�Ƿ���ϳ�����������:
								<asp:CheckBox id="chbmeet" runat="server" Text="����/������"></asp:CheckBox>�������(�ƻ�):
								<asp:TextBox id="txtcheckupplan" runat="server" Width="168px"></asp:TextBox></P>
							<P><FONT color="green">&nbsp;&nbsp; ע��:1������ʱ��һ��������������졣2������ʱ�䳬��31����ֹͣ����ͨ�ڲ�����</FONT></P>
							<P>
						</asp:panel><BR>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnCCSave" runat="server" Text="����" Width="64px" CssClass="inputbutton"></asp:button>
						<asp:Label id="Label12" runat="server" ForeColor="#0000C0" BackColor="White"></asp:Label></P>
					<P><asp:panel id="Panel3" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
							runat="server">
							<gridwc:xpgrid id="XpGrid1" runat="server" Height="2px" width="100%" AllowSort="True" AllowPrint="True"
								AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="True" SelectKind="MulitLines"></gridwc:xpgrid>
						</asp:panel></P>
					<P>&nbsp;</P>
					<P></asp:panel></P>
					<P>&nbsp;</P>
				</TD>
			</TR>
			</TBODY></TABLE> <INPUT id="HiddenLeft" style="Z-INDEX: 104; POSITION: absolute; TOP: 0px; LEFT: 320px"
				type="hidden" value="0" name="Hidden2" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 103; POSITION: absolute; TOP: 0px; LEFT: 160px" type="hidden"
				name="Hidden2" runat="server"> <INPUT id="Hidden1" style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 0px" type="hidden"
				value="0" name="Hidden1" runat="server"> </FONT></form>
	</body>
</HTML>
