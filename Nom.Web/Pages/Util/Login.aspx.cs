using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nom.Common;

namespace Nom.Web.Pages.Util
{
	public partial class Login : Nom.Web.Base.BasePage
	{
		#region Events
		protected override void OnLoad(EventArgs e)
		{
			if ((!IsPostBack) && (Request.QueryString[Constants.RequestParameters.LogOut] != null) && (Request.QueryString[Constants.RequestParameters.LogOut].Equals("true")))
			{
				LogOut();
			}

			base.OnLoad(e);
		}
		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text.Trim();
			string password = txtPassword.Text.Trim();

			if (Membership.ValidateUser(username, password))
			{
				FormsAuthentication.SetAuthCookie(username, false);
				Response.Redirect(GetReturnURL());
			}
			else
			{
				/*
				MembershipUser mu = Membership.GetUser(username);
				if (mu == null)
				{
					//not exist
					LoginError.Visible = true;
					Username.CssClass = "text error";
					Password.CssClass = "text error";
				}
				else
				{
					
					if (mu.IsLockedOut)
					{
						//inactive or deleted
						lblError.Text = "<span class=\"formError\"><span class=\"errMessage\">Locked out!, please contact customer services</span></span>";
						lblError.Visible = true;
						return;
					}
					if (!mu.IsApproved)
					{
						//not email verified
						resendActivation.Visible = true;
						lblError.Text = "<span class=\"formError\"><span class=\"errMessage\">Email needs verification</span></span>";
						lblError.Visible = true;
						return;
					}
					else
					{
						//not exist
						LoginError.Visible = true;
						Username.CssClass = "text error";
						Password.CssClass = "text error";
					}
					
				}
				*/
			}
		}
		#endregion

		#region Private Methods
		private string GetReturnURL()
		{
			string returnUrl = Request.Params["ReturnUrl"];
			if (string.IsNullOrEmpty(returnUrl))
				returnUrl = "/";

			return returnUrl;
		}
		private void LogOut()
		{
			if (UserHelper.IsUserLoggedIn())
			{
				HttpCookie authCookie = FormsAuthentication.GetAuthCookie(Membership.GetUser().UserName, false);
				Response.Cookies.Remove(authCookie.Name);
			}

			FormsAuthentication.SignOut();
		}
		#endregion
	}
}
