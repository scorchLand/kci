using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DevDev.Extensions
{
	public static class CollectionExtensions
	{
		public static T GetSafe<T>(this IReadOnlyList<T> list, int index) => list.Count <= index ? default : list[index];


		public static TValue Get<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
		{
			dictionary.TryGetValue(key, out TValue result);
			return result;
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
		{
			return list == null || list.Any() == false;
		}


		public static int GetIndex<T>(this IReadOnlyList<T> list, T item) where T : class
		{
			if (list.IsNullOrEmpty())
			{
				return -1;
			}

			for (int i = 0; i < list.Count; i++)
			{
				var target = list[i];
				if (target == item)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
