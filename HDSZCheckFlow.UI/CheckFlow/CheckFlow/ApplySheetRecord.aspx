<%@ Page language="c#" Codebehind="ApplySheetRecord.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.ApplySheetRecord" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApplySheetRecord</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="����" color="#000000" size="3">
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD>
							<asp:datagrid id="dgPostail" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
								Width="100%">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Left" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="������">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="��ɫ" DataField="CheckRoleName">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Checkdate" HeaderText="����ʱ��">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IsAgree" HeaderText="��������">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CheckComment" HeaderText="���">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="center"><font size="+4"><a href="#" onclick="javascript:history.go(-1)" style="FONT-SIZE: 16px">����</a></font></TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
