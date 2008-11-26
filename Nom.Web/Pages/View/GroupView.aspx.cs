using System;
using Nom.Business;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Web.Pages.View
{
	public partial class GroupView : Nom.Web.Base.BaseViewPage
	{
		#region Private Properties
		private Group _viewGroup = null;
		#endregion

		#region Public Properties
		public Group ViewGroup
		{
			get { return _viewGroup; }
			set { _viewGroup = value; }
		}
		#endregion

		#region Events
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadViewGroup();
			BindControls();
			SetGroupDetails();
		}
		#endregion

		#region Private Methods
		private void LoadViewGroup()
		{
			if (ItemID.HasValue)
			{
				ViewGroup = GroupManager.GetGroup(ItemID.Value);
			}
		}
		private void BindControls()
		{
			ctrlUsers.Group = ViewGroup;
		}
		private void SetGroupDetails()
		{
			litTitle.Text = ViewGroup.Name;
			litProfile.Text = ViewGroup.Profile;
		}
		#endregion
	}
}
