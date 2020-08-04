<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.QuerySuiteControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="QuerySuiteClassListControl" Src="QuerySuiteClassListControl.ascx" %>
<%@ Register TagPrefix="lsuc" TagName="ConditionEditControl" Src="ConditionEditControl.ascx" %>
<%@ Register TagPrefix="lsuc" TagName="WizardFieldSelectorControl" Src="WizardFieldSelectorControl.ascx" %>
<script language="javascript">
<!--
	function CheckEnable(chk, ctl)
	{
		if (chk.checked)
			ctl.disabled = false;
		else
			ctl.disabled = true;
	}
	
	function GotoMaintainPage()
	{
		window.location.href = "<%= this.MaintainPageURL%>";
	}
//-->
</script>
<P>
	<TABLE class="tool" id="toolbarTable" cellSpacing="0" cellPadding="0" border="0">
		<TR class="tooltop">
			<TD class="tooltiao" vAlign="top" align="left" rowSpan="3"></TD>
			<TD colSpan="4">
				<P>&nbsp;</P>
			</TD>
			<TD></TD>
		</TR>
		<TR>
			<TD class="yuanjiao" colSpan="2"></TD>
			<TD width="100%"></TD>
			<TD class="youyuanjiao"></TD>
			<TD class="youyuanjiao"></TD>
		</TR>
		<TR height="100%">
			<TD class="kongxi" colSpan="2"></TD>
			<TD vAlign="top" width="100%">
				<DIV>
					<P><asp:panel id="pnlBasic" runat="server" Width="100%" Visible="False">
							<TABLE id="Table4" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD><FONT size="2"><STRONG>&nbsp;第一步：基本设置</STRONG></FONT></TD>
								</TR>
								<TR>
									<TD>
										<P>
											<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
												<TR>
													<TD width="40%">方案名称
													</TD>
													<TD>
														<asp:TextBox id="txtCaption" Width="200px" runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD><FONT face="宋体">方案类别</FONT></TD>
													<TD>
														<uc1:QuerySuiteClassListControl id="ctlClassList" runat="server" width="200"></uc1:QuerySuiteClassListControl></TD>
												</TR>
												<TR>
													<TD>
														<asp:CheckBox id="chkTopNumber" runat="server" CssClass="xiao" Text="限制返回的记录数" AutoPostBack="True"></asp:CheckBox></TD>
													<TD>
														<asp:TextBox id="txtTopNumber" Width="200px" runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD>
														<asp:CheckBox id="chkPageSize" runat="server" CssClass="xiao" Text="进行分页显示" AutoPostBack="True"></asp:CheckBox></TD>
													<TD>
														<asp:TextBox id="txtPageSize" Width="200px" runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD>方案描述</TD>
													<TD>
														<asp:TextBox id="txtDescription" Width="200px" runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD>类型
													</TD>
													<TD>
														<asp:RadioButtonList id="rblQueryType" runat="server" CssClass="xiao" RepeatDirection="Horizontal">
															<asp:ListItem Value="1" Selected="True">普通查询</asp:ListItem>
															<asp:ListItem Value="2">统计查询</asp:ListItem>
														</asp:RadioButtonList><FONT size="2"></FONT></TD>
												</TR>
												<TR>
													<TD><FONT size="2">查询关联类型</FONT></TD>
													<TD>
														<asp:RadioButtonList id="rblJoinType" runat="server" CssClass="xiao" RepeatDirection="Horizontal">
															<asp:ListItem Value="1" Selected="True">内部关联</asp:ListItem>
															<asp:ListItem Value="2">左外关联</asp:ListItem>
														</asp:RadioButtonList><FONT size="2"></FONT></TD>
												</TR>
											</TABLE>
										</P>
									</TD>
								</TR>
								<TR>
									<TD><FONT size="2"></FONT></TD>
								</TR>
							</TABLE>
						</asp:panel></P>
					<P><FONT face="宋体"><asp:panel id="pnlSelectFields" runat="server" Width="100%" Visible="False">
								<lsuc:WizardFieldSelectorControl id="wzdSelectFields" runat="server" Caption="第二步：选择需要显示的字段。"></lsuc:WizardFieldSelectorControl>
							</asp:panel></P>
					<P><asp:panel id="pnlGroup" runat="server" Width="100%" Visible="False">
							<lsuc:WizardFieldSelectorControl id="wzdGroup" runat="server" Caption="第三步：进行排序设置。"></lsuc:WizardFieldSelectorControl>
						</asp:panel><asp:panel id="pnlCondition" runat="server" Width="100%" Visible="False">
							<TABLE id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD><FONT size="2"><STRONG>&nbsp;第四步：设置查询条件</STRONG></FONT></TD>
								</TR>
								<TR>
									<TD>
										<lsuc:ConditionEditControl id="ctlCondition" runat="server"></lsuc:ConditionEditControl><FONT size="2"></FONT></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="70%" align="center" border="0">
							<TR>
								<TD style="WIDTH: 7px"><asp:imagebutton id="btnPrevious" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/shangyibu.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 22px"><asp:imagebutton id="btnNext" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/xiayibu.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 2px"><asp:imagebutton id="btnSaveSuite" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/baocun.gif"></asp:imagebutton></TD>
								<TD style="WIDTH: 7px">
									<asp:ImageButton id="btnExecute" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/zhixing.gif"></asp:ImageButton></TD>
								<TD style="WIDTH: 7px">
									<asp:ImageButton id="btnSaveAs" runat="server" ImageUrl="<%=ApplicationPath%>xpGrid/images/licunwei.gif"></asp:ImageButton></TD>
								<TD style="WIDTH: 7px"><IMG class=btnEnable onclick=GotoMaintainPage(); alt="" src="<%=ApplicationPath%>xpGrid/images/quxiao.gif"></TD>
							</TR>
						</TABLE>
					</P>
					</FONT>
					<P><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></P>
				</DIV>
			</TD>
			<TD class="youtooltiao"></TD>
			<TD class="youtooltiao"></TD>
		</TR>
	</TABLE>
	<script language="javascript">
<!--
	<%=_sOpenExecute%>
//-->
	</script>
</P>
