<%@ Page language="c#" Codebehind="WebForm7.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.WebForm7" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm7</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="Style/JS/jquery.min.js"></script>
		<script>
			$(function() {     
		$("#btnOK").click(function() {     
			$.ajax({     
				//要用post方式     
				type: "Post",     
				//方法所在页面和方法名     
				url: "WebForm7.aspx/SayHello",     
				contentType: "application/json; charset=utf-8",     
				dataType: "json",     
				success: function(data) {     
					//返回的数据用data.d获取内容     
					alert('aaa');
					alert(data.d);     
				},     
				error: function(err) {     
					alert(err);     
				}     
			});     
	    
			//禁用按钮的提交     
			return false;     
		});     
	});   
			
		</script>
		<style type="text/css">TD { BORDER-BOTTOM: #cccccc 1px solid }
	.EditCell_TextBox { BORDER-BOTTOM: #0099cc 1px solid; BORDER-LEFT: #0099cc 1px solid; WIDTH: 90%; BORDER-TOP: #0099cc 1px solid; BORDER-RIGHT: #0099cc 1px solid }
	.EditCell_DropDownList { WIDTH: 90% }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<a id="btnOK" href="#">aaa</a> <FONT face="宋体">
				<asp:label style="Z-INDEX: 101; POSITION: absolute; TOP: 152px; LEFT: 160px" id="Label1" runat="server"
					Width="272px">可点击编辑的DataGrid</asp:label><asp:datagrid style="Z-INDEX: 102; POSITION: absolute; TOP: 232px; LEFT: 16px" id="DataGrid1"
					runat="server" Width="912px" AutoGenerateColumns="False">
					<Columns>
						<asp:BoundColumn DataField="ID" HeaderText="ID"></asp:BoundColumn>
						<asp:BoundColumn DataField="Thread" HeaderText="Thread"></asp:BoundColumn>
						<asp:BoundColumn DataField="Level" HeaderText="Level"></asp:BoundColumn>
					</Columns>
				</asp:datagrid><asp:button style="Z-INDEX: 103; POSITION: absolute; TOP: 144px; LEFT: 672px" id="Button1" runat="server"
					Text="获取编辑后的值"></asp:button></FONT>
			<table id="tabProduct" border="0" cellSpacing="0" cellPadding="0" width="698">
				<tr>
					<td bgColor="#efefef" width="32" align="center" Name="Num"><input value="checkbox" type="checkbox" name="checkbox"></td>
					<td bgColor="#efefef" width="186" Name="Num" EditType="TextBox">序号</td>
					<td bgColor="#efefef" width="152" Name="ProductName" EditType="DropDownList" DataItems="{text:'A',value:'a'},{text:'B',value:'b'},{text:'C',value:'c'},{text:'D',value:'d'}">商品名称</td>
					<td bgColor="#efefef" width="103" Name="Amount" EditType="TextBox">数量</td>
					<td bgColor="#efefef" width="103" Name="Price" EditType="TextBox">单价</td>
					<td bgColor="#efefef" width="120" Name="SumMoney" Format="#,###.00" Expression="Amount*Price">合计</td>
				</tr>
				<tr>
					<td bgColor="#ffffff" align="center"><input value="checkbox" type="checkbox" name="checkbox2"></td>
					<td bgColor="#ffffff">1</td>
					<td bgColor="#ffffff" Value="c">C</td>
					<td bgColor="#ffffff">0</td>
					<td bgColor="#ffffff">0</td>
					<td bgColor="#ffffff">0</td>
				</tr>
				<tr>
					<td bgColor="#ffffff" align="center"><input value="checkbox" type="checkbox" name="checkbox22"></td>
					<td bgColor="#ffffff">2</td>
					<td bgColor="#ffffff" Value="d">D</td>
					<td bgColor="#ffffff">0</td>
					<td bgColor="#ffffff">0</td>
					<td bgColor="#ffffff">0</td>
				</tr>
			</table>
		</form>
		<script type="text/javascript" src="Style/JS/GridEdit.js"></script>
		<script language="javascript">
		
		var tabProduct = document.getElementById("tabProduct");
		
		var tabGrid   = document.getElementById("DataGrid1");
		// 设置表格可编辑
		// 可一次设置多个，例如：EditTables(tb1,tb2,tb2,......)
		EditTables(tabProduct,tabGrid);
		
		/*
		function ShowUserName(useCode)
		{
			//获取姓名
			var userName=HDSZCheckFlow.UI.WebForm7.UpdateValue(useCode.value);
			if(userName.length==0)
			{}
			else
			{
				document.getElementById("lblName").innerText=userName.value;
			}
		}*/

		</script>
	</body>
</HTML>
