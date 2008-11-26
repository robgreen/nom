<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentVenues.ascx.cs" Inherits="Nom.Web.Controls.View.RecentVenues" %>
<div id="recentVenues">
	<h3>Recent noms</h3>
	<asp:Repeater ID="rptRecentVenues" runat="server">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<ItemTemplate>
				<li>
					<span class="title"><asp:HyperLink ID="hypVenueProfile" runat="server"><asp:Literal ID="litTitle" runat="server" /></asp:HyperLink></span>
				</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<asp:PlaceHolder ID="plhNoRecentVenues" Visible="false" runat="server">
	<p><asp:Literal ID="litUserFirstName" runat="server" /> hasn't been for nom yet, why not invite them to your group?</p>
	</asp:PlaceHolder>
</div>