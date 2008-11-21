using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Business
{
	public class SessionHelper
	{
		public static User GetCurrentUser()
		{
			MembershipUser mu = Membership.GetUser();

			if (mu != null)
			{
				User user = UserManager.GetUser((int)mu.ProviderUserKey);

				if (user != null)
					return user;
			}

			return null;
		}
	}
}
