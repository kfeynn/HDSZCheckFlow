//对2个List进行Item的移动/Copy/删除的操作，
//传入参数是控件本身
//optRemove 1 表示移动， 0，表示复制
 
function MoveSelectItems(lstFrom, lstTo, optRemove )
{
	var sColumnType = lstTo.getAttribute("ColumnType");
	
	if (sColumnType == null)
	{
		sColumnType = "0";
	}
	
	if (lstFrom.selectedIndex==-1)
	{
		alert("请选择需要移动的项目！");
		return false;
	}
	while (lstFrom.selectedIndex>-1 )	
	{
		
		var opt= document.createElement("Option");

		opt.text = GetItemDefaultCaption(lstFrom.item(lstFrom.selectedIndex),sColumnType);
		opt.value = lstFrom.item(lstFrom.selectedIndex).value;		
		lstTo.add(opt);
		
		if (optRemove==1)
			lstFrom.remove(lstFrom.selectedIndex);
		else	
			lstFrom.options[lstFrom.selectedIndex].selected = false;
		 
	}
}

function MoveAllItems(lstFrom, lstTo, optRemove)
{
	var sColumnType = lstTo.getAttribute("ColumnType");
	if (sColumnType == null)
	{
		sColumnType = "0";
	}
	
	if (optRemove == 1)
	{
		while ( lstFrom.options.length >0)
		{


			var opt= document.createElement("Option");
			opt.text = GetItemDefaultCaption(lstFrom.item(0),sColumnType);;
			opt.value = lstFrom.item(0).value;		
			lstTo.add(opt);

			lstFrom.remove(0);
			
		}
	}
	else
	{
		for (var i=0; i<lstFrom.options.length; i++)
		{
			var opt= document.createElement("Option");
			opt.text = GetItemDefaultCaption(lstFrom.item(i),sColumnType);;
			opt.value = lstFrom.item(i).value;		
			lstTo.add(opt);
		}
	
	}
	
}

function RemoveSelectItems(lst)
{
	if (lst.selectedIndex==-1)
	{
		alert("请选择需要删除的项目！");
		return false;
	}


	while (lst.selectedIndex>-1 )	
	{		 
		lst.remove(lst.selectedIndex); 		 
	}
}

function RemoveAllItems(lst)
{
	for ( var i=lst.options.length -1 ; i>-1 ; i--)
	{
		lst.remove(i);
		
	}

}

//这个方法用于在提交前收集客户端的List中的Value,传给hidden在服务器端使用
function CollectFields(lst,hid)
{
	if (lst == null)
		return false;
	
	 
		
	var sIDList = "";
	var sSeperator ="\t";
	for (var i =0; i< lst.options.length; i++)
	{
		var item = lst.item(i);
		var temp,sTemp;
		
		temp = item.getAttribute("RecordID")
		if (temp == null)
			sTemp ="0";
		else
			sTemp = temp;		
		sUnit = sTemp + sSeperator;
		
		sUnit = sUnit + item.value + sSeperator;
		
		temp = item.getAttribute("Sort");
		if (temp == null)
			sTemp ="1";
		else
			sTemp = temp;		
		sUnit = sUnit + sTemp + sSeperator;		

		temp = item.getAttribute("StatFun");
		if (temp == null)
			sTemp ="0";
		else
			sTemp = temp;		
		sUnit = sUnit + sTemp + sSeperator;
		
		sUnit = sUnit + item.text + sSeperator;
		
		temp = item.getAttribute("FieldValue");
		if (temp == null)
			sTemp ="";
		else
			sTemp = temp;
			
		sUnit = sUnit + sTemp + sSeperator;			
		
		sIDList =  sIDList + sUnit ;
	}
	
	hid.value = sIDList;
	//alert(sIDList);
}


//列表中的选择内容向上移动
function ListMoveUp(lst)
{
	if(lst.selectedIndex == -1)
	{
		alert("没有需要移动的选项");
		return false;
	}
	
	if (lst.options[0].selected)
	{
		alert("对不起，选项已经在最上的位置，不能移动！");
		return false;
	}
	
	for( var i =1; i< lst.length; i++)
	{
		if (lst.options[i].selected)
		{
			lst.options[i].swapNode(lst.options[i-1]);
		}
	}
}

//列表中的选择内容向下移动
function ListMoveDown(lst)
{
	if(lst.selectedIndex == -1)
	{
		alert("没有需要移动的选项");
		return false;
	}
	
	if (lst.options[lst.length-1].selected)
	{
		alert("对不起，选项已经在最下的位置，不能移动！");
		return false;
	}

	
	for( var i = lst.length -2 ; i>-1; i--)
	{
		if (lst.options[i].selected)
		{
			lst.options[i].swapNode(lst.options[i+1]);
		}
	}
}

 
	function ltrim(sInput)
	{
		var sReturn;
		
		var re = /^\s*/g;
		//r = re.match(re);
		
		sReturn = sInput.replace(re,"");
		
		return sReturn;
	}
	
	function BoundItem2SelectList (lst,hid)
	{
		var sCode = hid.value;
		var aIDs = sCode.split("\t");
		
		for (var i =0; i<aIDs.length -1; i+=6)
		{
			var opt = document.createElement("OPTION");
			opt.setAttribute("RecordID",aIDs[i]);
			opt.value = aIDs[i+1];
			opt.setAttribute("Sort",aIDs[i+2]);
			opt.setAttribute("StatFun",aIDs[i+3]);
			opt.text = aIDs[i+4];
			
			opt.setAttribute("FieldValue",aIDs[i+5]);
			
			lst.add(opt);
		}
		
	}
	
	 //移动的时候，使用
	 function GetItemDefaultCaption(item,sColumnType) 
	 {
		sReturn = item.text;
		
		switch(sColumnType)
		{
			case "1":
				sReturn += " [升序] ";
				break;
			case "2":
				sReturn += " [无] ";
		}
		
		return sReturn;
	 }
