<%@ Register TagPrefix="uc1" TagName="ConditionEditControl" Src="ConditionEditControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ConditionShowControl" Src="ConditionShowControl.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.QuerySaverEditControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<script language="javascript" src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/controls.js" type="text/javascript"></script>
<script language="javascript">
<!--
	function Delete()
	{
		var hidDelete  = document.all("<%=hidDelete.ClientID%>");
		var frm = hidDelete.form;
		
		if (DeleteAlert(frm,"chkItem"))
		{
			hidDelete.value = "1";
			frm.submit();
		}
		 
	}
	function DeleteAlert(frm, chkName)
	{
		//count
		var nCount=0;
		for(var i=0;i< frm.length;i++)
		{
			e=frm.elements[i];
			if ( e.type=='checkbox' && e.name.indexOf(chkName) != -1 )
			{
				if (e.checked==true)
				{
					
					nCount++;
				}	
			}
		}
		
		
		if (nCount==0)
		{
			alert("�Բ�����û��ѡ����Ҫɾ������Ŀ�����ܹ�����ɾ����");
			return false;
		}
		
		return confirm("��ȷ��Ҫɾ����صļ�¼��");

	}
	
	function SaverEditor_CloseWindow()
	{
		//ReturnResult();
		window.close();
	}	
	
	function ReturnResult()
	{
		var nReturn = <%=this.Updated%>;
		
		if (nReturn ==1 && window.returnValue == null)
		{
			var aReturn = new Array();
			aReturn[0] = 1;
			aReturn[1] = <%=this.SaverID%>;
			aReturn[2] = "";
			
			window.returnValue = aReturn;
			
		}

	}	
//-->
</script>
<asp:Panel id="pnlEdit" runat="server" Width="100%">
	<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD width="80%">��������
				<asp:TextBox id="txtCaption" runat="server"></asp:TextBox>
				<asp:CheckBox id="chkShare" runat="server" Text="����"></asp:CheckBox></TD>
			<TD align="right" width="20%"></TD>
		</TR>
	</TABLE>
	<uc1:ConditionEditControl id="ctlEditor" runat="server"></uc1:ConditionEditControl>
	<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD>
				<asp:Label id="lblExistForeignTables" runat="server" CssClass="xiao" Visible="False">���ѡ�������¹������е��ֶν����������ã����ܹ����棺</asp:Label></TD>
		</TR>
		<TR>
			<TD></TD>
		</TR>
	</TABLE>
</asp:Panel>
<asp:Panel id="pnlList" runat="server" Width="100%">
	<BR>
	<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD>
				<asp:datagrid id="grdList" Width="100%" runat="server" CssClass="gridborder" GridLines="Vertical" CellPadding="3" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="LightSkyBlue" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="DodgerBlue"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="#F7FAFF"></AlternatingItemStyle>
					<ItemStyle ForeColor="Black" BackColor="#E1F3FF"></ItemStyle>
					<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#99CCFF"></HeaderStyle>
					<FooterStyle ForeColor="Black" BackColor="#99CCFF"></FooterStyle>
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Top"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
							<HeaderTemplate>
								<input type="checkbox" id="chkAll" value="Y" onclick="CheckAll(this,'chkItem');" runat="server">
							</HeaderTemplate>
							<ItemTemplate>
								<input type="checkbox" id="chkItem"  value='<%# DataBinder.Eval(Container.DataItem, "SaverID","{0}") %>'  runat="server"  onclick="UnCheck(this,'chkAll');" >
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:ButtonColumn Text="��ť" DataTextField="Caption" HeaderText="��������">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						</asp:ButtonColumn>
						<asp:BoundColumn HeaderText="����">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
					</Columns>
				</asp:datagrid></TD>
		</TR>
		<TR>
			<TD>
				<INPUT id="hidDelete" type="hidden" value="Hello" name="hidDelete" runat="server">&nbsp;&nbsp; 
				[���˹���ķ�������ɾ��]</TD>
		</TR>
	</TABLE>
</asp:Panel>
<br>
<TABLE id="Table5" cellSpacing="0" cellPadding="0" border="0">
	<TR>
		<TD><asp:ImageButton id="btnSave" runat="server"></asp:ImageButton></TD>
		<td><asp:ImageButton id="btnSearch" runat="server"></asp:ImageButton></td>
		<td><IMG class="btnEnable" id="btnDelete" onclick="Delete()" runat="server"></td>
		<td><asp:ImageButton id="btnAdd" runat="server"></asp:ImageButton></td>
		<td><asp:ImageButton id="btnList" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/chakanlb.gif"></asp:ImageButton></td>
		<td><IMG class="btnEnable" id="btnClose" alt="" src="<%=ApplicationPath%>xpGrid/images/guanbi.gif" runat="server" onclick="SaverEditor_CloseWindow();"></td>
	</TR>
</TABLE>
<br>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD>
			<asp:Label id="lblMessage" runat="server" CssClass="ErrorLabel"></asp:Label></TD>
	</TR>
</TABLE>
