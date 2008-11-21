Nom.Geo = {
	Objects: {
		LatLonPair: function() {
			this.Lat = 0;
			this.Lng = 0;
		}
	},
	Resources: {
		GoogleLS: new GlocalSearch(),
		LastQuery: null
	},
	FindLatLonPair:	function(postCode, callBack) {
		Nom.Geo.Resources.GoogleLS.setSearchCompleteCallback(null, function() {
			if (Nom.Geo.Resources.GoogleLS.results[0]) {		
				Nom.Geo.LastQuery = new Nom.Geo.Objects.LatLonPair();
				Nom.Geo.LastQuery.Lat = Nom.Geo.Resources.GoogleLS.results[0].lat;
				Nom.Geo.LastQuery.Lng = Nom.Geo.Resources.GoogleLS.results[0].lng;

				if (callBack != null)
					callBack();
			}
		});	
				
		Nom.Geo.Resources.GoogleLS.execute(postCode + ", UK");
	}
}