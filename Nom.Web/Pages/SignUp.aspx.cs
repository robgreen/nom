using System;
using Nom.Business;

namespace Nom.Web.Pages
{
	public partial class SignUp : Nom.Web.Base.BasePage
	{
		public void btnSubmit_Click(object sender, EventArgs e)
		{
			string email = null;
			string password = null;
			string forename = null;
			string surname = null;
			bool wlOptIn = false;

			if (!string.IsNullOrEmpty(txtEmail.Text))
				email = txtEmail.Text;
			if (!string.IsNullOrEmpty(txtPassword.Text))
				password = txtPassword.Text;
			if (!string.IsNullOrEmpty(txtForename.Text))
				forename = txtForename.Text;
			if (!string.IsNullOrEmpty(txtSurname.Text))
				surname = txtSurname.Text;

			SignUpManager.BeginSignUpRequest(email, password, forename, surname, wlOptIn);
		}
	}
}
