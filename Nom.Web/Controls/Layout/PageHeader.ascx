<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageHeader.ascx.cs" Inherits="Nom.Web.Controls.Layout.PageHeader" %>
<%@ Register Src="~/Controls/Layout/UserTools.ascx" TagPrefix="Nom" TagName="UserTools" %>
<div class="header">
	<h1>Nom</h1>
	<Nom:UserTools ID="ctrlUserTools" runat="server" />
</div>
