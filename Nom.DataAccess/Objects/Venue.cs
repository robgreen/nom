using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Nom.DataAccess.Managers;

namespace Nom.DataAccess.Objects
{
	public class Venue
	{
		#region Private Properties
		private int? _id;
		private string _name;
		private string _profile;
		private string _postalCode;
		private float? _priceAverage;
		private int? _rankCount;
		private int? _rankAverage;
		private DateTime _createdDate;
		#endregion

		#region Public Properties
		public int? ID
		{
			get { return _id; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Profile
		{
			get { return _profile; }
			set { _profile = value; }
		}
		public string PostalCode
		{
			get { return _postalCode; }
			set { _postalCode = value; }
		}
		public float? PriceAverage
		{
			get { return _priceAverage; }
			set { _priceAverage = value; }
		}
		public int? RankCount
		{
			get { return _rankCount; }
			set { _rankCount = value; }
		}
		public int? RankAverage
		{
			get { return _rankAverage; }
			set { _rankAverage = value; }
		}
		public DateTime CreatedDate
		{
			get { return _createdDate; }
		}
		#endregion

		#region Constructor
		public Venue()
		{
		}
		public Venue(IDataReader reader)
		{
			_id = (int)reader["VenueID"];
			_name = reader["Name"] as string;
			_profile = reader["Profile"] as string;
			_postalCode = reader["PostalCode"] as string;
			if (!reader.IsDBNull(reader.GetOrdinal("PriceAverage")))
				_priceAverage = float.Parse(reader["PriceAverage"].ToString());
			if (reader.GetSchemaTable().Columns.Contains("RankCount"))
				_rankCount = (int?)reader["RankCount"];
			if (reader.GetSchemaTable().Columns.Contains("RankAverage"))
				_rankAverage = (int?)reader["RankAverage"];
			_createdDate = (DateTime)reader["CreatedDate"];
		}
		#endregion

		#region Public Methods
		public void Save()
		{
			if (!_id.HasValue)
				VenueManager.AddVenue(this, out _id, out _createdDate);
			else
				VenueManager.UpdateVenue(this);
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(typeof(Venue));
			sb.Append(" [");
			sb.Append("ID: ");
			sb.Append(ID);
			sb.Append(", ");
			sb.Append("Name: \"");
			sb.Append(Name);
			sb.Append("\", ");
			sb.Append("Profile: \"");
			sb.Append(Profile);
			sb.Append("\", ");
			sb.Append("PostalCode: \"");
			sb.Append(PostalCode);
			sb.Append("\", ");
			sb.Append("PriceAverage: \"");
			sb.Append(PriceAverage);
			sb.Append("\", ");
			sb.Append("RankCount: \"");
			sb.Append(RankCount);
			sb.Append("\", ");
			sb.Append("RankAverage: \"");
			sb.Append(RankAverage);
			sb.Append("\", ");
			sb.Append("CreatedDate: \"");
			sb.Append(CreatedDate);
			sb.Append("\"");
			sb.Append("]");

			return sb.ToString();
		}
		#endregion
	}
}
