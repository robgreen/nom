using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Nom.DataAccess.Managers;

namespace Nom.DataAccess.Objects
{
	public class Group
	{
		#region Private Properties
		private int? _id;
		private float? _geoLatitude;
		private float? _geoLongitude;
		private string _name;
		private string _profile;
		private string _postalCode;
		private DateTime _createdDate;
		private List<User> _users = null;
		#endregion

		#region Public Properties
		public int? ID
		{
			get { return _id; }
		}
		public float? GeoLatitude
		{
			get { return _geoLatitude; }
			set { _geoLatitude = value; }
		}
		public float? GeoLongitude
		{
			get { return _geoLongitude; }
			set { _geoLongitude = value; }
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
		public DateTime CreatedDate
		{
			get { return _createdDate; }
		}
		public List<User> Users
		{
			get
			{
				if (_users == null && _id.HasValue)
					_users = GroupManager.GetUsers(_id.Value);

				return _users;
			}
		}
		#endregion

		#region Constructor
		public Group()
		{
		}
		public Group(IDataReader reader)
		{
			_id = (int)reader["GroupID"];
			if (!reader.IsDBNull(reader.GetOrdinal("GeoLat")))
				_geoLatitude = float.Parse(reader["GeoLat"].ToString());
			if (!reader.IsDBNull(reader.GetOrdinal("GeoLng")))
				_geoLongitude = float.Parse(reader["GeoLng"].ToString());
			_name = reader["Name"] as string;
			_profile = reader["Profile"] as string;
			_postalCode = reader["PostalCode"] as string;
			_createdDate = (DateTime)reader["CreatedDate"];
		}
		#endregion

		#region Public Methods
		public void Save()
		{
			if (!_id.HasValue)
				GroupManager.AddGroup(this, out _id, out _createdDate);
			else
				GroupManager.UpdateGroup(this);
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(typeof(Group));
			sb.Append(" [");
			sb.Append("ID: ");
			sb.Append(ID);
			sb.Append(", ");
			sb.Append("Name: \"");
			sb.Append(Name);
			sb.Append("\", ");
			sb.Append("GeoLatitude \"");
			sb.Append(GeoLatitude);
			sb.Append("\", ");
			sb.Append("GeoLongitude: \"");
			sb.Append(GeoLongitude);
			sb.Append("\", ");
			sb.Append("Profile: \"");
			sb.Append(Profile);
			sb.Append("\", ");
			sb.Append("PostalCode: \"");
			sb.Append(PostalCode);
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
