<%@ Page language="c#" Codebehind="FinallyCheckApplyForOneApply.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.FinallyCheckApplyForOneApply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style/BasicLayout.css">
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
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				id="tabDispDocument" class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center">������Ϣ</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">�� �� ��:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����">
							<asp:HyperLink style="Z-INDEX: 0" id="hlApplySheetNo" runat="server"></asp:HyperLink></FONT></td>
				</tr>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">�������:</TD>
					<TD style="WIDTH: 80%" colSpan="5"><FONT face="����"><asp:label id="lblBudgetType" runat="server" Width="112px"></asp:label></FONT></TD>
				</TR>
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
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center">Ԥ�����</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 16px" align="right"><SPAN id="Label2">��ͬ��:</SPAN></td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="����"><asp:label id="lblBargainNo" runat="server"></asp:label></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label4">//׷�ӽ��</SPAN>:</td>
					<td style="WIDTH: 80%" colSpan="5"></td>
				</tr>-->
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right">Ҫ�󽻻�����:</TD>
					<TD style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><asp:label id="lblRequestDate" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">��������:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="����">
							<asp:label style="Z-INDEX: 0" id="lblPayForArticle" runat="server"></asp:label></FONT></td>
				</tr>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right"><FONT face="����">ó������:</FONT></TD>
					<TD style="WIDTH: 80%" colSpan="5"><FONT face="����">
							<asp:label style="Z-INDEX: 0" id="lblTradeAgreement" runat="server"></asp:label></FONT></TD>
				</TR>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right"><FONT face="����">���ղ���:</FONT></TD>
					<TD style="WIDTH: 80%" colSpan="5">
						<asp:label style="Z-INDEX: 0" id="lblCheckDept" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Label3">��ע˵��</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><FONT face="����"><asp:label id="lblReMark" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><A onclick="javascript:showDisplay('bodyInfo')" href="javascript:void(0)">��ϸ��</A></td>
				</tr>
				<tr style="DISPLAY: none; HEIGHT: 22px" id="bodyInfo">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" colSpan="6" align="center">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>
									<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApplyBody" runat="server" Width="99%" BorderColor="#93BEE2"
										BackColor="White" AutoGenerateColumns="False" PageSize="20" AllowSorting="True">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="AssetType"></asp:BoundColumn>
											<asp:BoundColumn DataField="SubjectName" HeaderText="��Ŀ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InventoryName" HeaderText="��Ʒ����"></asp:BoundColumn>
											<asp:BoundColumn DataField="InvType" HeaderText="����ͺ�"></asp:BoundColumn>
											<asp:BoundColumn DataField="UnitName" HeaderText="��λ"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="����" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="exchangeRate" HeaderText="����" DataFormatString="{0:N3}"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="�۸�" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbPrice" HeaderText="Rmb�۸�" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbMoney" HeaderText="Rmb�ܼ�" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Offer" HeaderText="��Ӧ��"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><A onclick="javascript:showDisplay('postail')" href="javascript:void(0)">�������</A></td>
				</tr>
				<tr style="DISPLAY: none; HEIGHT: 28px" id="postail">
					<td style="WIDTH: 100%" colSpan="6" align="center"><FONT face="����"><asp:datagrid style="Z-INDEX: 0" id="dgPostail" runat="server" Width="100%" AutoGenerateColumns="False"
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
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><A onclick="javascript:showDisplay('AnnexInfo')" href="javascript:void(0)">����(<%=NumOfAnnex%>
							)</A>&nbsp;
					</td>
				</tr>
				<tr style="DISPLAY: none; HEIGHT: 28px" id="AnnexInfo">
					<td style="WIDTH: 100%" colSpan="6" align="center"><FONT face="����"><asp:table id="tbAnnex" runat="server" Width="100%" Font-Size="12px"></asp:table></FONT></td>
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
				<tr>
					<td style="WIDTH: 19.67%" align="right"><FONT face="����"></FONT><FONT face="����"></FONT></td>
					<td colSpan="5" align="left"><FONT face="����"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td colSpan="6"><INPUT style="Z-INDEX: 0; WIDTH: 66px; HEIGHT: 20px" id="retrunBack" class="redButtonCss"
							onclick="javascript:history.go(-1);" value="����" type="button" name="retrunBack"></td>
				</tr>
				<tr>
					<td height="32" colSpan="6" align="left"><FONT face="����"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
