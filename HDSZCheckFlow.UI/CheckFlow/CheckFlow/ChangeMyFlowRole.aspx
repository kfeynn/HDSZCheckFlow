<%@ Page language="c#" Codebehind="ChangeMyFlowRole.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ChangeMyFlowRole" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ChangeMyFlowRole</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript" type="text/javascript">
//		function ShowUserName(useCode)
//		{
//			var userName=HDSZCheckFlow.UI.CheckFlow.CheckFlow.ChangeMyFlowRole.GetUserNameByCode(useCode.value);
//			if(userName.length==0)
//			{}
//			else
//			{
//				document.getElementById("txtPersonName").innerText=userName.value;
//			}
		    //}
//		    onkeyup="javascript:ShowUserName(this)"



$(function() {
$("#txtPerson").keyup(function() {
alert(document.getElementById('txtPerson').value);
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
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����">
				<TABLE id="Table1" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 88px; POSITION: absolute; TOP: 64px"
					cellSpacing="0" cellPadding="0" width="80%" border="1" borderColor="#0066cc">
					<TR height="52">
						<TD align="left" bgcolor="#ccccff" colspan="2">������Ա��Ȩ�������ִ���ʽ.1.ת��Ȩ�޸�ĳ�� 2.��ʱ����Ȩ��. 
							���ߴ��������֮�󶼿�����ȡ��</TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">�ҵ�����Ȩ��:</TD>
						<TD><asp:Table id="tblMyRole" runat="server" Width="100%"></asp:Table></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">Ȩ��״̬:
						</TD>
						<TD><asp:Label id="lblRoleState" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">ת��Ȩ��:
						</TD>
						<TD><asp:textbox id="txtPerson"  runat="server" Width="80px"></asp:textbox>
							<asp:textbox id="txtPersonName" runat="server" Width="80px" Enabled="False" BackColor="#E0E0E0"></asp:textbox>
							<asp:Button id="btnSure" runat="server" Width="72px" Text="ȷ��" CssClass="redButtonCss"></asp:Button>
							<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">��ʱ��������:</TD>
						<TD>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Button id="btnGiveUp" runat="server" CssClass="redButtonCss" Text="��ʱ��������"></asp:Button></TD>
					</TR>
					<TR height="52">
						<TD style="WIDTH: 116px" align="right" bgcolor="#ccccff">����Ȩ��:
						</TD>
						<TD><asp:Button id="btnGetBackRole" runat="server" Text="�ջ�Ȩ��" CssClass="inputbutton"></asp:Button></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
