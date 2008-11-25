using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Controls.View.User
{
	public partial class Groups : Nom.Web.Base.BaseControl
	{
		#region Public Properties
		public Nom.DataAccess.Objects.User User
		{
			get;
			set;
		}
		#endregion

		#region Events
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<Nom.DataAccess.Objects.Group> groups = GroupManager.GetGroupsForUser(User);

			if (groups.Count > 0)
			{
				rptGroups.DataSource = groups;
				rptGroups.ItemDataBound += new RepeaterItemEventHandler(rptGroups_ItemDataBound);
				rptGroups.DataBind();
			}
			else
			{
				litUserFirstName.Text = User.Forename;

				plhNoGroups.Visible = true;
			}
		}
		#endregion

		#region Protected Methods
		protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item
				|| e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.SelectedItem)
			{
				Nom.DataAccess.Objects.Group group = (Nom.DataAccess.Objects.Group)e.Item.DataItem;

				HyperLink hypGroupProfile = (HyperLink)e.Item.FindControl("hypGroupProfile");
				Literal litTitle = (Literal)e.Item.FindControl("litTitle");

				hypGroupProfile.NavigateUrl = LinkHelper.GetViewGroupURL(group.ID.Value);
				litTitle.Text = group.Name;
			}
		}
		#endregion
	}
}