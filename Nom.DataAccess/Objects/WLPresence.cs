using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Nom.DataAccess.Objects
{
	public class WLPresence
	{
		#region Private Properties
		private string _displayName;
		private WLPresenceIcon _icon;
		private string _id; 
		private string _status;
		private string _statusText;
		#endregion

		#region Public Properties
		public string DisplayName
		{
			get { return _displayName; }
		}
		public WLPresenceIcon Icon
		{
			get { return _icon; }
		}
		public string ID
		{
			get { return _id; }
		}
		public string Status
		{
			get { return _status; }
		}
		public string StatusText
		{
			get { return _statusText; }
		}
		#endregion

		#region Constructor
		public WLPresence()
		{
		}
		public WLPresence(HttpWebResponse hwResponse)
		{
			TextReader tr = new StreamReader(hwResponse.GetResponseStream());
			JsonReader jr = new JsonTextReader(tr);

			while (jr.Read())
			{
				if (jr.TokenType == JsonToken.PropertyName)
				{
					if (jr.Value.ToString() == "displayName")
					{
						jr.Read();
						_displayName = jr.Value.ToString();
					}
					else if (jr.Value.ToString() == "id")
					{
						jr.Read();
						_id = jr.Value.ToString();
					}
					else if (jr.Value.ToString() == "status")
					{
						jr.Read();
						_status = jr.Value.ToString();
					}
					else if (jr.Value.ToString() == "statusText")
					{
						jr.Read();
						_statusText = jr.Value.ToString();
					}
					else if (jr.Value.ToString() == "height")
					{
						jr.Read();
						_icon.Height = int.Parse(jr.Value.ToString());
					}
					else if (jr.Value.ToString() == "url")
					{
						jr.Read();
						_icon.URL = jr.Value.ToString();
					}
					else if (jr.Value.ToString() == "width")
					{
						jr.Read();
						_icon.Width = int.Parse(jr.Value.ToString());
					}
				}
			}
		}
		#endregion

		#region Internal Classes
		public struct WLPresenceIcon
		{
			public int Height { get; set; }
			public string URL { get; set; }
			public int Width { get; set; }
		}
		#endregion
	}
}
