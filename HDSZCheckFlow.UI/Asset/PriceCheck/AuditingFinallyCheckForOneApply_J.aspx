<%@ Page language="c#" Codebehind="AuditingFinallyCheckForOneApply_J.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.Asset.PriceCheck.AuditingFinallyCheckForOneApply_J" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AuditingForOneApply</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../Style/Style/BasicLayout.css">
		<script language="javascript">
		function showDisplay(type)
		{
			if(document.all(type).style.display=='none')
			{
			    //document.all(type).style.display='block';
				//以下解决谷歌浏览器显示错误
				document.all(type).style.display='';   
				document.all(type).style.display='table-row';
				
				
			}
			else
			{
				document.all(type).style.display='none';
			}
		} 
		</script>
		<style type="text/css">
			 
			#txtPosital { resize: none }
			 
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
			<table style="Z-INDEX: 101; POSITION: absolute; BORDER-BOTTOM-COLOR: #0066cc; BORDER-TOP-COLOR: #0066cc; WIDTH: 100%; BORDER-COLLAPSE: collapse; HEIGHT: 36px; BORDER-RIGHT-COLOR: #0066cc; BORDER-LEFT-COLOR: #0066cc; TOP: 0px; LEFT: 0px"
				id="tabDispDocument" class="GbText" border="1" rules="all" borderColor="#0066cc" cellPadding="3">
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center">基本情報</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">
						書類番号:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体">
							<asp:HyperLink style="Z-INDEX: 0" id="hlApplySheetNo" runat="server"></asp:HyperLink></FONT></td>
				</tr>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">審査類別:</TD>
					<TD style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblBudgetType" runat="server" Width="112px"></asp:label></FONT></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">申請項目:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblSubject" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">申請類型:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblApplyType" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">提案部門及び提案者:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"><asp:label id="lblDpteAndPerson" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">申請日付:</td>
					<td style="WIDTH: 30%"><FONT face="宋体"><asp:label id="lblApplyDate" runat="server"></asp:label></FONT></td>
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 10%" align="right">希望納期:</td>
					<td style="WIDTH: 12.21%"><FONT face="宋体"><asp:label id="lblDeliveryDate" runat="server"></asp:label></FONT></td>
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 10%" align="right">記入日時:</td>
					<td style="WIDTH: 20%"><FONT face="宋体"><asp:label id="lblSubmitDate" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">金額(RMB):</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体"></FONT><asp:label id="lblMoney" runat="server"></asp:label></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center">予算情況</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%; HEIGHT: 16px" align="right"><SPAN id="Label2">契約番号:</SPAN></td>
					<td style="WIDTH: 80%; HEIGHT: 16px" colSpan="5"><FONT face="宋体"><asp:label id="lblBargainNo" runat="server"></asp:label></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%; BACKGROUND-COLOR: #e8f4ff" align="right"><SPAN id="Label4">//追加金额</SPAN>:</td>
					<td style="WIDTH: 80%" colSpan="5"></td>
				</tr>-->
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%; HEIGHT: 23px" align="right">希望納期:</TD>
					<TD style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><asp:label id="lblRequestDate" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">支払条件:</td>
					<td style="WIDTH: 80%" colSpan="5"><FONT face="宋体">
							<asp:label style="Z-INDEX: 0" id="lblPayForArticle" runat="server"></asp:label></FONT></td>
				</tr>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right"><FONT style="Z-INDEX: 0" face="宋体">貿易条項:</FONT></TD>
					<TD style="WIDTH: 80%" colSpan="5"><FONT face="宋体">
							<asp:label style="Z-INDEX: 0" id="lblTradeAgreement" runat="server"></asp:label></FONT></TD>
				</TR>
				<TR style="HEIGHT: 22px">
					<TD style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%" align="right">検収部門:</TD>
					<TD style="WIDTH: 80%" colSpan="5">
						<asp:label style="Z-INDEX: 0" id="lblCheckDept" runat="server"></asp:label></TD>
				</TR>
				<tr style="HEIGHT: 22px">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 17.31%; HEIGHT: 23px" align="right"><SPAN id="Label3">付&nbsp; 
							注</SPAN>:</td>
					<td style="WIDTH: 80%; HEIGHT: 23px" colSpan="5"><FONT face="宋体"><asp:label id="lblReMark" runat="server"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><A onclick="javascript:showDisplay('bodyInfo')" href="javascript:void(0)" style="Z-INDEX: 0">詳細書類</A></td>
				</tr>
				<tr style="DISPLAY: none; HEIGHT: 22px" id="bodyInfo">
					<td style="BACKGROUND-COLOR: #e8f4ff; WIDTH: 20%" colSpan="6" align="center">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td>
									<asp:datagrid style="Z-INDEX: 0; MARGIN: 5px" id="dgApplyBody" runat="server" Width="99%" AllowSorting="True"
										PageSize="20" AutoGenerateColumns="False" BackColor="White" BorderColor="#93BEE2">
										<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
										<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
										<AlternatingItemStyle Font-Size="X-Small" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle" BackColor="#337FB2"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="AssetType"></asp:BoundColumn>
											<asp:BoundColumn DataField="SubjectName" HeaderText="項目名称"></asp:BoundColumn>
											<asp:BoundColumn DataField="InventoryName" HeaderText="物品名称"></asp:BoundColumn>
											<asp:BoundColumn DataField="InvType" HeaderText="仕様"></asp:BoundColumn>
											<asp:BoundColumn DataField="UnitName" HeaderText="単位"></asp:BoundColumn>
											<asp:BoundColumn DataField="Number" HeaderText="数量" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="currTypeCode" HeaderText="通貨"></asp:BoundColumn>
											<asp:BoundColumn DataField="exchangeRate" HeaderText="為替レート" DataFormatString="{0:N3}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="originalcurrPrice" HeaderText="価格" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbPrice" HeaderText="RMB単価" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RmbMoney" HeaderText="Rmb总价" DataFormatString="{0:N2}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Offer" HeaderText="仕入先"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="下一页" PrevPageText="上一页"></PagerStyle>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><A onclick="javascript:showDisplay('postail')" href="javascript:void(0)" style="Z-INDEX: 0">審査意見</A></td>
				</tr>
				<tr style="DISPLAY: none; HEIGHT: 28px" id="postail">
					<td style="WIDTH: 100%" colSpan="6" align="center"><FONT face="宋体"><asp:datagrid style="Z-INDEX: 0" id="dgPostail" runat="server" Width="100%" AutoGenerateColumns="False"
								BackColor="White" BorderColor="#93BEE2">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="13px" HorizontalAlign="Center" BackColor="#E8F4FF"></AlternatingItemStyle>
								<ItemStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="13px" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
									BackColor="#337FB2"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="Name" HeaderText="審批者">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Checkdate" HeaderText="審批日時">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IsAgree" HeaderText="審批類型">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CheckComment" HeaderText="審査意見">
										<HeaderStyle Width="50%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
							</asp:datagrid></FONT></td>
				</tr>
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center"><A onclick="javascript:showDisplay('AnnexInfo')" href="javascript:void(0)" style="Z-INDEX: 0">添付ファイル(<%=NumOfAnnex%>)</A>&nbsp;
					</td>
				</tr>
				<tr style="DISPLAY: none; HEIGHT: 28px" id="AnnexInfo">
					<td style="WIDTH: 100%" colSpan="6" align="center"><FONT face="宋体"><asp:table id="tbAnnex" runat="server" Width="100%" Font-Size="12px"></asp:table></FONT></td>
				</tr>
				<!--<tr style="HEIGHT: 22px; BACKGROUND-COLOR: #e8f4ff">
					<td style="WIDTH: 19.67%" align="center">批阅人</td>
					<td style="WIDTH: 20%" align="center">批阅时间</td>
					<td style="WIDTH: 10%" align="center">批阅类型</td>
					<td style="WIDTH: 50%" align="left" colspan="3">批阅内容</td>
				</tr>
				<tr style="HEIGHT: 22px">
					<td style="WIDTH: 19.67%" align="center"><FONT face="宋体">zyq</FONT></td>
					<td style="WIDTH: 20%" align="center"><FONT face="宋体">审核后立即更新此记录</FONT></td>
					<td style="WIDTH: 10%" align="center"><FONT face="宋体">tongyi/fandui</FONT></td>
					<td style="WIDTH: 50%" align="left" colspan="3"><FONT face="宋体">这次买的东西太多！</FONT></td>
				</tr>-->
				<tr style="HEIGHT: 28px">
					<td style="WIDTH: 100%" background="../../Style/Images/treetopbg.jpg" colSpan="6" align="center">審査意見</td>
				</tr>
				<tr>
					<td style="WIDTH: 17.21%" vAlign="top" align="right">審査意見:</td>
					<td colSpan="5" align="left"><asp:textbox id="txtPosital" runat="server" Width="70%" TextMode="MultiLine" Height="100px" Rows="8"
							Columns="100"></asp:textbox></td>
				</tr>
				<tr>
					<td style="WIDTH: 17.21%" align="right"><FONT face="宋体"></FONT></td>
					<td colSpan="5" align="left"><FONT face="宋体"><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></FONT></td>
				</tr>
				<tr style="HEIGHT: 22px" align="center">
					<td colSpan="6"><asp:button id="btnAgree" runat="server" Width="72px" Text="同意" CssClass="redButtonCss"></asp:button><asp:button id="btnRefuse" runat="server" Width="72px" Text="拒否" CssClass="redButtonCss"></asp:button><asp:button id="btnGoBack" runat="server" Width="72px" Text="戻り" CssClass="redButtonCss"></asp:button></td>
				</tr>
				<tr>
					<td height="32" colSpan="6" align="left"><FONT face="宋体"></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
