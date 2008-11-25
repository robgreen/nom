<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master" CodeBehind="GroupView.aspx.cs" Inherits="Nom.Web.Pages.View.GroupView" %>
<%@ Register Src="~/Controls/View/Group/Users.ascx" TagPrefix="Nom" TagName="Users" %>
<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2><asp:Literal ID="litTitle" runat="server" /></h2>
	<Nom:Users ID="ctrlUsers" runat="server" />
</asp:Content>