//Context--------------
var global = window.document

var appState = new applicationState()
var objTreeView=null;
var selectedNode=null;
var selectedNodeOldValue=null;
var selectedNodeNavigateurl=null;
var selectedNodeTarget=null;
var mouseDownType=null;

var TableName, DataTextField, DataValueField, ParentField, AppPath//, XmlFile, XslFile

var keydownX;
var keydownY;

function applicationState() 
{
  this.contextMenu = null; 
  this.queryWin=null;
}

function loadContextMenu(apppath, tableName, dataTextField, dataValueField, parentField, xmlFile, xslFile) 
{
	//当点击非重命名文本框内时不还原节点文本，否则还原节点文本（即节点变成不可编辑）
	if(selectedNode!=null)
	{ 
		if(selectedNode.getAttribute("text")!=null && (selectedNode.getAttribute("text")).indexOf("input")>=0 && mouseDownType!="input")
			selectedNode.setAttribute("text",selectedNodeOldValue);
		selectedNode=null;
	}
  var xmlDoc
  var xslDoc
  var contextMenu

    var node=null;
    var nodeIndex=event.treeNodeIndex;
    if(typeof(nodeIndex)=="undefined")
	{
		node=null;
		clean();
		return;
	}
	else
	{ 
		node=event.srcElement.getTreeNode(nodeIndex);
	}
if(node.getAttribute("id") == rootID)
{
	//alert(node.getAttribute("id"));//return;
	//alert(node.getParent());
}

AppPath = apppath;
  //if(apppath != "") 
  //{
    xmlDoc = new ActiveXObject('MSXML2.DOMDocument')
    xmlDoc.async = false;

    xslDoc = new ActiveXObject('MSXML2.DOMDocument')
    xslDoc.async = false;

    xmlDoc.load(apppath+xmlFile);
    xslDoc.load(apppath+xslFile);

    if(appState.contextMenu != null) appState.contextMenu.removeNode(true);
  
    global.body.insertAdjacentHTML("beforeEnd", xmlDoc.documentElement.transformNode(xslDoc));
    contextMenu = global.body.childNodes(global.body.childNodes.length-1);

    contextMenu.style.left = window.event.x;
    contextMenu.style.top = window.event.y;
    
    keydownX=window.event.x;
	keydownY=window.event.y;

    appState.contextMenu = contextMenu;
   
	//if(node) appState.nodeId=node.getAttribute("id");
	selectedNode=node;
	selectedNodeOldValue=selectedNode.getAttribute("text");
	//alert(selectedNode.getAttribute("id"));
	selectedNodeNavigateurl=selectedNode.getAttribute("navigateurl");
	selectedNodeTarget=selectedNode.getAttribute("target");
	objTreeView=event.srcElement;
	TableName = tableName;
	DataTextField = dataTextField;
	DataValueField = dataValueField;
	ParentField = parentField;
	window.event.cancelBubble = true
  //}
}

function loadContextMenuSub(obj) {
  var contextMenu
  var parentMenu

  parentMenu = returnContainer(obj)
  contextMenu = global.all[obj.id + "Sub"]
  contextMenu.style.display = "block";
  contextMenu.style.top = obj.offsetTop + parentMenu.style.pixelTop
  contextMenu.style.left = obj.offsetWidth + parentMenu.style.pixelLeft
  parentMenu.subMenu = contextMenu
}

