 
/*--------------------------------���½ű����ڱ���ϵͳ-----------------------------------------*/		
	/*����Excel�ļ��Ľű�*/
			function Export2Excel()
				{
						var strCacheName=document.getElementById("CacheName").value;
						if (strCacheName != "")
							{
							var MyUrl=""
							MyUrl=top.SystemRootPath+"AppSystem/ReptSystem/Export2Excel.aspx?CacheName=" +strCacheName;
							document.getElementById("CacheName").value = "" ;
							if (MyUrl.substring(0,9) != "undefined"){parent.document.location.href=MyUrl;};
							}
				}
	/*���IE������ʷ�б��Է�ֹ�û��ص���Чҳ��*/
		function CleanThisHistory()
				{
					var strName=event.srcElement.name;
					if(strName != "ExportToExcel"){location.replace("");}
				}	
	/*�����趨�Ƿ����Cache�ı�־*/
			function SetCleanFlag()
				{
						var strName=event.srcElement.name;
						switch(strName){
							case "btnFirstPage":
								document.getElementById("NeedCleanCache").value=0;
								break;
							case "btnPrevPage":
								document.getElementById("NeedCleanCache").value=0;
								break;
							case "btnNextPage":
								document.getElementById("NeedCleanCache").value=0;
								break;
							case "btnLastPage":
								document.getElementById("NeedCleanCache").value=0;
								break;
							case "btnGotoPage":
								document.getElementById("NeedCleanCache").value=0;
								break;
							case "btnPrint":
								document.getElementById("NeedCleanCache").value=0;
								break;
							case "ExportToExcel":
								document.getElementById("NeedCleanCache").value=0;
								break;
							default:
								document.getElementById("NeedCleanCache").value=1;
								}
				}
	/*���ڽ����а�ť����ֹ��*/
			function DisableAll()
				{
				 document.getElementById("btnFirstPage").disabled = true;
				 document.getElementById("btnPrevPage").disabled = true;
				 document.getElementById("btnNextPage").disabled = true;
				 document.getElementById("btnLastPage").disabled = true;
				 document.getElementById("txtGotoPage").disabled = true;
				 document.getElementById("btnGotoPage").disabled = true;
				 document.getElementById("btnPrint").disabled = false;
				 document.getElementById("btnExport").disnabled = true;
				 }
	 /*������һҳ*/
			function GoBack()
				{
					alert("OK");
					history.back();
					
				}	
	/*���´���ͨ����һ�������ֹرյķ����������ӡ����ʱ����Cache�����˻� */			
			function CleanCache()
				{
					var jsNeedCleanCache
					try
						  {
							jsNeedCleanCache=document.getElementById("NeedCleanCache").value;
									    //�˴������ӡ��PDFʱ�ű����������
						  }										    
						catch(err)									
						  {
							jsNeedCleanCache=0
						  }
						  
					if (jsNeedCleanCache==0) 
						{return}; /*Do Nothing*/
					if (jsNeedCleanCache==1)
						{
						 var jsCacheName=document.getElementById("CacheName").value;
						 var MyUrl=""
						 MyUrl=top.SystemRootPath+"AppSystem/ReptSystem/CleanCache.aspx?" + "CacheName=" + jsCacheName;
						 if(MyUrl.substring(0,9) != "undefined"){wins=window.showModalDialog(MyUrl, window, "dialogWidth: 250px; dialogHeight: 100px;help: no;status:no");};
						}
				}
	/*---------------------------------End-----------------------------------------*/				

	/*����IE״̬������*/
	function SetState()
				{
				parent.time=600; //δ�����������ظ�����
				window.status=parent.AppName;
				}	
	/*���´���������ʾӦ�ó�������*/
	function ShowState()
				{
					window.status=document.getElementById("lblAppName").innerText;		
				}
	/*�����ӳٹرմ���*/	
	function DelayCloseWin(value)
				{
				if(value != 0 && value !="" && value != null){window.setTimeout("window.close()",value);}
				else {window.setTimeout("window.close()",4000);}
				}
	/*���´���ͨ����һ�������ֹرյķ�����ʹJavascript�ű��ܹ�����asp.net���� */
			function CloseWin()
				{
					if (top.SystemRootPath != "")
					   {
						  wins=window.showModalDialog(top.SystemRootPath+"xpGrid/LogOut.aspx?UserId="+window.userid, window, "dialogWidth: 250px; dialogHeight: 100px;help: no;status:no;");
					   }			
				}
				
			function CloseWin2(UserId)
				{
					if (top.SystemRootPath != "")
					   {
						  wins=window.showModalDialog(top.SystemRootPath+"xpGrid/LogOut.aspx?UserId="+UserId, window, "dialogWidth: 250px; dialogHeight: 100px;help: no;status:no;");
					   }			
				}

				
	/*���´����ô��ڴ�С*/
			function sWidth()
				{
					return document.body.clientWidth;
				}
			function sHeight()
				{
					return document.body.clientHeight;
				}				
			function SetFormSize()
				{
				document.getElementById("Form1").style.width=sWidth();
				document.getElementById("Form1").style.height=sHeight();
				}
			
    /*���´��뽫������� */
		function maxwin()
				{
					self.moveTo(0,0);
					self.resizeTo(screen.availWidth,screen.availHeight);
				}
	/*���´������ڽ��س�תΪTab�� �������˸�����ctrl*/
			function setenter()
				{
				if ((event.keyCode==8) && (event.srcElement.type != "text") && (event.srcElement.type != "password") && (event.srcElement.type != "checkbox") && (event.srcElement.type != "textarea") && (event.srcElement.type != "file") && (event.srcElement.type != "radio")){event.keyCode=17;}
				if ((event.keyCode==13) && ((event.srcElement.type == "text") || (event.srcElement.type == "password") || (event.srcElement.type == "checkbox") || (event.srcElement.type == "file") || (event.srcElement.type == "radio") ) ) {event.keyCode=9;};
				}
				
	/*���´������ڽ��������ҳ��ĵ�һ������ؼ�*/
			function FirstInputCtrl()
				{
			var Pmin=99999; //���ڴ�ſؼ�λ�þ���ֵ�е���Сֵ
			var TempP=0;
			var ctrlIndex=0;
			var TempType=0; //Ĭ����INPUT��������
			
			var links1 = document.getElementsByTagName("INPUT"); //�����������ؼ��б�
			 if (links1.length>0)
			  {
				for(var i = 0; i < links1.length; i++)
				{
					//if (links1[i].type != "hidden")
					//alert(links1[i].name);
					if ((links1[i].type == "text" || links1[i].type == "password" ) &&  !(links1[i].disabled))
						{
						var t=links1[i].offsetTop;
						var l=links1[i].offsetLeft;
						TempP=Math.sqrt(Math.pow(t,2)+Math.pow(l,2));
						if (TempP<Pmin)
							{
							Pmin=TempP;
							ctrlIndex=i;
							TempType=1;
							} //enf of if
						} //end of if
				 
				} //end of for
			  } //end of if 
				
				var links2 = document.getElementsByTagName("TEXTAREA"); //�����ı���
			   if (links2.length>0) 
			    {
			 	for(var i = 0; i < links2.length; i++)
					{
						if ((links2[i].type != "hidden") && !(links2[i].disabled))
							var t=links2[i].offsetTop;
							var l=links2[i].offsetLeft;
							TempP=Math.sqrt(Math.pow(t,2)+Math.pow(l,2));
							if (TempP<Pmin)
								{
								Pmin=TempP;
								ctrlIndex=i;
								TempType=2;
								}// end of if
					} //end of for
				} //end of if
				
			var links3 = document.getElementsByTagName("SELECT");  //�����б�
			   if (links3.length>0)
			    {
			 	for(var i = 0; i < links3.length; i++)
					{
						if ((links3[i].type == "select-one") && !(links3[i].name.indexOf("ddlSaverList")> 0) && !(links3[i].disabled))
						   {
							var t=links3[i].offsetTop;
							var l=links3[i].offsetLeft;
							//alert(links3[i].name);
							TempP=Math.sqrt(Math.pow(t,2)+Math.pow(l,2));
							if (TempP<Pmin)
								{
							//	alert(links3[i].name);
								Pmin=TempP;
								ctrlIndex=i;
								TempType=3;
								}// end of if Temp
							}//end of if links3.type name
					} //end of for
				} //end of if links3.length
			
				try
				{				
				if (TempType==1 ){links1[ctrlIndex].focus();selectText();return false};
				if (TempType==2 ){links2[ctrlIndex].focus();selectText();return false};
				
				//��������б��һ��������ΪddlSaverList��ֱ�ӵڶ�����ý������Ի��� 2006��8��16��
				if (TempType==3 ){
					if (!(links3[0].name.indexOf("ddlSaverList")> 0)){
						links3[0].focus();
						selectText();
						return false
						}
					else{					
						links3[1].focus();
						selectText();
						return false
						}
								}
				}
				catch(err){}
			}

	/*���´������ڻ�ÿؼ��ľ���λ��*/
			function getPosition(ctrlname){
				var t=ctrlname.offsetTop;
				var l=ctrlname.offsetLeft;
				while(ctrlname=ctrlname.offsetParent){
				t+=ctrlname.offsetTop;
				l+=ctrlname.offsetLeft;
				}
				alert("top="+t+"/nleft="+l);
				}
								
	
	/*���´������ڽ���������ı����δβ*/
			function MoveToLast()
				{
				var e = event.srcElement;
				var r =e.createTextRange();
				r.moveStart("character",e.value.length);
				r.collapse(true);
				r.select();
				}
				
	/*���´�������ѡ�����ı��������������ı�*/
			function selectText() 
				{ 
				var e = event.srcElement;
				var e = document.activeElement;
				if ((e.type=="text" || e.type=="password" ))
					{
						var rng = e.createTextRange(); 
						rng.moveEnd("character",-10);
						rng.moveStart("character",-1);
						rng.collapse(true); 
						rng.moveStart("character",0) 
						rng.moveEnd("character",e.value.length) 
						rng.select(); 
					}
				} 	
    				
	/*���º�������ʵ��ȡ��if (j<=0)*/
				function getint(I,k)
					{
					var result=0;
					result=parseInt((""+(I/k)));
					return result;
					}
					
	/*���º������ڽ�ֹ����Formѡ��ؼ�)*/					
					
				function NoSelect()
					{
						var tj =false;
						try
						  {
							tj=(event.srcElement.type="undefined")  //�˴����Ī��������ִ��������
						  }										    //1���ֹ�����ѡ���ı����е��ı�
						catch(err)									//2�����ֹ�����ѡ��Form�еĶ���
						  {
							tj=false
						  }
						if(tj)
						  {
							window.event.returnValue=false;
						  }
					}
								
	/*���º���������������Ҽ�*/					
			
				function NoRightMenu()
					{
						window.event.returnValue=false;
					}