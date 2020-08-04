<%@ Register TagPrefix="lsuc" TagName="FieldValueControl" Src="FieldValueControl.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.ConditionEditControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="lsuc" TagName="FieldLoaderControl" Src="FieldLoaderControl.ascx" %>
<%@ Register TagPrefix="lsuc" TagName="FieldSelectControl" Src="FieldSelectorControl.ascx" %>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/xmlExecute.js" type=text/JavaScript></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/function.js" type=text/JavaScript></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/selector.js" type=text/JavaScript></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/common_js.aspx" type=text/JavaScript></script>
<script language="javascript">
<!--
	var EditMode = <%=(int)this.EditMode%>;


	
	function ChangeOperator()
	{
	
		var lstFields =document.all("<%=ctlFieldLoader.ListBoxName %>");
		
		var ddlOperators = document.all("<%=ddlOperators.ClientID%>");
		var btnFunSettor = document.all("<%=btnFunSettor.ClientID%>");

		var iIndex = lstFields.selectedIndex;
		if (iIndex == -1)
			return false;
			
		var item = lstFields.item(iIndex);
		var sColType = item.getAttribute("ColType");
		var sEditFormat = item.getAttribute("EditFormat");
			
		if (btnFunSettor != null)
		{
			btnFunSettor.setAttribute("FunExp","");	
			if (sEditFormat.length== 0)
			{
				btnFunSettor.disabled= false;
				btnFunSettor.className = "btnEnable";
			}
			else
			{
				btnFunSettor.disabled= true;
				btnFunSettor.className = "btnDisable";

			}
			
		}
		
		if (sColType != ddlOperators.getAttribute("ColType") || sEditFormat != ddlOperators.getAttribute("EditFormat"))
		{
			//alert("sColType + sEditFormat" + sColType + sEditFormat);
			LoadOperators(ddlOperators,sColType,sEditFormat,EditMode);
			
			LoadValue(sColType,sEditFormat,"",EditMode);
		}
		
		
		
	}
	
	function ConAdd()
	{
		lstConditions = document.all("<%=lstConditions.ClientID%>");
		lstFields = document.all("<%=ctlFieldLoader.ListBoxName %>");
		ddlOperators = document.all("<%=ddlOperators.ClientID%>");
		chkPreCondition = document.all("<%=chkPreCondition.ClientID%>");
		btnFunSettor = document.all("<%=btnFunSettor.ClientID%>");
		
		if (lstFields.selectedIndex == -1)
		{
			alert("请选择设置条件的字段！");
			return false;
		}
		
		var opt = document.createElement("OPTION");
		
		var nLabelNo = 1;
		if( lstConditions.length >0)
		{
			//alert(lstConditions.item(lstConditions.length-1).getAttribute("LabelNo"));
			nLabelNo = parseInt(lstConditions.item(lstConditions.length-1).getAttribute("LabelNo")) + 1;
		}
		
		var nRecorID = 0;
		var nColumnID = lstFields.item(lstFields.selectedIndex).value;
		var nOperator = ddlOperators.item(ddlOperators.selectedIndex).value;
		var nPre = 0,sPreFlag="";
		
		if ( EditMode ==0 &&  chkPreCondition.checked )
		{
			nPre = 1;
			sPreFlag= "[Pre]"
		}
		var sValue = GetValueFromFieldValueControl();
		
		//alert(sValue[0]);
		
		if (sValue==null  )
		{
			//if (nPre==0)
			//{
			//	alert("您还没有为条件表达式赋值！");
			//	return false;			
			//}
			//else
			//{
				var arr =  new Array(2);
				arr[0]="";
				arr[1]="";
				sValue = arr;
			//}
		}
		
		//进行数据验证
		var sTest = sValue[0];
		var item = lstFields.item(lstFields.selectedIndex);
		var sColType = item.getAttribute("ColType");
		var sFunExp ="";
		if (btnFunSettor != null)
		{
			sFunExp = btnFunSettor.getAttribute("FunExp");
		}
		
		if (sFunExp.length>0)
		{
			 
			sColType = sFunExp.substring(sFunExp.indexOf("/"));
		}
		var sEditFormat = item.getAttribute("EditFormat");
		 
		if (sTest!="" && ( CheckIsNumeric(sColType) && sEditFormat.length==0 || CheckIsDate(sColType)))
		{
			 
			if (CheckIsNumeric(sColType) && CheckIsDate(sColType)==false)
			{
				 
	 			if (isNaN(sTest) )
	 			{
					alert("请输入正确的数字！");
					return;
	 			}
			}
			if (CheckIsDate(sColType))
			{
			
				var re =/\d+/g; 
				
				var dd = new Array();
				var i=0;
				var arr;
				while ((arr = re.exec(sTest)) != null)
				{
					dd[i] = arr;
					i++;
				}
				
			 	
			  
			 			 
	 			if ( i!=3 || isdate(dd[0]+ "/" +dd[1]+ "/" + dd[2])==false  )
	 			{
	 				alert("请输入正确的日期！");
	 				return;
	 			}
	 			else
	 			{
	 				sValue[0] =dd[0]+"/" +dd[1] + "/" +dd[2]; 
	 				sValue[1] = sValue[0];
	 			}
	 			
			}
		}
		
		var sCaption =  nLabelNo +". " + lstFields.item(lstFields.selectedIndex).text + " " + ddlOperators.item(ddlOperators.selectedIndex).text + " \"" + sValue[1]  + "\" " +sPreFlag;
		if (EditMode ==0)
		{
			var funCaption =btnFunSettor.getAttribute("FunCaption");
			if (funCaption == null)
				funCaption ="";
			else
				funCaption = "[" + funCaption + "]";
				
			sCaption =  nLabelNo +". " + lstFields.item(lstFields.selectedIndex).text + funCaption +  " " + ddlOperators.item(ddlOperators.selectedIndex).text + " \"" + sValue[1]  + "\" " +sPreFlag;
			opt.setAttribute("FunExp",btnFunSettor.getAttribute("FunExp"));
		}
		opt.text = sCaption;
		opt.setAttribute("LabelNo",nLabelNo);
		opt.setAttribute("RecordID",nRecorID);
		opt.setAttribute("ColumnID",nColumnID);
		opt.setAttribute("Operator",nOperator);
		opt.setAttribute("Pre",nPre);
		opt.setAttribute("value",sValue[0]);
		
		lstConditions.add(opt);
		
		if (EditMode ==0)
		{
			
			var txtConditionExpression =  document.all("<%=txtConditionExpression.ClientID%>");
			
			var sExp =ltrim(txtConditionExpression.value);
			if (sExp.length ==0)
				sExp = nLabelNo;
			else
				sExp = sExp + " + " + nLabelNo
			
			txtConditionExpression.value = sExp ;
			
			chkPreCondition.checked = false;
		}
		
		GetConCode();
	
	}
	
	function ConDelete()
	{
		var lst= document.all("<%=lstConditions.ClientID%>");
		
		if (lst.selectedIndex==-1)
		{
			alert("请选择需要删除的项目！");
			return false;
		}


		while (lst.selectedIndex>-1 )	
		{	
			DealWithConExpressionDelete(lst.item(lst.selectedIndex).getAttribute("LabelNo"));
			lst.remove(lst.selectedIndex); 		 
		}
		
		GetConCode();
		//逻辑表达式处理	
	}
	
	//Get条件的组合编码
	function GetConCode()
	{
		hidConCode = document.all("<%=hidConCode.ClientID%>");
		lstConditions = document.all("<%=lstConditions.ClientID%>");
		var sSeperator = "\t";
		var sCode = "";
		
		for (var i =0; i<lstConditions.length; i++)
		{
			//RecordID, ColumnID, Operator, Pre, value
			var opt=lstConditions.item(i);
			var sItem = opt.getAttribute("RecordID") + sSeperator + opt.getAttribute("ColumnID") + sSeperator +  opt.getAttribute("Operator") + sSeperator + opt.getAttribute("Pre") + sSeperator + opt.getAttribute("value") + sSeperator + opt.text + sSeperator + opt.getAttribute("LabelNo") + sSeperator + opt.getAttribute("FunExp") + sSeperator;
			sCode += sItem;
		}
		
		hidConCode.value = sCode;
		//alert(lstConditions.innerHTML);
		
	}
	

	function ReplaceConID(sInput,sRegExp,nCheckNext)
	{
		//var sReturn;
		
		//var re =new RegExp("\+|\,\\s*[!]\\s*"+sID,"g");
		//var re =new RegExp("(\\+|,)(\\s|!)*" + sID);
		var re =new RegExp(sRegExp);
		r = sInput.match(re);
		while (r!=null)
		{
			var sReplace= r[0];
			var nPos = sInput.lastIndexOf(sReplace);
			var sNextChar = sInput.charAt(nPos+sReplace.length);
			if ( nCheckNext==0 || (sNextChar=="" || sNextChar<"0" || sNextChar>"9"))
				sInput = sInput.substring(0,nPos) + sInput.substring(nPos+sReplace.length);
			
			r = sInput.match(re);				
		}
		 
		return sInput;
	}
	
	
	
	function DealWithConExpressionDelete( sID)
	{
		var txtExp = document.all("<%=txtConditionExpression.ClientID%>");
		if (txtExp == null)
			return;
			
		var sInput = txtExp.value;
		 
		
		sInput = ReplaceConID(sInput,"(\\+|,)*\\((\\s|!)*" + sID + "(\\s|!)*\\)",1);
		sInput = ReplaceConID(sInput,"(\\+|,)(\\s|!)*" + sID,1);
		sInput = ReplaceConID(sInput,"(\\s|!)*" + sID + "(\\s|!)*(\\+|,)*",0);
		sInput = ReplaceConID(sInput,"(\\s|!)*" + sID + "(\\s|!)*", 1);
		sInput = ReplaceConID(sInput,"\\((\\s|!)*\\)", 0);
		
		//((3)) + 4; 如何划分
		txtExp.value= sInput;
		
		 
	}	
	
	function OpenFunSettor(btnFunSettor)
	{
		var lstFields =document.all("<%=ctlFieldLoader.ListBoxName %>");
		
		var nSelectedIndex = lstFields.selectedIndex;
		if (nSelectedIndex==-1)
		{
			alert("请在字段列表中选择函数设置的字段！");
			return;
		}

		var sPath = "<%=ApplicationPath%>xpGrid/Query/QueryControl/FunSettor.aspx?ColumnID=" +  lstFields.item(nSelectedIndex).value;
		var vReturn = ShowModelDialog(sPath,"", "dialogHeight: 300px; dialogWidth: 450px;");
		
		if (vReturn != null)
		{
			btnFunSettor.setAttribute("FunExp",vReturn[2] + "/" +vReturn[0]);
			btnFunSettor.setAttribute("FunCaption",vReturn[1]);
		//	btnFunSettor.setAttribute("FunDataType",vReturn[2]);
			
			LoadValue(vReturn[2],"","",EditMode);
			
		}
		
		//alert(vReturn[0] + vReturn[1]);
	}
	
