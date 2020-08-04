<%@ Page language="c#" Codebehind="AddApplySheetNew.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.CheckFlow.AddApplySheetNew"   EnableEventValidation="false" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddApplySheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link href="../../Style/Style.css" type="text/css" rel="stylesheet" />
		<script type="text/javascript" language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script type="text/javascript" src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<script type="text/javascript" language="javascript" src="../../AppSystem/JsLib/jquery-1.6.min.js"></script> 
		<script type="text/javascript" language="javascript" src="../../AppSystem/JsLib/myHandleRequest.js"></script>
        <script type="text/javascript" language="javascript">
            window.XPGrid = "XPGrid1";
//            function ShowUserName(useCode) {
//                alert('aaa');
//                var userName = HDSZCheckFlow.UI.CheckFlow.CheckFlow.AddApplySheet.GetUserNameByCode(useCode.value);
//                if (userName.length == 0)
//                { }
//                else {
//                    document.getElementById("txtPersonName").innerText = userName.value;
//                }
            //            }



//            function GetEmployeeListWS_REST() {
//                jQuery.ajax({
//                    url: "http://localhost:8080/RESTDemo/rest/hello/helloXML",
//                    async: false,
//                    type: 'GET',
//                    contentType: "text/xml; charset=utf-8",
//                    dataType: "text",
//                    crossDomain: true,
//                    //data: packet,
//                    error: function(xhr, textStatus, errorThrown) { alert(xhr + ' ' + textStatus + '' + errorThrown); },
//                    success: function(response, status, xmlData) {

//                        $("#EmployeeDetailsWs").text(response);
//                    }
//                });

