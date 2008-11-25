using System;
using System.Web.Security;

namespace Nom.Common
{
	public class UserHelper
	{
		public static bool IsUserLoggedIn()
		{
			return (GetCurrentUser() != null);
		}
		public static MembershipUser GetCurrentUser()
		{
			MembershipUser mu = Membership.GetUser();

			return mu;
		}
	}
}
