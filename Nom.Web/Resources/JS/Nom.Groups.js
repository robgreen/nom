Nom.Groups = {
	GeoLookupCall: function() {
		var postCode = document.getElementById("txtPostalCode");
		if (postCode != null)
		{
			Nom.Geo.FindLatLonPair(postCode.value, Nom.Groups.GeoLookupCallBack);
		}
	},
	GeoLookupCallBack: function() {
		if (Nom.Geo.LastQuery != null)
		{
			var txtLat = document.getElementById("hdnLat");
			if (txtLat != null) txtLat.value = Nom.Geo.LastQuery.Lat;

			var txtLng = document.getElementById("hdnLng");
			if (txtLng != null) txtLng.value = Nom.Geo.LastQuery.Lng;
		}
	}
}