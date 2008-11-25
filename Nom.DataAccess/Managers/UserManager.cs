using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Nom.DataAccess.Objects;

namespace Nom.DataAccess.Managers
{
	public class UserManager
	{
		public static void AddUser(User user, out int? userId, out DateTime createdDate)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.UserManager.AddUser, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Email", user.Email);
					cmd.Parameters.AddWithValue("@Password", user.Password);
					cmd.Parameters.AddWithValue("@Forename", user.Forename);
					cmd.Parameters.AddWithValue("@Surname", user.Surname);
					cmd.Parameters.AddWithValue("@WindowsLiveEnabled", user.WindowsLiveEnabled);
					if (!string.IsNullOrEmpty(user.WindowsLiveID))
						cmd.Parameters.AddWithValue("@WindowsLiveID", user.WindowsLiveID);
					SqlParameter prmUserId = new SqlParameter();
					prmUserId.Direction = ParameterDirection.Output;
					prmUserId.DbType = DbType.Int32;
					prmUserId.ParameterName = "@UserID";
					cmd.Parameters.Add(prmUserId);
					SqlParameter prmCreatedDate = new SqlParameter();
					prmCreatedDate.Direction = ParameterDirection.Output;
					prmCreatedDate.DbType = DbType.DateTime;
					prmCreatedDate.ParameterName = "@CreatedDate";
					cmd.Parameters.Add(prmCreatedDate);

					conn.Open();

					cmd.ExecuteScalar();

					userId = (int)cmd.Parameters["@UserID"].Value;
					createdDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;
				}
			}
		}

		public static User GetUser(int userId)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.UserManager.GetUser, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@UserID", userId);

					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						reader.Read();
						return new User(reader);
					}
				}
			}
		}
		public static User GetUser(string email)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.UserManager.GetUserByEmail, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Email", email);

					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						reader.Read();
						return new User(reader);
					}
				}
			}
		}
		public static List<User> GetUsers()
		{
			List<User> users = new List<User>();

			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.UserManager.GetUsers, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
							users.Add(new User(reader));
					}
				}
			}

			return users;
		}

		public static List<User> GetUsersByGroup(int groupId)
		{
			List<User> users = new List<User>();

			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.UserManager.GetUsersByGroup, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@GroupID", groupId);
					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
							users.Add(new User(reader));
					}
				}
			}

			return users;
		}

		public static void RemoveUser(User user)
		{
			if (user.ID.HasValue)
				RemoveUser(user.ID.Value);
			else
				throw new Exception("User has not been saved and thus cannot be removed.");
		}
		public static void RemoveUser(int userId)
		{
			throw new Exception("Method not implemented.");
		}

		public static void UpdateUser(User user)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.UserManager.UpdateUser, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@UserID", user.ID);
					if (!string.IsNullOrEmpty(user.Password))
						cmd.Parameters.AddWithValue("@Password", user.Password);
					cmd.Parameters.AddWithValue("@Forename", user.Forename);
					cmd.Parameters.AddWithValue("@Surname", user.Surname);
					cmd.Parameters.AddWithValue("@Email", user.Email);
					cmd.Parameters.AddWithValue("@WindowsLiveEnabled", user.WindowsLiveEnabled);
					if (!string.IsNullOrEmpty(user.WindowsLiveID))
						cmd.Parameters.AddWithValue("@WindowsLiveID", user.WindowsLiveID);

					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
