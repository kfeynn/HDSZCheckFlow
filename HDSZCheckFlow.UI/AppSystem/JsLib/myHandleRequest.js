		$(function(){
			$("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVENTORYCODE").change(function(){ 
				var inv_pk=$("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVENTORYCODE").val();//pkֵ 
            $.ajaxSettings.async = false;
            $.getJSON("../../BaseData/Commons/MyHandleRequest.ashx?inv_pk=" + inv_pk + "&R=" + new Date(), function(base_inventory)  
             {
              var orPrice=base_inventory[0].RealOriginalcurPrice; //ԭ�ҵ��� 
              var currTypeCode=base_inventory[0].RealCurrTypeCode; //����
              var rmbPrice=base_inventory[0].RmbPrice; //���ҵ���

              //Ʒ��
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVENTORYNAME").val(base_inventory[0].invName);
              
              //���
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_INVTYPE").val(base_inventory[0].invspec);
              
              //��λ
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_UNIT").val(base_inventory[0].measname);
              
              //ԭ�ҵ���
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_ORIGINALCURRPRICE").val(orPrice);
              
              //��0 ��ֹ���֣�.2 , .5 ������ʾ
               if(base_inventory[0].RmbPrice.indexOf(".")==0){
					rmbPrice="0"+rmbPrice
				}
              //���ҵ���
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_RMBPRICE").val(rmbPrice);          
             //����
              $("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_CURRTYPECODE").val(currTypeCode); 
          
             //���˲����ϵĵ���
              if(orPrice==null || orPrice=="" || orPrice=="0"){
					$("#"+XPGrid+"_g_edtGridItem_btnUpdateButton").attr("disabled", true);//���水ť���ó�ʧ�̡�
					$("#"+XPGrid+"_g_edtGridItem_APPLYSHEETBODY_PURCHASE_MONEY").val("");//��ձ���Ԥ����
					var tab=$("#"+XPGrid+"_g_edtGridItem_tblEditTable");
					$("tr[id='tr_msg']").remove();//���֮ǰ���������ֹ�ظ���ӡ�
					tab.append("<tr id=\"tr_msg\">"+
										"<td class=\"LabelCell\"><span style=\"color:blue;\">��ܰ��ʾ��</span></td>"+
										"<td class=\"ControlCell\"><span style=\"color:red;\">����ѡ�������Ŀǰû��ά���۸�</span></td>"+
										"</tr>");
					return;
              }else{
				   $("tr[id='tr_msg']").remove();
				   $("#"+XPGrid+"_g_edtGridItem_btnUpdateButton").removeAttr("disabled");//���ſ������桱��ť���á�
              }             
            });	
			});			
		});
