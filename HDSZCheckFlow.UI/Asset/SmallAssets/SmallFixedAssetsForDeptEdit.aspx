<%@ Page language="c#" Codebehind="SmallFixedAssetsForDeptEdit.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssetsForDeptEdit"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ֹ�����С��̶��ʲ�</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../../Style/BasicLayout.css">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style.css">
		<LINK rel="stylesheet" type="text/css" href="../../AppSystem/common.css">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
			<table style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				id="tabDispDocument" class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3">
				<tr>
					<td style="BORDER-BOTTOM: 0px solid; BORDER-LEFT: 0px solid; WIDTH: 49px; BORDER-TOP: 0px solid; BORDER-RIGHT: 0px solid"
						height="6"></td>
					<TD style="BORDER-BOTTOM: 0px solid; BORDER-LEFT: 0px solid; WIDTH: 152px; BORDER-TOP: 0px solid; BORDER-RIGHT: 0px solid"
						height="6"></TD>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 1383px" colSpan="10" align="center"><FONT face="����">
							<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="WIDTH: 86px; HEIGHT: 23px">Ʒ�ֱ���</TD>
									<TD style="WIDTH: 176px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtInv" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 116px; HEIGHT: 23px">���ͷ���</TD>
									<TD style="WIDTH: 156px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlType" runat="server" Width="120px"></asp:dropdownlist></TD>
									<TD style="Z-INDEX: 0; WIDTH: 154px; HEIGHT: 23px" align="center">�������</TD>
									<TD style="WIDTH: 193px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id="txtInvManageCode_query" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="HEIGHT: 23px">������</TD>
									<TD style="HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlClassDeptCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 23px"></TD>
									<TD style="HEIGHT: 23px"></TD>
								</TR>
								<TR>
									<TD style="Z-INDEX: 0; WIDTH: 86px">Ʒ������</TD>
									<TD style="WIDTH: 176px"><asp:textbox style="Z-INDEX: 0" id="txtName" runat="server" Width="128px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 116px">��ʼ���ڣ����룩</TD>
									<TD style="WIDTH: 156px"><asp:textbox style="Z-INDEX: 0" id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
											runat="server" Width="120px"></asp:textbox></TD>
									<TD style="Z-INDEX: 0; WIDTH: 154px" align="center">�������ڣ����룩</TD>
									<TD style="WIDTH: 193px"><asp:textbox style="Z-INDEX: 0" id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
											runat="server" Width="128px"></asp:textbox></TD>
									<TD>�������</TD>
									<TD><asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptentCode" runat="server" Width="128px"></asp:dropdownlist></TD>
									<TD><asp:button style="Z-INDEX: 0" id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss"
											Text="��ѯ"></asp:button></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 101.88%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="10" align="right"><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT><FONT face="����"></FONT>
						<DIV id="divPages" class="  pages PageBox " runat="server"></DIV>
					</TD>
				</TR>
				<TR style="DISPLAY: block; HEIGHT: 22px" id="bodyInfo">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 101.88%" colSpan="10" align="center"><asp:datagrid id="dgApply" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White"
							BorderColor="#93BEE2" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<asp:CheckBox id="chbAll" runat="server" AutoPostBack="True"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<FONT face="����">
											<asp:CheckBox id="CheckBox2" runat="server"></asp:CheckBox></FONT>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="Id" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="InvManageCode" HeaderText="�������"></asp:BoundColumn>
								<asp:BoundColumn DataField="invCode" SortExpression="invCode" HeaderText="�������"></asp:BoundColumn>
								<asp:BoundColumn DataField="InvName" HeaderText="�������"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclasscode" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="invclassname" HeaderText="��������"></asp:BoundColumn>
								<asp:BoundColumn DataField="ClassDeptName" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="Price" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="CurrTypeCode_New" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="iNum" SortExpression="iNum" HeaderText="����"></asp:BoundColumn>
								<asp:BoundColumn DataField="storage" HeaderText="��ŵص�"></asp:BoundColumn>
								<asp:BoundColumn DataField="KeeperCode" HeaderText="�����˹���"></asp:BoundColumn>
								<asp:BoundColumn DataField="managername" HeaderText="������"></asp:BoundColumn>
								<asp:BoundColumn DataField="Dbizdate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="�Ƿ񱨷�">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem,"IsRetire").ToString().Trim()=="0"?"��":"��"%>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="RetireDate" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="ReMark" HeaderText="��ע"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="��һҳ" PrevPageText="��һҳ"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 101.88%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="10" align="left"><FONT face="����"></FONT><FONT face="����"></FONT>&nbsp;&nbsp;
						<asp:button id="btnEdit" runat="server" CssClass="ButtonFlat" Text=" �� �� "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnExport" runat="server" CssClass="ButtonFlat" Text=" �� �� "></asp:button>&nbsp;&nbsp; 
						&nbsp;&nbsp; <FONT face="����">
							<asp:label style="Z-INDEX: 0" id="lblMsg" runat="server" ForeColor="#ff0000">&nbsp;</asp:label></FONT></TD>
				</TR>
				<tr>
					<TD style="WIDTH: 5.25%; HEIGHT: 27px" background="../../Style/Images/treetopbg.jpg"
						colSpan="10" align="left"></TD>
				</tr>
				<tr>
					<td style="WIDTH: 1382px" background="../../Style/Images/treetopbg.jpg" colSpan="10">&nbsp;
					</td>
				</tr>
				<tr>
					<TD style="WIDTH: 49px; HEIGHT: 23px" align="right">�������
					</TD>
					<TD style="WIDTH: 152px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlInvName" runat="server" Width="128px"></asp:dropdownlist></TD>
					<TD style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 23px" align="right">�� ��</TD>
					<TD style="WIDTH: 145px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptClassCode" runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD style="Z-INDEX: 0; WIDTH: 46px; HEIGHT: 23px" align="right">�� ��
					</TD>
					<TD style="WIDTH: 195px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlDeptCode" runat="server" Width="128px"></asp:dropdownlist></TD>
					<td style="Z-INDEX: 0; WIDTH: 78px" align="center">��&nbsp;��</td>
					<td style="Z-INDEX: 0; WIDTH: 205px" colSpan="3"><asp:textbox style="Z-INDEX: 0" id="txtINum" runat="server" Width="128px"></asp:textbox></td>
				</tr>
				<tr>
					<TD style="Z-INDEX: 0; WIDTH: 49px" align="right">�������</TD>
					<TD style="WIDTH: 152px"><asp:textbox style="Z-INDEX: 0" id="txtInvManageCode" runat="server" Width="128px"></asp:textbox></TD>
					<TD style="Z-INDEX: 0; WIDTH: 72px" align="right">��&nbsp;��
					</TD>
					<TD style="WIDTH: 145px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlCurrTypeCode" runat="server" Width="128px">
							<asp:ListItem Selected="True"></asp:ListItem>
							<asp:ListItem Value="RMB">�����</asp:ListItem>
							<asp:ListItem Value="USD">��Ԫ</asp:ListItem>
							<asp:ListItem Value="JPY">��Ԫ</asp:ListItem>
							<asp:ListItem Value="HKD">�۱�</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="Z-INDEX: 0; WIDTH: 46px" align="right">��&nbsp;��</TD>
					<TD style="WIDTH: 195px"><asp:textbox style="Z-INDEX: 0" id="txtPrice" runat="server" Width="128px"></asp:textbox></TD>
					<td style="Z-INDEX: 0; WIDTH: 78px" align="center">��������</td>
					<td style="Z-INDEX: 0" colSpan="3"><asp:textbox style="Z-INDEX: 0" id="txtDbizdate" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
							runat="server" Width="128px"></asp:textbox></td>
				</tr>
				<tr>
					<TD style="Z-INDEX: 0; WIDTH: 49px" align="right">��ŵص�</TD>
					<TD style="WIDTH: 152px"><asp:textbox style="Z-INDEX: 0" id="txtStorage" runat="server" Width="128px"></asp:textbox></TD>
					<td style="Z-INDEX: 0; WIDTH: 72px" align="right">�����˹���</td>
					<td style="WIDTH: 145px"><asp:textbox style="Z-INDEX: 0" id="txtKeeperCode" runat="server" Width="128px"></asp:textbox></td>
					<td style="WIDTH: 46px" align="right">�� ע</td>
					<td style="WIDTH: 195px"><asp:textbox style="Z-INDEX: 0" id="txtReMark" runat="server" Width="128px"></asp:textbox></td>
					<TD style="WIDTH: 464px" colSpan="4" align="center"><asp:button style="Z-INDEX: 0" id="btnSubmit" runat="server" Width="72px" CssClass="redButtonCss"
							Text="�ύ"></asp:button></TD>
				</tr>
			</table>
			<INPUT style="Z-INDEX: 104; POSITION: absolute; TOP: 592px; LEFT: 1192px" id="pagesIndex"
				value="0" type="hidden" name="Hidden1" runat="server"> <INPUT style="Z-INDEX: 103; POSITION: absolute; TOP: 528px; LEFT: 1192px" id="HerdSort"
				type="hidden" name="Hidden3" runat="server">
			<asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 504px; LEFT: 1208px" id="linkToPage"
				runat="server"></asp:linkbutton><INPUT style="Z-INDEX: 105; POSITION: absolute; TOP: 560px; LEFT: 1192px" id="FieldSort"
				type="hidden" name="Hidden2" runat="server"> <input id="IsUpdate" type="hidden" name="IsUpdate" runat="server">
		</form>
	</body>
</HTML>
