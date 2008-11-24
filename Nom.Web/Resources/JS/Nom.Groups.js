Nom.Groups = {
	Init: function() {
		$(function() {
			GeoLookupInit();
		});
	},
	GeoLookupInit: function() {
		var postCodes = $("#txtPostalCode");
		var postCode;
		
		if (postCodes.length > 0)
		{
			postCode = postCodes[0];
			$(postCode).keyup(function() {
				if (this.value.length > 2)
					Nom.Groups.GeoLookupCall();
			});
		}
	},
	GeoLookupCall: function() {
		var postCode = $("#txtPostalCode")[0];
		if (postCode != null)
		{
			Nom.Geo.FindLatLonPair(postCode.value, Nom.Groups.GeoLookupCallBack);
		}
	},
	GeoLookupCallBack: function() {
		if (Nom.Geo.LastQuery != null)
		{
			var txtLat = $("#hdnLat")[0];
			if (txtLat != null)
				txtLat.value = Nom.Geo.LastQuery.Lat;

			var txtLng = $("#hdnLng")[0];
			if (txtLng != null)
				txtLng.value = Nom.Geo.LastQuery.Lng;
		}
	}
}

Nom.Groups.Init();