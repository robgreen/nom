<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupHub.aspx.cs" Inherits="Nom.Web.Pages.Hub.GroupHub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Groups</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<h1>Nom</h1>
		<h2>Groups</h2>
		<asp:GridView ID="grdGroups" runat="server" />
    </div>
    </form>
</body>
</html>