function contextHighlightRow(obj) {
  var parentMenu
  var subMenu
  var i

  parentMenu = returnContainer(obj)

  if(obj.selected == "false") {
    for(i=0; i < obj.childNodes.length; i++) {
      obj.childNodes(i).style.borderTop = "1px solid white"
      obj.childNodes(i).style.borderBottom = "1px solid white"

      if(obj.childNodes(i).cellIndex == 0) {
        obj.childNodes(i).style.borderLeft = "1px solid white"
      }
      else if (obj.childNodes(i).cellIndex == obj.cells.length-1) {
        obj.childNodes(i).style.borderRight = "1px solid white"
      }
    }

    if(parentMenu.subMenu != null && parentMenu != parentMenu.subMenu) {
      subMenu = parentMenu.subMenu

      while(subMenu != null) {
        subMenu.style.display = "none";
        subMenu = subMenu.subMenu
      }
    }
    obj.selected = "true";
  }
  else {
    for(i=0; i < obj.childNodes.length; i++) {
      if(i == 0) {
        obj.childNodes(i).style.borderTop = "1px solid " + obj.titlebar
        obj.childNodes(i).style.borderBottom = "1px solid " + obj.titlebar
      }
      else {
        obj.childNodes(i).style.borderTop = "1px solid " + obj.background
        obj.childNodes(i).style.borderBottom = "1px solid " + obj.background
      }
      
      if(obj.childNodes(i).cellIndex == 0) {
        obj.childNodes(i).style.borderLeft = "1px solid " + obj.titlebar
      }
      else if (obj.childNodes(i).cellIndex == obj.cells.length-1) {
        obj.childNodes(i).style.borderRight = "1px solid " + obj.background
      }
    }
    obj.selected = "false";
  }
}

function returnContainer(container) {
  while(container.tagName != "DIV") {
    container = container.parentNode  
  }
  return container
}
function clean() 
{
	var contextMenu

	// remove and destroy context menu
	if(appState.contextMenu != null) 
	{
	contextMenu = appState.contextMenu.removeNode(true)
	contextMenu = null
	}
	
		// remove and destroy query window
		if(appState.queryWin != null) 
		{
			queryWin = appState.queryWin.removeNode(true)
			queryWin = null
		}
	
	//当点击非重命名文本框内时不还原节点文本，否则还原节点文本（即节点变成不可编辑）
	if(selectedNode!=null)
	{ 
		if(selectedNode.getAttribute("text")!=null && (selectedNode.getAttribute("text")).indexOf("input")>=0 && mouseDownType!="input")
			selectedNode.setAttribute("text",selectedNodeOldValue);
	}
	
}

function GetLevelDefine(node)
{
	if(node.getParent() != null)
		return GetLevelDefine(node.getParent());
	else
	{
	//alert(node.getAttribute("text"));
		return node.getAttribute("NodeData");
	}
}

//-----------------
function AddEquiNode()
{
	var id=selectedNode.getAttribute("id");
	var parentNode=selectedNode.getParent();
	if(parentNode == null)//是根节点
		return;
	if(parentNode==null) parentNode=objTreeView;
	var newNode = objTreeView.createTreeNode();
	var ret = window.showModalDialog(AppPath+'/xpGrid/TreeViewEdit.aspx?tid=' + TableName + '&nid=' + DataTextField + '&cid=' + DataValueField + '&type=1&pid=' + ParentField + '&pvalue=' + parentNode.getAttribute("id") + '&level='+GetLevelDefine(selectedNode), window, "dialogWidth: 350px; dialogHeight: 300px;status:no");
    if(ret == null || ret == "")
		return;
    newNode.setAttribute("text", ret.substr(ret.indexOf("|") + 1));
    newNode.setAttribute("id", ret.substr(0, ret.indexOf("|")));
    newNode.setAttribute("NodeData", ret.substr(0, ret.indexOf("|")));
    parentNode.add(newNode);
    
	selectedNodeOldValue=ret.substr(ret.indexOf("|") + 1);
    selectedNode=newNode;   
    //RenameNode();
}
function AddSubNode()
{
	var parentNode=selectedNode;
	//var newid=getNewId(parentNode);
	//alert(selectedNode.getAttribute("NodeData"));
	var newNode = objTreeView.createTreeNode();
	var ret = window.showModalDialog(AppPath+'/xpGrid/TreeViewEdit.aspx?tid=' + TableName + '&nid=' + DataTextField + '&cid=' + DataValueField + '&type=3&pid=' + ParentField + '&pvalue=' + parentNode.getAttribute("id") + '&level='+GetLevelDefine(selectedNode), window, "dialogWidth: 350px; dialogHeight: 300px;status:no");
    if(ret == null || ret == "")
		return;
    newNode.setAttribute("text", ret.substr(ret.indexOf("|") + 1));
    newNode.setAttribute("id", ret.substr(0, ret.indexOf("|")));
    newNode.setAttribute("NodeData", ret.substr(0, ret.indexOf("|")));
    parentNode.add(newNode);
    
    parentNode.setAttribute("expanded", true);
	selectedNodeOldValue=ret.substr(ret.indexOf("|") + 1);
    selectedNode=newNode;   
    //RenameNode();
}

