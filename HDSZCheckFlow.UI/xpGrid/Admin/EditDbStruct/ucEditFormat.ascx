<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.ucEditFormat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<p>&nbsp;</p>
<p>
<p align="center">
	<asp:RadioButtonList id="rblEditFormatType" RepeatColumns="5" AutoPostBack="True" runat="server">
		<asp:ListItem Value="1" Selected="True">普通</asp:ListItem>
		<asp:ListItem Value="2">复选框</asp:ListItem>
		<asp:ListItem Value="3">备注型</asp:ListItem>
		<asp:ListItem Value="4">编码表</asp:ListItem>
		<asp:ListItem Value="5">关联数据</asp:ListItem>
		<asp:ListItem Value="6">密码</asp:ListItem>
		<asp:ListItem Value="7">图片</asp:ListItem>
		<asp:ListItem Value="8">查询选择</asp:ListItem>
		<asp:ListItem Value="9">计算字段</asp:ListItem>
		<asp:ListItem Value="10">附件</asp:ListItem>
	</asp:RadioButtonList></p>
<asp:Panel id="pnlCheckbox" Runat="server" Visible="False">
	<P>复选框设置</P>
	<P>
		<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="400" align="center" border="0">
			<TR>
				<TD>显示文本：</TD>
				<TD>
					<asp:TextBox id="txtCBDisplaylabel" runat="server"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>选中时的值：</TD>
				<TD>
					<asp:TextBox id="txtCbCheckValue" runat="server"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>未选中时的值：</TD>
				<TD>
					<asp:TextBox id="txtCbUNCheckValue" runat="server"></asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel id="pnlCode" Runat="server" Visible="False">
	<P>编码表设置</P>
	<P>
		<TABLE id="Table3" cellSpacing="0" cellPadding="1" width="400" align="center" border="0">
			<TR>
				<TD><FONT face="宋体">请选择编码表：</FONT></TD>
			</TR>
			<TR>
				<TD>
					<asp:DropDownList id="ddlCodeList" runat="server"></asp:DropDownList></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<asp:Panel id="pnlLookup" Runat="server" Visible="False">
	<P>关联数据设置</P>
	<P>
		<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="530" align="center" border="0">
			<TR>
				<TD>关联查询：<br>返回2个字段</TD>
				<TD>
					<asp:TextBox id="txtLookSQL" runat="server" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>关联条件：</TD>
				<TD>
					<asp:TextBox id="txtLookCond" runat="server" TextMode="MultiLine" Columns="50" Rows="8"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>输入条件：</TD>
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
				<TD>缩略图长：</TD>
				<TD>
					<asp:TextBox id="txtImageWidth" runat="server">100</asp:TextBox></TD>
			</TR>
			<TR>
				<TD>缩略图宽：</TD>
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
				<TD>列数：</TD>
				<TD>
					<asp:TextBox id="txtColumnNum" runat="server">40</asp:TextBox></TD>
			</TR>
			<TR>
				<TD>行数：</TD>
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
				<TD>查询SQL语句：</TD>
				<TD>
					<asp:TextBox id="txtFindSql" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>输入参数字段：</TD>
				<TD>
					<asp:TextBox id="txtInputField" runat="server" TextMode="MultiLine" Columns="50" Rows="3"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>返回SQL语句：</TD>
				<TD>
					<asp:TextBox id="txtReturnSql" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox></TD>
			</TR>
			<TR>
				<TD>接收参数字段：</TD>
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
				<TD>计算表达式：</TD>
				<TD><asp:TextBox id="txtComputeFieldExpr" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox></TD>
			</TR>
		<tr>
<td>
编辑时显示：
	</td>
		<td><asp:CheckBox ID="cbComputeField" Runat=server Text="显示"></asp:CheckBox></td>
</tr>
</TABLE>
</P>
</asp:Panel>
<asp:Panel id="pnlAttachment" Visible="False" Runat="server">
	<P>
		<TABLE id="tblAttachment" align="center">
			<TR>
				<TD>下载连接显示内容：</TD>
				<TD>
					<asp:TextBox id="txtAttachment" runat="server" Columns="50"></asp:TextBox></TD>
			</TR>
		</TABLE>
	</P>
</asp:Panel>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="center">
			<asp:Button id="btnConfirmEditFormat" Runat="server" Text="确定" CssClass="InputButton"></asp:Button>&nbsp; 
			&nbsp; &nbsp;
			<asp:Button id="btnCancelEditFormat" Runat="server" Text="取消" CssClass="InputButton"></asp:Button></TD>
	</TR>
</TABLE>
<P>&nbsp;</P>
