<%@ Page AutoEventWireup="false" Inherits="XpGridFrame.Reports.xpGridReport" enableViewState="False" %>
<HTML>
	<HEAD>
		<title>���������</title>
		<META http-equiv="Content-Type" content="text/html; charset=gb2312">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY scroll="no" onload="divTag.style.display='none';">
		<div id="divTag" style="LEFT: 0px; POSITION: relative">����װ�ر�����......</div>
		<form id="xpGridReport" method="post" runat="server" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; CLIP: rect(0px 0px 0px 0px); PADDING-TOP: 0px">
			<div runat="server" id="divExcel"><object classid="clsid:0002E551-0000-0000-C000-000000000046" codebase="http://download.microsoft.com/download/e/7/9/e7994ca9-3a9e-4a55-810f-75e4774c4f21/owc10.exe"
					id="Spreadsheet1" VIEWASTEXT>
					<%=xmlData%>
				</object>
			</div>
			<script language="vbscript">
Sub Spreadsheet1_BeforeContextMenu(x, y, Menu, Cancel)

   Cancel.Value = true

End Sub
			</script>
			<!--<input type=button onclick="xpGridReport.Spreadsheet1.Printing.PrintPreview();" value="print">-->
			&nbsp; &nbsp; &nbsp; &nbsp; <input type="button" onclick="window.print();" value="��ӡ">
			&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <input type="button" onclick="xpGridReport.Spreadsheet1.Printing.PrintPreview();" value="����Excel">
			<!--<div align=center>�����ɱ����������ƺ����ɣ������ر���������󱾵ز��ԣ�<a href="/XpGridFrame.rar">�����������ر��������</a></div>-->
			<TABLE style="WIDTH: 100%; HEIGHT: 22px">
				<TR>
					<td>&nbsp;&nbsp;
						<asp:LinkButton id="lnkRefresh" runat="server">�������ɱ���</asp:LinkButton>
					</td>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
