<%@ Register TagPrefix="lsuc" TagName="FieldColumnControl" Src="FieldColumnControl.ascx" %>
<%@ Register TagPrefix="lsuc" TagName="FieldLoaderControl" Src="FieldLoaderControl.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.FieldSelectorControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="JavaScript" src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/selector.js" type="text/JavaScript"></script>
 <p>
 	<TABLE cellSpacing="0" cellPadding="2" width="100%" border="1" bordercolor=#99ccff >
		<TR>
			<TD width="40%" valign="top" >
				<P><FONT face="ËÎÌו">
						<lsuc:FieldLoaderControl id="ctlFieldLoader" runat="server" width="70%"  ></lsuc:FieldLoaderControl></FONT></P>
			</TD>
			<TD width="20%" align="center" >
				<br>
				<P>
					<img class="btnEnable" src="<%=ApplicationPath%>/xpGrid/images/xuanze.gif" onclick= "MoveSelectItems(<%=ctlFieldLoader.ListBoxName%>, <%=ctlSelectedFields.ListBoxName%>, <%=_iIsReferList%>);CollectFields(<%=ctlSelectedFields.ListBoxName%>,<%=shidFieldIDListName%>)"></P>
				<P>
					<img class="btnEnable" src="<%=ApplicationPath%>/xpGrid/images/quanbuxz.gif" onclick= "MoveAllItems(<%=ctlFieldLoader.ListBoxName%>, <%=ctlSelectedFields.ListBoxName%>, <%=_iIsReferList%>);CollectFields(<%=ctlSelectedFields.ListBoxName%>,<%=shidFieldIDListName%>)"></P>
				<P>
					<img class="btnEnable" src="<%=ApplicationPath%>/xpGrid/images/shanchu.gif" onclick= "RemoveSelectItems(<%=ctlSelectedFields.ListBoxName%>);CollectFields(<%=ctlSelectedFields.ListBoxName%>,<%=shidFieldIDListName%>); <%=_sReferLoad%>"></P>
				<P>
					<img class="btnEnable" src="<%=ApplicationPath%>/xpGrid/images/quanbusc.gif" id="btnDeleteAll" onclick= "RemoveAllItems(<%=ctlSelectedFields.ListBoxName%>);CollectFields(<%=ctlSelectedFields.ListBoxName%>,<%=shidFieldIDListName%>);<%=_sReferLoad%>"></P>
				<P><FONT face="ËÎÌו"> <INPUT id="hidFieldIDList" type="hidden" value=" " name="hidFieldIDList" runat="server"></FONT></P>
			</TD>
			<TD width="40%" valign="top" >
				<P>
					<lsuc:FieldColumnControl id="ctlSelectedFields" runat="server" ></lsuc:FieldColumnControl></P>
			</TD>
			<TD width="40%">
				<P>
					<img class="btnEnable" id="btnMoveUp"   src="<%=ApplicationPath%>/xpGrid/images/shangyi.gif"  onclick = "ListMoveUp(<%=ctlSelectedFields.ListBoxName%>);CollectFields(<%=ctlSelectedFields.ListBoxName%>,<%=shidFieldIDListName%>)" <%=_sVisibleStyle%> ></P>
				<P>
					<img class="btnEnable" id="btnMoveDown" src="<%=ApplicationPath%>/xpGrid/images/xiayi.gif" onclick = "ListMoveDown(<%=ctlSelectedFields.ListBoxName%>);CollectFields(<%=ctlSelectedFields.ListBoxName%>,<%=shidFieldIDListName%>)" <%=_sVisibleStyle%>></P>
			</TD>
		</TR>
	</TABLE>
</P>
<script language="javascript">
<!--
	BoundItem2SelectList(document.all('<%=ctlSelectedFields.ListBoxName%>'),document.all('<%=shidFieldIDListName%>'));
	BoundFieldFromTable(document.all('<%=ctlFieldLoader.DropDownControlName%>'), document.all('<%=ctlFieldLoader.ListBoxName%>'), <%=_sReferListClientID%> ,'<%=ExcludeListOnLoading%>' );

//-->
</script>
