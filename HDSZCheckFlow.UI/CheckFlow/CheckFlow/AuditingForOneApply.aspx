<%@ Page language="c#" Codebehind="AuditingForOneApply.aspx.cs" AutoEventWireup="false"   Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.AuditingForOneApply" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
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
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%" align="right">�����Ŀ:</td>
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
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6">Ԥ�����</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 16px" align="right"><SPAN id="Label2">Ԥ����(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="����"><asp:label id="lblBudget" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 16px" align="right"><SPAN id="Label2">������(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="����"><asp:label id="lblPushMoney" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 23px" align="right"><SPAN id="Label3">�������(RMB)</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><FONT face="����"><asp:label id="lblChange" runat="server"></asp:label></FONT></td>
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
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 19.67%; HEIGHT: 22px" align="right">ʣ 
						��(RMB)</SPAN>:</td>
					<td style="HEIGHT: 23px" align="left" colSpan="5"><FONT face="����"></FONT><asp:label id="lblLeft" runat="server"></asp:label><A href="./AttachFiles/hilly/72691351/bug.txt" target="_blank"></A></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('bodyInfo')" href="javascript:void(0)">��ϸ��</A><FONT face="����">(����鿴��ϸ)</FONT></td>
				</tr>
				<tr id="bodyInfo" style="DISPLAY: none; HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" align="center" colSpan="6">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:datagrid style="Z-INDEX: 0" id="dgLBBody" runat="server" Width="100%" AutoGenerateColumns="False"
										BackColor="White" BorderColor="#93BEE2">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="invCode" HeaderText="���ϱ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="invName" HeaderText="Ʒ��"></asp:BoundColumn>
											<asp:BoundColumn DataField="INVSPEC" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="MEASNAME" HeaderText="��λ"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҵ���" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RMBPrice" HeaderText="RMB����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB�ܼ�" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Memo" HeaderText="��ע"></asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<asp:datagrid style="Z-INDEX: 0" id="dgApplyBody" runat="server" Width="100%" AutoGenerateColumns="False"
										BackColor="White" BorderColor="#93BEE2">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="invCode" HeaderText="���ϱ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="invName" HeaderText="Ʒ��"></asp:BoundColumn>
											<asp:BoundColumn DataField="INVSPEC" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="MEASNAME" HeaderText="��λ"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҵ���" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RMBPrice" HeaderText="RMB����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB�ܼ�" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Memo" HeaderText="��ע"></asp:BoundColumn>
											<asp:BoundColumn DataField="Dnoutnum" HeaderText="������������">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cnoutnum" HeaderText="������������">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
							<tr>
								<td><asp:datagrid id="dgApplyBody_Pay" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
										AutoGenerateColumns="False">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
											BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="seqNum" HeaderText="���"></asp:BoundColumn>
											<asp:BoundColumn DataField="Item" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҽ��" DataFormatString="{0:N}"></asp:BoundColumn>
											<asp:BoundColumn DataField="ExchangeRate" HeaderText="����" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Money" HeaderText="RMB���" DataFormatString="{0:N}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid>
									<P><asp:panel id="panel1" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
											Width="100%" Height="521" Runat="server" Visible="False"></P>
									<P><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><BR>
										&nbsp;&nbsp;&nbsp;&nbsp;<FONT color="#ff9966">��ʼ���ڣ�</FONT>
										<asp:textbox id="txtDateFrom" onfocus="WdatePicker({skin:'whyGreen', maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="88px" Enabled="False"></asp:textbox>&nbsp;<FONT color="#ff9966">�������ڣ�</FONT>
										<asp:textbox id="txtDateTo" onfocus="WdatePicker({skin:'whyGreen', minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="88px" Enabled="False"></asp:textbox>&nbsp;<FONT color="#ff9966">������У�</FONT>
										<asp:textbox id="txtGocity" runat="server" Width="200px" Enabled="False"></asp:textbox>&nbsp;<BR>
										<BR>
										&nbsp;&nbsp;&nbsp;&nbsp;�������ͣ�&nbsp;
										<asp:dropdownlist id="ddlCCType" runat="server" Enabled="False">
											<asp:ListItem Value="����">����</asp:ListItem>
											<asp:ListItem Value="����">����</asp:ListItem>
										</asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���÷ѵȼ�:&nbsp;&nbsp;
										<asp:textbox id="txtAppclass" runat="server" Width="80px" Enabled="False"></asp:textbox>&nbsp;&nbsp; 
										ͬ��������&nbsp;
										<asp:textbox id="txtwithapps" runat="server" Width="80px" Enabled="False"></asp:textbox>&nbsp;
									</P>
									<P>&nbsp;&nbsp;&nbsp; ͬ �� �ˣ�&nbsp;&nbsp;
										<asp:textbox id="txtWithwho" runat="server" Width="576px" Enabled="False"></asp:textbox></P>
									<P>&nbsp;&nbsp;&nbsp;&nbsp; �������ɣ�
										<asp:textbox id="txtCCMemo" runat="server" Width="432px" Height="82px" TextMode="MultiLine" Enabled="False"></asp:textbox></P>
									<P>&nbsp;&nbsp;&nbsp;<FONT color="green">ע��:���Ϻ�ɫ��ĿΪ������Ŀ������Ϊ����������Ŀ�����ڳ���������д</FONT>
									</P>
									<P><asp:panel id="Panel2" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
											runat="server" Height="164px">
											<P>&nbsp; ǰ�γ������ڣ�
												<asp:TextBox id="txtPreabound" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
													runat="server" Width="112px" Enabled="False"></asp:TextBox>ǰ�λع����ڣ�
												<asp:TextBox id="txtPreback" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
													Width="112px" Enabled="False"></asp:TextBox>&nbsp;VIsa��
												<asp:CheckBox id="chbVisa" runat="server" Enabled="False" Text="��/��"></asp:CheckBox>&nbsp;VIsa��Ч�ڣ�
												<asp:TextBox id="txtVisaDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
													Width="112px" Enabled="False"></asp:TextBox></P>
											<P></P>
											<P>&nbsp; ���գ�
												<asp:CheckBox id="chkPassport" runat="server" Enabled="False" Text="��/��"></asp:CheckBox>&nbsp;���պţ�&nbsp;
												<asp:TextBox id="txtPassportno" runat="server" Width="184px" Enabled="False"></asp:TextBox>&nbsp;������Ч�ڣ�
												<asp:TextBox id="txtpassportdate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
													runat="server" Enabled="False"></asp:TextBox></P>
											<P>&nbsp;����ע�䣺
												<asp:CheckBox id="chbbacterin" runat="server" Enabled="False" Text="��/��"></asp:CheckBox>������Ч�ڣ�
												<asp:TextBox id="txtbacterindate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
													runat="server" Enabled="False"></asp:TextBox></P>
											<P>&nbsp;��ע���
												<asp:TextBox id="txtabountMemo" runat="server" Width="552px" Height="92px" Enabled="False" TextMode="MultiLine"></asp:TextBox></P>
											<P>&nbsp;�Ƿ�Я��������Ʒ:
												<asp:CheckBox id="chblimit" runat="server" Enabled="False" Text="��/��"></asp:CheckBox>�Ƿ��ṩ���Ƽ���(�������ϵ�)��
												<asp:CheckBox id="chblimits" runat="server" Enabled="False" Text="��/��"></asp:CheckBox>����ǰ���:
												<asp:CheckBox id="chbcheckup" runat="server" Enabled="False" Text="Ҫ/��"></asp:CheckBox></P>
											<P>�Ƿ���ϳ�����������:
												<asp:CheckBox id="chbmeet" runat="server" Enabled="False" Text="����/������"></asp:CheckBox>�������(�ƻ�):
												<asp:TextBox id="txtcheckupplan" runat="server" Width="168px" Enabled="False"></asp:TextBox></P>
											<P><FONT color="green">&nbsp;&nbsp; ע��:1������ʱ��һ��������������졣2������ʱ�䳬��31����ֹͣ����ͨ�ڲ�����</FONT></P>
											<P>
										</asp:panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
									<P><asp:panel id="Panel3" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
											runat="server">
											<asp:datagrid id="dgCCBodyInfo" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
												BorderColor="#93BEE2" Visible="False">
												<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
												<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
												<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
												<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
													BackColor="#337FB2"></HeaderStyle>
												<Columns>
													<asp:BoundColumn DataField="seqNum" HeaderText="���"></asp:BoundColumn>
													<asp:BoundColumn DataField="CodeName" HeaderText="��������"></asp:BoundColumn>
													<asp:BoundColumn DataField="currcode" HeaderText="����"></asp:BoundColumn>
													<asp:BoundColumn DataField="ExchangeRate" HeaderText="����" DataFormatString="{0:N}">
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Money" HeaderText="���" DataFormatString="{0:N}">
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="memo" HeaderText="��ע"></asp:BoundColumn>
												</Columns>
											</asp:datagrid>
										</asp:panel></P>
									<P><FONT face="����"></FONT>&nbsp;</P>
									</asp:panel>
									<asp:panel id="Panel5" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
										Width="100%" Visible="False" Runat="server" Height="521">
										<P></P>
										<P><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><BR>
											<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%">
												<TR height="15">
													<TD width="15%" align="center">��Ŀ</TD>
													<TD style="WIDTH: 481px" align="center">�ƻ��ճ�</TD>
													<TD align="center">��ע</TD>
												</TR>
												<TR>
													<TD style="COLOR: #ff9966">�д�ʱ��</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="Textbox2" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
															Enabled="False"></asp:textbox>��
														<asp:textbox id="Textbox1" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
															Enabled="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px; COLOR: #ff9966">�д���λ</TD>
													<TD style="WIDTH: 481px; HEIGHT: 14px">
														<asp:textbox id="txtVisitCompany" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 14px">��ע�����</TD>
												</TR>
												<TR>
													<TD style="COLOR: #ff9966">�д���Ա</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtCallinPerson" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>�ٽ��ʷѵ�ʹ�ñ�����ǰ���롣�ر��ǻ������Ľ��ʷѵ�ʹ�ã�������ǰ����������档</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 12px">����Ŀ��</TD>
													<TD style="WIDTH: 481px; HEIGHT: 12px">
														<asp:textbox id="txtCallinMemo" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 12px">��δ����ǰ����ʱ������������ı�ע����д��ԭ���º��������롣</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 15px">��̸�ص�</TD>
													<TD style="WIDTH: 481px; HEIGHT: 15px">
														<asp:textbox id="txtTalkPlace" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 15px">�����ÿ����������Ӵ���Ա������ȫԱ���롣��ϯ��Ա�϶�Ļ���������������</TD>
												</TR>
												<TR>
													<TD>�Ӵ�����</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtVisitDept" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>��ֻ��JDI�ڲ���Ա�μӵĻ�͵ȣ�ԭ���ϸ��˳е����á�</TD>
												</TR>
												<TR>
													<TD>�Ӵ���Ա</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtVisitPerson" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>�����ͽӴ�ʱ�Ļ�ͳ�ϯ��Ա��ԭ��������1������˾�Ӵ���Ա1������ԭ���Ϲ�˾�Ӵ���Ա���ܶ�������������</TD>
												</TR>
												<TR>
													<TD>�Ӵ�������ϵ��ʽ</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtvisitphone" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>�޽�ֹʹ�ö��λᣨ����OK�ȣ����ʷѡ�</TD>
												</TR>
												<TR>
													<TD>��ز���</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtRelationDept" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD>�������κ����ɣ���ֹ�Ӵ���������������������Ա��</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 20px">��ˮ׼��</TD>
													<TD style="WIDTH: 481px; HEIGHT: 20px">
														<asp:checkbox id="chbTea" runat="server" Enabled="False" Text="��Ҫ/����Ҫ"></asp:checkbox></TD>
													<TD style="HEIGHT: 20px"></TD>
												</TR>
												<TR>
													<TD>�ι۹���</TD>
													<TD style="WIDTH: 481px">
														<asp:checkbox id="chblookFactory" runat="server" Enabled="False" Text="��/��"></asp:checkbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px">�ι�����</TD>
													<TD style="WIDTH: 481px; HEIGHT: 14px">
														<asp:textbox id="txtLookNum" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD style="HEIGHT: 14px"></TD>
												</TR>
												<TR>
													<TD>��Ͱ���</TD>
													<TD style="WIDTH: 481px">
														<asp:checkbox id="chbLunch" runat="server" Enabled="False" Text="ʳ����/��"></asp:checkbox></TD>
													<TD>���������ò������</TD>
												</TR>
												<TR>
													<TD>��������</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtOtherNeed" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 14px">��������</TD>
													<TD style="WIDTH: 481px; HEIGHT: 14px">��˾�ɳ���
														<asp:radiobutton id="RadioButton1" runat="server" Enabled="False" Text="��" GroupName="carplan"></asp:radiobutton>
														<asp:radiobutton id="RadioButton2" runat="server" Enabled="False" Text="��" GroupName="carplan"></asp:radiobutton>
														<asp:radiobutton id="RadioButton3" runat="server" Enabled="False" Text="����" GroupName="carplan"></asp:radiobutton>
														<asp:radiobutton id="RadioButton4" runat="server" Enabled="False" Text="��" GroupName="carplan" Checked="True"></asp:radiobutton></TD>
													<TD style="HEIGHT: 14px">�����ó����絥��</TD>
												</TR>
												<TR>
													<TD>����Ҫ��</TD>
													<TD style="WIDTH: 481px">
														<asp:textbox id="txtEspecialRequest" runat="server" Width="344px" Enabled="False"></asp:textbox></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD></TD>
													<TD style="WIDTH: 481px"><FONT face="����"></FONT></TD>
													<TD></TD>
												</TR>
											</TABLE>
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										</P>
										<P>
											<asp:panel style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
												id="Panel4" runat="server">
												<asp:datagrid id="dgYQInfo" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
													BorderColor="#93BEE2" Visible="False">
													<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
													<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
													<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
													<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
													<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
														BackColor="#337FB2"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="seqNum" HeaderText="���"></asp:BoundColumn>
														<asp:BoundColumn DataField="Item" HeaderText="����"></asp:BoundColumn>
														<asp:BoundColumn DataField="currTypeCode" HeaderText="����"></asp:BoundColumn>
														<asp:BoundColumn DataField="originalcurrPrice" HeaderText="ԭ�ҽ��" DataFormatString="{0:N}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ExchangeRate" HeaderText="����" DataFormatString="{0:N}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Money" HeaderText="RMB���" DataFormatString="{0:N}"></asp:BoundColumn>
													</Columns>
												</asp:datagrid>
											</asp:panel></P>
										<BR>
									</asp:panel>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><A onclick="javascript:showDisplay('postail')" href="javascript:void(0)">�������</A><FONT face="����">(����鿴��ϸ)</FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: none; HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" colSpan="6"><FONT face="����"><asp:datagrid id="dgPostail" runat="server" BorderColor="#93BEE2" BackColor="White" Width="100%"
								AutoGenerateColumns="False">
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
						colSpan="6"><A onclick="javascript:showDisplay('AnnexInfo')" href="javascript:void(0)">����(<%=NumOfAnnex%>)</A><FONT face="����">(����鿴��ϸ)</FONT></td>
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
