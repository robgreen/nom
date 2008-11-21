using System;
using System.Web;
using System.Web.UI;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Business
{
	public class GroupHelper
	{
		public static void BeginCreateGroupRequest(string name, string profile, string postalCode, float? lat, float? lng)
		{
			Group newGroup = new Group();

			if (!string.IsNullOrEmpty(name))
				newGroup.Name = name;
			if (!string.IsNullOrEmpty(profile))
				newGroup.Profile = profile;
			if (!string.IsNullOrEmpty(postalCode))
				newGroup.PostalCode = postalCode;
			if (lat.HasValue)
				newGroup.GeoLatitude = lat.Value;
			if (lng.HasValue)
				newGroup.GeoLongitude = lng.Value;

			try
			{
				newGroup.Save();

				GroupManager.AddGroupUser(newGroup, SessionHelper.GetCurrentUser());

				HttpContext.Current.Response.Redirect(LinkHelper.SignUp.Confirmation);
			}
			catch (Exception e)
			{
				throw new Exception("Problem saving group:", e);
			}
		}
	}
}
