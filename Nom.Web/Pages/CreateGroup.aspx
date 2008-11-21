<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="Nom.Web.Pages.CreateGroup" %>
<%@ Register TagPrefix="Nom" TagName="Head" Src="~/Controls/Head.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create Group</title>
    <Nom:Head ID="Head" runat="server" />
	<script type="text/javascript" src="/Resources/JS/Nom.Geo.js"></script>
	<script type="text/javascript" src="/Resources/JS/Nom.Groups.js"></script>
</head>
<body>
	<form id="form1" runat="server">
	<asp:HiddenField ID="hdnLat" runat="server" />
	<asp:HiddenField ID="hdnLng" runat="server" />
	<h1>Nom</h1>
	<h2>Create Group</h2>
	<div class="fieldRow">
		<asp:Label ID="lblName" AssociatedControlID="txtName" runat="server">Name:</asp:Label>
		<asp:TextBox ID="txtName" TextMode="SingleLine" runat="server" />
	</div>
	<div class="fieldRow">
		<asp:Label ID="lblProfile" AssociatedControlID="txtProfile" runat="server">Profile:</asp:Label>
		<asp:TextBox ID="txtProfile" TextMode="MultiLine" Rows="10" runat="server" />
	</div>
	<div class="fieldRow">
		<asp:Label ID="lblPostalCode" AssociatedControlID="txtPostalCode" runat="server">Postal Code:</asp:Label>
		<asp:TextBox ID="txtPostalCode" TextMode="SingleLine" runat="server" />
	</div>
	<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Can has me friends to nom with?" runat="server" />
	</form>
</body>
</html>
