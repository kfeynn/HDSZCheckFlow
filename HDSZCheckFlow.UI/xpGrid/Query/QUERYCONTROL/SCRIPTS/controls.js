

function CheckAll( checkAllBox, szItemName )
{
	var frm = checkAllBox.form ;
	var actVar = checkAllBox.checked ;
	for(i=0;i< frm.length;i++)
	{
		e=frm.elements[i];
		if ( e.type=='checkbox' && e.name.indexOf(szItemName) != -1 )
			e.checked= actVar ;
      
	}

}


function UnCheck(checkItem, szAllName)
{

 
	var frm = checkItem.form ;			
	
	for(i=0;i< frm.length;i++)
	{
		e=frm.elements[i];
		if ( e.type=='checkbox' && e.name.indexOf(szAllName) != -1 )
		{
			e.checked= false ;
			break;
		}
	}
}





function SelectTextBox(txt)
{
	txt.select();
}

function GetSelectCount(frm, chkName)
{
		//count
		var nCount=0;
		for(var i=0;i< frm.length;i++)
		{
			e=frm.elements[i];
			if ( e.type=='checkbox' && e.name.indexOf(chkName) != -1 )
			{
				if (e.checked==true)
				{
					
					nCount++;
				}	
			}
		}
		
		return nCount;
}

	function AvoidEnter()
	{
		if (window.event.keyCode == 13)
		{
			window.event.keyCode = 0;
		}
	}

