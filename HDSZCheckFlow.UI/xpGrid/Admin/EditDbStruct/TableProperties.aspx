<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditDbStruct.TableProperties" %>
<%@ Register TagPrefix="uc1" TagName="ucEditFormat" Src="ucEditFormat.ascx" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en" >
<HTML>
	<HEAD>
		<title>������</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
			<!--
		      
			function newImage(arg) {
      			if (document.images) {
      				rslt = new Image();
      				rslt.src = arg;
      				return rslt;
      			}
			}
		      
			function changeImages() {
      			if (document.images && (preloadFlag == true)) {
      				for (var i=0; i<changeImages.arguments.length; i+=2) {
      					document[changeImages.arguments[i]].src = changeImages.arguments[i+1];
      				}
      			}
			}
		      
			var preloadFlag = false;
			function preloadImages() {
      			if (document.images) {

					LeftNavImage1_over = newImage("images/navbar_button_editTable_ove.gif");
					LeftNavImage2_over = newImage("images/navbar_button_RunDark_over.gif");
					LeftNavImage3_over = newImage("images/navbar_button_DeleteDark_ov.gif");
					LeftNavImage4_over = newImage("images/navbar_button_InsertDark_ov.gif");
				  	
				preloadFlag = true;
      			}
			}
		      
			function confirmDrop(table,label,field) {
				if (confirm("ȷ��Ҫɾ���ֶ�" + field + "��?") == true) 
		   		{
		   		 		//location.href = 'TableProperties.aspx?table=' + table + '&field=' + field + '&tablelabel=' + label;
		   		}
			}

			//parent.location.href='Databases.aspx';
			//parent.location.href='ListTables.aspx';

			preloadImages();
			// -->
		</script>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form id="TableProperties" method="post" runat="server">
			<table class="Grid" cellSpacing="0" cellPadding="2" width="100%">
				<tr>
					<td height="100%" valign="top">
						<table width="100%" cellpadding="7" height="100%">
							<TBODY>
								<tr>
									<td colspan="2">
										<table border="1" cellpadding="0" cellspacing="0">
											<tr>
												<td nowrap>
													<img src="images/large_icons_tableProps.gif" align="absMiddle"> <b>������</b>
													<%= Request["table"].ToString () %>
												</td>
												<td nowrap>
													����˵����
													<asp:textbox id="txtTableLabel" width="125px" runat="server"></asp:textbox>
												</td>
												<td nowrap>
													�������ࣺ<asp:DropDownList id="ddlTableType" runat="server" />
													<asp:DropDownList id="ddlVisible" Visible="False" runat="server">
														<asp:ListItem Value="1">���ɼ�</asp:ListItem>
														<asp:ListItem Value="2">�ɼ��ɸ�</asp:ListItem>
														<asp:ListItem Value="3">�ɼ����ɸ�</asp:ListItem>
													</asp:DropDownList></td>
												<td nowrap>
													&nbsp;&nbsp;��ʾ˳��&nbsp;
													<asp:textbox id="txtOrder" width="35px" runat="server">0</asp:textbox>
												</td>
												<td>
													<asp:Button ID="btnSaveTableProperties" OnClick="btnSaveTableProperties_Click" CssClass="InputButton"
														Runat="server" Text="���������"></asp:Button>
												</td>
												<td align="right">
													<a href='<%= "BrowseTable.aspx?table=" + Request["table"].ToString () + "&amp;tableLabel=" + Request["tablelabel"].ToString () %>' target="MainFrame" onmouseover="changeImages('NavBarImage2', 'images/navbar_button_RunDark_Over.gif'); return true; "
																	onmouseout="changeImages('NavBarImage2', 'images/navBar_button_RunDark.gif'); return true; ">
														<img src="images/navbar_button_RunDark.gif" border="0" name="NavBarImage2" alt="�������"></a>
													<asp:imagebutton id="ibtnDropTable" onclick="ibtnDropTable_Click" borderwidth="0" alternatetext="ɾ����"
														imageurl="images/navbar_button_DeleteDark.gif" onmouseover="this.src='images/navbar_button_DeleteDark_Ov.gif'"
														onmouseout="this.src='images/navBar_button_DeleteDark.gif'" runat="server"></asp:imagebutton>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td height="100%" valign="top">
										�ֶ���Ϣ�� &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
										&nbsp;
										<asp:Button ID="btnAddColumn" CssClass="InputButton" Runat="server" Text="�����ֶ�" OnClick="btnAddColumn_Click"></asp:Button><br>
										<br>
										<!--<div style='BORDER-RIGHT:#000000 1px solid; BORDER-TOP:#000000 1px solid; BACKGROUND:#ffffff; OVERFLOW:auto; BORDER-LEFT:#000000 1px solid; WIDTH:100%; BORDER-BOTTOM:#000000 1px solid; HEIGHT:250px'>-->
										<asp:datalist id="dlTableProps" runat="server" cellpadding="0" cellspacing="0" repeatdirection="Vertical">
											<headertemplate>
												<table cellpadding="2" cellspacing="0" border="0" width="100%" class="Grid">
													<tr>
														<td class="GridColumnHeading" nowrap>ɾ��</td>
														<td class="GridColumnHeading" nowrap>�޸�</td>
														<td class="GridColumnHeading" nowrap>����</td>
														<td class="GridColumnHeading" nowrap>�ֶ�����</td>
														<td class="GridColumnHeading" nowrap>��������</td>
														<td class="GridColumnHeading" nowrap>��������</td>
														<td class="GridColumnHeading" nowrap>�ֶο��</td>
														<td class="GridColumnHeading" nowrap>�ֶξ���</td>
														<td class="GridColumnHeading" nowrap>С��λ</td>
														<td class="GridColumnHeading" nowrap>�����ֵ</td>
														<td class="GridColumnHeading" nowrap>Ĭ��ֵ</td>
														<td class="GridColumnHeading" nowrap>�༭��ʽ</td>
														<td class="GridColumnHeading" nowrap>��ʶ��</td>
														<td class="GridColumnHeading" nowrap>��ʾ˳��</td>
														<td class="GridColumnHeading" nowrap>��ʾ���</td>
														<td class="GridColumnHeading" nowrap>��ʾ��ʽ</td>
														<td class="GridColumnHeading" nowrap>У����ʽ</td>
														<td class="GridColumnHeading" nowrap>У����ʾ��Ϣ</td>
														<td class="GridColumnHeading" nowrap>�ɼ�����</td>
													</tr>
											</headertemplate>
											<itemtemplate>
												<tr>
													<td class="tableGrid" align="center">
														<asp:imagebutton id="btnDropColumn" borderwidth="0" alternatetext="ɾ���ֶ�" imageurl="images/drop.gif" commandargument='<%# DataBinder.Eval (Container.DataItem, "ColumnID") %>' CommandName="ɾ���ֶ�" onmouseover="this.src='images/navbar_button_DeleteDark_ov.gif'" onmouseout="this.src='images/drop.gif'" runat=server>
														</asp:imagebutton>
													</td>
													<td>
														<asp:imagebutton id="btnEditColumn" borderwidth="0" alternatetext="�޸��ֶ�" imageurl="images/navBar_button_editTable.gif" commandargument='<%# DataBinder.Eval (Container.DataItem, "ColumnID") %>' CommandName="�޸��ֶ�" onmouseover="this.src='images/navbar_button_editTable_ove.gif'" onmouseout="this.src='images/navBar_button_editTable.gif'" runat=server>
														</asp:imagebutton></td>
													<td class="tableGrid" nowrap align="center">&nbsp;<%# FetchPKImage (DataBinder.Eval (Container.DataItem, "colProperty").ToString ()) %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "colname") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "DisplayLabel") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# GetDataType (DataBinder.Eval (Container.DataItem, "DataType").ToString ()) %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "LENGTH") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "XPrec") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "XScale") %></td>
													<td class="tableGrid" nowrap align="Center">&nbsp;<%# FetchNullImage (DataBinder.Eval (Container.DataItem, "NULLABLE").ToString ()) %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "ColDefault") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "EditFormat") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# FetchIDImage (DataBinder.Eval (Container.DataItem, "DataType").ToString ()) %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "DisplayOrder") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "DisplayWidth") %></td>
													<td class="tableGrid" nowrap>&nbsp;<%# DataBinder.Eval (Container.DataItem, "DisplayFormat") %></td>
													<td class="TableGrid"><%# DataBinder.Eval (Container.DataItem, "ColVarify") %></td>
													<td class="TableGrid"><%# DataBinder.Eval (Container.DataItem, "VarifyMsg") %></td>
													<td class="tableGrid" nowrap>&nbsp;<span name="spanVisible"><%# DataBinder.Eval (Container.DataItem, "ColVisible")%></span></td>
												</tr>
											</itemtemplate>
											<EditItemTemplate>
												<tr>
													<td class="tableGrid" align="center">
														<a href='<%# "javascript:confirmDrop(\"" + Request["table"].ToString () + "," + DataBinder.Eval (Container.DataItem, "colname") + "\");" %>'>
															<img src="images/drop.gif" border="0"></a>
													</td>
													<td nowrap>
														<asp:imagebutton id="imgSaveEditCommand" borderwidth="0" alternatetext="�����޸�" CommandArgument='<%#DataBinder.Eval (Container.DataItem, "ColumnID")%>' CommandName="�����޸�" imageurl="images/checkbox.gif" runat=server>
														</asp:imagebutton><br>
														<br>
														<br>
														<img id="imgCancelEditCommand" borderwidth="0" src="images/drop.gif" alt="ȡ���޸�" onclick="window.location.href=window.location.href;">
													</td>
													<td nowrap class="tableGrid" colspan="15">
														<table cellpadding="2" cellspacing="0" border="1" class="Grid">
															<tr>
																<td class="TableGrid">�ֶ�����</td>
																<td nowrap align="left" class="tableGrid">
																	<asp:DropDownList id="cboColProperty" cssclass="TableInput" SelectedIndex='<%# (int)DataBinder.Eval (Container.DataItem, "ColProperty") - 1 %>' runat=server>
																		<asp:ListItem Value="1">�ؼ���</asp:ListItem>
																		<asp:ListItem Value="2">�̶���</asp:ListItem>
																		<asp:ListItem Value="3">�Զ�����</asp:ListItem>
																	</asp:DropDownList>
																</td>
															</tr>
															<tr>
																<td class="TableGrid">�ֶ�����</td>
																<!--<td class="tableGrid" nowrap>&nbsp;# FetchIDImage (DataBinder.Eval (Container.DataItem, "DataType").ToString ()) </td>-->
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtColumnID" cssclass="TableInput" readonly=true Visible="false" text='<%# DataBinder.Eval (Container.DataItem, "columnid") %>' runat=server>
																	</asp:textbox>
																	<asp:textbox id="txtColName" cssclass="TableInput" readonly=true text='<%# DataBinder.Eval (Container.DataItem, "colname") %>' runat=server>
																	</asp:textbox>
																	<asp:RequiredFieldValidator id="RequiredFieldValidator1" ControlToValidate="txtColName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
															</tr>
															<tr>
																<td class="TableGrid">��������</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtDisplayLabel" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "displaylabel") %>' width="110px" runat=server>
																	</asp:textbox>
																	<asp:RequiredFieldValidator id="Requiredfieldvalidator2" ControlToValidate="txtDisplayLabel" runat="server"
																		ErrorMessage="*"></asp:RequiredFieldValidator></td>
															</tr>
															<tr>
																<td class="TableGrid">��������</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:dropdownlist id="cboType" autopostback="True" onselectedindexchanged="OnDataTypeChange" cssclass="TableInput"
																		width="100px" runat="server"></asp:dropdownlist></td>
															</tr>
															<tr>
																<td class="TableGrid">�ֶο��</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtLength" text='<%# DataBinder.Eval (Container.DataItem, "length") %>' cssclass="TableInput" runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">�ֶξ���</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtPrecision" text='<%# DataBinder.Eval (Container.DataItem, "xprec") %>' cssclass="TableInput" runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">С��λ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtScale" text='<%# DataBinder.Eval (Container.DataItem, "xscale") %>' cssclass="TableInput" runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">�����ֵ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:checkbox id="chkNull" text=" " checked='<%# DataBinder.Eval (Container.DataItem, "nullable").ToString() == "1" %>' runat=server>
																	</asp:checkbox></td>
															</tr>
															<tr>
																<td class="TableGrid">Ĭ��ֵ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtDefault" text='<%# DataBinder.Eval (Container.DataItem, "coldefault") %>' cssclass="TableInput" runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">�༭��ʽ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:linkbutton id="lbtnEditFormat" commandargument='<%# DataBinder.Eval (Container.DataItem, "ColumnID") %>' CommandName="���ø�ʽ" text='���ø�ʽ' ToolTip='<%# DataBinder.Eval (Container.DataItem, "EditFormat") %>' runat=server>
																	</asp:linkbutton>
																</td>
															</tr>
															<tr>
																<td class="TableGrid">��ʶ��</td>
																<td class="TableGrid" align="left" nowrap>
																	<asp:checkbox id="chkIdentity" Checked='<%# DataBinder.Eval (Container.DataItem, "datatype").ToString().IndexOf("IDENTITY") > 0 %>' runat="server">
																	</asp:checkbox></td>
															</tr>
															<tr>
																<td class="TableGrid">��ʾ˳��</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtDisplayOrder" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "DisplayOrder") %>' runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">��ʾ���</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtDisplayWidth" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "DisplayWidth") %>' runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">��ʾ��ʽ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtDisplayFormat" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "DisplayFormat") %>' runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">У����ʽ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtColVarify" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "ColVarify") %>' runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">У����ʾ��Ϣ</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:textbox id="txtVarifyMsg" cssclass="TableInput" text='<%# DataBinder.Eval (Container.DataItem, "VarifyMsg") %>' runat=server>
																	</asp:textbox></td>
															</tr>
															<tr>
																<td class="TableGrid">�ɼ�����</td>
																<td align="left" valign="center" class="TableGrid">
																	<asp:DropDownList id="cboColVisible" cssclass="TableInput" SelectedIndex='<%# (int)DataBinder.Eval (Container.DataItem, "ColVisible") - 1 %>' runat=server>
																		<asp:ListItem Value="1">���ɼ�</asp:ListItem>
																		<asp:ListItem Value="2">�ɼ��ɸ�</asp:ListItem>
																		<asp:ListItem Value="3">�ɼ����ɸ�</asp:ListItem>
																	</asp:DropDownList>
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</EditItemTemplate>
											<footertemplate>
						</table>
						</footertemplate> </asp:datalist><uc1:ucEditFormat id="ucEditFormat1" runat="server"></uc1:ucEditFormat>
					</td>
				</tr>
			</table>
			<br>
			</TD></TR></TBODY></TABLE>
		</form>
		<script language="javascript">
<!--
var aReturn=document.getElementsByTagName("span");
if(aReturn.length > 0)
{
	for(var i = 0; i < aReturn.length; i++)
	{
		if(aReturn[i].childNodes[0].nodeValue == "1")
			aReturn[i].childNodes[0].nodeValue = "���ɼ�";
		else if(aReturn[i].childNodes[0].nodeValue == "2")
			aReturn[i].childNodes[0].nodeValue = "�ɼ��ɸ�";
		else if(aReturn[i].childNodes[0].nodeValue == "3")
			aReturn[i].childNodes[0].nodeValue = "�ɼ����ɸ�";
		else
			aReturn[i].childNodes[0].nodeValue = "";
	}
}
//-->
		</script>
	</body>
</HTML>