//            }

            $(function() {
                $("#txtPerson").keyup(function() {
                    // alert(document.getElementById('txtPerson').value);
                    $.post("AJAX.asmx/GetUserNameByCode",
						{
						    useCode: document.getElementById('txtPerson').value
						},
						
						function(data, status) {
						    alert("Data: " + data + "\nStatus: " + status);
						    document.getElementById("txtPersonName").innerText = data.text;

						},"text/html"
						
						);
                });
            });

		</script>

	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table2" style="Z-INDEX: 100; POSITION: absolute; TOP: 40px; LEFT: 40px" cellSpacing="1"
					cellPadding="1" width="95%" border="0">
					<tr>
						<td style="HEIGHT: 18px"><TABLE style="MARGIN: 3px" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
								<TR height="18">
									<TD align="center">
                                        <asp:button id="btnInConrt" CssClass="ButtonFlat" runat="server" 
                                            Text="预算内提交" Enabled="False"></asp:button>
										<FONT face="宋体"></FONT>
										<asp:button id="btnOutConrt" runat="server" CssClass="ButtonFlat" Text="预算外提交" 
                                            Enabled="False" ></asp:button>
										<asp:Label id="lblMsg" runat="server"></asp:Label>
                                    </TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD><TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1" class="TableSearch2">
								<TR>
									<TD align="right" width="90%" colspan="8" height="18"><a target="_blank" href="BaseSubjecQuery.aspx">查询产品价格</a>
										<asp:Label id="lblAnnexMsg" runat="server"></asp:Label></TD>
									<TD width="10%" align="center">
										<asp:HyperLink id="hyLindToAnnex" runat="server" Visible="False">添加附件</asp:HyperLink></TD>
								</TR>
								<TR>
									<TD colspan="3">
										<P style="COLOR: #333366; FONT-SIZE: 18px">添加申请单：</P>
									</TD>
									<TD style="WIDTH: 142px">&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD colspan="3">
										<asp:label id="lblMessage" runat="server"></asp:label>&nbsp;</TD>
								</TR>
								<TR>
									<TD>申请类型</TD>
									<TD><asp:dropdownlist id="ddlApplyType" runat="server" AutoPostBack="True" ForeColor="Transparent" BackColor="White"
											Width="120px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 68px">申请日期</TD>
									<TD style="WIDTH: 142px"><asp:textbox id="txtDate" onfocus="WdatePicker({minDate:'%y-%M-{01}'})" runat="server" Width="120px"></asp:textbox></TD>
									<TD>申请部门</TD>
									<TD><asp:dropdownlist id="ddlDeptClass" runat="server" Width="120px" AutoPostBack="True">
                                        <asp:ListItem></asp:ListItem>
                                        </asp:dropdownlist></TD>
									<TD>申请科组</TD>
									<TD colspan="2" width="40%"><asp:dropdownlist id="ddlDept" runat="server" AutoPostBack="True" Width="160px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<td>一级科目</td>
									<td>
										<asp:DropDownList id="ddlFirstSubject" runat="server" AutoPostBack="True" Width="120px"></asp:DropDownList></td>
									<TD>申请科目</TD>
									<TD style="WIDTH: 142px" colspan="3"><asp:dropdownlist id="ddlSubject" runat="server" Width="296px"></asp:dropdownlist></TD>
									<TD>申 请 人</TD>
									<TD colspan="2"><asp:textbox id="txtPerson"   runat="server" Width="120px" ></asp:textbox></TD>
								</TR>
								<TR>
									<TD>姓&nbsp;&nbsp;&nbsp; 名</TD>
									<TD><asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px" ForeColor="Red"></asp:textbox></TD>
									<TD>
										交货日期</TD>
									<TD style="WIDTH: 142px">
										<asp:textbox id="txtDeliveryDate" onfocus=" WdatePicker()" runat="server" Width="93px"></asp:textbox></TD>
									<TD style="WIDTH: 67px">单 据 号</TD>
									<TD>&nbsp;
										<asp:Label id="Label9" runat="server" Width="64px"></asp:Label></TD>
									<TD>&nbsp;提交日期</TD>
									<TD colspan="2">&nbsp;
										<asp:Label id="Label10" runat="server" Width="64px"></asp:Label></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD>&nbsp;</TD>
									<TD style="WIDTH: 142px">&nbsp;</TD>
									<TD style="WIDTH: 67px">&nbsp;</TD>
									<TD><asp:button id="btnAdd" runat="server" Text="添加" CssClass="inputButton" 
                                            Width="72px"   ></asp:button></TD>
									<TD>
										<asp:button id="btnEdit" runat="server" Text="修改" Width="72px" 
                                            CssClass="inputButton"  ></asp:button></TD>
									<TD colspan="2">
										<asp:button id="btnSave" runat="server" Text="保存" Width="72px" 
                                            CssClass="inputButton"  ></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<td height="80">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1" class="TableSearch2">
								<TR>
									<TD style="HEIGHT: 16px; COLOR: #333366"><asp:label id="Label2" runat="server" Visible="False">预算金额(季度)</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label id="Label8" runat="server" Visible="False">推算金额(季度)</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label3" runat="server" Visible="False">调整金额(季度)</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label5" runat="server" Visible="False">已经使用</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label4" runat="server" Visible="False">待摊金额</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label11" runat="server" Visible="False">预算外金额</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
									<TD style="HEIGHT: 16px">
										<asp:label style="Z-INDEX: 0" id="Label12" runat="server" Visible="False">单据调整</asp:label></TD>
									<TD style="HEIGHT: 16px"><asp:label id="Label6" runat="server" Visible="False">剩   余</asp:label></TD>
								</TR>
								<TR>
									<TD><asp:label id="lblBudget" runat="server"></asp:label></TD>
									<TD>
										<asp:label id="lblPush" runat="server"></asp:label></TD>
									<TD><asp:label id="lblChange" runat="server"></asp:label></TD>
									<TD><asp:label id="lblSumCheck" runat="server"></asp:label></TD>
									<TD><asp:label id="lblready" runat="server"></asp:label></TD>
									<TD><asp:label id="lblOutMoney" runat="server"></asp:label></TD>
									<TD><asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
									<TD>
										<asp:Label style="Z-INDEX: 0" id="lblAlterMoney" runat="server"></asp:Label></TD>
									<TD><asp:label id="lblLeft" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</td>
					</TR>
					<TR>
						<TD><asp:label id="Label1" runat="server" Visible="False" Font-Size="16px" ForeColor="#003366">添加单据明细：</asp:label></TD>
					</TR>
					<TR>
						<TD style="BORDER-BOTTOM: darkgoldenrod 0px solid; BORDER-LEFT: darkgoldenrod 0px solid; BORDER-TOP: darkgoldenrod 0px solid; BORDER-RIGHT: darkgoldenrod 0px solid; LEFT: 8px">
                            <gridwc:xpgrid id="XPGrid1" runat="server" width="100%" AllowSort="True" 
                                AllowPrint="True" AllowExportExcel="True"
								AllowEdit="True" AllowDelete="True" AllowAdd="True" SelectKind="MulitLines"></gridwc:xpgrid></TD>
					</TR>
				</TABLE>
				<INPUT id="HiddenLeft" style="Z-INDEX: 104; POSITION: absolute; TOP: 0px; LEFT: 320px"
					type="hidden" value="0" name="Hidden2" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 103; POSITION: absolute; TOP: 0px; LEFT: 160px" type="hidden"
					name="Hidden2" runat="server"> <INPUT id="Hidden1" style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 0px" type="hidden"
					name="Hidden1" runat="server"> </FONT>
		</form>
	</body>
</HTML>
