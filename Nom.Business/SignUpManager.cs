using System;
using System.Web;
using System.Web.UI;
using Nom.Common;
using Nom.DataAccess.Objects;

namespace Nom.Business
{
	public class SignUpManager
	{
		public static void BeginSignUpRequest(string email, string password, string forename, string surname, bool wlOptIn)
		{
			User newUser = new User();

			if (!string.IsNullOrEmpty(email))
				newUser.Email = email;
			if (!string.IsNullOrEmpty(password))
				newUser.Password = password;
			if (!string.IsNullOrEmpty(forename))
				newUser.Forename = forename;
			if (!string.IsNullOrEmpty(surname))
				newUser.Surname = surname;
			newUser.WindowsLiveEnabled = wlOptIn;

			try
			{
				newUser.Save();

				HttpContext.Current.Session.Add(Constants.Session.CurrentUser, newUser);

				if (wlOptIn)
					HttpContext.Current.Response.Redirect(WindowsLiveHelper.GetWindowsLiveInviteURL());
				else
					HttpContext.Current.Response.Redirect(LinkHelper.SignUp.Confirmation);
			}
			catch (Exception e)
			{
				throw new Exception("Problem saving user:", e);
			}
		}

		public static void BeginWLSignUpRequest(string wlId, string status)
		{
			WindowsLiveHelper.ResultStatus result = WindowsLiveHelper.ResultStatus.Declined;

			switch (status)
			{
				case "Accepted":
					result = WindowsLiveHelper.ResultStatus.Accepted;
					break;

				case "Declined":
					result = WindowsLiveHelper.ResultStatus.Declined;
					break;
				case "NoPrivacyUrl":
					result = WindowsLiveHelper.ResultStatus.NoPrivacyUrl;
					break;
			}

			if (result == WindowsLiveHelper.ResultStatus.Accepted)
			{
				User user = (User)HttpContext.Current.Session[Constants.Session.CurrentUser];

				if (user != null)
				{
					user.WindowsLiveID = wlId;
					user.Save();

					HttpContext.Current.Response.Redirect(LinkHelper.SignUp.Confirmation);
				}
				else
				{
					throw new Exception("User no longer logged in.");
				}
			}
		}
	}
}
