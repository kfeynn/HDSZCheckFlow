<%@ Page language="c#" Codebehind="AddBanquet.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.Evection.AddBanquet" %>
<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AddApplySheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../AppSystem/JsLib/date.js"></script>
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<script language="javascript">
//		function ShowUserName(useCode)
//		{
//			var userName=HDSZCheckFlow.UI.CheckFlow.Evection.AddEvection.GetUserNameByCode(useCode.value);
//			if(userName.length==0)
//			{}
//			else
//			{
//				document.getElementById("txtPersonName").innerText=userName.value;
//			}
		    //		}

		    $(function() {
		        $("#txtPerson").keyup(function() {
		            // alert(document.getElementById('txtPerson').value);
		            $.post("AJAX.asmx/GetUserNameByCode",
						{
						    useCode: document.getElementById('txtPerson').value
						},
						function(data, status) {
						    //alert("Data: " + data.text + "\nStatus: " + status);
						    document.getElementById("txtPersonName").innerText = data.text;

						    //alert(data.text);

						    //						    $("#txtPersonName").css({
						    //						        "ForeColor": "red"
						    //						    });

						});
		        });
		    });
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table2" style="Z-INDEX: 101; POSITION: absolute; TOP: 40px; LEFT: 40px" cellSpacing="1"
					cellPadding="1" width="90%" border="0">
					<TBODY>
						<tr>
							<td align="center"><asp:label id="lblMsg" runat="server"></asp:label></td>
						</tr>
						<tr>
							<td style="HEIGHT: 13px">
								<TABLE id="Table3" cellSpacing="1" cellPadding="1" align="left" border="0">
									<TR>
										<TD></TD>
										<TD><asp:button id="btnInConrt" runat="server" Text="预算内提交" Enabled="False"></asp:button></TD>
										<TD><asp:button id="btnOutConrt" runat="server" Text="预算外提交" Enabled="False"></asp:button></TD>
									</TR>
								</TABLE>
							</td>
						</tr>
						<tr>
							<td align="center">
								<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD align="right" width="90%">&nbsp;
											<asp:label id="lblAnnexMsg" runat="server"></asp:label></TD>
										<TD width="10%"><asp:hyperlink id="hyLindToAnnex" runat="server" Visible="False">添加附件</asp:hyperlink></TD>
									</TR>
								</TABLE>
								<asp:dropdownlist id="ddlEvection" runat="server" Width="138px"></asp:dropdownlist><asp:button id="btnEditEvection" runat="server" Text="修改单据"></asp:button></td>
						</tr>
						<TR>
							<TD>&nbsp;
								<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TBODY>
										<TR>
											<TD colSpan="3">
												<P style="FONT-SIZE: 14px">添加申请单：</P>
											</TD>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
											<TD style="WIDTH: 99px">&nbsp;</TD>
											<TD colSpan="3"><asp:label id="lblMessage" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD style="COLOR: #ff9966">申请类型</TD>
											<TD><asp:dropdownlist id="ddlApplyType" runat="server" AutoPostBack="True" ForeColor="Transparent" BackColor="White"></asp:dropdownlist></TD>
											<TD style="WIDTH: 68px; COLOR: #ff9966">申请日期</TD>
											<TD><asp:textbox id="txtDate" onfocus="WdatePicker()" runat="server" Width="80px"></asp:textbox></TD>
											<TD style="COLOR: #ff9966">申请部门</TD>
											<TD style="WIDTH: 99px"><asp:dropdownlist id="ddlDeptClass" runat="server" Width="80px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD style="COLOR: #ff9966">申请科组</TD>
											<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
											<td>&nbsp;</td>
										</TR>
										<TR>
											<td style="COLOR: #ff9966">一级科目</td>
											<td><asp:dropdownlist id="ddlFirstSubject" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
											<TD style="COLOR: #ff9966">申请科目</TD>
											<TD colspan="3" style="WIDTH: 330px"><asp:dropdownlist id="ddlSubject" runat="server" Width="306px"></asp:dropdownlist></TD>
			</FONT>
			<TD>&nbsp;</TD>
			<TD>&nbsp;</TD>
			<TD>&nbsp;</TD>
			</TR>
			<TR><%--onkeyup="javascript:ShowUserName(this)"--%>
				<TD style="HEIGHT: 16px">&nbsp;<FONT face="Times New Roman" color="#ff9966">申请人工号</FONT></TD>
				<TD style="HEIGHT: 16px">
					<asp:textbox id="txtPerson"  runat="server" Width="80px"></asp:textbox></TD>
				<TD style="HEIGHT: 16px">姓&nbsp;&nbsp;&nbsp; 名</TD>
				<TD style="HEIGHT: 16px">
					<asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px" ForeColor="Red"></asp:textbox></TD>
				<TD style="WIDTH: 67px; HEIGHT: 16px">单 据 号</TD>
				<TD style="WIDTH: 99px; HEIGHT: 16px">&nbsp;
					<asp:label id="Label9" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 16px">&nbsp;提交日期</TD>
				<TD style="HEIGHT: 16px">&nbsp;<asp:label id="Label10" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 16px">&nbsp;</TD>
			</TR>
			<TR>
				<TD>&nbsp;
				</TD>
				<TD>&nbsp;
				</TD>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD style="WIDTH: 67px">&nbsp;</TD>
				<TD style="WIDTH: 99px"><asp:button id="btnAdd" runat="server" Text="添加" Width="72px" CssClass="inputButton"></asp:button></TD>
				<TD><asp:button id="btnEdit" runat="server" Text="修改" Width="72px" CssClass="inputButton"></asp:button></TD>
				<TD><asp:button id="btnSave" runat="server" Text="保存" Width="72px" CssClass="inputButton"></asp:button></TD>
				<TD>&nbsp;</TD>
			</TR>
			</TBODY></TABLE></TD></TR>
			<TR>
				<td height="100">
					<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
						<TR>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label2" runat="server" Visible="False">预算金额(季度)</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label8" runat="server" Visible="False">推算金额(季度)</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label3" runat="server" Visible="False">调整金额(季度)</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label5" runat="server" Visible="False">已经使用</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label4" runat="server" Visible="False">待摊金额</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label11" runat="server" Visible="False">预算外金额</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label style="Z-INDEX: 0" id="Label13" runat="server" Visible="False">单据调整</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label6" runat="server" Visible="False">剩   余</asp:label></TD>
						</TR>
						<TR>
							<TD>
								<asp:label id="lblBudget" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblPush" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblChange" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblSumCheck" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblready" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblOutMoney" runat="server"></asp:label></TD>
							<TD>
								<asp:label id="lblSheetMoney" runat="server"></asp:label></TD>
							<TD>
								<asp:Label style="Z-INDEX: 0" id="lblAlterMoney" runat="server"></asp:Label></TD>
							<TD>
								<asp:label id="lblLeft" runat="server"></asp:label></TD>
						</TR>
					</TABLE>
				</td>
			</TR>
			<TR>
				<TD><a name="p"></a><asp:label id="Label1" runat="server" Visible="False" Font-Size="16px">添加单据明细：</asp:label></TD>
			</TR>
			<TR>
				<TD>
					<P><asp:panel id="panel1" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
							Visible="False" Width="100%" Runat="server" Height="521"></P>
					<P><BR>
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR height="15">
								<TD align="center" width="15%">项目</TD>
								<TD align="center" style="WIDTH: 433px">计划日程</TD>
								<TD align="center">备注</TD>
							</TR>
							<TR>
								<TD style="COLOR: #ff9966">
									<P>招待时间</P>
								</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtDateFrom" runat="server" onfocus="WdatePicker({skin:'whyGreen', maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"></asp:textbox>至
									<asp:textbox id="txtDateTo" runat="server" onfocus="WdatePicker({skin:'whyGreen', minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px; COLOR: #ff9966">招待单位</TD>
								<TD style="WIDTH: 433px; HEIGHT: 14px"><asp:textbox id="txtVisitCompany" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 14px">【注意事项】</TD>
							</TR>
							<TR>
								<TD style="Z-INDEX: 0; COLOR: #ff9966">来客人员姓名</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtCallinPerson" runat="server" Width="344px"></asp:textbox></TD>
								<TD>①交际费的使用必须事前申请。特别是会餐以外的交际费的使用，必须事前完成审批报告。</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px">来访目的</TD>
								<TD style="WIDTH: 433px; HEIGHT: 12px"><asp:textbox id="txtCallinMemo" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 12px">②未能事前申请时，需在申请书的备注栏中写明原因，事后立即申请。</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 15px">会谈地点</TD>
								<TD style="WIDTH: 433px; HEIGHT: 15px"><asp:textbox id="txtTalkPlace" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 15px">③来访客人姓名、接待人员姓名需全员记入。出席人员较多的话请添附具体名单。</TD>
							</TR>
							<TR>
								<TD>接待部门</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtVisitDept" runat="server" Width="344px"></asp:textbox></TD>
								<TD>④只有JDI内部人员参加的会餐等，原则上个人承担费用。</TD>
							</TR>
							<TR>
								<TD>接待人员</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtVisitPerson" runat="server" Width="344px"></asp:textbox></TD>
								<TD>⑤来客接待时的会餐出席人员，原则上来客1名，公司接待人员1名。（原则上公司接待人员不能多于来客人数）</TD>
							</TR>
							<TR>
								<TD>接待部门联系方式</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtvisitphone" runat="server" Width="344px"></asp:textbox></TD>
								<TD>⑥禁止使用二次会（卡拉OK等）交际费。</TD>
							</TR>
							<TR>
								<TD>相关部门</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtRelationDept" runat="server" Width="344px"></asp:textbox></TD>
								<TD>⑦无论任何理由，禁止接待或馈赠反社会团体相关人员。</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 20px">茶水准备</TD>
								<TD style="WIDTH: 433px; HEIGHT: 20px"><asp:checkbox id="chbTea" runat="server" Text="需要/不需要"></asp:checkbox></TD>
								<TD style="HEIGHT: 20px"></TD>
							</TR>
							<TR>
								<TD>参观工厂</TD>
								<TD style="WIDTH: 433px"><asp:checkbox id="chblookFactory" runat="server" Text="是/否"></asp:checkbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px">参观人数</TD>
								<TD style="WIDTH: 433px; HEIGHT: 14px"><asp:textbox id="txtLookNum" runat="server" Width="344px"></asp:textbox></TD>
								<TD style="HEIGHT: 14px"></TD>
							</TR>
							<TR>
								<TD>午餐安排</TD>
								<TD style="WIDTH: 433px"><asp:checkbox id="chbLunch" runat="server" Text="食堂内/外"></asp:checkbox></TD>
								<TD>食堂午餐 附《来宾用餐申请表》</TD>
							</TR>
							<TR>
								<TD>其他需求</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtOtherNeed" runat="server" Width="344px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 14px">车辆安排</TD>
								<TD style="WIDTH: 433px; HEIGHT: 14px">公司派车：
									<asp:radiobutton id="RadioButton1" runat="server" Text="接" GroupName="carplan"></asp:radiobutton><asp:radiobutton id="RadioButton2" runat="server" Text="送" GroupName="carplan"></asp:radiobutton><asp:radiobutton id="RadioButton3" runat="server" Text="往返" GroupName="carplan"></asp:radiobutton><asp:radiobutton id="RadioButton4" runat="server" Text="无" GroupName="carplan" Checked="True"></asp:radiobutton></TD>
								<TD style="HEIGHT: 14px">用车 附《用车联络单》</TD>
							</TR>
							<TR>
								<TD>特殊要求</TD>
								<TD style="WIDTH: 433px"><asp:textbox id="txtEspecialRequest" runat="server" Width="344px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD style="WIDTH: 433px"><asp:button id="btnCCSave" runat="server" Text="保存" Width="64px" CssClass="inputbutton"></asp:button><asp:label id="Label12" runat="server" Width="248px" ForeColor="#0000C0" BackColor="White"></asp:label></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<BR>
						<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</P>
					<P><asp:panel id="Panel3" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
							runat="server">
							<gridwc:xpgrid id="XpGrid1" runat="server" Height="2px" width="100%" AllowSort="True" AllowPrint="True"
								AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="True" SelectKind="MulitLines"></gridwc:xpgrid>
						</asp:panel></P>
					<P>&nbsp;</P>
					<P>&nbsp;</P>
					</asp:panel>
					<P>&nbsp;</P>
				</TD>
			</TR>
			</TBODY></TABLE><INPUT id="HiddenLeft" style="Z-INDEX: 104; POSITION: absolute; TOP: 0px; LEFT: 320px"
				type="hidden" value="0" name="Hidden2" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 103; POSITION: absolute; TOP: 0px; LEFT: 160px" type="hidden"
				name="Hidden2" runat="server"> <INPUT id="Hidden1" style="Z-INDEX: 102; POSITION: absolute; TOP: 0px; LEFT: 0px" type="hidden"
				value="0" name="Hidden1" runat="server"> </FONT></form>
	</body>
</HTML>
