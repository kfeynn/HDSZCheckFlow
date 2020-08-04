<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.QuerySuiteClassMaintainControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../../style.css" type="text/css" rel="stylesheet">
<script language="javascript" src="<%=ApplicationPath%>/xpGrid/Query/QUERYCONTROL/scripts/controls.js" type="text/javascript"></script>
<TABLE class="tool" id="toolbarTable" cellSpacing="0" cellPadding="0" border="0">
	<TR height="100%">
		<TD class="kongxi" colSpan="2"></TD>
		<TD vAlign="top" width="100%">
			<DIV>
				<P><gridwc:xpgrid id="grdList" runat="server" RightControl="False" AllowAdd="True" AllowDelete="True"
						AllowEdit="True"></gridwc:xpgrid></P>
				<P><asp:label id="lblMessage" runat="server"></asp:label></P>
			</DIV>
		</TD>
		<TD class="youtooltiao"></TD>
		<TD class="youtooltiao"></TD>
	</TR>
</TABLE>
