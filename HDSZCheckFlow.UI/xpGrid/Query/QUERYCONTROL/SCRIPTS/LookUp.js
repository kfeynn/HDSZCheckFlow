
function fnSetValues(){
   var sFeatures="dialogHeight: 78px;dialogWidth:310;center:yes";
   return sFeatures;
}



function SetLookValue(editor,bm,endmark,ApplicationPath)
{
  var sFeatures=fnSetValues();
  var SelectValue;  // = window.showModalDialog(ApplicationPath+"/WebPublic/PubGetCodeValue.aspx?bm=" + bm + "&endmark=" + endmark);
  var oOption;
  if (bm=="B01")
	SelectValue = window.showModalDialog(ApplicationPath+"/WebPublic/PubGetDeptValue.aspx?bm=" + bm + "&endmark=" + endmark);
  else
    SelectValue = window.showModalDialog(ApplicationPath+"/WebPublic/PubGetCodeValue.aspx?bm=" + bm + "&endmark=" + endmark);
  if ( SelectValue != "undefined" && SelectValue != null)
  {
	for (var i = 0; i < editor.options.length; i++)
	{
	    oOption = editor.options[i];
		if ( oOption.value == SelectValue )
		{
		  oOption.Selected = true;
		  editor.selectedIndex = i;
		  break;
		}
	}
	if (i==editor.options.length)
	  alert("所选的值不是合法的，该项目可能只允许输入末级编码！");
  }
}
