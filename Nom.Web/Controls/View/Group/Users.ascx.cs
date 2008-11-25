using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Nom.Business;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Controls.View.Group
{
	public partial class Users : Nom.Web.Base.BaseControl
	{
		#region Public Properties
		public Nom.DataAccess.Objects.Group Group
		{
			get;
			set;
		}
		#endregion

		#region Events
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<Nom.DataAccess.Objects.User> users = GroupManager.GetUsers(Group.ID.Value);

			if (users.Count > 0)
			{
				rptUsers.DataSource = users;
				rptUsers.ItemDataBound += new RepeaterItemEventHandler(rptUsers_ItemDataBound);
				rptUsers.DataBind();
			}
		}
		#endregion

		#region Protected Methods
		protected void rptUsers_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item
				|| e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.SelectedItem)
			{
				Nom.DataAccess.Objects.User user = (Nom.DataAccess.Objects.User)e.Item.DataItem;
				WLPresence userPresence = WindowsLiveHelper.GetWindowsLivePresence(user);

				HyperLink hypUserProfile = (HyperLink)e.Item.FindControl("hypUserProfile");
				Literal litTitle = (Literal)e.Item.FindControl("litTitle");
				Image imgWLIcon = (Image)e.Item.FindControl("imgWLIcon");

				hypUserProfile.NavigateUrl = LinkHelper.GetViewUserURL(user.ID.Value);
				litTitle.Text = user.Name;

				if (userPresence != null)
				{
					imgWLIcon.ImageUrl = userPresence.Icon.URL;
					imgWLIcon.Height = userPresence.Icon.Height;
					imgWLIcon.Width = userPresence.Icon.Width;
					imgWLIcon.AlternateText = userPresence.StatusText;
				}
			}
		}
		#endregion
	}
}