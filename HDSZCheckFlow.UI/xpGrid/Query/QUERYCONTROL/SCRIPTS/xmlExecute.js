function DataCommunicate(strXML,ActionFileURL) {

    //alert('010');
	var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
	xmlDoc.async = false;
	strXML = "<XpGrid>" + strXML + "</XpGrid>";
	var httpObj = new ActiveXObject("Microsoft.XMLHTTP");
	if(xmlDoc.loadXML(strXML))
	{
		httpObj.Open("POST",ActionFileURL,false);
		httpObj.Send(xmlDoc);

		
		//alert(httpObj.responseText);
		//alert(ActionFileURL); // zyq test
		
		if(xmlDoc.loadXML(httpObj.responseText)==false)
		{
			return "<XpGrid>FALSE</XpGrid>";
		}
		else
		{
			return "<XpGrid>" + xmlDoc.xml + "</XpGrid>";
		}
	}
}

function DataCommunicateEx(strXML,ActionFileURL)
{
	var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
	xmlDoc.async = false;
	strXML = "<XpGrid>" + strXML + "</XpGrid>";
	var httpObj = new ActiveXObject("Microsoft.XMLHTTP");
	if(xmlDoc.loadXML(strXML))
	{
		httpObj.Open("POST",ActionFileURL,false);
		httpObj.Send(xmlDoc);
		return httpObj.responseXML.xml;
	}
	else
		return "FALSE";
}



function BoundFieldFromTable(ddlTables, lstFields, lstRefer,sExcludeIDList)
{
	BoundField(ddlTables.item(ddlTables.selectedIndex).value,lstFields,lstRefer,sExcludeIDList);
}

function BoundField(TableName, lstFields, lstRefer,sExcludeIDList)
{
	var sXmlPath ="XGetFieldsByTable.aspx";
	var Right = 0;
	
	//alert(lstFields.getAttribute("EditMode"));
	if (lstFields.getAttribute("EditMode") == "1")
	{
		Right =1;
	}
	if (lstFields.getAttribute("RightControl") == "1" || lstFields.getAttribute("RightControl") == "True")
	{
		Right =1;
	}
	
	var sSender = "<Table TableName=\"" + TableName  + "\" Right =\"" + Right + "\" />";
	//alert("sSender1" + sSender);
	var sReceiver = DataCommunicate(sSender,sXmlPath);
	//alert("sReceiver" + sReceiver);
	var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
	xmlDoc.loadXML(sReceiver);
	
	for ( var n=lstFields.options.length -1 ; n>-1 ; n--)
	{
		lstFields.remove(n);
	}
	
	var nodelist = xmlDoc.selectNodes("//Field");
	for (var i=0; i < nodelist.length; i++)
	{
		var sValue = nodelist[i].attributes[0].value;
		if ( (lstRefer == null || CheckExist(lstRefer, sValue)==false) && sExcludeIDList.indexOf("," + sValue + ",") == -1)
		{
			var opt= document.createElement("Option");
			opt.text = nodelist[i].attributes[1].value;
			opt.setAttribute("value", sValue );
			//alert(sValue + ";" + nodelist[i].attributes[2].value + nodelist[i].attributes[3].value);
			opt.setAttribute("ColType", nodelist[i].attributes[2].value);
			opt.setAttribute("EditFormat", nodelist[i].attributes[3].value);
			
			lstFields.add(opt);
		}
	}
	
	
}

function CheckExist(lstRefer, sValue)
{
	for (var i=0; i< lstRefer.options.length; i++)
	{
		if (sValue == lstRefer.options[i].value)
			return true;
	}
	return false;
}


//为选择的列表设置Option的属性
//iOption, 1,代表排序属性Sort; 2,代表统计字段属性Stat; 
function FieldSetAttribute(lst,iOption, sValue)
{
	if (lst.selectedIndex ==-1)
	{
		alert("请先选择需要设置的项目！");
		return;
	}
	
	var sOption;
	switch (iOption)
	{
		case 1:
			sOption = "Sort";
			break;
		case 2:
			sOption = "StatFun";
			break;	
	}
	
	//lst
	var iIndex = lst.selectedIndex;
	if (iIndex>-1)
	{
		var opt = lst.item(iIndex);
		opt.setAttribute(sOption,sValue);
		opt.text=ChangeItemCaption(opt,iOption);
		
		//alert(opt.text);	
	}
	 lst.selectedIndex = iIndex ;
	
}

