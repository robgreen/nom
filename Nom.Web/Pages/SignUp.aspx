<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master" CodeBehind="SignUp.aspx.cs" Inherits="Nom.Web.Pages.SignUp" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2>Sign Up</h2>
	<div class="fieldRow">
		<asp:Label ID="lblForename" AssociatedControlID="txtForename" runat="server">Forename:</asp:Label>
		<asp:TextBox ID="txtForename" TextMode="SingleLine" runat="server" />
	</div>
	<div class="fieldRow">
		<asp:Label ID="lblSurname" AssociatedControlID="txtSurname" runat="server">Surname:</asp:Label>
		<asp:TextBox ID="txtSurname" TextMode="SingleLine" runat="server" />
	</div>
	<div class="fieldRow">
		<asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server">Email:</asp:Label>
		<asp:TextBox ID="txtEmail" TextMode="SingleLine" runat="server" />
	</div>
	<div class="fieldRow">
		<asp:Label ID="lblPassword" AssociatedControlID="txtPassword" runat="server">Password:</asp:Label>
		<asp:TextBox ID="txtPassword" TextMode="SingleLine" runat="server" />
	</div>
	<div class="fieldRow">
		<asp:Label ID="lblWLOptIn" AssociatedControlID="chkWLOptIn" runat="server">Receive alerts via Windows Live Messenger:</asp:Label>
		<asp:CheckBox ID="chkWLOptIn" Text="true" runat="server" />
	</div>
	<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Can has me some nom?" runat="server" />
</asp:Content>