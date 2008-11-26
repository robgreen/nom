using System;
using Nom.Business;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Pages.View
{
	public partial class VenueView : Nom.Web.Base.BaseViewPage
	{
		#region Private Properties
		private Venue _viewVenue = null;
		#endregion

		#region Public Properties
		public Venue ViewVenue
		{
			get { return _viewVenue; }
			set { _viewVenue = value; }
		}
		#endregion

		#region Events
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadViewVenue();
			BindControls();
			SetVenueDetails();
		}
		#endregion

		#region Private Methods
		private void LoadViewVenue()
		{
			if (ItemID.HasValue)
			{
				ViewVenue = VenueManager.GetVenue(ItemID.Value);
			}
		}
		private void BindControls()
		{
			//ctrlUsers.Group = ViewGroup;
		}
		private void SetVenueDetails()
		{
			litTitle.Text = ViewVenue.Name;
		}
		#endregion
	}
}
