<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GMGeoCode.aspx.cs" Inherits="Nom.Web.Tests.GMGeoCode" %>
<%@ Register TagPrefix="Nom" TagName="Head" Src="~/Controls/Head.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Google Maps - GeoCoding Test Page</title>
	<Nom:Head ID="Head" runat="server" />
	<script type="text/javascript" src="/Resources/JS/Nom.Geo.js"></script>
	<script type="text/javascript">
		function test()
		{
			var pcInput = document.getElementById("postcode");
			if (pcInput != null)
			{
				Nom.Geo.FindLatLonPair(pcInput.value);
			}
		}
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<label for="postcode">Post Code:</label>
		<input type="text" id="postcode" />
		<input type="button" value="Google says what?" onclick="test()" />
    </div>
    </form>
</body>
</html>
