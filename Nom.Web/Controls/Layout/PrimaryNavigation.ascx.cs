using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nom.Common;

namespace Nom.Web.Controls.Layout
{
	public partial class PrimaryNavigation : Nom.Web.Base.BaseControl
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Configure();
		}

		private void Configure()
		{
			hypGroupHub.NavigateUrl = LinkHelper.GetHubGroupURL();
			hypVenueHub.NavigateUrl = LinkHelper.GetHubVenueURL();
		}
	}
}