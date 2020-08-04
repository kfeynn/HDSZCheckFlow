<%@ Page language="c#" Codebehind="BaseSubjecQuery.aspx.cs"  AutoEventWireup="false"  Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.BaseSubjecQuery"   %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>BaseSubjecQuery</title>
<meta name=GENERATOR content="Microsoft Visual Studio .NET 7.1">
<meta name=CODE_LANGUAGE content=C#>
<meta name=vs_defaultClientScript content=JavaScript>
<meta name=vs_targetSchema content=http://schemas.microsoft.com/intellisense/ie5><LINK rel=stylesheet type=text/css href="../../Style/Style.css" >
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server"><FONT face=宋体><asp:datagrid style="Z-INDEX: 101; POSITION: absolute; TOP: 88px; LEFT: 16px" id=DataGrid1 runat="server" Height="91px" Width="100%" EnableViewState="false">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="left" BackColor="#E8F4FF"></AlternatingItemStyle>
					<ItemStyle Font-Size="X-Small" HorizontalAlign="left" ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle HorizontalAlign="left" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
				</asp:datagrid>
<TABLE 
style="Z-INDEX: 102; POSITION: absolute; HEIGHT: 54px; TOP: 24px; LEFT: 32px" 
id=Table1 border=0 cellSpacing=1 cellPadding=1 width="80%" 
  >
  <TR>
    <TD style="WIDTH: 50px; HEIGHT: 16px">类别：</TD>
    <TD style="WIDTH: 142px; HEIGHT: 16px"><asp:dropdownlist id=ddlType runat="server" Width="95px"></asp:dropdownlist></TD>
    <TD style="WIDTH: 50px; HEIGHT: 16px">
      <P>编码：</P></TD>
    <TD style="WIDTH: 161px; HEIGHT: 16px"><asp:textbox id=txtCode runat="server" Width="128px"></asp:textbox></TD>
    <TD style="WIDTH: 50px; HEIGHT: 16px">名称：</TD>
    <TD style="HEIGHT: 16px"><asp:textbox id=txtName runat="server" Width="96px"></asp:textbox></TD></TR>
  <TR>
    <TD style="WIDTH: 88px"></TD>
    <TD style="WIDTH: 142px"></TD>
    <TD style="WIDTH: 56px"><asp:button id=Button1 runat="server" Width="144px" Visible="False" Text="更新基础资料"></asp:button></TD>
    <TD style="WIDTH: 161px"><asp:label id=Label1 runat="server"></asp:label></TD>
    <TD></TD>
    <TD><asp:button id=btnQuery runat="server" Width="64px" Text="查询" CssClass="inputbutton"></asp:button></TD></TR></TABLE></FONT></form>
	</body>
</HTML>
