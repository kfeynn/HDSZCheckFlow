<%@ Page language="c#" Codebehind="AddPriceCheckApply_Setp2.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.AddPriceCheckApply_Setp2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddAssetApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style/Style.css">
		<script type="text/javascript" language="javascript" src="../../Style/JS/jquery-1.7.1.min.js"></script>
		<script language="javascript">
		function showDisplay(type)
		{
			//չ��������ʾ����
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
		<style type="text/css">TD { }
	.EditCell_TextBox { BORDER-BOTTOM: #0099cc 1px solid; BORDER-LEFT: #0099cc 1px solid; WIDTH: 90%; BORDER-TOP: #0099cc 1px solid; BORDER-RIGHT: #0099cc 1px solid }
	.EditCell_DropDownList { WIDTH: 90% }
	.CellO { DISPLAY: none }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tblToolBar" border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080"
				align="center">
				<tr>
					<td class="tdButtonBar">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="90%">��Ӫ��������<asp:label id="lbMsg" runat="server" ForeColor="Red"></asp:label></td>
								<TD style="PADDING-RIGHT: 5px" width="10%" align="right"></TD>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!--��������������-->
			<table style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td height="5" align="left"><asp:button style="Z-INDEX: 0" id="btnInBudget" runat="server" Text="�ύ�۸�þ�" CssClass="ButtonFlat"></asp:button><FONT face="����">&nbsp;&nbsp;&nbsp;
						</FONT>
					</td>
				</tr>
			</table>
			<!--��ѯ������ʼ-->
			<table id="tblSearch" class="TableSearch2" border="0" cellSpacing="1" cellPadding="0" width="100%"
				align="center">
				<tr height="25">
					<td align="right"><FONT face="����">�� ͬ �ţ�</FONT></td>
					<td><FONT face="����"><asp:textbox style="Z-INDEX: 0" id="tbBargainNo" runat="server" Width="98%"></asp:textbox></FONT></td>
					<td align="right"><FONT face="����">����������</FONT></td>
					<td colSpan="3"><FONT face="����"><asp:textbox style="Z-INDEX: 0" id="tbPayForArticle" runat="server" Width="98%"></asp:textbox></FONT></td>
					<TD align="center"><FONT face="����"><asp:button style="Z-INDEX: 0" id="btnSave" runat="server" Text="��  ��" CssClass="inputbutton"></asp:button></FONT></TD>
					<td><FONT style="MARGIN-LEFT: 15px" face="����"><INPUT style="WIDTH: 48px; HEIGHT: 20px" class="inputbutton" onclick="javascript:history.go(-1);"
								value="�� ��" type="button"></FONT></td>
					<TD><FONT face="����"></FONT></TD>
					<td><FONT color="#336666" face="����"></FONT></td>
				</tr>
				<TR>
					<TD align="right">���ղ��ţ�</TD>
					<TD><FONT face="����">
							<asp:TextBox style="Z-INDEX: 0" id="txtCheckDept" runat="server" Width="98%"></asp:TextBox></FONT></TD>
					<TD align="right">ó�����</TD>
					<TD colSpan="3">
						<asp:TextBox style="Z-INDEX: 0" id="txtTradeAgreement" runat="server" Width="98%"></asp:TextBox></TD>
					<TD align="center"></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="Z-INDEX: 0" align="right"><FONT face="����">��&nbsp;&nbsp;&nbsp;&nbsp;ע��</FONT></TD>
					<TD colSpan="5"><asp:textbox id="tbRemark" runat="server" Width="99%"></asp:textbox></TD>
					<TD><FONT style="Z-INDEX: 0" face="����">�������ڣ�</FONT></TD>
					<TD><FONT face="����">
							<asp:textbox style="Z-INDEX: 0" id="txtRequestDate" onfocus=" WdatePicker()" runat="server"></asp:textbox></FONT></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<tr>
					<td width="8%" align="right">��&nbsp;&nbsp;&nbsp;&nbsp;�ͣ�</td>
					<td width="15%"><asp:dropdownlist id="ddlType" runat="server" Width="98%" Enabled="False"></asp:dropdownlist></td>
					<td width="8%" align="right">�������ڣ�</td>
					<td width="15%"><asp:textbox id="tbApplyDate" onfocus="WdatePicker({minDate:'%y-%M-{01}'})" runat="server" Width="98%"
							Enabled="False"></asp:textbox></td>
					<td style="PADDING-LEFT: 3px" width="8%" align="left">���벿�ţ�</td>
					<td width="15%"><asp:dropdownlist id="ddlClassDept" runat="server" Width="98%" Enabled="False" AutoPostBack="True"></asp:dropdownlist></td>
					<td style="PADDING-LEFT: 3px" width="8%" align="left">������飺</td>
					<td colSpan="2"><asp:dropdownlist id="ddlDept" runat="server" Width="98%" Enabled="False" AutoPostBack="True"></asp:dropdownlist></td>
					<td align="right"><FONT face="����"></FONT></td>
				</tr>
				<tr>
					<td align="right">��Ŀ���</td>
					<td><asp:dropdownlist id="ddlFirstSubject" runat="server" Width="98%" Enabled="False" AutoPostBack="True"></asp:dropdownlist></td>
					<td align="right"><!--�����Ŀ��--><FONT style="Z-INDEX: 0" face="����">�������ڣ�</FONT></td>
					<td><FONT face="����"><asp:textbox style="Z-INDEX: 0" id="tbDeliveryDate" onfocus=" WdatePicker()" runat="server" Width="98%"
								Enabled="False"></asp:textbox></FONT></td>
					<td><FONT face="����"></FONT></td>
					<td><FONT face="����"></FONT></td>
					<td style="PADDING-LEFT: 3px" width="90" align="left"><FONT face="����">�� �� �ˣ�</FONT></td>
					<td><FONT color="#336666" face="����"><asp:textbox id="tbPerson" runat="server" Width="100px" Enabled="False"></asp:textbox></FONT></td>
					<td><FONT color="#336666" face="����"></FONT></td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2"><FONT face="����">&nbsp; </FONT>
						<asp:hyperlink style="Z-INDEX: 0" id="hyLindToAnnex" runat="server" ForeColor="Red" Font-Bold="True"
							Font-Size="14px" Font-Underline="True">��Ӹ���</asp:hyperlink></td>
					<td align="right"><FONT face="����"></FONT></td>
					<td><FONT face="����"></FONT></td>
					<td style="PADDING-LEFT: 3px" colSpan="2"><FONT color="#336666" face="����">�� �� �ţ�
							<asp:label style="Z-INDEX: 0" id="lblApplyNo" runat="server" Width="64px"></asp:label></FONT></td>
					<td style="PADDING-LEFT: 3px"><FONT color="#336666" face="����">�Ƶ����ڣ�</FONT></td>
					<td colSpan="3"><FONT color="#336666" face="����"><asp:label style="Z-INDEX: 0" id="lblMakeDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr height="5">
					<td height="5" colSpan="10">
						<hr style="COLOR: lightgrey">
					</td>
				</tr>
				<TR style="PADDING-BOTTOM: 15px">
					<td colSpan="10" align="center"><asp:panel id="PBudgetInfo" runat="server">
							<TABLE border="0" cellSpacing="0" cellPadding="0" width="80%">
								<TR style="COLOR: #339966">
									<TD style="HEIGHT: 19px">
										<asp:label id="lbBudget" runat="server">Ԥ����</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbOutMoney" runat="server">Ԥ������</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbSumCheck" runat="server">�Ѿ�ʹ��</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label style="Z-INDEX: 0" id="lbready" runat="server">��̯���</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbSheetMoney" runat="server">����ʹ��</asp:label></TD>
									<TD style="HEIGHT: 19px">
										<asp:label id="lbLeft" runat="server">ʣ   ��</asp:label></TD>
								</TR>
								<TR style="COLOR: #333333">
									<TD>
										<asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblOutMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblSumCheck" runat="server"></asp:label></TD>
									<TD>
										<asp:label style="Z-INDEX: 0" id="lblready" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</TR>
			</table>
			<!--XPGrid ������ӱ���-->
			<p style="MARGIN-TOP: 8px"><asp:panel style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px"
					id="pAddItem" runat="server" Visible="true">
<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" bgColor="#808080" align="center">
						<TR>
							<TD class="tdButtonBar">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD width="100%">��ӵ�����ϸ��</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="aliceblue">
									<TR id="tbAddBody">
										<TD><FONT face="����"></FONT></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD bgColor="infobackground" width="100%"><FONT face="����">
									<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApply" runat="server" Width="99%" AutoGenerateColumns="False"
										AllowSorting="True" PageSize="20" BorderColor="#93BEE2" BackColor="White">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="FBID" HeaderText="FBID"></asp:BoundColumn>
											<asp:BoundColumn DataField="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InventoryName" HeaderText="��Ʒ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InvType" HeaderText="����ͺ�"></asp:BoundColumn>
											<asp:BoundColumn DataField="UnitName" HeaderText="��λ"></asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҵ���" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="originalMoney" HeaderText="ԭ�ҽ��" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="��׼����">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbPrice" HeaderText="���ҵ���" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="����" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbMoney" HeaderText="���ҽ��" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CheckNumber" HeaderText="�Ѳþ�����" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FCurrTypeCode" HeaderText="�þ�����">
												<ItemStyle BackColor="#999966"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FNumber" HeaderText="�þ�����" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right" BackColor="#999966"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FinallyPrice" HeaderText="�þ��۸�" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right" BackColor="#999966"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="offer" HeaderText="��Ӧ��">
												<ItemStyle BackColor="#999966"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
									</asp:datagrid></FONT></TD>
						</TR>
					</TABLE><FONT face="����"></FONT>&nbsp; </asp:panel></p>
			<INPUT style="Z-INDEX: 101; POSITION: absolute; TOP: 720px; LEFT: 88px" id="hideApplyCheckHead"
				runat="server" value="0" type="hidden" name="hideApplyCheckHead">
		</form>
		<script type="text/javascript" src="../../Style/JS/GridEdit.js"></script>
		<script language="javascript">
		
			//����JS����Gridʹ��˫���༭��
			var tabGrid   = document.getElementById("dgApply");
			// ���ñ��ɱ༭
			// ��һ�����ö�������磺EditTables(tb1,tb2,tb2,......)
			EditTables(tabGrid);

		</script>
	</body>
</HTML>
