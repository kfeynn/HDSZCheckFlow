<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.scripts.common_js" %>

function ShowModelDialog(sPath, sParameters, sOptions)
{
	var arr = new Array();
	arr[0]=sPath;
	arr[1]=sParameters;
	 
	return window.showModalDialog("<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/DialogFrame.htm", arr,sOptions);
}

function BrowseDate(txtDate)
{
	var sPath = "<%=ApplicationPath%>xpGrid/Query/QueryControl/DatePicker.aspx?date="+ txtDate.value;
	txtDate.value=ShowModelDialog(sPath, "","");
}