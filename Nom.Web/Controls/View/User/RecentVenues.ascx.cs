using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Controls.View.User
{
	public partial class RecentVenues : Nom.Web.Base.BaseControl
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

			Dictionary<Venue, int> venues = VenueManager.GetVenuesForUser(User);

			if (venues.Count > 0)
			{
				rptRecentVenues.DataSource = venues;
				rptRecentVenues.ItemDataBound += new RepeaterItemEventHandler(rptRecentVenues_ItemDataBound);
				rptRecentVenues.DataBind();
			}
			else
			{
				litUserFirstName.Text = User.Forename;

				plhNoRecentVenues.Visible = true;
			}
		}
		#endregion

		#region Protected Methods
		protected void rptRecentVenues_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item
				|| e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.SelectedItem)
			{
				Venue venue = ((KeyValuePair<Venue, int>)e.Item.DataItem).Key;

				Literal litTitle = (Literal)e.Item.FindControl("litTitle");

				litTitle.Text = venue.Name;
			}
		}
		#endregion
	}
}