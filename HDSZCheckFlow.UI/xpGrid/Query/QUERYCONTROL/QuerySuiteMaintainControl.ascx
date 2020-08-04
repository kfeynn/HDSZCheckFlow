<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Register TagPrefix="uc1" TagName="QuerySuiteClassListControl" Src="QuerySuiteClassListControl.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.QuerySuiteMaintainControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language=javascript src="<%=ApplicationPath%>/xpGrid/Query/QUERYCONTROL/Scripts/controls.js" type=text/javascript></script>
<TABLE id="Table2" cellSpacing="1" cellPadding="1" border="0">
	<TR><td width=30>&nbsp;</td>
		<TD>方案名称
		</TD>
		<TD>
			<asp:textbox id="txtCaption" runat="server"></asp:textbox></TD>
		<TD>方案分类
		</TD>
		<TD>
			<uc1:querysuiteclasslistcontrol id="ctlClassList" runat="server" width="120"></uc1:querysuiteclasslistcontrol></TD>
		<TD>
			<asp:Button id="btnSearch" runat="server" Text="查询"></asp:Button></TD>
	</TR>
</TABLE>
<br>
<TABLE id="Table1" cellSpacing="0" cellPadding="2" border="0">
	<TR><td width=30>&nbsp;</td>
		<TD><gridwc:XPGrid id="grdList" runat="server" SelectKind="SingleLine" RightControl="False"></gridwc:XPGrid></TD>
	</TR>
</TABLE>
