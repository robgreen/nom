using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using Nom.Business.Caching;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Business.Providers
{
	public sealed class NomMembershipProvider : SqlMembershipProvider
	{
		private string connectionString;

		public override void Initialize(string name, NameValueCollection config)
		{
			if (config == null)
				throw new ArgumentNullException("config");

			if (name == null || name.Length == 0)
				name = Constants.MembershipProviders.Nom;

			if (String.IsNullOrEmpty(config["description"]))
			{
				config.Remove("description");
				config.Add("description", "Nom Membership Provider");
			}

			base.Initialize(name, config);

			ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings[Nom.DataAccess.Constants.ConnectionStrings.Nom];
			if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
				throw new ProviderException("Connection string cannot be blank.");
			connectionString = ConnectionStringSettings.ConnectionString;
		}

		public override string ApplicationName
		{
			get { return "Nom"; }
			set { throw new ProviderException("Application name can't be changed."); }
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			if (!string.IsNullOrEmpty(username))
			{
				User user = UserManager.GetUser(username);

				if (user != null)
					return user.ToMembershipUser();
				else
					return null;
			}
			else
			{
				return null;
			}
		}
		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			User user = CacheHelper.GetUser(int.Parse(providerUserKey.ToString()));

			if (user != null)
				return user.ToMembershipUser();
			else
				return null;
		}

		public override bool ValidateUser(string username, string password)
		{
			using (SqlConnection conn = Nom.DataAccess.Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Nom.DataAccess.Constants.StoredProcedures.UserManager.ValidateUser, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@Email", username));
					cmd.Parameters.Add(new SqlParameter("@Password", password));
					conn.Open();

					int? userId = null;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
					{
						if (reader.HasRows)
						{
							reader.Read();
							userId = reader.GetInt32(0);
						}

						reader.Close();

						return userId != null;
					}
				}
			}
		}
	}
}