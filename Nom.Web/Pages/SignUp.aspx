<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Nom.Web.Pages.SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sign Up</title>
</head>
<body>
	<form id="form1" runat="server">
	<h1>Nom</h1>
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
	</form>
</body>
</html>
