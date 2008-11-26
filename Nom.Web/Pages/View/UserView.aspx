<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master" CodeBehind="UserView.aspx.cs" Inherits="Nom.Web.Pages.View.UserView" %>
<%@ Register Src="~/Controls/View/RecentVenues.ascx" TagPrefix="Nom" TagName="RecentVenues" %>
<%@ Register Src="~/Controls/View/User/Groups.ascx" TagPrefix="Nom" TagName="Groups" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2><asp:Literal ID="litTitle" runat="server" /> <span class="wlIcon"><asp:Image ID="imgWLIcon" runat="server" /></span></h2>
	<div class="userJoined">
		<p>Joined <asp:Literal ID="litJoined" runat="server" /></p>
	</div>
	<Nom:RecentVenues ID="ctrlRecentVenues" runat="server" />
	<Nom:Groups ID="ctrlGroups" runat="server" />
</asp:Content>