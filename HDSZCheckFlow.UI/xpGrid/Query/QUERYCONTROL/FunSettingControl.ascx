<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.FunSettingControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/script/date.js" type=text/JavaScript></script>
<script language="javascript">
<!--
	function CloseWindow()
	{
		var sValue = "<%=this.ReturnValue%>";
		if (sValue.length>0)
		{
			var a = new Array();
			a[0] = sValue;
			a[1] = "<%=this.ReturnCaption%>";
			a[2] = "<%=this.ReturnDataType%>";
			window.returnValue = a;
			window.close();
		}
	}
	
	CloseWindow();
//-->
</script>
<FONT face="宋体">
	<TABLE id="Table1" BORDER="1" CELLSPACING="0" CELLPADDING="2" borderColor="#99ccff" width="100%">
		<TR>
			<TD width="20%">相关函数</TD>
			<TD width="80%">
				<asp:DropDownList id="ddlFunList" runat="server" Width="160px" AutoPostBack="True"></asp:DropDownList></TD>
		</TR>
		<TR>
			<TD>对应参数</TD>
			<TD>
				<asp:DataGrid CssClass="gridborder" id="grdParams" runat="server" AutoGenerateColumns="False" BorderColor="LightSkyBlue" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3" GridLines="Vertical">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="DodgerBlue"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#F7FAFF"></AlternatingItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#E1F3FF"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#99CCFF"></HeaderStyle>
					<FooterStyle ForeColor="Black" BackColor="#99CCFF"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="ParameterName" HeaderText="参数名称">
							<HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DataType" HeaderText="数据类型">
							<HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="参数数值">
							<HeaderStyle HorizontalAlign="Center" Width="40%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox ID="txtValue" Runat="server"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid></TD>
		</TR>
	</TABLE>
</FONT>
<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD align="middle"><FONT face="宋体">
				<asp:ImageButton id="btnOK" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/queding.gif"></asp:ImageButton></FONT></TD>
		<TD align="middle"><FONT face="宋体"><IMG class="btnEnable" id="btnCancel" alt="" src="<%=ApplicationPath%>xpGrid/images/quxiao.gif" runat="server" onclick="javascript:window.close();"></FONT></TD>
	</TR>
</TABLE>
<script language="javascript">
<!--
	<%=_sAlertExp%>
//-->
</script>
