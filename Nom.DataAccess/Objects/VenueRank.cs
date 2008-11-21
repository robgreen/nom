using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Nom.DataAccess.Managers;

namespace Nom.DataAccess.Objects
{
	public class VenueRank
	{
		#region Private Properties
		private int _userId;
		private int _venueId;
		private int _rank;
		#endregion

		#region Public Properties
		public int UserID
		{
			get { return _userId; }
			set { _userId = value; }
		}
		public int VenueID
		{
			get { return _venueId; }
			set { _venueId = value; }
		}
		public int Rank
		{
			get { return _rank; }
			set { _rank = value; }
		}
		#endregion

		#region Constructor
		public VenueRank()
		{
		}
		public VenueRank(IDataReader reader)
		{
			_userId = (int)reader["UserID"];
			_venueId = (int)reader["VenueID"];
			_rank = (int)reader["Rank"];
		}
		#endregion

		#region Public Methods
		public void Save()
		{
			VenueManager.AddVenueRank(this);
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(typeof(VenueRank));
			sb.Append(" [");
			sb.Append("VenueID: ");
			sb.Append(VenueID);
			sb.Append(", ");
			sb.Append("UserID: \"");
			sb.Append(UserID);
			sb.Append("\", ");
			sb.Append("Rank: \"");
			sb.Append(Rank);
			sb.Append("\"");
			sb.Append("]");

			return sb.ToString();
		}
		#endregion
	}
}