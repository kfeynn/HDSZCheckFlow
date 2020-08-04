<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.QueryResultControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<script language="javascript" type="text/javascript" src="<% =ApplicationPath %>xpGrid/Query/QueryControl/scripts/xmlExecute.js" ></script>
<script language="javascript" type="text/javascript" src="<% =ApplicationPath %>xpGrid/Query/QueryControl/scripts/common_js.aspx" ></script>
<script language="javascript">
<!--
	function OpenConditionBySet(SetID)
	{
		var hidConditions = document.all("<%=hidConditions.ClientID%>");
		var hidPre =  document.all("<%=hidPre.ClientID%>");
		
		hidConditions.value="";		
		// alert(iSetID);
		if (SetID != "0")
		{
			var sDialogPath= "<% =ApplicationPath %>xpGrid/Query/QueryControl/ConditionCollector.aspx?SetID="+SetID + "&Pre=1";
			
			var sValue = ShowModelDialog(sDialogPath, "","");
			if (sValue != null)
			{
				hidConditions.value = sValue;
				hidPre.value = "1";
				hidPre.form.submit();				
			}
		}
		 
	}
//-->
</script>
<P>
	<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0">
		<TR>
			<TD></TD>
			<TD><IMG id="btnSearch" alt="" src="<%=ApplicationPath%>xpGrid/images/chaxun.gif" runat="server" class="btnEnable"></TD>
			<TD><asp:ImageButton id="btnExport" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/baobiaosc.gif" Visible="False"></asp:ImageButton></TD>
			<TD></TD>
			<TD></TD>
			<TD></TD>
			<TD><IMG id="btnReturn" alt="" src="<%=ApplicationPath%>xpGrid/images/fanhui.gif" runat="server" border="0" class="btnEnable"></TD>
			<TD>
				<INPUT id="hidPre" type="hidden" runat="server" name="hidPre"></TD>
			<TD></TD>
			<TD><INPUT id="hidConditions" type="hidden" runat="server" NAME="hidConditions"></TD>
			<TD class="toolright"></TD>
		</TR>
	</TABLE>
</P>
<p><TABLE id="tblSubject" cellSpacing="1" cellPadding="0" height="20" width="600" border="1"
		style="BORDER-RIGHT: #bbe0ff thin solid; BORDER-TOP: #bbe0ff thin solid; BORDER-LEFT: #bbe0ff thin solid; BORDER-BOTTOM: #bbe0ff thin solid"
		borderColor="#bbe0ff" runat="server">
		<TR height="30">
			<TD height="20" width="90" valign="bottom">&nbsp;查询名称：</TD>
			<TD align="left" valign="bottom">&nbsp;<%#_sSuiteCaption%>
				&nbsp; &nbsp; [<%#_sQueryType%>]</TD>
		</TR>
		<TR>
			<TD>&nbsp;描&nbsp;&nbsp;&nbsp;&nbsp;述：</TD>
			<TD align="left">&nbsp;<%#_sSuiteDescription%></TD>
		</TR>
	</TABLE>
</p>
<gridwc:xpgrid id="ctlResult" runat="server" Width="100%"></gridwc:xpgrid>
<TABLE id="toolbarTable" cellSpacing="0" cellPadding="0" border="0">
	<TR height="100%">
		<TD colSpan="2"></TD>
		<TD vAlign="top" width="100%">
			<asp:Label id="lblMessage" runat="server" Visible="False" CssClass="xiao">对不起没有查询到相关记录</asp:Label></TD>
		</TD>
		<TD></TD>
		<TD></TD>
	</TR>
</TABLE>
<script language="javascript">
<!--
<%=_sOnLoad%>
//-->
</script>
