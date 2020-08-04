<%@ Page language="c#" Codebehind="Asset_BudgetConsistencyCheckMoney.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetConsistencyCheckMoney"  EnableEventValidation="false" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>一键维护预算使用金额</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style/BasicLayout.css" type="text/css" rel="stylesheet">
		<script src="../../AppSystem/Style/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
		<LINK href="../../Style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../../AppSystem/common.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function CheckForm()
			{
				return true;
			}
			
			//全选
			function SelectAll(dgName,bool)
			{
				var dgName=document.getElementById(dgName);
				var checkbox=dgName.getElementsByTagName('input');
				
				for(var i=0;i<checkbox.length;i++)
				{
					if(checkbox[i].type=='checkbox')
					{
						checkbox[i].checked=bool;
					}
				}
			}
			
			//是否有选择
			function IsExistSelect()
			{
				
				var flag=false;
				var dg=document.getElementById('dgApply');
				var checkbox=dg.getElementsByTagName('input');
				
				for(var i=0;i<checkbox.length;i++)
				{
					if(checkbox[i].checked)
					{
						flag=true;
					}
				}
				
				if(flag==false)
				{
					var meg=document.getElementById('meg');
					meg.innerHTML="请选择以下记录";
					meg.style.color="red";
				}
				
				return flag;
			}
			
		</script>
		<style>.myCss { BACKGROUND-COLOR: #dee4f4 }
	.cssFooter { COLOR: blue; TEXT-ALIGN: right }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table class="GbText" id="tabDispDocument" style="Z-INDEX: 101; BORDER-LEFT-COLOR: #0066cc; LEFT: 1px; BORDER-BOTTOM-COLOR: #0066cc; WIDTH: 100%; BORDER-TOP-COLOR: #0066cc; POSITION: absolute; TOP: 1px; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc"
				borderColor="#0066cc" cellPadding="3" rules="all" border="1">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 713px">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%">
							<tr>
								<td style="WIDTH: 49px" align="right">年份：</td>
								<td style="WIDTH: 116px"><asp:textbox id="txtDate_Year" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy'})" runat="server"
										Width="90px"></asp:textbox></td>
								<td style="WIDTH: 47px" align="right">部门：</td>
								<td style="WIDTH: 111px"><asp:dropdownlist id="ddlDeptClass" runat="server" Width="90px" AutoPostBack="True"></asp:dropdownlist></td>
								<td>
									<asp:radiobutton id="radion_exception" Text="异常" Runat="server" GroupName="radio"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="radio_normal" Text="正常" Runat="server" GroupName="radio"></asp:radiobutton>&nbsp;
									<asp:radiobutton id="radio_all" Text="所有" Checked="true" Runat="server" GroupName="radio"></asp:radiobutton>
								</td>
								<td align="right">
									<asp:button id="btnQuery" runat="server" Text=" 检 索 " CssClass="redButtonCss myCss"></asp:button>
								</td>
							</tr>
						</table>
					</td>
					<td align="right" colSpan="4"><FONT face="宋体"><asp:button id="btnConsistency" runat="server" Text="一键维护" CssClass="redButtonCss myCss"></asp:button>&nbsp;<span id="meg" style="FONT-SIZE: 12px; COLOR: blue">(提示:先选记录)</span>
						</FONT>
					</td>
				</tr>
				<TR style="HEIGHT: 28px">
					<TD style="WIDTH: 100%; HEIGHT: 27px" align="right" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
						<DIV class="  pages PageBox " id="divPages" runat="server"></DIV>
					</TD>
				</TR>
				<TR id="bodyInfo" style="DISPLAY: block; HEIGHT: 22px">
					<td style="WIDTH: 100%; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><asp:datagrid id="dgApply" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2"
							PageSize="20" AllowSorting="True" Width="100%">
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
							<FooterStyle ForeColor="#003399" BackColor="#DEE4F4"></FooterStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<asp:CheckBox ID="chkSelectAll" Runat="server" onclick="javascript:SelectAll('dgApply',this.checked);"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="chkSelect" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="rum" HeaderText="编号"></asp:BoundColumn>
								<asp:BoundColumn DataField="Iyear" SortExpression="Iyear" HeaderText="年份"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DeptCode" HeaderText="部门编码"></asp:BoundColumn>
								<asp:BoundColumn DataField="DeptName" SortExpression="DeptName" HeaderText="部门名称"></asp:BoundColumn>
								<asp:BoundColumn DataField="ItemName" SortExpression="ItemName" HeaderText="项目类型"></asp:BoundColumn>
								<asp:BoundColumn DataField="SubjectName" SortExpression="SubjectName" HeaderText="项目内容"></asp:BoundColumn>
								<asp:BoundColumn DataField="Asset_Budget_CheckMoney" SortExpression="Asset_Budget_CheckMoney" HeaderText="预算表使用金额"
									DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Asset_ApplySheet_Body_CheckMoney" SortExpression="Asset_ApplySheet_Body_CheckMoney"
									HeaderText="单据提交已使用金额" DataFormatString="{0:N}">
									<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
						</asp:datagrid></td>
				</TR>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr id="postail" style="DISPLAY: block; HEIGHT: 28px">
					<td style="WIDTH: 20%; HEIGHT: 29px; BACKGROUND-COLOR: #e8f4ff" align="center" colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" align="center" background="../../Style/Images/treetopbg.jpg"
						colSpan="6"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
			<asp:linkbutton id="linkToPage" style="Z-INDEX: 102; LEFT: 400px; POSITION: absolute; TOP: 512px"
				runat="server"></asp:linkbutton><INPUT id="HerdSort" style="Z-INDEX: 103; LEFT: 200px; POSITION: absolute; TOP: 424px"
				type="hidden" name="Hidden3" runat="server"><INPUT id="FieldSort" style="Z-INDEX: 104; LEFT: 224px; POSITION: absolute; TOP: 448px"
				type="hidden" name="Hidden2" runat="server"><INPUT id="pagesIndex" style="Z-INDEX: 105; LEFT: 248px; POSITION: absolute; TOP: 472px"
				type="hidden" value="0" name="Hidden1" runat="server">
		</form>
	</body>
</HTML>
