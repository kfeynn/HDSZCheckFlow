<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.FieldValueControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<SELECT id="ddlValues" name="Select1" runat="server" style="DISPLAY: none; WIDTH: 100%">
</SELECT>
<INPUT id="chkValue" type="checkbox" name="Checkbox1" runat="server" style="DISPLAY: none">
<span ms_positioning="FlowLayout" id="divCheckLabel" runat="server" style="DISPLAY: none">
	Label</span> <INPUT type="text" id="txtValue" name="Text1" runat="server" style="DISPLAY: none; WIDTH: 100%" onfocus="SetDayHere(this)">
<INPUT id="btnBrowser" type="button" value="浏览" name="Button1" runat="server" style="DISPLAY: none">
<script language="javascript" src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/common_js.aspx" type="text/javascript" ></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QUERYCONTROL/scripts/date.js<%=this.NotReference%>" type="text/javascript" ></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QUERYCONTROL/scripts/lookup.js" type="text/javascript" ></script>
<script language="javascript">
<!--
	function LoadValue(ColType, EditFormat,sValue,EditMode)
	{
		var txtValue = document.all("<%=txtValue.ClientID%>");
		var chkValue = document.all("<%=chkValue.ClientID%>");
		var ddlValues = document.all("<%=ddlValues.ClientID%>");
		var btnBrowser = document.all("<%=btnBrowser.ClientID%>");
		var divCheckLabel = document.all("<%=divCheckLabel.ClientID%>");
		
		var sFormatType = EditFormat.substr(0,4).toLowerCase();

		txtValue.style.display = "none";
		chkValue.style.display = "none";
		ddlValues.style.display = "none";
		btnBrowser.style.display = "none";
		divCheckLabel.style.display = "none";

		if (EditFormat == "" || EditFormat.toLowerCase() == "memo")
		{
			//普通的文字，数字编辑，
			txtValue.style.display = "inline";
			txtValue.value = sValue;
			txtValue.setAttribute("ColType",ColType);
			//txtValue.onclick = "";
		}
		else if(ColType.toLowerCase() == "datetime")
		{
			//日期编辑
			txtValue.style.display = "inline";
			txtValue.value = sValue;
			txtValue.setAttribute("ColType",ColType);
			//txtValue.onclick = "setday(this);";
		}
		else if(sFormatType.toLowerCase() == "find")
		{
			txtValue.style.display = "inline";
			txtValue.value = sValue;
			txtValue.setAttribute("ColType",ColType);
		}
		else if(sFormatType.toLowerCase() == "comp")
		{
			txtValue.style.display = "inline";
			txtValue.value = sValue;
			txtValue.setAttribute("ColType",ColType);
		}
		else
		{
			var sFormat = EditFormat.substring(EditFormat.indexOf("(") + 1 ,EditFormat.lastIndexOf(")") );
			var nPos =0;
			var nPosNext = 0;
			switch(sFormatType)
			{
				case "code":
					LoadCodeValue(ddlValues,2,sFormat,sValue,EditMode);
					break;
				case "look":	
					//LoadCodeValue(ddlValues,1,sFormat,sValue,EditMode);		
					LoadCodeValue(ddlValues,1,escape(sFormat),sValue,EditMode);		
					break;
				case "chec":
					
					var sCheckValue;
					
					chkValue.style.display="inline";
					divCheckLabel.style.display = "inline";
					
					nPos=sFormat.indexOf("|");
					divCheckLabel.innerText = sFormat.substring(0,nPos);
					
					nPosNext = sFormat.indexOf("|", nPos+1);
					sCheckValue = sFormat.substr(nPos+1,nPosNext-nPos-1);
					
					
					chkValue.value = sCheckValue;					
					chkValue.setAttribute("nvalue",sFormat.substring(nPosNext+1));
					
					if (sValue == sCheckValue)
						chkValue.checked = true;
					else
						chkValue.checked = false;			
					
					break;
				case "comb":
					
					ddlValues.style.display = "inline";
					
					for (var i= ddlValues.length-1; i<-1; i--)
					{
						ddlValues.remove(i);
					}
					nPos = 0;
					nPosNext = sFormat.indexOf("|");
					var nSelectedIndex = -1 ;
					var i=0;
					while (1)
					{
						var sItemValue;
						if (nPosNext == -1)
							sItemValue = sFormat.substring(nPos);
						else
							sItemValue = sFormat.substring(nPos, nPosNext -1);
							
						var opt = document.createElement("OPTION");
						opt.value = sItemValue;
						opt.text = sItemValue;
						ddlValues.add(opt);
						nPos = nPosNext + 1;
						if (nPosNext == -1)
							break;
							
						nPosNext = sFormat.indexOf("|", nPosNext +1);
						
						if (sValue == sItemValue)
							nSelectedIndex = i;
						
						i++;
					}
					
					ddlValues.selectedIndex = nSelectedIndex;
					
					break;
				case "":
			}
		}
	}
	
