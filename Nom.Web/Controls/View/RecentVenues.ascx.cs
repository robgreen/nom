using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Controls.View
{
	public partial class RecentVenues : Nom.Web.Base.BaseControl
	{
		#region Public Properties
		public Nom.DataAccess.Objects.Group Group
		{
			get;
			set;
		}
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

			Dictionary<Venue, int> venues = new Dictionary<Venue, int>();

			if (Group != null)
			{
				venues = VenueManager.GetVenuesForGroup(Group);
			}
			else if (User != null)
			{
				venues = VenueManager.GetVenuesForUser(User);

				litUserFirstName.Text = User.Forename;
			}

			if (venues.Count > 0)
			{
				rptRecentVenues.DataSource = venues;
				rptRecentVenues.ItemDataBound += new RepeaterItemEventHandler(rptRecentVenues_ItemDataBound);
				rptRecentVenues.DataBind();
			}
			else
			{
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

				HyperLink hypVenueProfile = (HyperLink)e.Item.FindControl("hypVenueProfile");
				Literal litTitle = (Literal)e.Item.FindControl("litTitle");

				hypVenueProfile.NavigateUrl = LinkHelper.GetViewVenueURL(venue.ID.Value);
				litTitle.Text = venue.Name;
			}
		}
		#endregion
	}
}