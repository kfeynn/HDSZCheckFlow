<%@ Page language="c#" Codebehind="AnnexInfoShow.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.BaseData.Commons.AnnexInfoShow" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<base target="_self">
		<title>�������ҳ������������������������������������������������������������������������������������������������������</title>

		<script type="text/javascript">
		    function $(id){ return document.getElementById(id)}
			function block(id) {$(id).style.display="block";}
			function none(id) {$(id).style.display="none";}
		</script>

		<style type="text/css">
			.common
			{
				width: 45px;
				height: 45px;
				display: none;
				margin-top: 300px;
			}
			.style
			{
        		margin-left:90px;
        		margin-bottom:5px;
        		font-family:Adobe ���� Std L;
			}
		</style>
		
		
	</HEAD>
	<body style="width:720px;height:650px;padding-top:10px; background:#e6ecf8;">
		<form id="Form1" method="post" runat="server">
		
			<!--��һ��-->
			<div style="width: 100%; height: 650px;">
				<!--�ڶ��� ����-->
				<div style="text-align:center; font-size:18px;font-family:Adobe ���� Std L;">�����������</div>
				
				
		        <!--�ڶ��� ����-->
				<div class="style">��������<asp:Label Runat="server" ID="lblFileTitle"/></div>
				
		        
		        <!--�ڶ��� ����-->
				<div style="vertical-align: middle; float: left; height: 100%; width: 9%; text-align: right;"
					onmouseover="block('imgbtnPrevious')" onmouseout="none('imgbtnPrevious')">
					<asp:ImageButton ID="imgbtnPrevious" CssClass="common" runat="server" ImageUrl="../../AppSystem/Images/previos-sail1.gif"
						OnClick="imgbtnPrevious_Click" />
				</div>
		        
		        <!--�ڶ��� ����-->
				<div>
					<iframe style="float: left; height: 100%; width: 80%; border-style: double; border-color: Green;"
						id="ifr" frameborder="1" src="<%=ViewState["savePath"]==""?"":ViewState["savePath"] %>">
					</iframe>
				</div>
		        
		        <!--�ڶ��� ����-->
				<div style="float: left; height: 100%; width: 9%; text-align: left;" onmouseover="block('imgbtnNext')"
					onmouseout="none('imgbtnNext')">
					<asp:ImageButton ID="imgbtnNext" CssClass="common" runat="server" ImageUrl="../../AppSystem/Images/next-sail1.gif"
						OnClick="imgbtnNext_Click" />
				</div>��
			</div>
			
		</form>
	</body>
</HTML>
