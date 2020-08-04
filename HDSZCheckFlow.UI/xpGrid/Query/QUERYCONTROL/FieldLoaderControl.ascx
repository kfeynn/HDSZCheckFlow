<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.FieldLoaderControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="lsuc" TagName="FieldColumnControl" Src="FieldColumnControl.ascx" %>
<script language="JavaScript" src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/xmlExecute.js" type="text/JavaScript"></script>
<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
	<TR>
		<TD><asp:DropDownList id="ddlTables" runat="server" Width="100%"></asp:DropDownList></TD>
	</TR>
	<TR>
		<TD>
			<P>
				<lsuc:FieldColumnControl id="ctlFieldColumn" runat="server" EnableViewState="False"></lsuc:FieldColumnControl></P>
		</TD>
	</TR>
</TABLE>
<script language="javascript">
<!--
	<%#_sAutoLoadFields%>
//-->
</script>
