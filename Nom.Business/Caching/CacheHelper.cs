using System;
using System.Collections.Generic;
using Nom.DataAccess.Objects;

namespace Nom.Business.Caching
{
	public class CacheHelper
	{
		public static Group GetGroup(int groupId)
		{
			return GroupCache.Instance.Get(groupId);
		}
		public static User GetUser(int userId)
		{
			return UserCache.Instance.Get(userId);
		}
		public static List<CacheStatistic> Stats()
		{
			List<CacheStatistic> stats = new List<CacheStatistic>();
			stats.Add(GroupCache.Instance.Stats());
			stats.Add(UserCache.Instance.Stats());

			return stats;
		}
	}
}
