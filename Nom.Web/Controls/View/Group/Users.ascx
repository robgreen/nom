<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Users.ascx.cs" Inherits="Nom.Web.Controls.View.Group.Users" %>
<div id="users">
	<h3>Users</h3>
	<asp:Repeater ID="rptUsers" runat="server">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<ItemTemplate>
				<li>
					<span class="title"><asp:HyperLink ID="hypUserProfile" runat="server"><asp:Literal ID="litTitle" runat="server" /></asp:HyperLink> <span class="wlIcon"><asp:Image ID="imgWLIcon" runat="server" /></span></span>
				</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>