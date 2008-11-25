<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master" CodeBehind="Login.aspx.cs" Inherits="Nom.Web.Pages.Util.Login" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2>Get your nom on</h2>
	<asp:Panel DefaultButton="btnLogin" ID="pnlLogin" runat="server">
			<fieldset>
				<div class="formRow">
					<asp:Label ID="lblUsername" AssociatedControlID="txtUsername" runat="server">Email</asp:Label>
					<asp:TextBox ID="txtUsername" runat="server" />
				</div>
				<div class="formRow">
					<asp:Label ID="lblPassword" AssociatedControlID="txtPassword" runat="server">Password</asp:Label>
					<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" />
				</div>
			</fieldset>
			<asp:Button id="btnLogin" OnClick="btnLogin_Click" Text="Login" runat="server" />
		</asp:Panel>
</asp:Content>