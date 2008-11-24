using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nom.Common
{
	public class Constants
	{
		public class APIKeys
		{
			public class Google
			{
				public const string Maps = "ABQIAAAAxQvFmNzaQOgPbX7Sz9ygdRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxRRq2mXNz3n83LDt3e2GXTlegSblA";
				public const string Search = "ABQIAAAAxQvFmNzaQOgPbX7Sz9ygdRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxRRq2mXNz3n83LDt3e2GXTlegSblA";
			}
		}
		public class MembershipProviders
		{
			public const string Nom = "NomMembershipProvider";
		}
		public class RequestParameters
		{
			public const string ItemID = "id";
		}
		public class Session
		{
			public const string CurrentUser = "cu";
		}
		public class WindowsLive
		{
			public class Parameters
			{
				public const string ID = "id";
				public const string PrivacyURL = "privacyurl";
				public const string Result = "result";
				public const string ReturnURL = "returnurl";
			}
			public class Resources
			{
				public const string Presence = "presence";
				public const string PresenceImage = "presenceimage";
			}
		}
	}
}
