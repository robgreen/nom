using System;
using Nom.Business;

namespace Nom.Web.Pages
{
	public partial class CreateGroup : System.Web.UI.Page
	{
		public void btnSubmit_Click(object sender, EventArgs e)
		{
			string name = null;
			string profile = null;
			string postalCode = null;
			float? lat;
			float? lng;

			if (!string.IsNullOrEmpty(txtName.Text))
				name = txtName.Text;
			if (!string.IsNullOrEmpty(txtProfile.Text))
				profile = txtProfile.Text;
			if (!string.IsNullOrEmpty(txtPostalCode.Text))
				postalCode = txtPostalCode.Text;
			if (!string.IsNullOrEmpty(hdnLat.Value))
				lat = float.Parse(hdnLat.Value);
			if (!string.IsNullOrEmpty(hdnLat.Value))
				lng = float.Parse(hdnLng.Value);

			// SignUpManager.BeginSignUpRequest(email, password, forename, surname, wlOptIn);
		}
	}
}
