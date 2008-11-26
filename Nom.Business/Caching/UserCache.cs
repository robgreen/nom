using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Business.Caching
{
	public class UserCache
	{
		#region Private Properties
		private Dictionary<int, User> _cacheCollection = new Dictionary<int, User>();
		private int _cacheHits = 0;
		private int _cacheMisses = 0;
		#endregion

		#region Private Static Properties
		private static UserCache _instance = new UserCache();
		#endregion

		#region Public Static Properties
		public static UserCache Instance
		{
			get
			{
				return _instance;
			}
		}
		#endregion

		public User Get(int userId)
		{
			if (_cacheCollection.ContainsKey(userId))
			{
				_cacheHits++;

				return _cacheCollection[userId];
			}
			else
			{
				_cacheMisses++;

				try
				{
					User dbUser = UserManager.GetUser(userId);

					if (dbUser != null)
					{
						_cacheCollection.Add(dbUser.ID.Value, dbUser);

						return _cacheCollection[userId];
					}
					else
					{
						return null;
					}
				}
				catch
				{
					return null;
				}
			}
		}

		public void Flush()
		{
			_cacheCollection.Clear();
		}
		public void Flush(Nom.DataAccess.Objects.User user)
		{
			Flush(user.ID.Value);
		}
		public void Flush(int userId)
		{
			_cacheCollection.Remove(userId);
		}

		public CacheStatistic Stats()
		{
			CacheStatistic cs = new CacheStatistic();
			cs.Name = "UserCache";
			cs.Type = typeof(UserCache);
			cs.Hits = _cacheHits;
			cs.Misses = _cacheMisses;

			return cs;
		}
	}
}
