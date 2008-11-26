using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nom.Business.Caching;

namespace Nom.Web.Tests
{
	public partial class CacheStats : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			rptCacheStats.DataSource = CacheHelper.Stats();
			rptCacheStats.DataBind();
		}

		protected void rptCacheStats_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item
				|| e.Item.ItemType == ListItemType.AlternatingItem
				|| e.Item.ItemType == ListItemType.SelectedItem)
			{
				Literal litTitle = (Literal)e.Item.FindControl("litTitle");
				Literal litHits = (Literal)e.Item.FindControl("litHits");
				Literal litMisses = (Literal)e.Item.FindControl("litMisses");
				Literal litHitRate = (Literal)e.Item.FindControl("litHitRate");

				CacheStatistic cs = (CacheStatistic)e.Item.DataItem;

				litTitle.Text = cs.Name + " (" + cs.Type + ")";
				litHits.Text = cs.Hits.ToString();
				litHitRate.Text = cs.HitRate;
				litMisses.Text = cs.Misses.ToString();
			}
		}
	}
}
