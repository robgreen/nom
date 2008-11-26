<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Nom.Master"CodeBehind="CacheStats.aspx.cs" Inherits="Nom.Web.Tests.CacheStats" %>

<asp:Content ContentPlaceHolderID="cphContent" runat="server">
	<h2>Cache Statistics</h2>
	<asp:Repeater ID="rptCacheStats" OnItemDataBound="rptCacheStats_ItemDataBound" runat="server">
		<ItemTemplate>
			<h3><asp:Literal ID="litTitle" runat="server" /></h3>
			<ul>
				<li>Hits: <asp:Literal ID="litHits" runat="server" /></li>
				<li>Misses: <asp:Literal ID="litMisses" runat="server" /></li>
				<li><strong>Hit rate</strong>: <asp:Literal ID="litHitRate" runat="server" /></li>
			</ul>
		</ItemTemplate>
	</asp:Repeater>
</asp:Content>