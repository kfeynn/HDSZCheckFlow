<%@ Register TagPrefix="uc1" TagName="ucEditFormat" Src="ucEditFormat.ascx" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.NewTable" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<HTML>
	<HEAD>
		<title>�½���</title>
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
						<font size=3>&nbsp;�½���... </font>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%" cellpadding="10">
							<TBODY>
								<tr>
									<td nowrap><img src="images/small_icons_tables.gif">&nbsp;������&nbsp;<asp:textbox id="txtTableName" width="100px" runat="server"></asp:textbox>
										&nbsp;&nbsp;&nbsp;&nbsp;����˵����&nbsp;<asp:textbox id="txtTableLabel" width="125px" runat="server"></asp:textbox>
										&nbsp;&nbsp;&nbsp;&nbsp;�ɼ����ԣ�&nbsp;
										<asp:DropDownList id="ddlVisible" runat="server">
											<asp:ListItem Value="1">���ɼ�</asp:ListItem>
											<asp:ListItem Value="2" Selected="True">�ɼ��ɸ�</asp:ListItem>
											<asp:ListItem Value="3">�ɼ����ɸ�</asp:ListItem>
										</asp:DropDownList>
										&nbsp;&nbsp;&nbsp;&nbsp;��ʾ˳��&nbsp;<asp:textbox id="txtOrder" width="35px" runat="server">0</asp:textbox>
										&nbsp; &nbsp; &nbsp;<asp:button id="btnSave" CssClass="inputbutton" text="����" runat="server"></asp:button></td>
								</tr>
								<tr>
									<td>
										<!--<div style='BORDER-RIGHT:#000000 1px solid; BORDER-TOP:#000000 1px solid; BACKGROUND:#ffffff; OVERFLOW:auto; BORDER-LEFT:#000000 1px solid; WIDTH:100%; BORDER-BOTTOM:#000000 1px solid; HEIGHT:350px'>-->
										<asp:datalist id="dlFields" repeatdirection="Vertical" cellspacing="0" cellpadding="0" runat="server">
											<headertemplate>
												<table class="Grid" cellspacing="0" cellpadding="0" border=0>
													<tr>
														<td align="left" valign="center" class="GridColumnHeading">�ֶ�����</td>
														<td align="left" valign="center" class="GridColumnHeading">�ֶ���</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>��������</td>
														<td align="left" valign="center" class="GridColumnHeading">��������</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>�ֶο��</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>�ֶξ���</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>С��λ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>�����ֵ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>Ĭ��ֵ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>�༭��ʽ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>��ʶ��</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>��ʾ˳��</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>��ʾ���</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>��ʾ��ʽ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>У����ʽ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>У����ʾ��Ϣ</td>
														<td align="left" valign="center" class="GridColumnHeading" nowrap>�ɼ�����</td>
													</tr>
											</headertemplate>
											<itemtemplate>
												<tr>
													<td align="left" valign="center" class="TableGrid">
														<asp:DropDownList id="cboColProperty" cssclass="TableInput" SelectedIndex='<%# (int)DataBinder.Eval (Container.DataItem, "ColProperty") - 1 %>' runat=server>
															<asp:ListItem Value="1">�ؼ���</asp:ListItem>
															<asp:ListItem Value="2">�̶���</asp:ListItem>
															<asp:ListItem Value="3">�Զ�����</asp:ListItem>
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
														<asp:linkbutton id="lbtnEditFormat" commandargument='<%# DataBinder.Eval (Container.DataItem, "ColumnID") %>' text='���ø�ʽ' ToolTip='<%# DataBinder.Eval (Container.DataItem, "EditFormat") %>' runat=server>
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
															<asp:ListItem Value="1">���ɼ�</asp:ListItem>
															<asp:ListItem Value="2">�ɼ��ɸ�</asp:ListItem>
															<asp:ListItem Value="3">�ɼ����ɸ�</asp:ListItem>
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
		alert("�����������");
		return false;
	}
	if(NewTable.txtTableLabel.value == "")
	{
		alert("���������������");
		return false;
	}
}
//-->
			</script>
		</form>
	</body>
</HTML>
