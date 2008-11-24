using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Nom.DataAccess.Managers;

namespace Nom.DataAccess.Objects
{
	public class User
	{
		#region Private Properties
		private int? _id;
		private string _email;
		private string _forename;
		private string _password;
		private string _surname;
		private bool _windowsLiveEnabled;
		private string _windowsLiveId;
		private DateTime _createdDate;
		#endregion

		#region Public Properties
		public int? ID
		{
			get { return _id; }
		}
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		public string Forename
		{
			get { return _forename; }
			set { _forename = value; }
		}
		public string Name
		{
			get { return string.Format("{0} {1}", _forename, _surname); }
		}
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}
		public string Surname
		{
			get { return _surname; }
			set { _surname = value; }
		}
		public bool WindowsLiveEnabled
		{
			get { return _windowsLiveEnabled; }
			set { _windowsLiveEnabled = value; }
		}
		public string WindowsLiveID
		{
			get { return _windowsLiveId; }
			set { _windowsLiveId = value; }
		}
		public DateTime CreatedDate
		{
			get { return _createdDate; }
		}
		#endregion

		#region Constructor
		public User()
		{
		}
		public User(IDataReader reader)
		{
			while (reader.Read())
			{
				_id = (int)reader["UserID"];
				_email = reader["Email"] as string;
				_forename = reader["Forename"] as string;
				_surname = reader["Surname"] as string;
				_windowsLiveEnabled = (bool)reader["WindowsLiveEnabled"];
				_windowsLiveId = reader["WindowsLiveID"] as string;
				_createdDate = (DateTime)reader["CreatedDate"];
			}
		}
		#endregion

		#region Public Methods
		public void Save()
		{
			if (!_id.HasValue)
				UserManager.AddUser(this, out _id, out _createdDate);
			else
				UserManager.UpdateUser(this);
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(typeof(User));
			sb.Append(" [");
			sb.Append("ID: ");
			sb.Append(ID);
			sb.Append(", ");
			sb.Append("Email: \"");
			sb.Append(Email);
			sb.Append("\", ");
			sb.Append("Forename: \"");
			sb.Append(Forename);
			sb.Append("\", ");
			sb.Append("Surname: \"");
			sb.Append(Surname);
			sb.Append("\", ");
			sb.Append("WindowsLiveEnabled: \"");
			sb.Append(WindowsLiveEnabled);
			sb.Append("\", ");
			sb.Append("WindowsLiveID: \"");
			sb.Append(WindowsLiveID);
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
