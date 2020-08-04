// JavaScript Document

	   //??
      function checkall(form){
     
	  	var _form= form;
       // var isChecked=( document.forms["form1"].checkAll1.checked == true ); 
        var elements= document.forms[_form].elements; 
        var counter=elements.length; 
        for(i=0;i<counter;i++){ 
            var element=elements[i]; 
            if(element.type=="checkbox"){ 
             element.checked=true;              
            } 
        }
		OnCheckBoxClick(_form);
       } 
	   
	   
	   
	   
	   
	   //???
      function checkReserve(fromName){ 
	  	var _form= fromName;
      //  var isChecked=( document.forms["form1"].checkAll1.checked == true ); 
        var elements= document.forms[_form].elements; 
       
        if( document.all('aaa').checked)
        {
			document.all('aaa').checked=false;
        }
        else
        {
			 document.all('aaa').checked=true;
        }
        var counter=elements.length; 
        for(i=0;i<counter;i++){ 
            var element=elements[i]; 
            if(element.type=="checkbox"){ 
				 if(element.checked)
				 {
					element.checked=false;
				 }else
				 {
					element.checked=true; 
				 }             
            } 
        }
		OnCheckBoxClick(_form);
		
       } 
	   
	   
	   
	   //?????????????????
	   	function OnCheckBoxClick(fromName) 
		{	
		 	var _form= fromName;
			document.all["hd_Msn_Name_And_Mail"].value = "";
			 var elements= document.forms[_form].elements; 
			var counter=elements.length; 
			var idList="";
			for(i=0;i<counter;i++){ 
				var objectElement=elements[i]; 
			  if((objectElement.type == "checkbox") )
				{ 
					 if(objectElement.checked)//????????
					 {
							//var tempArrLstId = objectElement.id.split("_");
							//var tempId = tempArrLstId[tempArrLstId.length - 1];
							var tempId=objectElement.id.value;
							if(idList.length > 1)
							{idList += "," + tempId;}
							else
							{idList = tempId;}
							
					 }        
				} 
			}
			document.all["hd_Msn_Name_And_Mail"].value = idList;
			//alert('aaaa'+  document.all["hd_Msn_Name_And_Mail"].value);
		}		
		
	
	
	   
