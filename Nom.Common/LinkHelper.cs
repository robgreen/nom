﻿using System;
using System.Web;

namespace Nom.Common
{
	public class LinkHelper
	{
		public class Application
		{
			public static string Host = (!HttpContext.Current.Request.Url.IsDefaultPort ? HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port : HttpContext.Current.Request.Url.Host);
		}
		public class Group
		{
			public const string Hub = "/Pages/Hub/GroupHub.aspx";
			public const string View = "/Pages/View/GroupView.aspx";
		}
		public class User
		{
			public const string LogIn = "/Pages/Util/Login.aspx";
			public const string LogOut = "/Pages/Util/Login.aspx?logout=true";
			public const string SignUp = "/Pages/SignUp.aspx";
			public const string View = "/Pages/View/UserView.aspx";
		}
		public class SignUp
		{
			public const string Confirmation = "/Pages/Thanks.aspx";
		}
		public class Venue
		{
			public const string Hub = "/Pages/Hub/VenueHub.aspx";
			public const string View = "/Pages/View/VenueView.aspx";
		}

		public static string GetHubGroupURL()
		{
			return string.Format("http://{0}{1}",
				new object[] {
					Application.Host,
					Group.Hub
				}
			);
		}
		public static string GetHubVenueURL()
		{
			return string.Format("http://{0}{1}",
				new object[] {
					Application.Host,
					Venue.Hub
				}
			);
		}
		public static string GetViewGroupURL(int groupId)
		{
			return string.Format("http://{0}{1}?{2}={3}",
				new object[] {
					Application.Host,
					Group.View,
					Constants.RequestParameters.ItemID,
					groupId
				}
			);
		}
		public static string GetViewUserURL(int userId)
		{
			return string.Format("http://{0}{1}?{2}={3}",
				new object[] {
					Application.Host,
					User.View,
					Constants.RequestParameters.ItemID,
					userId
				}
			);
		}
		public static string GetViewVenueURL(int venueId)
		{
			return string.Format("http://{0}{1}?{2}={3}",
				new object[] {
					Application.Host,
					Venue.View,
					Constants.RequestParameters.ItemID,
					venueId
				}
			);
		}
		public static string GetLogInURL()
		{
			return string.Format("http://{0}{1}",
				Application.Host,
				User.LogIn
			);
		}
		public static string GetLogOutURL()
		{
			return string.Format("http://{0}{1}",
				Application.Host,
				User.LogOut
			);
		}
		public static string GetSignUpURL()
		{
			return string.Format("http://{0}{1}",
				Application.Host,
				User.SignUp
			);
		}
	}
}