<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserTools.ascx.cs" Inherits="Nom.Web.Controls.Layout.UserTools" %>
<div id="userTools">
<asp:PlaceHolder ID="plhLoggedIn" runat="server">
	<p><asp:HyperLink ID="hypUserProfile" runat="server"><asp:Literal ID="litUserName" runat="server" /></asp:HyperLink> | <asp:HyperLink ID="hypLogOut" runat="server">Logout</asp:HyperLink></p>
</asp:PlaceHolder>
<asp:PlaceHolder ID="plhLoggedOut" runat="server">
	<p><asp:HyperLink ID="hypLogIn" runat="server">Login</asp:HyperLink> | <asp:HyperLink ID="hypSignUp" runat="server">Sign Up</asp:HyperLink></p>
</asp:PlaceHolder>
</div>