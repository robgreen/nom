using System;
using Nom.Common;

namespace Nom.Web.Base
{
	public class BaseViewPage: BasePage
	{
		#region Private Properties
		private int? _itemId = null;
		#endregion

		#region Public Properties
		public int? ItemID
		{
			get { return _itemId; }
			set { _itemId = value; }
		}
		#endregion

		#region Events
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			InitRequestParameters();
		}
		#endregion

		#region Private Methods
		private void InitRequestParameters()
		{
			if (!string.IsNullOrEmpty(Request.QueryString.Get(Constants.RequestParameters.ItemID)))
			{
				int itemId = -1;
				if (int.TryParse(Request.QueryString[Constants.RequestParameters.ItemID], out itemId))
					_itemId = itemId;
				else
					throw new Exception("Invalid item identifier expected.");
			}
			else
				throw new Exception("Item identifier expected.");
		}
		#endregion
	}
}
