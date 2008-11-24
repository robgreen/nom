using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
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

			List<Group> groups = GroupManager.GetGroupsForUser(User);

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
				Group group = (Group)e.Item.DataItem;

				Literal litTitle = (Literal)e.Item.FindControl("litTitle");

				litTitle.Text = group.Name;
			}
		}
		#endregion
	}
}