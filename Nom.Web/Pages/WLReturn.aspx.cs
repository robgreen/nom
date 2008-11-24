using System;
using Nom.Business;
using Nom.Common;

namespace Nom.Web.Pages
{
	public partial class WLReturn : Nom.Web.Base.BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string id = null;
			string result = null;

			if (Request.Params[Constants.WindowsLive.Parameters.ID] != null)
				id = Request.Params[Constants.WindowsLive.Parameters.ID];
			if (Request.Params[Constants.WindowsLive.Parameters.Result] != null)
				result = Request.Params[Constants.WindowsLive.Parameters.Result];

			SignUpManager.BeginWLSignUpRequest(id, result);
		}
	}
}
