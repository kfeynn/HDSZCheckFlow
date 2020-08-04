<%@ Register TagPrefix="gridwc" Namespace="XPGrid" Assembly="xpGrid" %>
<%@ Page language="c#" Codebehind="AddEvection.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.CheckFlow.Evection.AddEvection" %>
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
//        }


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
				<TABLE id="Table2" style="Z-INDEX: 100; POSITION: absolute; TOP: 40px; LEFT: 40px" cellSpacing="1"
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
								<asp:DropDownList id="ddlEvection" runat="server" Width="138px"></asp:DropDownList>
								<asp:Button id="btnEditEvection" runat="server" Text="修改单据"></asp:Button>
							</td>
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
											<TD>&nbsp;</TD>
											<TD colSpan="3"><asp:label id="lblMessage" runat="server"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD style="COLOR: #ff9966">申请类型</TD>
											<TD><asp:dropdownlist id="ddlApplyType" runat="server" AutoPostBack="True" ForeColor="Transparent" BackColor="White"></asp:dropdownlist></TD>
											<TD style="WIDTH: 68px; COLOR: #ff9966">申请日期</TD>
											<TD><asp:textbox id="txtDate" onfocus="WdatePicker()" runat="server" Width="80px"></asp:textbox></TD>
											<TD style="COLOR: #ff9966">申请部门</TD>
											<TD><asp:dropdownlist id="ddlDeptClass" runat="server" AutoPostBack="True" Width="80px"></asp:dropdownlist></TD>
											<TD style="COLOR: #ff9966">申请科组</TD>
											<TD><asp:dropdownlist id="ddlDept" runat="server"></asp:dropdownlist></TD>
											<td>&nbsp;</td>
										</TR>
										<TR>
											<td style="COLOR: #ff9966">一级科目</td>
											<td><asp:dropdownlist id="ddlFirstSubject" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
											<TD style="COLOR: #ff9966">申请科目</TD>
											<TD colspan="3"><asp:dropdownlist id="ddlSubject" runat="server" Width="303px"></asp:dropdownlist></TD>
			</FONT>
			<TD></TD>
			<TD></TD>
			<TD>&nbsp;</TD>
			</TR>
			<TR><%--onkeyup="javascript:ShowUserName(this)"--%>
				<TD style="HEIGHT: 18px"><FONT face="宋体" color="#ff9966"><FONT face="Times New Roman" color="#ff9966">出差</FONT>人工号</FONT></TD>
				<TD style="HEIGHT: 18px"><asp:textbox id="txtPerson"  runat="server" Width="80px"></asp:textbox></TD>
				<TD style="HEIGHT: 18px">姓&nbsp;&nbsp;&nbsp; 名</TD>
				<TD style="HEIGHT: 18px"><asp:textbox id="txtPersonName" runat="server" Enabled="False" Width="80px"></asp:textbox></TD>
				<TD style="WIDTH: 67px; HEIGHT: 18px">单 据 号</TD>
				<TD style="HEIGHT: 18px">&nbsp;<asp:label id="Label9" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 18px">&nbsp;提交日期</TD>
				<TD style="HEIGHT: 18px">&nbsp;<asp:label id="Label10" runat="server" Width="64px"></asp:label></TD>
				<TD style="HEIGHT: 18px">&nbsp;</TD>
			</TR>
			<TR>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD>&nbsp;</TD>
				<TD style="WIDTH: 67px">&nbsp;</TD>
				<TD><asp:button id="btnAdd" runat="server" Text="添加" Width="72px" CssClass="inputButton"></asp:button></TD>
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
								<asp:label id="Label13" runat="server" Visible="False">预算外金额</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:label id="Label7" runat="server" Visible="False">本次使用</asp:label></TD>
							<TD style="HEIGHT: 16px">
								<asp:Label style="Z-INDEX: 0" id="Label14" runat="server">单据调整</asp:Label></TD>
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
				<TD>
					<asp:label id="Label1" runat="server" Visible="False" Font-Size="16px">添加单据明细：</asp:label>
				</TD>
			</TR>
			<TR>
				<TD>
					<P><asp:panel id="panel1" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BACKGROUND-COLOR: white; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid"
							Visible="False" Width="100%" Runat="server" Height="521"></P>
					<P><BR>
						&nbsp;&nbsp;&nbsp;&nbsp;<FONT color="#ff9966">开始日期：</FONT>
						<asp:textbox id="txtDateFrom" onfocus="WdatePicker({skin:'whyGreen', maxDate:'#F{$dp.$D(\'txtDateTo\')||\'2020-10-01\'}'})"
							runat="server" Width="88px"></asp:textbox>&nbsp;<FONT color="#ff9966">结束日期：</FONT>
						<asp:textbox id="txtDateTo" onfocus="WdatePicker({skin:'whyGreen', minDate:'#F{$dp.$D(\'txtDateFrom\')}',maxDate:'2020-10-01'})"
							runat="server" Width="88px"></asp:textbox>&nbsp;<FONT color="#ff9966">出差城市：</FONT>
						<asp:textbox id="txtGocity" runat="server" Width="200px"></asp:textbox>&nbsp;<BR>
						<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;出差类型：&nbsp;
						<asp:dropdownlist id="ddlCCType" runat="server">
							<asp:ListItem Value="国内">国内</asp:ListItem>
							<asp:ListItem Value="国外">国外</asp:ListItem>
						</asp:dropdownlist>
						<asp:Label id="Label11" runat="server">Label</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;差旅费等级:&nbsp;&nbsp;
						<asp:textbox id="txtAppclass" runat="server" Width="80px"></asp:textbox>&nbsp;&nbsp; 
						同行人数：&nbsp;
						<asp:textbox id="txtwithapps" runat="server" Width="80px"></asp:textbox>&nbsp;
					</P>
					<P>&nbsp;&nbsp;&nbsp; 同 行 人：&nbsp;&nbsp;
						<asp:textbox id="txtWithwho" runat="server" Width="576px"></asp:textbox></P>
					<P>&nbsp;&nbsp;&nbsp;&nbsp; 出差理由：
						<asp:textbox id="txtCCMemo" runat="server" Width="432px" Height="82px" TextMode="MultiLine"></asp:textbox></P>
					<P>&nbsp;&nbsp;&nbsp;<FONT color="green">注意:以上褐色项目为必填项目。以下为国外出差的项目，国内出差无须填写</FONT>
					</P>
					<P><asp:panel id="Panel2" runat="server" Height="164px" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px">
							<P>&nbsp; 前次出国日期：
								<asp:TextBox id="txtPreabound" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
									runat="server" Width="112px"></asp:TextBox>前次回国日期：
								<asp:TextBox id="txtPreback" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
									Width="112px"></asp:TextBox>&nbsp;VIsa：
								<asp:CheckBox id="chbVisa" runat="server" Text="有/无"></asp:CheckBox>&nbsp;VIsa有效期：
								<asp:TextBox id="txtVisaDate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})" runat="server"
									Width="112px"></asp:TextBox></P>
							<P></P>
							<P>&nbsp; 护照：
								<asp:CheckBox id="chkPassport" runat="server" Text="有/无"></asp:CheckBox>&nbsp;护照号：&nbsp;
								<asp:TextBox id="txtPassportno" runat="server" Width="184px"></asp:TextBox>&nbsp;护照有效期：
								<asp:TextBox id="txtpassportdate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
									runat="server"></asp:TextBox></P>
							<P>&nbsp;疫苗注射：
								<asp:CheckBox id="chbbacterin" runat="server" Text="有/无"></asp:CheckBox>疫苗有效期：
								<asp:TextBox id="txtbacterindate" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd'})"
									runat="server"></asp:TextBox></P>
							<P>&nbsp;备注事项：
								<asp:TextBox id="txtabountMemo" runat="server" Width="552px" Height="92px" TextMode="MultiLine"></asp:TextBox></P>
							<P>&nbsp;是否携带限制物品:
								<asp:CheckBox id="chblimit" runat="server" Text="有/无"></asp:CheckBox>是否提供限制技术(程序、资料等)：
								<asp:CheckBox id="chblimits" runat="server" Text="有/无"></asp:CheckBox>出港前体检:
								<asp:CheckBox id="chbcheckup" runat="server" Text="要/否"></asp:CheckBox></P>
							<P>是否符合出口限制条件:
								<asp:CheckBox id="chbmeet" runat="server" Text="符合/不符合"></asp:CheckBox>体检日期(计划):
								<asp:TextBox id="txtcheckupplan" runat="server" Width="168px"></asp:TextBox></P>
							<P><FONT color="green">&nbsp;&nbsp; 注意:1、出差时间一个月以上者须体检。2、出差时间超过31天者停止发放通勤补贴。</FONT></P>
							<P>
						</asp:panel><BR>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="btnCCSave" runat="server" Text="保存" Width="64px" CssClass="inputbutton"></asp:button>
						<asp:Label id="Label12" runat="server" ForeColor="#0000C0" BackColor="White"></asp:Label></P>
					<P><asp:panel id="Panel3" style="BORDER-BOTTOM: darkgoldenrod 1px solid; BORDER-LEFT: darkgoldenrod 1px solid; BORDER-TOP: darkgoldenrod 1px solid; BORDER-RIGHT: darkgoldenrod 1px solid; LEFT: 8px"
							runat="server">
							<gridwc:xpgrid id="XpGrid1" runat="server" Height="2px" width="100%" AllowSort="True" AllowPrint="True"
								AllowExportExcel="True" AllowEdit="True" AllowDelete="True" AllowAdd="True" SelectKind="MulitLines"></gridwc:xpgrid>
						</asp:panel></P>
					<P>&nbsp;</P>
					<P></asp:panel></P>
					<P>&nbsp;</P>
				</TD>
			</TR>
			</TBODY></TABLE> <INPUT id="HiddenLeft" style="Z-INDEX: 104; POSITION: absolute; TOP: 0px; LEFT: 320px"
				type="hidden" value="0" name="Hidden2" runat="server"> <INPUT id="Hidden2" style="Z-INDEX: 103; POSITION: absolute; TOP: 0px; LEFT: 160px" type="hidden"
				name="Hidden2" runat="server"> <INPUT id="Hidden1" style="Z-INDEX: 101; POSITION: absolute; TOP: 0px; LEFT: 0px" type="hidden"
				value="0" name="Hidden1" runat="server"> </FONT></form>
	</body>
</HTML>
