using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nom.Business.Caching
{
	public struct CacheStatistic
	{
		public int Hits
		{
			get;
			set;
		}
		public string HitRate
		{
			get
			{
				float hitRate = 0;

				if (Hits > 0)
				{
					hitRate = ((float)Hits / ((float)Misses + (float)Hits));
				}

				return hitRate.ToString("P");
			}
		}
		public string Name
		{
			get;
			set;
		}
		public Type Type
		{
			get;
			set;
		}
		public int Misses
		{
			get;
			set;
		}
	}
}