//-->
</script>
<TABLE WIDTH="100%" BORDER="1" CELLSPACING="0" CELLPADDING="2" borderColor=#99ccff id="tblMain"
	runat="server">
	<TR>
		<TD width="32%" valign=middle><p style="MARGIN-TOP: 5px">相关表与字段</p></TD>
		<TD width="17%">
			<asp:Label id="Label3" runat="server"><p style="MARGIN-TOP: 5px">条件操作符</p></asp:Label></TD>
		<TD width="50%" nowrap=true align=right>&nbsp;<IMG id="btnFunSettor" src="<%=ApplicationPath%>xpGrid/images/hanshusd.gif" runat="server" onclick="OpenFunSettor(this)" class="InputButtonDisable" style="display:none" disabled><!-- 未实现 --> &nbsp; <IMG id=btnConAdd src="<%=ApplicationPath%>images/xinzeng.gif" runat="server" class=InputButton> &nbsp; <IMG id=btnConDelete src="<%=ApplicationPath%>images/shanchu.gif" 
            runat="server" class=InputButton>
		</TD>
	</TR>
	<TR>
		<TD vAlign="top" rowspan="2">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD vAlign="top">
						<lsuc:fieldloadercontrol id="ctlFieldLoader" runat="server"></lsuc:fieldloadercontrol>
					</TD>
				</TR>
				<TR>
					<TD>
						<INPUT id="hidConCode" type="hidden" name="hidConCode" runat="server"></TD>
				</TR>
			</TABLE>
		</TD>
		<TD vAlign="top">
			<SELECT id="ddlOperators" style="WIDTH: 100%" runat="server" NAME="ddlOperators">
				<OPTION selected></OPTION>
			</SELECT></TD>
		<TD>
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD width="75%">
						<lsuc:fieldvaluecontrol id="ctlFieldValues" runat="server"></lsuc:fieldvaluecontrol></TD>
					<TD width="25%">
						<INPUT id="chkPreCondition" type="checkbox" name="chkPreCondition" runat="server">
						<asp:Label id="Label4" runat="server">待定</asp:Label></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD colspan="2" align="left">
			<asp:listbox id="lstConditions" runat="server" Width="90%" SelectionMode="Multiple" Rows="9"
				EnableViewState="False"></asp:listbox>
		</TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="Label2" runat="server">逻辑表达式</asp:Label>
			&nbsp;
		</TD>
		<td colspan="2">
			<asp:textbox id="txtConditionExpression" runat="server" Width="90%"></asp:textbox><FONT face="宋体">&nbsp;</FONT>
		</td>
	</TR>
	<TR>
		<TD colSpan="3">
			<asp:Label id="Label1" runat="server">在逻辑表达式中，[+]表示并且，[,]表示或者，[!]表示相反条件，同时支持()运算</asp:Label>&nbsp;
		</TD>
	</TR>
