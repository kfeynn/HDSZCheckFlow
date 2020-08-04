<%@ Page language="c#" Codebehind="WebForm6.aspx.cs" AutoEventWireup="false" Inherits="HDSZCheckFlow.UI.WebForm6" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm6</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<script type="text/javascript" src="Style/JS/jquery.min.js"></script>
		<script type="text/javascript">
		
		        $(function() {
					$("#btnOK").click(function() {
						$.post("AppSystem/SysPage/Service1.asmx/HelloWorld",
									{
										i: "100",
										a: "aadfsaf"
									},
									function(data, status) {
										alert("Data: " + data.text + "\nStatus: " + status);
									});
					});
				});


			
		</script>
		
		<script>
		
		function getServerTime()
		{
		
			alert('a');
			var request = new Sys.Net.WebRequest();

			request.set_url('AppSystem/SysPage/Service1.asmx/HelloWorld');
			request.set_httpVerb('POST');
			request.add_completed(onGetServerTimeComplete);
			request.invoke()

			$get('divTime').innerHTML = '';
		}

		function onGetServerTimeComplete(executor, eventArgs)
		{
			if (executor.get_responseAvailable())
			{
				$get('divTime').innerHTML = executor.get_xml().documentElement.firstChild.nodeValue;
			}
		}


		</script>
		
		
		
		
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌו"></FONT>   <a href="WebForm7.aspx">aaaaaa</a>  <a href="#" id = "btnOK"  >AJAX TEST</a><br />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
&nbsp;<div id= "divTime"></div> 
		</form>
	</body>
</HTML>
