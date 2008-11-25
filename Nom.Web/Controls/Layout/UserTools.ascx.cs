using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nom.Common;

namespace Nom.Web.Controls.Layout
{
	public partial class UserTools : Nom.Web.Base.BaseControl
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (UserHelper.IsUserLoggedIn())
			{
				plhLoggedOut.Visible = false;

				MembershipUser mu = UserHelper.GetCurrentUser();

				litUserName.Text = mu.UserName;
				hypUserProfile.NavigateUrl = LinkHelper.GetViewUserURL(int.Parse(mu.ProviderUserKey.ToString()));
				hypLogOut.NavigateUrl = LinkHelper.GetLogOutURL();
			}
			else
			{
				plhLoggedIn.Visible = false;

				hypLogIn.NavigateUrl = LinkHelper.GetLogInURL();
				hypSignUp.NavigateUrl = LinkHelper.GetSignUpURL();
			}
		}
	}
}