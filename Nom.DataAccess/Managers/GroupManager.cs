using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Nom.DataAccess.Objects;

namespace Nom.DataAccess.Managers
{
	public class GroupManager
	{
		public static void AddGroup(Group group, out int? groupId, out DateTime createdDate)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GroupManager.AddGroup, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Name", group.Name);
					if (group.GeoLatitude.HasValue)
						cmd.Parameters.AddWithValue("@GeoLat", group.GeoLatitude.Value);
					if (group.GeoLongitude.HasValue)
						cmd.Parameters.AddWithValue("@GeoLng", group.GeoLongitude.Value);
					if (!string.IsNullOrEmpty(group.Name))
						cmd.Parameters.AddWithValue("@Profile", group.Profile);
					if (!string.IsNullOrEmpty(group.PostalCode))
						cmd.Parameters.AddWithValue("@PostalCode", group.PostalCode);
					SqlParameter prmGroupId = new SqlParameter();
					prmGroupId.Direction = ParameterDirection.Output;
					prmGroupId.DbType = DbType.Int32;
					prmGroupId.ParameterName = "@GroupID";
					cmd.Parameters.Add(prmGroupId);
					SqlParameter prmCreatedDate = new SqlParameter();
					prmCreatedDate.Direction = ParameterDirection.Output;
					prmCreatedDate.DbType = DbType.DateTime;
					prmCreatedDate.ParameterName = "@CreatedDate";
					cmd.Parameters.Add(prmCreatedDate);

					conn.Open();

					cmd.ExecuteScalar();

					groupId = (int)cmd.Parameters["@GroupID"].Value;
					createdDate = (DateTime)cmd.Parameters["@CreatedDate"].Value;
				}
			}
		}

		public static void AddGroupUser(Group group, User user)
		{
			if (group.ID.HasValue && user.ID.HasValue)
				AddGroupUser(group.ID.Value, user.ID.Value);
			else
				throw new Exception("Cannot add a user to a group when either the user or group has not been saved");
		}
		public static void AddGroupUser(int groupId, int userId)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GroupManager.AddGroupUser, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@GroupID", groupId);
					cmd.Parameters.AddWithValue("@UserID", userId);

					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}

		public static Group GetGroup(int groupId)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GroupManager.GetGroup, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@GroupID", groupId);

					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						return new Group(reader);
					}
				}
			}
		}
		public static List<Group> GetGroups()
		{
			List<Group> groups = new List<Group>();

			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GroupManager.GetGroups, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					conn.Open();

					using (IDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
							groups.Add(new Group(reader));
					}
				}
			}

			return groups;
		}

		public static List<User> GetUsers(int groupId)
		{
			return UserManager.GetUsersByGroup(groupId);
		}

		public static void RemoveGroup(Group group)
		{
			if (group.ID.HasValue)
				RemoveGroup(group.ID.Value);
			else
				throw new Exception("Group has not been saved and thus cannot be removed.");
		}
		public static void RemoveGroup(int groupId)
		{
			throw new Exception("Method not implemented.");
		}

		public static void RemoveGroupUser(Group group, User user)
		{
			if (group.ID.HasValue && user.ID.HasValue)
				RemoveGroupUser(group.ID.Value, user.ID.Value);
			else
				throw new Exception("Cannot remove a user from a group when either the user or group has not been saved");

		}
		public static void RemoveGroupUser(int groupId, int userId)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GroupManager.RemoveGroupUser, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@GroupID", groupId);
					cmd.Parameters.AddWithValue("@UserID", userId);

					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}

		public static void UpdateGroup(Group group)
		{
			using (SqlConnection conn = Helper.GetConnection())
			{
				using (SqlCommand cmd = new SqlCommand(Constants.StoredProcedures.GroupManager.UpdateGroup, conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@GroupID", group.ID);
					cmd.Parameters.AddWithValue("@Name", group.Name);
					if (group.GeoLatitude.HasValue)
						cmd.Parameters.AddWithValue("@GeoLat", group.GeoLatitude.Value);
					if (group.GeoLongitude.HasValue)
						cmd.Parameters.AddWithValue("@GeoLng", group.GeoLongitude.Value);
					if (!string.IsNullOrEmpty(group.Profile))
						cmd.Parameters.AddWithValue("@Profile", group.Profile);
					if (!string.IsNullOrEmpty(group.PostalCode))
						cmd.Parameters.AddWithValue("@PostalCode", group.PostalCode);

					conn.Open();

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
