<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master" CodeBehind="CreateGroup.aspx.cs" Inherits="Nom.Web.Pages.CreateGroup" %>

<asp:Content ContentPlaceHolderID="cphHead" runat="server">
	<script type="text/javascript" src="/Resources/JS/Nom.Geo.js"></script>
	<script type="text/javascript" src="/Resources/JS/Nom.Groups.js"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2>Create Group</h2>
	<asp:HiddenField ID="hdnLat" runat="server" />
	<asp:HiddenField ID="hdnLng" runat="server" />
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
</asp:Content>