<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageHeader.ascx.cs" Inherits="Nom.Web.Controls.Layout.PageHeader" %>
<%@ Register Src="~/Controls/Layout/UserTools.ascx" TagPrefix="Nom" TagName="UserTools" %>
<%@ Register Src="~/Controls/Layout/PrimaryNavigation.ascx" TagPrefix="Nom" TagName="PrimaryNavigation" %>
<div id="header">
	<h1><a href="/">Nom</a> <span class="version">pre-alpha</span></h1>
	<Nom:PrimaryNavigation ID="ctrlPrimaryNavigation" runat="server" />
	<Nom:UserTools ID="ctrlUserTools" runat="server" />
</div>
