<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.ucEditFormat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<p>&nbsp;</p>
<p>
<p align="center">
	<asp:RadioButtonList id="rblEditFormatType" RepeatColumns="5" AutoPostBack="True" runat="server">
		<asp:ListItem Value="1" Selected="True">��ͨ</asp:ListItem>
		<asp:ListItem Value="2">��ѡ��</asp:ListItem>
		<asp:ListItem Value="3">��ע��</asp:ListItem>
		<asp:ListItem Value="4">�����</asp:ListItem>
		<asp:ListItem Value="5">��������</asp:ListItem>
		<asp:ListItem Value="6">����</asp:ListItem>
		<asp:ListItem Value="7">ͼƬ</asp:ListItem>
		<asp:ListItem Value="8">��ѯѡ��</asp:ListItem>
		<asp:ListItem Value="9">�����ֶ�</asp:ListItem>
		<asp:ListItem Value="10">����</asp:ListItem>
	</asp:RadioButtonList></p>
<asp:Panel id="pnlCheckbox" Runat="server" Visible="False">
	<P>��ѡ������</P>
	<P>
		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
			<TR>
				<TD>��ʾ�ı���</TD>
				<TD>
					<asp:TextBox id="txtCBDisplaylabel" runat="server"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>ѡ��ʱ��ֵ��</TD>
				<TD>
					<asp:TextBox id="txtCbCheckValue" runat="server"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>δѡ��ʱ��ֵ��</TD>
				<TD>
					<asp:TextBox id="txtCbUNCheckValue" runat="server"></asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel id="pnlCode" Runat="server" Visible="False">
	<P>���������</P>
	<P>
		<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="400" align="center" border="0">
			<TR>
				<TD><FONT face="����">��ѡ������</FONT></TD>
			</TR>
			<TR>
				<TD>
					<asp:DropDownList id="ddlCodeList" runat="server"></asp:DropDownList></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel id="pnlLookup" Runat="server" Visible="False">
	<P>������������</P>
	<P>
		<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="530" align="center" border="0">
			<TR>
				<TD>������ѯ��<br>����2���ֶ�</TD>
				<TD>
					<asp:TextBox id="txtLookSQL" runat="server" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>����������</TD>
				<TD>
					<asp:TextBox id="txtLookCond" runat="server" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>����������</TD>
				<TD>
					<asp:TextBox id="txtInputLookFild" runat="server" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel ID="pnlImage" Visible="False" Runat="server">
	<P>
		<TABLE align="center">
			<TR>
				<TD>����ͼ����</TD>
				<TD>
					<asp:TextBox id="txtImageWidth" runat="server">100</asp:TextBox></TD>
			</TR>
			<TR>
				<TD>����ͼ��</TD>
				<TD>
					<asp:TextBox id="txtImageHeight" runat="server">80</asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel ID="pnlMemo" Visible="False" Runat="server">
	<P>
		<TABLE align="center">
			<TR>
				<TD>������</TD>
				<TD>
					<asp:TextBox id="txtColumnNum" runat="server">40</asp:TextBox></TD>
			</TR>
			<TR>
				<TD>������</TD>
				<TD>
					<asp:TextBox id="txtRowNum" runat="server">8</asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel id="pnlFindSql" Visible="False" Runat="server">
	<P>
		<TABLE id="tblFindSql" align="center">
			<TR>
				<TD>��ѯSQL��䣺</TD>
				<TD>
					<asp:TextBox id="txtFindSql" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>��������ֶΣ�</TD>
				<TD>
					<asp:TextBox id="txtInputField" runat="server" TextMode="MultiLine" Columns="50" Rows="3"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>����SQL��䣺</TD>
				<TD>
					<asp:TextBox id="txtReturnSql" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>���ղ����ֶΣ�</TD>
				<TD>
					<asp:TextBox id="txtRecieveField" runat="server" TextMode="MultiLine" Columns="50" Rows="3"></asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel id="pnlComputeField" Visible="False" Runat="server">
	<P>
		<TABLE id="tblComputeField" align="center">
			<TR>
				<TD>������ʽ��</TD>
				<TD><asp:TextBox id="txtComputeFieldExpr" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox></TD>
			</TR>
		<tr>
<td>
�༭ʱ��ʾ��
	</td>
		<td><asp:CheckBox ID="cbComputeField" Runat=server Text="��ʾ"></asp:CheckBox></td>
</tr>
</TABLE>
</P>
</asp:Panel>
<asp:Panel id="pnlAttachment" Visible="False" Runat="server">
	<P>
		<TABLE id="tblAttachment" align="center">
			<TR>
				<TD>����������ʾ���ݣ�</TD>
				<TD>
					<asp:TextBox id="txtAttachment" runat="server" Columns="50"></asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="center">
			<asp:Button id="btnConfirmEditFormat" Runat="server" Text="ȷ��" CssClass="InputButton"></asp:Button>&nbsp; 
			&nbsp; &nbsp;
			<asp:Button id="btnCancelEditFormat" Runat="server" Text="ȡ��" CssClass="InputButton"></asp:Button></TD>
	</TR>
</TABLE>
<P>&nbsp;</P>
