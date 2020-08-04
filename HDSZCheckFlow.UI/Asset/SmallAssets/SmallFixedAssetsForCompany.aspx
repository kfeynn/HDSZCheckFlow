<%@ Page language="c#" Codebehind="SmallFixedAssetsForCompany.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssetsForCompany"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>公司资产</title>
<meta name=GENERATOR content="Microsoft Visual Studio .NET 7.1">
<meta name=CODE_LANGUAGE content=C#>
<meta name=vs_defaultClientScript content=JavaScript>
<meta name=vs_targetSchema content=http://schemas.microsoft.com/intellisense/ie5>
<script type=text/javascript 
src="../../AppSystem/Style/My97DatePicker/WdatePicker.js"></script>
<LINK rel=stylesheet type=text/css href="../../Style/BasicLayout.css" ><LINK rel=stylesheet type=text/css href="../../Style/Style.css" ><LINK rel=stylesheet type=text/css href="../../AppSystem/common.css" >
<script language=javascript>
			function CheckForm()
			{
				return true;
			}
		</script>
</HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server"><FONT face=宋体></FONT><FONT face=宋体></FONT><FONT 
face=宋体></FONT>
<table 
style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px" 
id=tabDispDocument class=GbText border=1 rules=all borderColor=#0066cc 
cellPadding=3>
  <tr>
    <td 
    style="BORDER-BOTTOM: 0px solid; BORDER-LEFT: 0px solid; BORDER-TOP: 0px solid; BORDER-RIGHT: 0px solid" 
    height=6></td></tr>
  <tr style="HEIGHT: 28px">
    <td colSpan=6 align=center><FONT face=宋体 
      >
      <TABLE id=Table1 border=0 cellSpacing=0 cellPadding=0 width="100%" 
      >
        <TR>
          <TD style="TEXT-ALIGN: center; WIDTH: 58px; HEIGHT: 23px">存货编码</TD>
          <TD style="WIDTH: 146px; HEIGHT: 23px"><asp:textbox style="Z-INDEX: 0" id=txtInv runat="server" Width="128px"></asp:textbox></TD>
          <TD style="Z-INDEX: 0; TEXT-ALIGN: center; WIDTH: 60px; HEIGHT: 23px" 
            >管理编码</TD>
          <TD style="HEIGHT: 23px"><asp:textbox id=txtInvManageCode runat="server" Width="128px"></asp:textbox></TD>
          <TD style="Z-INDEX: 0; WIDTH: 67px; HEIGHT: 23px" align=center 
          >存放地点</TD>
          <TD style="WIDTH: 162px; HEIGHT: 23px"><asp:textbox id=txtStorage runat="server" Width="128px"></asp:textbox></TD>
          <TD style="TEXT-ALIGN: center; WIDTH: 61px; HEIGHT: 23px" 
            >部&nbsp;&nbsp;&nbsp; 门</TD>
          <TD style="WIDTH: 182px; HEIGHT: 23px"><asp:dropdownlist style="Z-INDEX: 0" id=ddlDeptClass runat="server" Width="128px" AutoPostBack="True"></asp:dropdownlist></TD>
          <TD style="TEXT-ALIGN: center; WIDTH: 89px; HEIGHT: 23px">责任人工号</TD>
          <TD style="HEIGHT: 23px"><asp:textbox id=txtKeeperCode runat="server" Width="128px"></asp:textbox></TD>
          <TD style="HEIGHT: 23px"></TD></TR>
        <TR>
          <TD style="Z-INDEX: 0; TEXT-ALIGN: center; WIDTH: 58px">存货名称</TD>
          <TD style="WIDTH: 146px"><asp:textbox style="Z-INDEX: 0" id=txtName runat="server" Width="128px"></asp:textbox></TD>
          <TD style="Z-INDEX: 0; TEXT-ALIGN: center; WIDTH: 60px">购入日期</TD>
          <TD style="WIDTH: 156px"><asp:textbox style="Z-INDEX: 0" id=txtDateFrom onfocus="WdatePicker({maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})" runat="server" Width="128px"></asp:textbox></TD>
          <TD style="Z-INDEX: 0; WIDTH: 67px" align=center 
            >购入日期</TD>
          <TD style="WIDTH: 162px"><asp:textbox style="Z-INDEX: 0" id=txtDateTo onfocus="WdatePicker({minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})" runat="server" Width="128px"></asp:textbox></TD>
          <TD style="TEXT-ALIGN: center;WIDTH: 61px">科&nbsp;&nbsp;&nbsp; 
