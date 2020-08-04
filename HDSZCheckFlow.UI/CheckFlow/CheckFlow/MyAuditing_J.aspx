<%@ Page language="c#" Codebehind="MyAuditing_J.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.MyAuditing_J"   EnableEventValidation="false"  %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MyAuditing</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 88px; LEFT: 8px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<TR>
						<TD>私の審批：
							<asp:Label id="lblMessage" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:DataGrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" BorderStyle="None"
								BorderColor="#93BEE2" BackColor="White" AllowPaging="True" PageSize="20">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ApplyPK"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ApplyTypeCode" HeaderText="申请类型代码"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplySheetNo" HeaderText="申請番号"></asp:BoundColumn>
									<asp:HyperLinkColumn Visible="False" DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="GetStepInfoApplySheet.aspx?ApplyHeadPK={0}"
										DataTextField="ApplySheetNo" HeaderText="申請番号"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="ApplyTypeName" HeaderText="申請類型"></asp:BoundColumn>
									<asp:BoundColumn DataField="ApplyDate" HeaderText="申請日付" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
									<asp:BoundColumn DataField="Dept" HeaderText="申請科組"></asp:BoundColumn>
									<asp:BoundColumn DataField="submitPerson" HeaderText="申請者"></asp:BoundColumn>
									<asp:BoundColumn DataField="SheetMoney" HeaderText="金額" DataFormatString="{0:N}">
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SubmitType" HeaderText="審査類別"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DisplaysPerson" HeaderText="DisplaysCode"></asp:BoundColumn>
									<asp:BoundColumn DataField="UserName" HeaderText="誰に審批代行"></asp:BoundColumn>
									<asp:TemplateColumn>
										<ItemTemplate>
											<asp:Button id="btnApply" runat="server" Text="審批入り" CssClass="inputbutton" CommandName="Apply"></asp:Button>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="次ページへ" PrevPageText="前ページへ"></PagerStyle>
							</asp:DataGrid></TD>
					</TR>
					<TR>
						<TD>
							<P>
								<asp:Panel style="Z-INDEX: 0" id="Panel1" runat="server"></P>
							<P><br>
								价格决裁：
								<asp:DataGrid style="Z-INDEX: 0" id="DataGrid3" runat="server" PageSize="20" AllowPaging="True"
									BackColor="White" BorderColor="#93BEE2" BorderStyle="None" AutoGenerateColumns="False" Width="100%">
									<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
									<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
									<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
									<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
									<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="ID" HeaderText="FinallyCheckId"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="ApplySheetHead_Pk" HeaderText="ApplySheetHeadPk"></asp:BoundColumn>
										<asp:HyperLinkColumn DataNavigateUrlField="ApplySheetHead_Pk" DataNavigateUrlFormatString="../../Asset/CheckFlow/AssetApplyForOneApply_J.aspx?applyHeadPK={0}"
											DataTextField="ApplySheetNo" HeaderText="申請番号"></asp:HyperLinkColumn>
										<asp:BoundColumn DataField="DeptName" HeaderText="申請部門"></asp:BoundColumn>
										<asp:BoundColumn DataField="ItemName" HeaderText="項目名称"></asp:BoundColumn>
										<asp:BoundColumn DataField="BargainNo" HeaderText="契約番号"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="DisplaysPerson" HeaderText="DisplaysCode"></asp:BoundColumn>
										<asp:BoundColumn DataField="Name" HeaderText="誰に審批代行"></asp:BoundColumn>
										<asp:TemplateColumn>
											<ItemTemplate>
												<asp:Button id="btnApply" runat="server" Text="審批入り" CssClass="inputbutton" CommandName="Apply"></asp:Button>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle NextPageText="次ページへ" PrevPageText="前ページへ"></PagerStyle>
								</asp:DataGrid></P>
							</asp:Panel>
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table2" style="Z-INDEX: 102; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
					cellPadding="0" width="100%" border="0">
					<TR>
						<TD height="26"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px">申請部門</TD>
						<TD style="HEIGHT: 17px">
							<asp:DropDownList id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:DropDownList></TD>
						<TD style="HEIGHT: 17px">開始日付</TD>
						<TD style="HEIGHT: 17px">
							<asp:TextBox id="txtDateFrom" onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
								runat="server" Width="90px" maxdate="#F{$('txtDateTo').value}"></asp:TextBox></TD>
						<TD style="HEIGHT: 17px" align="center">終了日付</TD>
						<TD style="HEIGHT: 17px">
							<asp:TextBox id="txtDateTo" onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
								runat="server" Width="90px" mindate="#F{$('txtDateFrom').value}"></asp:TextBox></TD>
						<TD style="HEIGHT: 17px">書類番号</TD>
						<TD style="HEIGHT: 17px">
							<asp:TextBox id="txtApplyNo" runat="server"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>申請科組</TD>
						<TD><asp:DropDownList id="ddlDept" runat="server" Width="90px"></asp:DropDownList></TD>
						<TD>申請類型</TD>
						<TD><asp:DropDownList id="ddlType" runat="server" Width="90px"></asp:DropDownList></TD>
						<TD align="center">書類状態</TD>
						<TD>
							<asp:dropdownlist id="ddlApplyType" runat="server" Width="90px"></asp:dropdownlist>
						</TD>
						<TD>
						</TD>
						<TD>
							<asp:button id="btnQuery" runat="server" Width="72px" CssClass="redButtonCss" Text="検索"></asp:button>
						</TD>
					</TR>
					<TR>
						<TD colspan="8"><hr>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
