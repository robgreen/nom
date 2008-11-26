using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nom.DataAccess
{
	public class Constants
	{
		public class ConnectionStrings
		{
			public const string Nom = "NomDB";
		}
		public class StoredProcedures
		{
			public class GroupManager
			{
				public const string AddGroup = "AddGroup";
				public const string AddGroupUser = "AddGroupUser";
				public const string GetGroup = "GetGroup";
				public const string GetGroups = "GetGroups";
				public const string GetUserGroups = "GetUserGroups";
				public const string RemoveGroup = "RemoveGroup";
				public const string RemoveGroupUser = "RemoveGroupUser";
				public const string UpdateGroup = "UpdateGroup";
			}
			public class UserManager
			{
				public const string AddUser = "AddUser";
				public const string GetUser = "GetUser";
				public const string GetUserByEmail = "GetUserByEmail";
				public const string GetUsers = "GetUsers";
				public const string GetUsersByGroup = "GetUsersByGroup";
				public const string RemoveUser = "RemoveUser";
				public const string UpdateUser = "UpdateUser";
				public const string UpdateUserPassword = "UpdateUserPassword";
				public const string ValidateUser = "ValidateUser";
			}
			public class VenueManager
			{
				public const string AddVenue = "AddVenue";
				public const string AddVenueRank = "AddVenueRank";
				public const string GetGroupRecentVenues = "GetGroupRecentVenues";
				public const string GetUserRecentVenues = "GetUserRecentVenues";
				public const string GetVenue = "GetVenue";
				public const string GetVenues = "GetVenues";
				public const string RemoveVenue = "RemoveVenue";
				public const string UpdateVenue = "UpdateVenue";
			}
		}
	}
}
