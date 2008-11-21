using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using Nom.Common;

namespace Nom.Business.Providers
{
	public sealed class NomMembershipProvider : MembershipProvider
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

			ConnectionStringSettings ConnectionStringSettings = ConfigurationManager.ConnectionStrings["AMGExtranetDB"];
			if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
				throw new ProviderException("Connection string cannot be blank.");
			connectionString = ConnectionStringSettings.ConnectionString;
		}

		public override string ApplicationName
		{
			get { return "Nom"; }
			set { throw new ProviderException("Application name can't be changed."); }
		}

		public override bool EnablePasswordReset
		{
			get { return true; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return true; }
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { return false; }
		}

		public override bool RequiresUniqueEmail
		{
			get { return true; }
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return Int32.MaxValue; }
		}

		public override int PasswordAttemptWindow
		{
			get { return 3; }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { return MembershipPasswordFormat.Hashed; }
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return 0; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return 6; }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { return "*"; }
		}

		public override bool ChangePassword(string username, string oldPwd, string newPwd)
		{
			if (!ValidateUser(username, oldPwd)) return false;
			ChangePassword(username, newPwd);

			return true;
		}

		private void ChangePassword(string username, string password)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("ChangePassword", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("@email", username));
			cmd.Parameters.Add(new SqlParameter("@password", password));

			int rowsAffected = 0;

			try
			{
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			}
			finally
			{
				conn.Close();
			}

			if (rowsAffected == 0)
				throw new MembershipPasswordException("User not found.");
		}

		public override bool ChangePasswordQuestionAndAnswer(string username, string password,
		  string newPwdQuestion, string newPwdAnswer)
		{
			// we don't support q&a for password retrieval
			return false;
		}

		public override MembershipUser CreateUser(string username, string password, string email,
		  string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey,
		  out MembershipCreateStatus status)
		{
			// we don't support creating users via this interface
			status = MembershipCreateStatus.ProviderError;
			return null;
		}

		public override bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			// we don't support deleting users via this interface
			return false;
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			return FindUsersHelper("EnumUserAuthCount", "EnumUserAuth", null, null,
			  pageIndex, pageSize, out totalRecords);
		}

		public override int GetNumberOfUsersOnline()
		{
			// we aren't tracking activity
			return 0;
		}

		public override string GetPassword(string username, string answer)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("GetPassword", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("@email", username));

			string password = null;
			SqlDataReader reader = null;

			try
			{
				conn.Open();
				reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
				if (reader.HasRows)
				{
					reader.Read();
					password = reader.GetString(0);
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				conn.Close();
			}

			return password;
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			return GetUserHelper("GetUserAuthByEmail", "@email", username);
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			return GetUserHelper("GetUserAuthByID", "@userid", providerUserKey);
		}

		private MembershipUser GetUserHelper(string getCmd, string parmName, object parm)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(getCmd, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter(parmName, parm));

			MembershipUser u = null;
			SqlDataReader reader = null;

			try
			{
				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.HasRows)
				{
					reader.Read();
					u = GetUserFromReader(reader);
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				conn.Close();
			}

			return u;
		}

		private MembershipUser GetUserFromReader(SqlDataReader reader)
		{
			object providerUserKey = reader["UserID"];
			string email = reader["Email"] as string;
			bool isApproved = (bool)reader["Activated"];
			bool isLockedOut = !(bool)reader["Active"];
			DateTime createDate = (DateTime)reader["CreatedDate"];
			DateTime blankDate = new DateTime();

			return new MembershipUser(this.Name, email, providerUserKey, email, "",
				"", isApproved, isLockedOut, createDate, blankDate, blankDate, blankDate, blankDate);
		}

		[Obsolete]
		public override bool UnlockUser(string username)
		{
			// we don't lock out password failures so no need to unlock
			return false;
		}

		public override string GetUserNameByEmail(string email)
		{
			// email is username
			return email;
		}

		public override string ResetPassword(string username, string answer)
		{
			string newPassword = System.Web.Security.Membership.GeneratePassword(8, 0);
			ChangePassword(username, newPassword);
			return newPassword;
		}

		public override void UpdateUser(MembershipUser user)
		{
			if (user.Email != user.UserName)
				throw new MembershipPasswordException("Can't change email address.");

			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("ChangeActiveState", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("@userid", user.ProviderUserKey));
			cmd.Parameters.Add(new SqlParameter("@active", user.IsApproved ? 1 : 0));

			int rowsAffected = 0;

			try
			{
				conn.Open();
				rowsAffected = cmd.ExecuteNonQuery();
			}
			finally
			{
				conn.Close();
			}

			if (rowsAffected == 0)
				throw new MembershipPasswordException("User not found.");
		}

		public override bool ValidateUser(string username, string password)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand("CheckPassword", conn);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("@email", username));
			cmd.Parameters.Add(new SqlParameter("@password", password));

			SqlDataReader reader = null;
			Int32 userid = 0;

			try
			{
				conn.Open();

				reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

				if (reader.HasRows)
				{
					reader.Read();
					userid = reader.GetInt32(0);
				}

				reader.Close();
			}
			finally
			{
				if (reader != null) reader.Close();
				conn.Close();
			}

			return userid != 0;
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch,
		  int pageIndex, int pageSize, out int totalRecords)
		{
			return FindUsersByEmail(usernameToMatch, pageIndex, pageSize, out totalRecords);
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch,
		  int pageIndex, int pageSize, out int totalRecords)
		{
			return FindUsersHelper("EnumUserAuthByEmailCount", "EnumUserAuthByEmail", "@email", emailToMatch,
			  pageIndex, pageSize, out totalRecords);
		}

		private MembershipUserCollection FindUsersHelper(string countCmd, string findCmd, string parmName, string parm,
			int pageIndex, int pageSize, out int totalRecords)
		{
			SqlConnection conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(countCmd, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			if (parmName != null) cmd.Parameters.Add(new SqlParameter(parmName, parm));

			MembershipUserCollection users = new MembershipUserCollection();

			SqlDataReader reader = null;
			totalRecords = 0;

			try
			{
				conn.Open();
				totalRecords = (int)cmd.ExecuteScalar();

				if (totalRecords > 0 && pageSize > 0)
				{
					cmd.CommandText = findCmd;
					reader = cmd.ExecuteReader();

					int counter = 0;
					int startIndex = pageSize * pageIndex;
					int endIndex = startIndex + pageSize - 1;

					while (reader.Read())
					{
						if (counter >= startIndex)
						{
							MembershipUser u = GetUserFromReader(reader);
							users.Add(u);
						}
						if (counter >= endIndex) { cmd.Cancel(); break; }
						counter++;
					}
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				conn.Close();
			}

			return users;
		}
	}
}