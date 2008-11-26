using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nom.Common;
using Nom.DataAccess.Managers;
using Nom.DataAccess.Objects;

namespace Nom.Business.Caching
{
	public class GroupCache
	{
		#region Private Properties
		private Dictionary<int, Group> _cacheCollection = new Dictionary<int, Group>();
		private int _cacheHits = 0;
		private int _cacheMisses = 0;
		#endregion

		#region Private Static Properties
		private static GroupCache _instance = new GroupCache();
		#endregion

		#region Public Static Properties
		public static GroupCache Instance
		{
			get
			{
				return _instance;
			}
		}
		#endregion

		public Group Get(int groupId)
		{
			if (_cacheCollection.ContainsKey(groupId))
			{
				_cacheHits++;

				return _cacheCollection[groupId];
			}
			else
			{
				_cacheMisses++;

				try
				{
					Group dbGroup = GroupManager.GetGroup(groupId);

					if (dbGroup != null)
					{
						_cacheCollection.Add(dbGroup.ID.Value, dbGroup);

						return _cacheCollection[groupId];
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
		public void Flush(Nom.DataAccess.Objects.Group group)
		{
			Flush(group.ID.Value);
		}
		public void Flush(int groupId)
		{
			_cacheCollection.Remove(groupId);
		}

		public CacheStatistic Stats()
		{
			CacheStatistic cs = new CacheStatistic();
			cs.Name = "GroupCache";
			cs.Type = typeof(GroupCache);
			cs.Hits = _cacheHits;
			cs.Misses = _cacheMisses;

			return cs;
		}
	}
}
