using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Pages.Hub
{
	public partial class GroupHub : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<Group> groups = GroupManager.GetGroups();
			grdGroups.DataSource = groups;
			grdGroups.DataBind();
		}
	}
}
