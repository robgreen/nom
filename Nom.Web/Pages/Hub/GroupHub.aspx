<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master" CodeBehind="GroupHub.aspx.cs" Inherits="Nom.Web.Pages.Hub.GroupHub" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2>Groups</h2>
	<asp:GridView ID="grdGroups" runat="server" />
</asp:Content>