function LoadCodeValue(ddlValues,nOption,sEditFormat,sValue,EditMode)
{
	
	for ( var i= ddlValues.length-1; i>-1; i--)
	{
		ddlValues.remove(i);
	}
	
	ddlValues.style.display = "inline";
	
	// 1 Look, 2 Code
	ddlValues.setAttribute("EditMode",EditMode);
	ddlValues.setAttribute("EditFormat",sEditFormat);
	ddlValues.setAttribute("LoadOption",nOption);
	
	var sXmlPath = "XGetCodesByEditFormat.aspx";
	
	var sSender = "<Code CodeType=\"" + nOption  + "\" CodeString=\"" + sEditFormat + "\" EditMode =\"" + EditMode + "\" />";
	var sReceiver = DataCommunicate(sSender,sXmlPath);
	var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
	xmlDoc.loadXML(sReceiver);
	var nSelectedIndex = -1;
	
	var optAll = document.createElement("Option");
	optAll.text ="";
	optAll.value ="";
	ddlValues.add(optAll);
	
	
	var nodelist = xmlDoc.selectNodes("//Code");
	for (var i=0; i < nodelist.length; i++)
	{
 		var opt= document.createElement("Option");
 		var sItemValue = nodelist[i].attributes[0].value;
		opt.text = nodelist[i].attributes[1].value;
		opt.setAttribute("value", sItemValue);
		
		ddlValues.add(opt);
		if (sItemValue == sValue)
			nSelectedIndex = i;
 	}	
 	 ddlValues.selectedIndex = nSelectedIndex;
	//alert(ddlValues.outerHTML);
}

function GetValueFromFieldValueControl()
{
	var sValue, sValueCaption;
	
	var txtValue = document.all("<%=txtValue.ClientID%>");
	var chkValue = document.all("<%=chkValue.ClientID%>");
	var ddlValues = document.all("<%=ddlValues.ClientID%>");
	var btnBrowser = document.all("<%=btnBrowser.ClientID%>");
	var divCheckLabel = document.all("<%=divCheckLabel.ClientID%>");
	
	if (txtValue.style.display =="inline")
	{
		sValue = txtValue.value;
		sValueCaption = sValue;
	}
	
	if (chkValue.style.display == "inline")
	{
		if (chkValue.checked )
		{
			sValue = chkValue.value;
			sValueCaption = divCheckLabel.innerText;
		}
		else
		{
			sValue = chkValue.getAttribute("nvalue");
			sValueCaption = "Not " + divCheckLabel.innerText;
		}
	}
	
	if (ddlValues.style.display == "inline")
	{
		if (ddlValues.selectedIndex>-1)
		{
			sValue = ddlValues.item(ddlValues.selectedIndex).value;
			sValueCaption = ddlValues.item(ddlValues.selectedIndex).text;
		}
	}		
	
	if ( sValue != null)
	{
		var aReturn = new Array(2);
		aReturn[0]= sValue;
		aReturn[1]= sValueCaption;
		return aReturn;
	}
	else
		return null;
}

function SetDayHere(txt)
{
	if (CheckIsDate(txt.getAttribute("ColType")))
	{
		setday(txt);
	}
}

function ShowTree()
{

	var ddlValues = document.all("<%=ddlValues.ClientID%>");

	
	//var bm = ddlValues.getAttribute("EditMode",EditMode);
	var sEditFormat = ddlValues.getAttribute("EditFormat");
	// 1 Look, 2 Code
	 
	var sOption = ddlValues.getAttribute("LoadOption");
	 
	var bm= sEditFormat.substring(0,sEditFormat.indexOf("|"));
	var endmark = 1;
	 
	
	if (sOption == "2" || bm == "B01")
	{
		SetLookValue(ddlValues,bm,endmark,"<%=ApplicationPath%>");
	}
	
}
	
//-->
</script>
