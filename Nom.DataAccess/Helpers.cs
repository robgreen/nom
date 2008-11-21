using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Nom.DataAccess
{
	public class Helper
	{
		public static SqlConnection GetConnection()
		{
			ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[Constants.ConnectionStrings.Nom];
			SqlConnection conn = new SqlConnection(ConnectionStringSettings.ConnectionString);
			return conn;
		}

		public class Reader
		{
			public static bool ContainsColumn(ref SqlDataReader reader, string column)
			{
				int? idx = null;
				try
				{
					idx = reader.GetOrdinal(column);
				}
				catch (IndexOutOfRangeException)
				{
				}

				return idx != null;
			}
			public static Nullable<T> GetValue<T>(object value) where T : struct
			{
				if (Convert.IsDBNull(value))
					return new Nullable<T>();
				else
					return new Nullable<T>((T)value);
			}
		}
	}
}