</TABLE>
<SCRIPT language="javascript">
<!--
	var lstFields =document.all("<%=ctlFieldLoader.ListBoxName %>");
	lstFields.setAttribute("EditMode",EditMode);

	BoundFieldFromTable(document.all('<%=ctlFieldLoader.DropDownControlName%>'), document.all('<%=ctlFieldLoader.ListBoxName%>'), null,'');
	BoundCondition2List(document.all('<%=lstConditions.ClientID%>'), document.all('<%=hidConCode.ClientID%>'));
	
	function BoundCondition2List(lst,hid)
	{
		var sCode = hid.value;
		var aIDs = sCode.split("\t");
		//alert(sCode);
		 
		for (var i =0; i<aIDs.length -1; i+=8)
		{
			var opt = document.createElement("OPTION");
			opt.setAttribute("RecordID",aIDs[i]);
			opt.setAttribute("ColumnID",aIDs[i+1]);
			opt.setAttribute("Operator",aIDs[i+2]);
			opt.setAttribute("Pre",aIDs[i+3]);
			opt.value = aIDs[i+4];
			opt.text = aIDs[i+5];
			opt.setAttribute("LabelNo",aIDs[i+6]);
			opt.setAttribute("FunExp",aIDs[i+7]);
			 
			
			lst.add(opt);
		}
		
	}
	

//-->
</SCRIPT>
