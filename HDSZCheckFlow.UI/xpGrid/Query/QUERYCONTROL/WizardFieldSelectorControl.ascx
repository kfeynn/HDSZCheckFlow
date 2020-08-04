<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.WizardFieldSelectorControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="lsuc" TagName="FieldSelectorControl" Src="FieldSelectorControl.ascx" %>
<P>
	<FONT face="宋体">
		<asp:Label id="lblTitle" runat="server" CssClass="xiao" Font-Bold="True">向导步骤</asp:Label>
	</FONT>
</P>
<P>
	<lsuc:FieldSelectorControl id="ctlFieldSelector" runat="server"></lsuc:FieldSelectorControl></P>
