<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.ConditionShowControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<link rel="stylesheet" href="../../style.css" type="text/css">
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/lookup.js" type="text/javascript" ></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/QueryControl/scripts/date.js" type="text/javascript" ></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/querycontrol/scripts/function.js" type="text/javascript" ></script>
<script language=JavaScript src="<%=ApplicationPath%>xpGrid/Query/querycontrol/scripts/xmlExecute.js" type="text/javascript" ></script>
<script language="javascript">
<!--
function CollectConditions(tblConditions,hidConditionCollector)
{
	var sReturn ="";
	var sSeperator ="\t";
	
	if (CheckValidate()==false)
		return;
	
	for (var i=1;i<tblConditions.rows.length;i++)
	{
		var row = tblConditions.rows[i];
		var sUnit = row.cells[0].children[0].innerText + sSeperator;
		sUnit += row.cells[0].children[1].value +sSeperator;
		
		var sPreCondition = row.cells[0].children[2].value;
		var sOperator = row.cells[0].children[3].value;
		var sValue = row.cells[0].children[4].value;
		var sFunExp = row.cells[0].children[5].value;
		
		 
		
		if (sPreCondition == "1" )
		{
			ddrOperator = row.cells[2].children[0];
			sOperator = ddrOperator.item(ddrOperator.selectedIndex).value;
			
			ctrlValue = row.cells[3].children[0];
			 
			switch(ctrlValue.type)
			{
				case "text":
					sValue = ctrlValue.value;
					break;
				case "checkbox":
					if (ctrlValue.checked)
					{
						sValue = ctrlValue.getAttribute("yvalue");
					}
					else
					{
						sValue = ctrlValue.getAttribute("nvalue");
					}
					
					break;
				case "select-one":
					sValue = ctrlValue.item(ctrlValue.selectedIndex).value;
					break;					
			}			
		}
		
		sUnit += sPreCondition + sSeperator;
		sUnit += sOperator + sSeperator;
		sUnit += sValue + sSeperator;
		sUnit += sFunExp +sSeperator;
		
		sReturn += sUnit; 
		
	}
	
	 
	hidConditionCollector.value=sReturn;
	hidConditionCollector.form.submit();
}


function ShowTree(ddlValues)
{

	alert("");	
	//var bm = ddlValues.getAttribute("EditMode",EditMode);
	var sEditFormat = ddlValues.getAttribute("EditFormat");
	// 1 Look, 2 Code
	 
 	 
	var bm= sEditFormat.substring(0,sEditFormat.indexOf("|"));
	var endmark = 1;
	 
	
	
	SetLookValue(ddlValues,bm,endmark,"<%=ApplicationPath%>");
	 
	
}

function CheckValidate()
{
	var txts = document.getElementsByTagName("input");
	 
	for( i=0; i<txts.length; i++)
	{
		var txt = txts[i];
		if (txt.type == "text")
		{
			var sDataType = txt.getAttribute("DataType");
			var sValue = trim(txt.value);
			
			if (sValue.length==0)
			{
				continue;
			}
			
			if  (CheckIsNumeric(sDataType) && !isnumeric(sValue)) 
			{
				alert("请输入数字!"); 
				SelectText(txt);
				return false;
			}
			 
				
			sValue =  sValue.replace("-","/");
			sValue =  sValue.replace("-","/");
			
			 
			if (CheckIsDate(sDataType)   ) 
			{
				if (!isdate(sValue))
				{				
					alert("请输入日期型数据!"); 
					SelectText(txt);
					return false;
				}
				else
				{
					txt.value = sValue;
				}
			}
			 
			
		}
	}

	return true;
}

//-->
</script>
<TABLE id="tblConditions" cellSpacing="0" width="100%">
	<TR>
		<TD style="HEIGHT: 26px"><FONT face="宋体" size="2">&nbsp;请输入查询条件：</FONT></TD>
	</TR>
	<TR>
		<TD><asp:datagrid id="grdConditions" CssClass="gridborder" runat="server" AutoGenerateColumns="False"
				BorderColor="LightSkyBlue" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="3"
				GridLines="Vertical" Width="100%">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="DodgerBlue"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#F7FAFF"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#E1F3FF"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#99CCFF"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#99CCFF"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="条件序号">
						<HeaderStyle HorizontalAlign="Center" Width="15%" VerticalAlign="Middle"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LabelNo") %>'>
							</asp:Label>
							<input type="hidden" id="ColumdID" runat ="server" value='<%# DataBinder.Eval(Container, "DataItem.ColumnID") %>' >
							<input type="hidden" id="PreCondition" runat="server"> <input type="hidden" id="Operator" runat="server">
							<input type="hidden" id="Value" runat ="server" value='<%# DataBinder.Eval(Container, "DataItem.Value") %>' NAME="Value">
							<input type="hidden" id="FunExp" runat ="server" value='<%# DataBinder.Eval(Container, "DataItem.FunExp") %>' NAME="FunExp">
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn HeaderText="字段名">
						<HeaderStyle HorizontalAlign="Center" Width="25%" VerticalAlign="Top"></HeaderStyle>
						<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="操作符">
						<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
						<ItemTemplate>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="参考值">
						<HeaderStyle HorizontalAlign="Center" Width="40%"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid><FONT size="2"></FONT></TD>
	</TR>
	<TR>
		<TD>
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 595px"><FONT face="宋体">&nbsp;</FONT><asp:label id="Label1" runat="server" CssClass="xiao">条件表达式:</asp:label><asp:label id="lblConditionExp" runat="server" CssClass="xiao"></asp:label><INPUT id="hidExistPre" type="hidden" value="0" runat="server"></TD>
					<TD style="WIDTH: 1px"></TD>
					<TD><FONT face="宋体">&nbsp;<IMG class="btnEnable" id="btnSearch" alt="" src="<%=ApplicationPath%>/xpGrid/images/chaxun.gif" runat="server"></FONT><FONT size="2" face="宋体"></FONT></TD>
				</TR>
			</TABLE>
			<FONT face="宋体">&nbsp;</FONT><INPUT id="hidConditionCollector" type="hidden" runat="server"></TD>
	</TR>
	<TR>
		<TD>
			<P><FONT face="宋体">&nbsp;
					<asp:PlaceHolder id="plhConditions" runat="server"></asp:PlaceHolder></FONT></P>
		</TD>
	</TR>
</TABLE>