function RenameNode()
{
	var sizeUnit=12;//为12px
	var nodeText=selectedNode.getAttribute("text");
	var size=LenOf(nodeText)*(sizeUnit/2)+20;
	objTreeView.selectedNodeIndex=selectedNode.getNodeIndex();
		var ret = window.showModalDialog(AppPath+'/xpGrid/TreeViewEdit.aspx?tid=' + TableName + '&nid=' + DataTextField + '&cid=' + DataValueField + '&type=2&pid=' + ParentField + '&pvalue=' + selectedNode.getAttribute("id") + '&level='+GetLevelDefine(selectedNode), window, "dialogWidth: 350px; dialogHeight: 300px;status:no");
    if(ret == null || ret == "")
		return;
	selectedNode.setAttribute("text", ret.substr(ret.indexOf("|") + 1));
    selectedNode.setAttribute("id", ret.substr(0, ret.indexOf("|")));
    selectedNode.setAttribute("NodeData", ret.substr(0, ret.indexOf("|")));
	selectedNodeOldValue=ret.substr(ret.indexOf("|") + 1);
}
function DeleteNode()
{
	if(!confirm("确定删除节点 ["+selectedNode.getAttribute("text")+"] 吗？")) return;
	var id=selectedNode.getAttribute("id");	
	if(selectedNode.getChildren().length > 0)
	{
		alert("请先删除子节点！");
		return;
	}
	var ret = window.showModalDialog(AppPath+'/xpGrid/TreeViewEdit.aspx?tid=' + TableName + '&nid=' + DataTextField + '&cid=' + DataValueField + '&type=4&pid=' + ParentField + '&pvalue=' + selectedNode.getAttribute("id") + '&level='+GetLevelDefine(selectedNode), window, "dialogWidth: 350px; dialogHeight: 300px;status:no");
	if(ret == 1)
	{
		selectedNode.remove();
	}
	selectedNode = selectedNode.getParent();
}

function getNodeSibIndex()
{
	var parentNode=selectedNode.getParent();	
	if(parentNode==null) parentNode=objTreeView;
	var nodes=parentNode.getChildren();	
	for(i=0;i<nodes.length;i++)
	{
		if(nodes[i].getNodeIndex()==selectedNode.getNodeIndex())
		{
			return i;
		}
	}
	return 0;
	
}

//-----------------
function document.oncontextmenu()
{
	clean();
	return false;
}
//验证字符串(包含汉字)有多少个字符长
function LenOf(str)
{
	str = str + 'a';
	var str1 = str.match(/[\x00-\xff]/g).length;
	return ((str.length-str1)*2+str1-1);
}

//去掉字串左边的空格
function lTrim(str)
{
	if (str.charAt(0) == " ")
	{
		str = str.slice(1);//将空格从字串中去掉	
		str = lTrim(str); //递归调用
	}
	return str;
}
//去掉字串右边的空格
function rTrim(str)
{
	var iLength;
	iLength = str.length;
	if (str.charAt(iLength - 1) == " ")
	{
		str = str.slice(0, iLength - 1);//将空格从字串中去掉		
		str = rTrim(str); //递归调用
	}
	return str;
}
//去掉字串两边的空格
function Trim(str)
{
	return lTrim(rTrim(str));
}

// 选中父节点自动选中子节点
