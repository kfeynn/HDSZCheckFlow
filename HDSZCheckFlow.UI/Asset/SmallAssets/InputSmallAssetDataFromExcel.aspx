<%@ Page language="c#" Codebehind="InputSmallAssetDataFromExcel.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.SmallAssets.InputSmallAssetDataFromExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InputBaseDataFromExcel</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<script language="javascript">
		function showDisplay(type)
		{
			if(document.all(type).style.display=='none')
			{
				document.all(type).style.display='block';
			}
			else
			{
				document.all(type).style.display='none';
			}
		} 
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; TOP: 48px; LEFT: 80px" id="Table1" border="1"
				cellSpacing="1" cellPadding="1" width="80%">
				<TR>
					<TD><FONT face="����">ѡ�񱾵�excel�ļ�����Ԥ����ȷ���������ȷ�����</FONT><A style="COLOR: gray" title="�鿴����Excel��ʽ" onclick="javascript:showDisplay('postail')"
							href="javascript:void(0)">�鿴�����ʽ</A></TD>
					<TD></TD>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					<TD></TD>
				</TR>
				<TR id="postail" style="DISPLAY: none; ">
					<TD colspan="4">�ֶ� �� NO ������ �������� ���� ���ű��� ������� ������� ������� �������� ���� ���� �۸� ��ע ��ŵص� 
						���������� �����˹���</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px"><INPUT style="WIDTH: 400px; HEIGHT: 21px" id="File1" size="47" type="file" name="File1"
							runat="server"></TD>
					<TD style="HEIGHT: 16px"><asp:button id="btnLook" runat="server" CssClass="InputButton" Text="Ԥ��"></asp:button></TD>
					<TD style="HEIGHT: 16px"><asp:dropdownlist id="DropDownList1" runat="server">
							<asp:ListItem Value="0">ѡ���������</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">С��̶��ʲ�</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:button id="btnAdd" runat="server" CssClass="InputButton" Text="ȷ�����"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:datagrid id="dgGrid" runat="server" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None"
							BorderColor="#CCCCCC" Width="100%">
							<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
							<ItemStyle ForeColor="#000066"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
