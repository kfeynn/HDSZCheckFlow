<%@ Page language="c#" Codebehind="LeftTreeMenuNew.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.AppSystem.SysPage.LeftTreeMenuNew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LeftTreeMenuNew</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../assets/css/dpl-min.css">
		<LINK rel="stylesheet" type="text/css" href="../assets/css/bui-min.css">
		
		<style type="text/css">
		body
		{
			text-align:center;
			font-family:宋体;
			height:90%;
			margin-left: 0px;
			margin-top: 0px;
			margin-right: 0px;
			margin-bottom: 0px;
			width: 100%;
			

			BACKGROUND-COLOR: #F2FBED;
			
			overflow-x:hidden; /*隐藏横向滚动条*/
		
		}
			
		.left-table02 {
			margin-top: 8px;
			margin-bottom: 8px;
			font-family: "宋体";
			font-size: 12px;
			color: #555555;
			text-decoration: none;
		}
		.left-table03 {
			margin-top: 6px;
			font-family: "宋体";
			font-size: 13px;
			color: #555555;
			text-decoration: none;
			background-image: url('../images/ui/nav02.gif');
		}
		.left-table03:hover {
			background-image: url('../images/ui/nav03.gif');
		}
		</style>
		<script type="text/javascript" src="../assets/js/jquery-1.8.1.min.js"></script>		
		<script type="text/javascript" src="../JsLib/Default.js"></script>	
		
		
	</HEAD>
	<body MS_POSITIONING="GridLayout" scroll ="yes" >
	
		<form id="Form1" method="post" runat="server">
			<table style="BORDER-BOTTOM: yellow 0px solid; TEXT-ALIGN: left; BORDER-LEFT: yellow 0px solid; VERTICAL-ALIGN: top; BORDER-TOP: yellow 0px solid; BORDER-RIGHT: yellow 0px solid"
				border="0" cellSpacing="0" cellPadding="0" width="101%">
				<tr>
					<!--头部-->
					<td style="BACKGROUND-IMAGE: url(../images/ui/nav04.gif); BORDER-BOTTOM: #e6f5ff 1px solid; HEIGHT: 30px; VERTICAL-ALIGN: top">
						<table style="WIDTH: 100%; HEIGHT: 100%" id="leftHead" border="0">
							<tr>
								<td style="WIDTH: 20px"><IMG style="PADDING-LEFT: 6px; WIDTH: 14px; HEIGHT: 14px" alt="user" src="../images/ui/grid.png">
								</td>
								<td   vAlign="middle">功能菜单
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<!--功能菜单-->
					<td style="BORDER-BOTTOM: red 0px solid; BORDER-LEFT: red 0px solid; VERTICAL-ALIGN: top; BORDER-TOP: red 0px solid; BORDER-RIGHT: red 0px solid">
						<div style="BORDER-BOTTOM: red 0px solid; BORDER-LEFT: red 0px solid; BORDER-TOP: red 0px solid; BORDER-RIGHT: red 0px solid"
							id="menuDiv"><asp:repeater id="rptParent" runat="server" OnItemDataBound="rptParent_ItemDataBound">
								<ItemTemplate>
									<!--  父类节点    -->
									<table width="100%" border="0" cellpadding="0" cellspacing="0" class="left-table03">
										<tr>
											<td height="20">
												<table id="parentTab" width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
													<tr>
														<td width="8%">
															<img name="img<%# Container.ItemIndex+1 %>" id="img<%# Container.ItemIndex+1 %>" alt="" src="../images/ui/ico04.gif" width="8" height="11" />
														</td>
														<td width="92%">
															<a href="javascript:void(0)" class="left-font03" onclick="list('<%# Container.ItemIndex+1 %>');">
																<%# DataBinder.Eval(Container.DataItem,"FuncName").ToString() %>
															</a>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<!--子类节点-->
									<table id="subtree<%# Container.ItemIndex+1 %>" style="display: none" width="80%" border="0" align="center" cellpadding="0"
										cellspacing="0" class="left-table02"> <!--子类节点-->
										<asp:Repeater ID="rptChildren" runat="server">
											<ItemTemplate>
												<tr>
													<td width="9%" height="23">
														<img id="xiaotu<%# Container.ItemIndex+count+1 %>" alt="" src="../images/ui/ico06.gif" width="8" height="12" />
													</td>
													<td width="91%" id="ChildTD">
														<a href="<%# DataBinder.Eval(Container.DataItem,"FuncUrl") %>" target="RightContent" class="left-font03" onclick="tupian('<%# Container.ItemIndex+count+1 %>');">
															<%# DataBinder.Eval(Container.DataItem,"FuncName").ToString() %>
														</a>
													</td>
												</tr>
											</ItemTemplate>
										</asp:Repeater>
									</table>
								</ItemTemplate>
							</asp:repeater></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
