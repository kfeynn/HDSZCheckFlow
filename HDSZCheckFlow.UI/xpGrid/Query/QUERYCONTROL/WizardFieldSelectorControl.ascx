<%@ Control Language="c#" AutoEventWireup="false" Inherits="XpGridFrame.WebPublic.QueryControl.WizardFieldSelectorControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="lsuc" TagName="FieldSelectorControl" Src="FieldSelectorControl.ascx" %>
<P>
	<FONT face="����">
		<asp:Label id="lblTitle" runat="server" CssClass="xiao" Font-Bold="True">�򵼲���</asp:Label>
	</FONT>
</P>
<P>
	<lsuc:FieldSelectorControl id="ctlFieldSelector" runat="server"></lsuc:FieldSelectorControl></P>
