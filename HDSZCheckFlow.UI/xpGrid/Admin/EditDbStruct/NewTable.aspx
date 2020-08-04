<%@ Register TagPrefix="uc1" TagName="ucEditFormat" Src="ucEditFormat.ascx" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.NewTable" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<HTML>
	<HEAD>
		<title>新建表</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<form id="NewTable" method="post" runat="server">
			<table width="500" cellspacing="0" class="TableStyle">
				<tr>
					<td class="GridColumnHeadingLeft" nowrap>
						<font size=3>&nbsp;新建表... </font>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%" cellpadding="10">
							<TBODY>
								<tr>
									<td nowrap><img src="images/small_icons_tables.gif">&nbsp;表名：&nbsp;<asp:textbox id="txtTableName" width="100px" runat="server"></asp:textbox>
										&nbsp;&nbsp;&nbsp;&nbsp;中文说明：&nbsp;<asp:textbox id="txtTableLabel" width="125px" runat="server"></asp:textbox>
										&nbsp;&nbsp;&nbsp;&nbsp;可见属性：&nbsp;
										<asp:DropDownList id="ddlVisible" runat="server">
											<asp:ListItem Value="1">不可见</asp:ListItem>
											<asp:ListItem Value="2" Selected="True">可见可改</asp:ListItem>
											<asp:ListItem Value="3">可见不可改</asp:ListItem>
										</asp:DropDownList>
										&nbsp;&nbsp;&nbsp;&nbsp;显示顺序：&nbsp;<asp:textbox id="txtOrder" width="35px" runat="server">0</asp:textbox>
										&nbsp; &nbsp; &nbsp;<asp:button id="btnSave" CssClass="inputbutton" text="保存" runat="server"></asp:button></td>
								</tr>
								<tr>
									<td>
										<!--<div style='BORDER-RIGHT:#000000 1px solid; BORDER-TOP:#000000 1px solid; BACKGROUND:#ffffff; OVERFLOW:auto; BORDER-LEFT:#000000 1px solid; WIDTH:100%; BORDER-BOTTOM:#000000 1px solid; HEIGHT:350px'>-->
										<asp:datalist id="dlFields" repeatdirection="Vertical" cellspacing="0" cellpadding="0" runat="server">
											<headertemplate>
												<table class="Grid" cellspacing="0" cellpadding="0" border=0>
													<tr>
														<td align="left" valign="center" class="GridColumnHeading">字段类型</td>
														<td align="left" valign="center" class="GridColumnHeading">字段名</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>中文名称</td>
														<td align="left" valign="center" class="GridColumnHeading">数据类型</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>字段宽度</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>字段精度</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>小数位</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>允许空值</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>默认值</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>编辑格式</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>标识列</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>显示顺序</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>显示宽度</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>显示格式</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>校验表达式</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>校验提示信息</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>可见属性</td>
													</tr>
											</headertemplate>
											<itemtemplate>
												<tr>
													<td align="left" valign="center" class="TableGrid">
														<asp:DropDownList id="cboColProperty" cssclass="TableInput" SelectedIndex='<%# (int)DataBinder.Eval (Container.DataItem, "ColProperty") - 1 %>' runat=server>
															<asp:ListItem Value="1">关键字</asp:ListItem>
															<asp:ListItem Value="2">固定项</asp:ListItem>
															<asp:ListItem Value="3">自定义项</asp:ListItem>
														</asp:DropDownList>
													</td>
													<!--<td align="middle" valign="center" class="TableGrid"><asp:checkbox id="chkPK" text=" " width="45px" ></asp:checkbox></td>-->
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtColName" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "colname") %>' width="80px" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtDisplayLabel" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "displaylabel") %>' width="110px" runat=server></asp:textbox></td>
													<td align="middle" valign="center" class="TableGrid"><asp:dropdownlist id="cboType" autopostback="True" onselectedindexchanged="OnDataTypeChange" cssclass="TableInput"
															width="100px" runat="server"></asp:dropdownlist></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtLength" enabled="False" text='<%# DataBinder.Eval (Container.DataItem, "length") %>' cssclass="TableInput" width="45px" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtPrecision" enabled="False" text='<%# DataBinder.Eval (Container.DataItem, "xprec") %>' cssclass="TableInput" width="45px" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtScale" enabled="False" text='<%# DataBinder.Eval (Container.DataItem, "xscale") %>' cssclass="TableInput" width="45px" runat=server></asp:textbox></td>
													<td align="middle" valign="center" class="TableGrid"><asp:checkbox id="chkNull" text=" " checked='<%# DataBinder.Eval (Container.DataItem, "nullable").ToString() == "1" %>' runat=server></asp:checkbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtDefault" width="50px" text='<%# DataBinder.Eval (Container.DataItem, "coldefault") %>' cssclass="TableInput" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid">
														<asp:linkbutton id="lbtnEditFormat" commandargument='<%# DataBinder.Eval (Container.DataItem, "ColumnID") %>' text='设置格式' ToolTip='<%# DataBinder.Eval (Container.DataItem, "EditFormat") %>' runat=server>
														</asp:linkbutton>
													</td>
													<td align="middle" valign="center" class="TableGrid"><asp:checkbox id="chkIdentity" autopostback="False" oncheckedchanged="OnIdentityClick" Checked='<%# DataBinder.Eval (Container.DataItem, "datatype").ToString().IndexOf(" IDENTITY") > 0 %>'
														runat="server"></asp:checkbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtDisplayOrder" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "DisplayOrder") %>' width="35px" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtDisplayWidth" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "DisplayWidth") %>' width="35px" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtDisplayFormat" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "DisplayFormat") %>' width="35px" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtColVarify" text='<%# DataBinder.Eval (Container.DataItem, "ColVarify") %>' cssclass="TableInput" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid"><asp:textbox id="txtVarifyMsg" text='<%# DataBinder.Eval (Container.DataItem, "VarifyMsg") %>' cssclass="TableInput" runat=server></asp:textbox></td>
													<td align="left" valign="center" class="TableGrid">
														<asp:DropDownList id="cboColVisible" cssclass="TableInput" SelectedIndex='<%# (int)DataBinder.Eval (Container.DataItem, "ColVisible") - 1 %>' runat=server>
															<asp:ListItem Value="1">不可见</asp:ListItem>
															<asp:ListItem Value="2">可见可改</asp:ListItem>
															<asp:ListItem Value="3">可见不可改</asp:ListItem>
														</asp:DropDownList>
													</td>
												</tr>
											</itemtemplate>
											<footertemplate>
						</table>
						</footertemplate> </asp:datalist>
						<uc1:ucEditFormat id="ucEditFormat1" runat="server"></uc1:ucEditFormat><!--</DIV>-->
					</td>
				</tr>
			</table>
			</TD></TR></TBODY></TABLE>
			<script language="javascript">
<!--
function checkInput()
{
	if(NewTable.txtTableName.value == "")
	{
		alert("请输入表名！");
		return false;
	}
	if(NewTable.txtTableLabel.value == "")
	{
		alert("请输入表中文名！");
		return false;
	}
}
//-->
			</script>
		</form>
	</body>
</HTML>
