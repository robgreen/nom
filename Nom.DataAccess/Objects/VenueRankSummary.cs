using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nom.DataAccess.Objects
{
	public class VenueRankSummary
	{
		#region Private Properties
		private List<VenueRank> _rankItems = new List<VenueRank>();
		private int? _totalRank;
		private int? _averageRank;
		#endregion

		#region Public Properties
		public List<VenueRank> RankItems
		{
			get { return _rankItems; }
			set { _rankItems = value; }
		}
		public int TotalRank
		{
			get
			{
				if (!_totalRank.HasValue)
					foreach (VenueRank vr in _rankItems)
						_totalRank = _totalRank + vr.Rank;

				return _totalRank.Value;
			}

		}
		public int AverageRank
		{
			get
			{
				if (!_averageRank.HasValue)
					_averageRank = _totalRank / _rankItems.Count;

				return _averageRank.Value;
			}
		}
		#endregion

		#region Public Methods
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(typeof(VenueRankSummary));
			sb.Append(" [");
			sb.Append("TotalRank: ");
			sb.Append(TotalRank);
			sb.Append(", ");
			sb.Append("AverageRank: \"");
			sb.Append(AverageRank);
			sb.Append("\"");
			sb.Append("]");

			return sb.ToString();
		}
		#endregion
	}
}
