<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.FieldColumnControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="FieldValueControl" Src="FieldValueControl.ascx" %>
<script language="javascript">
<!--
//设置默认值

//option 0, 取消；1,设置
function SetDefaultValue(lst, Option)
{
	//alert(lst);
	var iIndex = lst.selectedIndex;
	if (iIndex ==-1)
	{
		alert("对不起，您没有选择需要进行操作的项目。");
		return ;
	}
	var opt = lst.item(iIndex);
	var sCaption = opt.text;
	var sValue = "" ;
	 
	var iPos = sCaption.indexOf("[");
	if(iPos != -1)
		sCaption = sCaption.substr(0,iPos);
	
	
	if (Option == 1 )
	{	
		var objControl =  GetValueFromFieldValueControl();
		if (objControl == null || objControl[1] =="")
		{
			alert("对不起预设值不能为空。");
			return;
		}
		sCaption = sCaption + "[" + objControl[1] + "]";
		sValue = objControl[0];
	}
//	alert(lst.selectedIndex);

	opt.text = sCaption; 
	opt.setAttribute("FieldValue",sValue);
	
	lst.selectedIndex= iIndex;
	
	
	
}
 	function ChangeValueLoader()
	{
		var lstFields =document.all("<%=lstFields.ClientID%>");
		
		
		var iIndex = lstFields.selectedIndex;
		alert("");
		if (iIndex == -1)
			return false;


		var item = lstFields.item(iIndex);

		var sXmlPath ="<% =ApplicationPath %>xpGrid/Query/QueryControl/xml/XGetFieldByID.aspx";
		var sSender = "<Field >" + item.value  + "</Field>";
		
		 alert(sSender);
		var sReceiver = DataCommunicate(sSender,sXmlPath);
		var xmlDoc = new ActiveXObject("MSXML.DOMDocument");
		
	alert(sReceiver);
		xmlDoc.loadXML(sReceiver);
		
		var  nodes= xmlDoc.selectNodes("//Field");
		var sColType = nodes[0].attributes[1].value;
		var sEditFormat = nodes[0].attributes[2].value;
		
		 

		LoadValue(sColType,sEditFormat,"StatFun",1);
		
	
		
	}
	
	function SetCaption(lst, txtCaption)
	{
		var iIndex = lst.selectedIndex;
		if (iIndex ==-1)
		{
			alert("对不起，您没有选择需要进行操作的项目。");
			return ;
		}
		var opt = lst.item(iIndex);
		
		//检查如果函数没有设置
		
		if (opt.getAttribute()=="0")
		{
			alert("对不起，没有设置统计功能的字段不能设置别名！");
			return;
		}
		
		var sCaption = txtCaption.value;
		if (sCaption.length==0)
		{
			alert("请输入字段别名！");
			return;
		}
		
		opt.text = txtCaption.value;
		lst.selectedIndex  =  iIndex;	
	}
 
 
//取消默认值

//-->
</script>
<asp:listbox id="lstFields" runat="server" Rows="10" Width="100%" SelectionMode="Multiple"></asp:listbox>
<asp:Panel id="pnlSort" Width="100%" runat="server" Visible="False" CssClass="xiao">
<INPUT id="rbAsc" type="radio" value="1" name="optSort" runat="server">升序 
<INPUT id="rbDesc" type="radio" value="0" name="optSort" runat="server">降序
	</asp:Panel>
<asp:Panel id="pnlStatFun" Width="100%" runat="server" Visible="False" CssClass="xiao">
<INPUT id="rbNone" type="radio" CHECKED value="0" name="optStatFun" runat="server">[无] 
<INPUT id="rbCount" type="radio" value="1" name="optStatFun" runat="server">计数 
<INPUT id="rbSum" type="radio" value="2" name="optStatFun" runat="server">总和 
<INPUT id="rbEverage" type="radio" value="3" name="optStatFun" runat="server">平均值 
<INPUT id="txtCaption" type="text" maxLength="125" size="15" name="Text1" runat="server"><IMG class="btnEnable" id="btnSetCaption" alt="" src="" runat="server">
	</asp:Panel>
<asp:Panel Runat="server" id="pnlValue" Width="100%" Visible="False">
	<uc1:FieldValueControl id="ctlFieldValues" runat="server"></uc1:FieldValueControl>
	<IMG class="btnEnable" id="btnSetValue" alt="" src="" runat="server"><IMG class="btnEnable" id="btnCancelSetting" alt="" src="" runat="server"></asp:Panel><FONT face="宋体"></FONT>
