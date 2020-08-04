<%@ Page language="c#" Codebehind="WebForm2.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.WebForm2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="Style/JS/CheckAll.js" type="text/javascript"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 192px; POSITION: absolute; TOP: 152px"
					runat="server">
					<Columns>
						<asp:TemplateColumn>
							<HeaderTemplate>
								<asp:CheckBox id="CheckBox1" runat="server" OnCheckedChanged="check" AutoPostBack="false"></asp:CheckBox>
							</HeaderTemplate>
							<ItemTemplate>
								<asp:CheckBox id=Check5 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
								</asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
				<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 192px; POSITION: absolute; TOP: 112px" runat="server"
					Text="绑定" Width="96px"></asp:Button>
				<asp:Button id="Button2" style="Z-INDEX: 103; LEFT: 520px; POSITION: absolute; TOP: 104px" runat="server"
					Text="取选中行的值" Width="104px"></asp:Button>
				<asp:TextBox id="TextBox1" style="Z-INDEX: 104; LEFT: 528px; POSITION: absolute; TOP: 160px"
					runat="server" Width="408px" Height="120px"></asp:TextBox>
				<asp:Button id="Button3" style="Z-INDEX: 105; LEFT: 664px; POSITION: absolute; TOP: 104px" runat="server"
					Text="JS取选中行的值" Width="112px"></asp:Button><INPUT id="hd_Msn_Name_And_Mail" style="Z-INDEX: 106; LEFT: 264px; POSITION: absolute; TOP: 40px"
					type="hidden" runat="server"><INPUT style="Z-INDEX: 107; LEFT: 520px; POSITION: absolute; TOP: 64px" type="button" value="Button"
					onclick="checkall('Form1')"> <INPUT style="Z-INDEX: 108; LEFT: 488px; POSITION: absolute; TOP: 24px" type="checkbox"
					id="aaa" onclick="checkReserve('Form1')"> </FONT>
		</form>
	</body>
</HTML>
