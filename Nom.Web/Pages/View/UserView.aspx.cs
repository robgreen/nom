using System;
using Nom.Business;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Pages.View
{
	public partial class UserView : Nom.Web.Base.BaseViewPage
	{
		#region Private Properties
		private User _viewUser = null;
		private WLPresence _viewUserPresence = null;
		#endregion

		#region Public Properties
		public User ViewUser
		{
			get { return _viewUser; }
			set { _viewUser = value; }
		}
		public WLPresence ViewUserPresence
		{
			get { return _viewUserPresence; }
			set { _viewUserPresence = value; }
		}
		#endregion

		#region Events
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadViewUser();
			BindControls();
			SetUserDetails();
		}
		#endregion

		#region Private Methods
		private void LoadViewUser()
		{
			if (ItemID.HasValue)
			{
				ViewUser = UserManager.GetUser(ItemID.Value);

				if (ViewUser != null)
					ViewUserPresence = WindowsLiveHelper.GetWindowsLivePresence(ViewUser);
			}
		}
		private void BindControls()
		{
			ctrlRecentVenues.User = ViewUser;
			ctrlGroups.User = ViewUser;
		}
		private void SetUserDetails()
		{
			litTitle.Text = ViewUser.Name;
			litJoined.Text = ViewUser.CreatedDate.ToString("MMM yy");
			imgWLIcon.ImageUrl = ViewUserPresence.Icon.URL;
			imgWLIcon.Height = ViewUserPresence.Icon.Height;
			imgWLIcon.Width = ViewUserPresence.Icon.Width;
			imgWLIcon.AlternateText = ViewUserPresence.StatusText;
		}
		#endregion
	}
}
