using System;
using System.Net;
using System.Text;
using System.Web;
using Nom.Common;
using Nom.DataAccess.Objects;

namespace Nom.Business
{
	public class WindowsLiveHelper
	{
		private const string WLSignUpBaseURL = "http://settings.messenger.live.com/applications/websignup.aspx?returnurl={0}&privacyurl={1}";
		private const string WLPresenceBaseURL = "http://messenger.services.live.com/users/{0}/{1}/";
		private const string WLLocalPrivacyURL = "/Pages/WLPrivacy.aspx";
		private const string WLLocalReturnURL = "/Pages/WLReturn.aspx";

		public static string GetWindowsLiveInviteURL()
		{
			return string.Format(WLSignUpBaseURL, GetHostForPath(WLLocalReturnURL), GetHostForPath(WLLocalPrivacyURL));
		}

		public static WLPresence GetWindowsLivePresence(User user)
		{
			if (!string.IsNullOrEmpty(user.WindowsLiveID))
			{
				HttpWebRequest hwRequest = (HttpWebRequest)WebRequest.Create(GetWindowsLivePresenceURL(user.WindowsLiveID));
				HttpWebResponse hwResponse = (HttpWebResponse)hwRequest.GetResponse();

				return new WLPresence(hwResponse);
			}
			else
			{
				throw new Exception("User has not activated Windows Live support.");
			}
		}

		private static string GetWindowsLivePresenceURL(string wlId)
		{
			return string.Format(WLPresenceBaseURL, wlId, Constants.WindowsLive.Resources.Presence);
		}

		private static string GetHostForPath(string path)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("http://");
			sb.Append(HttpContext.Current.Request.Url.Host);
			if (!HttpContext.Current.Request.Url.IsDefaultPort)
			{
				sb.Append(":");
				sb.Append(HttpContext.Current.Request.Url.Port);	
			}
			sb.Append(path);

			return sb.ToString();
		}

		public enum ResultStatus
		{
			Accepted = 0,
			Declined = 1,
			NoPrivacyUrl = 2
		}
	}
}
