		$(function(){
			$("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVENTORYCODE").change(function(){ 
				var inv_pk=$("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVENTORYCODE").val();//pk值 
            $.ajaxSettings.async = false;
            $.getJSON("../../BaseData/Commons/MyHandleRequest.ashx?inv_pk=" + inv_pk + "&R=" + new Date(), function(base_inventory)  
             {
              var orPrice=base_inventory[0].RealOriginalcurPrice; //原币单价 
              var currTypeCode=base_inventory[0].RealCurrTypeCode; //币种
              var rmbPrice=base_inventory[0].RmbPrice; //本币单价

              //品名
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVENTORYNAME").val(base_inventory[0].invName);
              
              //规格
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVTYPE").val(base_inventory[0].invspec);
              
              //单位
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_UNIT").val(base_inventory[0].measname);
              
              //原币单价
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_ORIGINALCURRPRICE").val(orPrice);
              
              //补0 防止出现：.2 , .5 这种显示
               if(base_inventory[0].RmbPrice.indexOf(".")==0){
					rmbPrice="0"+rmbPrice
				}
              //本币单价
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_RMBPRICE").val(rmbPrice);          
             //币种
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_CURRTYPECODE").val(currTypeCode); 
          
             //过滤不符合的单价
              if(orPrice==null || orPrice=="" || orPrice=="0"){
					$("#"+XPGrid+"_g_edtGridItem_btnUpdateButton").attr("disabled", true);//保存按钮设置成失教。
					$("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_MONEY").val("");//清空本币预算金额
					var tab=$("#"+XPGrid+"_g_edtGridItem_tblEditTable");
					$("tr[id='tr_msg']").remove();//添加之前先清除，防止重复添加。
					tab.append("<tr id=\"tr_msg\">"+
										"<td class=\"LabelCell\"><span style=\"color:blue;\">温馨提示：</span></td>"+
										"<td class=\"ControlCell\"><span style=\"color:red;\">您所选择的物料目前没有维护价格！</span></td>"+
										"</tr>");
					return;
              }else{
				   $("tr[id='tr_msg']").remove();
				   $("#"+XPGrid+"_g_edtGridItem_btnUpdateButton").removeAttr("disabled");//则否放开“保存”按钮可用。
              }             
            });	
			});			
		});
