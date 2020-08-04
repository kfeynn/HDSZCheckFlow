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
					<TD><FONT face="宋体">选择本地excel文件。先预览，确认无误后再确认入库</FONT><A style="COLOR: gray" title="查看导入Excel格式" onclick="javascript:showDisplay('postail')"
							href="javascript:void(0)">查看导入格式</A></TD>
					<TD></TD>
					<TD><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
					<TD></TD>
				</TR>
				<TR id="postail" style="DISPLAY: none; ">
					<TD colspan="4">字段 ： NO 管理编号 部门名称 科组 部门编码 科组编码 存货编码 存货名称 购入日期 数量 币种 价格 备注 存放地点 
						管理责任人 责任人工号</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 16px"><INPUT style="WIDTH: 400px; HEIGHT: 21px" id="File1" size="47" type="file" name="File1"
							runat="server"></TD>
					<TD style="HEIGHT: 16px"><asp:button id="btnLook" runat="server" CssClass="InputButton" Text="预览"></asp:button></TD>
					<TD style="HEIGHT: 16px"><asp:dropdownlist id="DropDownList1" runat="server">
							<asp:ListItem Value="0">选择入库类型</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">小额固定资产</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:button id="btnAdd" runat="server" CssClass="InputButton" Text="确认入库"></asp:button></TD>
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
