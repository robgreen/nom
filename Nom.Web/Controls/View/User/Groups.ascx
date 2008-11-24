<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Groups.ascx.cs" Inherits="Nom.Web.Controls.View.User.Groups" %>
<div id="groups">
	<h3>Groups</h3>
	<asp:Repeater ID="rptGroups" runat="server">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<ItemTemplate>
				<li>
					<span class="title"><asp:Literal ID="litTitle" runat="server" /></span>
				</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<asp:PlaceHolder ID="plhNoGroups" Visible="false" runat="server">
	<p><asp:Literal ID="litUserFirstName" runat="server" /> isn't part of any groups, why not invite them to your group?</p>
	</asp:PlaceHolder>
</div>