组</TD>
          <TD style="WIDTH: 182px"><asp:dropdownlist style="Z-INDEX: 0" id=ddlDeptName runat="server" Width="128px" AutoPostBack="False"></asp:dropdownlist></TD>
          <TD><asp:button style="Z-INDEX: 0" id=btnQuery runat="server" Width="72px" Text="查询" CssClass="redButtonCss"></asp:button></TD>
          <td align=center><asp:button style="Z-INDEX: 0" id="btnExportExcel" runat="server" Width="72px" Text="导出Excel" CssClass="redButtonCss"></asp:button></td></TR></TABLE></FONT></td></tr>
  <TR style="HEIGHT: 28px">
    <TD style="WIDTH: 100%; HEIGHT: 27px" 
    background=../../Style/Images/treetopbg.jpg colSpan=6 align=right 
    ><FONT face=宋体></FONT><FONT 
      face=宋体></FONT><FONT face=宋体 
      ></FONT><FONT face=宋体 
      ></FONT><FONT face=宋体 
      ></FONT><FONT face=宋体 
      ></FONT><FONT face=宋体 
      ></FONT><FONT face=宋体></FONT>
      <DIV id=divPages class="  pages PageBox " 
      runat="server"></DIV></TD></TR>
  <TR style="DISPLAY: block; HEIGHT: 22px" id=bodyInfo>
    <TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 100%" colSpan=6 align=center 
    ><asp:datagrid style="Z-INDEX: 0" id=dgApply runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2" PageSize="20" AllowSorting="True">
							<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>								
								<asp:BoundColumn DataField="InvManageCode" HeaderText="管理编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptClassCode" HeaderText="部门编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="ClassDeptName" HeaderText="部门名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptCode" HeaderText="科组编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" HeaderText="科组"></asp:BoundColumn>							
								<asp:BoundColumn DataField="invCode" SortExpression="invCode" HeaderText="存货编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="invname" HeaderText="存货名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="dbizdate" SortExpression="dbizdate" HeaderText="购入日期" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="iNum" HeaderText="数量"></asp:BoundColumn>
								<asp:BoundColumn DataField="Price" HeaderText="单价"></asp:BoundColumn>
								<asp:BoundColumn DataField="CurrTypeCode_New" HeaderText="币种"></asp:BoundColumn>
								<asp:BoundColumn DataField="storage" HeaderText="存放地点"></asp:BoundColumn>
								<asp:BoundColumn DataField="KeeperCode" HeaderText="责任人工号"></asp:BoundColumn>
								<asp:BoundColumn DataField="managername" HeaderText="责任人"></asp:BoundColumn>
								<asp:BoundColumn DataField="ReMark" HeaderText="备注"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></TD></TR>
  <TR style="HEIGHT: 28px">
    <TD style="WIDTH: 100%; HEIGHT: 27px" 
    background=../../Style/Images/treetopbg.jpg colSpan=6 align=left 
    ><FONT face=宋体></FONT><FONT 
      face=宋体></FONT><FONT face=宋体 
      >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT> 
    </TD></TR> <!--<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><FONT face="宋体"></FONT></td>
				</tr>--></table><INPUT 
style="Z-INDEX: 104; POSITION: absolute; TOP: 456px; LEFT: 656px" id=pagesIndex 
value=0 type=hidden name=Hidden1 runat="server"><INPUT 
style="Z-INDEX: 103; POSITION: absolute; TOP: 456px; LEFT: 200px" id=HerdSort 
type=hidden name=Hidden3 runat="server"> <asp:linkbutton style="Z-INDEX: 102; POSITION: absolute; TOP: 512px; LEFT: 400px" id=linkToPage runat="server"></asp:linkbutton><INPUT 
style="Z-INDEX: 105; POSITION: absolute; TOP: 456px; LEFT: 424px" id=FieldSort 
type=hidden name=Hidden2 
runat="server"></form>
	</body>
</HTML>
