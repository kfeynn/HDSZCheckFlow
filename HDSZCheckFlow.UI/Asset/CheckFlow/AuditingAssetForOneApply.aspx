<%@ Page language="c#" Codebehind="AuditingAssetForOneApply.aspx.cs"    AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.AuditingAssetForOneApply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function showDisplay(type)
		{
			if(document.all(type).style.display=='none')
			{
			    //document.all(type).style.display='block';
				//���½���ȸ��������ʾ����
				document.all(type).style.display='';   
				document.all(type).style.display='table-row';
				
				
			}
			else
			{
				document.all(type).style.display='none';
			}
		} 
		</script>
		<style type="text/css">
			 
			#txtPosital { resize: none }
			 
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">������Ϣ</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">�� �� ��:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����"><asp:label id="lblSheetNo" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">�������:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����">
							<asp:Label id="lblBudgetType" runat="server" Width="112px"></asp:Label></FONT>
					</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">������Ŀ:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����"><asp:label id="lblSubject" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">��������:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����"><asp:label id="lblApplyType" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">�᰸���ż���Ա:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����"><asp:label id="lblDpteAndPerson" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">��������:</td>
					<td style="WIDTH: 30%"><FONT face="����"><asp:label id="lblApplyDate" runat="server"></asp:label></FONT></td>
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 10%" align="right">��������:</td>
					<td style="WIDTH: 12.21%"><FONT face="����"><asp:label id="lblDeliveryDate" runat="server"></asp:label></FONT></td>
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 10%" align="right">�ʱ��:</td>
					<td style="WIDTH: 20%"><FONT face="����"><asp:label id="lblSubmitDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">���(RMB):</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����"></FONT><asp:label id="lblMoney" runat="server"></asp:label></td>
				</tr>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right"><FONT face="����">�᰸���ɼ�Ч��:</FONT></TD>
					<TD style="WIDTH: 80%" colSpan="5">
						<asp:Label style="Z-INDEX: 0" id="lblReasonEffect" runat="server"></asp:Label></TD>
				</TR>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">Ԥ�����</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 16px" align="right"><SPAN id="Label2">Ԥ����(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="����"><asp:label id="lblBudget" runat="server"></asp:label></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label4">//׷�ӽ��</SPAN>:</td>
					<td style="WIDTH: 80%" colSpan="5"></td>
				</tr>-->
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Span1">Ԥ������(RMB)</SPAN>:</TD>
					<TD style="WIDTH: 80%; HEIGHT: 23px" colSpan="5">
						<asp:label id="lblOutMoney" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right"><SPAN id="Label5">�Ѿ�ʹ��(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����">
							<asp:HyperLink id="hlSumCheck" runat="server"></asp:HyperLink></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Label3">��̯���(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><FONT face="����"><asp:label id="lblready" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 22px" align="right"><SPAN id="Label7">����ʹ��(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 22px" colSpan="5"><FONT face="����"><asp:label id="lblSheetMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td align="right">ʣ ��(RMB):</td>
					<td style="HEIGHT: 23px" align="left" colSpan="5"><FONT face="����"></FONT><asp:label id="lblLeft" runat="server"></asp:label><A href="./AttachFiles/hilly/72691351/bug.txt" target="_blank"></A></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('bodyInfo')" href="javascript:void(0)">��ϸ��</A></td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: none; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:datagrid id="dgApplyBody" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
										AutoGenerateColumns="False">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="SubjectName" HeaderText="��������"></asp:BoundColumn>
											<asp:BoundColumn DataField="InventoryName" HeaderText="��Ʒ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InvType" HeaderText="����ͺŻ�ͼֽ"></asp:BoundColumn>
											<asp:BoundColumn DataField="UnitName" HeaderText="��λ"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҵ���" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="��׼����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbPrice" HeaderText="RMB����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbMoney" HeaderText="RMB�ܼ�" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('postail')" href="javascript:void(0)">�������</A></td>
				</tr>
				<tr id="postail" style="DISPLAY: none; HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="����">
							<asp:datagrid style="Z-INDEX: 0" id="dgPostail" runat="server" Width="100%" AutoGenerateColumns="False"
								BackColor="White" BorderColor="#93BEE2">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
									BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="������">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Checkdate" HeaderText="����ʱ��">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IsAgree" HeaderText="��������">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CheckComment" HeaderText="���">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('AnnexInfo')" href="javascript:void(0)">����(<%=NumOfAnnex%>)</A>&nbsp;&nbsp; 
						<!--<A onclick="window.showModalDialog('../../BaseData/Commons/AnnexInfoShow.aspx?applyHeadPk=<%=applyHeadPk%>','','dialogWidth=800px;dialogHeight=770px;status=no;help=no;scrollbars:no;')" href="#">
							�鿴</A>-->
					</td>
				</tr>
				<tr id="AnnexInfo" style="DISPLAY: none; HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="����"><asp:table id="tbAnnex" runat="server" Width="100%" Font-Size="12px"></asp:table></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px; BACKGROUND-COLOR: #e8f4ff">
					<td style="WIDTH: 19.67%" align="center">������</td>
					<td style="WIDTH: 20%" align="center">����ʱ��</td>
					<td style="WIDTH: 10%" align="center">��������</td>
					<td style="WIDTH: 50%" align="left" colspan="3">��������</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%" align="center"><FONT face="����">zyq</FONT></td>
					<td style="WIDTH: 20%" align="center"><FONT face="����">��˺��������´˼�¼</FONT></td>
					<td style="WIDTH: 10%" align="center"><FONT face="����">tongyi/fandui</FONT></td>
					<td style="WIDTH: 50%" align="left" colspan="3"><FONT face="����">�����Ķ���̫�࣡</FONT></td>
				</tr>-->
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">�������</td>
				</tr>
				<tr>
					<td style="WIDTH: 19.67%" vAlign="top" align="right">�������:</td>
					<td align="left" colSpan="5"><asp:textbox id="txtPosital" runat="server" Width="70%" Height="100px" TextMode="MultiLine" Rows="8"
							Columns="100"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 19.67%" align="right"><FONT face="����"></FONT></td>
					<td align="left" colSpan="5"><FONT face="����"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td colSpan="6"><asp:button id="btnAgree" runat="server" Width="72px" CssClass="redButtonCss" Text="ͬ��"></asp:button><asp:button id="btnRefuse" runat="server" Width="72px" CssClass="redButtonCss" Text="�ܾ�"></asp:button><asp:button id="btnGoBack" runat="server" Width="72px" CssClass="redButtonCss" Text="����"></asp:button></td>
				</tr>
				<tr>
					<td align="left" colSpan="6" height="32"><FONT face="����"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
