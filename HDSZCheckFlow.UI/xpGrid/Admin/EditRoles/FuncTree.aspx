<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page language="c#" AutoEventWireup="false" Inherits="XpGridFrame.Admin.EditRoles.FuncTree" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FuncTree</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="JavaScript" src="../../JsLib/MyScript.js"></SCRIPT>
	</HEAD>
	<body onmousemove="SetState();" onmousedown="SetState();" onkeydown="setenter();" onselectstart="NoSelect();"
		oncontextmenu="NoRightMenu();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" onsubmit="document.getElementById('hidTreeCheck').value='';CollectCheck(trvFuncTree.getTreeNode('0'));">
			<FONT face="宋体"></FONT><INPUT id="hidTreeCheck" style="Z-INDEX: 102; POSITION: absolute; TOP: 472px; LEFT: 200px"
				type="hidden" name="hidTreeCheck">
			<asp:Button CssClass="InputButton" ID="btnSave" Runat="server" Text="保存" style="Z-INDEX: 101; POSITION: absolute; TOP: 40px; LEFT: 240px"></asp:Button>
			<iewc:TreeView id="trvFuncTree" runat="server" AutoSelect="True" ExpandLevel="3" SelectExpands="True"
				style="Z-INDEX: 103; POSITION: absolute; TOP: 72px; LEFT: 104px" Height="460px" Width="250px"></iewc:TreeView>
			<asp:Label id="Label4" style="Z-INDEX: 105; POSITION: absolute; TOP: 40px; LEFT: 136px" runat="server"
				CssClass="Title" Width="72px" Height="8px">功能授权</asp:Label>
			<script language="javascript">
				<!--
				function trvFuncTree.oncheck()
				{
					checkChild(this.getTreeNode(this.clickedNodeIndex),this.getTreeNode(this.clickedNodeIndex).getAttribute('Checked'));
					//alert(this.getTreeNode(this.clickedNodeIndex).getAttribute('Checked'));
					checkParent(this.getTreeNode(this.clickedNodeIndex),this.getTreeNode(this.clickedNodeIndex).getAttribute('Checked'));
					this.queueEvent('oncheck', this.getTreeNode(this.clickedNodeIndex).getNodeIndex());
				}
				function checkParent(node,chk) 
				{
					// 选中父节点
					var parentNode = node.getParent();
					if(parentNode != null)
					{
						// 判断父节点下面是否有选中的节点
						var b = false;
						var NodeArray = new Array();
						NodeArray = parentNode.getChildren();
						var len = NodeArray.length;
						for(var i = 0; i < len; i++)
						{
							if(NodeArray[i].getAttribute('Checked') == true)
								b = true;
						}
						if(parentNode.getAttribute('Checked') != b)
						{
							parentNode.setAttribute('Checked',b);
				//alert("parnt:"+parentNode.getAttribute('text') + "\r\n" + parentNode.getAttribute('Checked') + b);
							trvFuncTree.queueEvent('oncheck', parentNode.getNodeIndex()); 
						}
						checkParent(parentNode, chk);
					}
				}
				function checkChild(node,chk)
				{
					// 开始选中下级
					var NodeArray = new Array();
					NodeArray = node.getChildren();
					var len = NodeArray.length;
					for(var i = 0; i < len; i++)
					{
				//alert(NodeArray[i].getAttribute('Checked'));
				//alert(chk);
						if(NodeArray[i].getAttribute('Checked') != chk)
						{
							NodeArray[i].setAttribute('Checked',chk);
							trvFuncTree.queueEvent('oncheck', NodeArray[i].getNodeIndex()); 
						}
						checkChild(NodeArray[i], chk);
					}
				}
				function CollectCheck(node)
				{
					// 开始选中下级
					var NodeArray = new Array();
					NodeArray = node.getChildren();
					var len = NodeArray.length;
					for(var i = 0; i < len; i++)
					{
						if(NodeArray[i].getAttribute('Checked') == true)
						{
							document.getElementById('hidTreeCheck').value += NodeArray[i].getAttribute("NodeData") + ","
						}
						CollectCheck(NodeArray[i]);
					}
				}
				function InitTree(node, nodeList)
				{
					// 开始选中下级
					var NodeArray = new Array();
					NodeArray = node.getChildren();
					var len = NodeArray.length;
					//alert(len);
					for(var i = 0; i < len; i++)
					{
						if(nodeList.indexOf("," + NodeArray[i].getAttribute('NodeData') + ",") >= 0 && NodeArray[i].getAttribute('Checked') == false)
						{
							NodeArray[i].setAttribute('Checked', true);
							trvFuncTree.queueEvent('oncheck', NodeArray[i].getNodeIndex()); 
						}
						InitTree(NodeArray[i], nodeList);
					}
				}
				//-->
			</script>
			<img src="../../../AppSystem/Images/gradtop.jpg" border="0" style="Z-INDEX:999;POSITION:absolute;BORDER-BOTTOM-STYLE:none;BORDER-RIGHT-STYLE:none;WIDTH:250px;BORDER-TOP-STYLE:none;HEIGHT:7px;BORDER-LEFT-STYLE:none;TOP:8px;LEFT:10px">
			<img src="../../../AppSystem/Images/gradleft.jpg" style="Z-INDEX:998;POSITION:absolute;BORDER-BOTTOM-STYLE:none;BORDER-RIGHT-STYLE:none;WIDTH:7px;BORDER-TOP-STYLE:none;HEIGHT:500px;BORDER-LEFT-STYLE:none;TOP:8px;LEFT:7px">
		</form>
	</body>
</HTML>