function ChangeItemCaption(opt,iOption)
{
	var sReplace ="";
	switch(iOption)
	{
		case 1:
			var sSort = opt.getAttribute("Sort");
			if (sSort=="1")
				sReplace = "[升序]";
			else
				sReplace = "[降序]";
			break;
		case 2:
			var sStatFun = "" + opt.getAttribute("StatFun");
			switch(sStatFun)
			{
				case "0":
					sReplace = "[无]";
					break;
				case "1":
					sReplace = "[计数]";
					break;
				case "2":
					sReplace = "[求和]";
					break;
				case "3":
					sReplace = "[平均值]";
					break;
			}
			break;
	}
	
	sReturn = opt.text;
	
	if (sReturn.indexOf("]")>-1)	 
		sReturn = sReturn.substr(0,sReturn.lastIndexOf("[")) + sReplace;
	
		
	return sReturn;
	
}

function FieldGetRadioAttribute(lst,iOption,sName,sDefault)
{
	if(lst.selectedIndex == -1)
	{
		return false;
	}

	var sOption;
	switch (iOption)
	{
		case 1:
			sOption = "Sort";
			break;
		case 2:
			sOption = "StatFun";
			break;	
	}
	
	//lst
	var sValue = lst.item(lst.selectedIndex).getAttribute(sOption);
	if (sValue == null)
		sValue = sDefault ;
	
	var opts = document.getElementsByName(sName);
	for (var i = 0; i<opts.length;  i++)
	{
		if (opts[i].value == sValue)
		{
			opts[i].checked = true;
			break;
		}
	}
	
	//alert(lst.innerHTML);	

}


//装载操作符
function LoadOperators(ddlOperators,sColType,sEditFormat,EditMode)
{
	var sXmlPath="XGetOperatorByGroup.aspx";
	var sGroup;
	
	//alert(EditMode);
	if (EditMode ==1 ) 
	{
		sGroup =0;
	}
	else
	{
		//alert(sColType);
		if (CheckIsNumeric(sColType) || CheckIsChar(sColType) || CheckIsDate(sColType))
		{
			if (CheckIsChar(sColType))
				sGroup = 3;
			else
			{
				if (CheckIsNumeric(sColType))
					sGroup = 2;
				else
					sGroup = 3;
			}
		}	
		else
		{
			return false;
		}
	}
	
	var sSender = "<Group GroupID=\"" + sGroup  + "\"/>";
	var sReceiver = DataCommunicate(sSender,sXmlPath);
	var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
	//alert("sReceiver2" + sReceiver);
	xmlDoc.loadXML(sReceiver);
	
	for ( var n=ddlOperators.options.length -1 ; n>-1 ; n--)
	{
		ddlOperators.remove(n);
		
	}
	
	var nodelist = xmlDoc.selectNodes("//Operator");
	for (var i=0; i < nodelist.length; i++)
	{
 		var opt= document.createElement("Option");
		opt.text = nodelist[i].attributes[1].value;
		opt.setAttribute("value", nodelist[i].attributes[0].value);
		//alert(sColType.toLowerCase());
		
		ddlOperators.add(opt);
 	}	
	//alert("sColType" + sColType);
	if(sColType.toLowerCase().indexOf("char") >= 0)
	{
		for(var i = 0; i < ddlOperators.options.length; i++)
			if(ddlOperators.options(i).text == "匹配")
				ddlOperators.options(i).selected = true;
	}
	ddlOperators.setAttribute("ColType",sColType);
	ddlOperators.setAttribute("EditFormat",sEditFormat);
}

function CheckIsNumeric(sColType)
{
	var sNumericString = ",smallmoney,float,smallint,int,money,int identity,decimal,numeric,";
	var sMatch = "," + sColType.toLowerCase() + ",";
	
	if(sNumericString.indexOf(sMatch)>-1)
		return true;
	else
		return false;
}

function CheckIsChar(sColType)
{
	var sCharString =",char,varchar,text,string,";
	var sMatch = "," + sColType.toLowerCase() + ",";
	if(sCharString.indexOf(sMatch)>-1)
		return true;
	else
		return false;
	
}

function CheckIsDate(sColType)
{
	var sNumericString = ",smalldatetime,datetime,date,";
	var sMatch = "," + sColType.toLowerCase() + ",";
	
	if(sNumericString.indexOf(sMatch)>-1)
		return true;
	else
		return false;
}

