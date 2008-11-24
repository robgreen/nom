using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Nom.Business;
using Nom.Business.Objects;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Tests
{
	public partial class WLUserPresence : Nom.Web.Base.BasePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GridView gv = new GridView();

			Dictionary<string, string> userPresence = new Dictionary<string, string>();
			List<User> users = UserManager.GetUsers();

			foreach (User u in users)
			{
				string presence = null;

				if (!string.IsNullOrEmpty(u.WindowsLiveID))
				{
					presence = "Unknown";

					WLPresence wlp = WindowsLiveHelper.GetWindowsLivePresence(u);
					if (wlp != null)
					{
						presence = wlp.StatusText;
					}
				}
				else
				{
					presence = "Not subscribed";
				}

				userPresence.Add(u.ToString(), presence);
			}

			gv.DataSource = userPresence;
			gv.DataBind();

			this.FindControl("form1").Controls.Add(gv);
		}
	}
}
