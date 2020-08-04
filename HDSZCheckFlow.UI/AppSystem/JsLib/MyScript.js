 
/*--------------------------------以下脚本用于报表系统-----------------------------------------*/		
	/*导出Excel文件的脚本*/
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
	/*清除IE访问历史列表，以防止用户回到无效页面*/
		function CleanThisHistory()
				{
					var strName=event.srcElement.name;
					if(strName != "ExportToExcel"){location.replace("");}
				}	
	/*用于设定是否清除Cache的标志*/
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
	/*用于将所有按钮都禁止掉*/
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
	 /*返回上一页*/
			function GoBack()
				{
					alert("OK");
					history.back();
					
				}	
	/*以下代码通过打开一个窗口又关闭的方法来清除打印报表时产生Cache，并退回 */			
			function CleanCache()
				{
					var jsNeedCleanCache
					try
						  {
							jsNeedCleanCache=document.getElementById("NeedCleanCache").value;
									    //此处解决打印到PDF时脚本出错的问题
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

	/*设置IE状态栏汉字*/
	function SetState()
				{
				parent.time=600; //未操作计数器回复计数
				window.status=parent.AppName;
				}	
	/*以下代码用于显示应用程序名称*/
	function ShowState()
				{
					window.status=document.getElementById("lblAppName").innerText;		
				}
	/*窗口延迟关闭代码*/	
	function DelayCloseWin(value)
				{
				if(value != 0 && value !="" && value != null){window.setTimeout("window.close()",value);}
				else {window.setTimeout("window.close()",4000);}
				}
	/*以下代码通过打开一个窗口又关闭的方法来使Javascript脚本能够调用asp.net代码 */
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

				
	/*以下代码获得窗口大小*/
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
			
    /*以下代码将窗口最大化 */
		function maxwin()
				{
					self.moveTo(0,0);
					self.resizeTo(screen.availWidth,screen.availHeight);
				}
	/*以下代码用于将回车转为Tab键 及屏蔽退格键变成ctrl*/
			function setenter()
				{
				if ((event.keyCode==8) && (event.srcElement.type != "text") && (event.srcElement.type != "password") && (event.srcElement.type != "checkbox") && (event.srcElement.type != "textarea") && (event.srcElement.type != "file") && (event.srcElement.type != "radio")){event.keyCode=17;}
				if ((event.keyCode==13) && ((event.srcElement.type == "text") || (event.srcElement.type == "password") || (event.srcElement.type == "checkbox") || (event.srcElement.type == "file") || (event.srcElement.type == "radio") ) ) {event.keyCode=9;};
				}
				
	/*以下代码用于将光标移至页面的第一个输入控件*/
			function FirstInputCtrl()
				{
			var Pmin=99999; //用于存放控件位置绝对值中的最小值
			var TempP=0;
			var ctrlIndex=0;
			var TempType=0; //默认是INPUT类型数组
			
			var links1 = document.getElementsByTagName("INPUT"); //获得所有输入控件列表
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
				
				var links2 = document.getElementsByTagName("TEXTAREA"); //多行文本框
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
				
			var links3 = document.getElementsByTagName("SELECT");  //下拉列表
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
				
				//如果下拉列表第一个下拉框为ddlSaverList则直接第二个获得焦点罗显华改 2006年8月16日
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

	/*以下代码用于获得控件的绝对位置*/
			function getPosition(ctrlname){
				var t=ctrlname.offsetTop;
				var l=ctrlname.offsetLeft;
				while(ctrlname=ctrlname.offsetParent){
				t+=ctrlname.offsetTop;
				l+=ctrlname.offsetLeft;
				}
				alert("top="+t+"/nleft="+l);
				}
								
	
	/*以下代码用于将光标移至文本框的未尾*/
			function MoveToLast()
				{
				var e = event.srcElement;
				var r =e.createTextRange();
				r.moveStart("character",e.value.length);
				r.collapse(true);
				r.select();
				}
				
	/*以下代码用于选择在文本框中所有已有文本*/
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
    				
	/*以下函数用于实现取整if (j<=0)*/
				function getint(I,k)
					{
					var result=0;
					result=parseInt((""+(I/k)));
					return result;
					}
					
	/*以下函数用于禁止界面Form选择控件)*/					
					
				function NoSelect()
					{
						var tj =false;
						try
						  {
							tj=(event.srcElement.type="undefined")  //此处解决莫名其妙出现错误的问题
						  }										    //1、手工可以选择文本框中的文本
						catch(err)									//2、但手工不能选择Form中的东西
						  {
							tj=false
						  }
						if(tj)
						  {
							window.event.returnValue=false;
						  }
					}
								
	/*以下函数用于屏蔽鼠标右键*/					
			
				function NoRightMenu()
					{
						window.event.returnValue=false;
					}