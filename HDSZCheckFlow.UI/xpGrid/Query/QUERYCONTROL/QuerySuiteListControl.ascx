<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.QuerySuiteListControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<script language="javascript" type="text/javascript" src="<% =ApplicationPath %>xpGrid/Query/QueryControl/scripts/xmlExecute.js" ></script>
<script language="javascript" type="text/javascript" src="<% =ApplicationPath %>xpGrid/Query/QueryControl/scripts/common_js.aspx" ></script>
<script language=javascript>
<!--
	function OpenConditionBySuite(SuiteID)
	{
		var hidConditionCollector =document.all("<%=hidConditionCollector.ClientID%>"); 
		var hidSelectedSetID = document.all("<%=hidSelectedSetID.ClientID%>"); 
		var hidSelectedPre = document.all("<%=hidSelectedPre.ClientID%>"); 
		var sXmlPath ="<% =ApplicationPath %>xpGrid/Query/QueryControl/xml/XGetConditionIDBySuiteID.aspx";
		var sSender = "<SuiteID>" + SuiteID  + "</SuiteID>";
		
		 
		var sReceiver = DataCommunicate(sSender,sXmlPath);
		var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
		
	
		xmlDoc.loadXML(sReceiver);
		
		var  nodes= xmlDoc.selectNodes("//Set");
		var iSetID = nodes[0].attributes[0].value;
				
		// alert(iSetID);
		hidSelectedSetID.value = iSetID;
		
		if (iSetID != "0")
		{
			var sDialogPath= "<% =ApplicationPath %>xpGrid/Query/QueryControl/ConditionCollector.aspx?SetID="+iSetID + "&Pre=1";
			hidConditionCollector.value= ShowModelDialog(sDialogPath, "","");
			hidSelectedPre.value = "1";
		}
		else
		{
			hidSelectedPre.value = "0";
			hidConditionCollector.value="";
		}
		
 		 
	}
//-->
</script>

<br>
		<asp:DataList id="dtlList" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
			<ItemTemplate>
			<div onclick = "OpenConditionBySuite(<%# DataBinder.Eval(Container.DataItem, "SuiteID" ) %>)">
				<asp:LinkButton id="lnkSuite" runat="server">
					<%# DataBinder.Eval(Container.DataItem, "Caption" ) %>
				</asp:LinkButton>
				<asp:Label id="lblSuiteID" runat="server"   Text ='<%# DataBinder.Eval(Container.DataItem, "SuiteID" )%>' visible ="False" >
				</asp:Label>
			</div>
			</ItemTemplate>
		</asp:DataList>
		<input type="hidden" id="hidConditionCollector" runat="server" NAME="hidConditionCollector">
		<input type="hidden" id="hidSelectedSetID" runat="server"  >
		<input type="hidden" id="hidSelectedPre" runat="server"  >
		
