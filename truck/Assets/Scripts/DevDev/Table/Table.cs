using System.Collections;
using System.Collections.Generic;
using OPS.Serialization.IO;
using UnityEngine;

namespace DevDev.Table
{
	public class Table<TRow, TKey> : IEnumerable<TRow>
		where TRow : class, IRow<TKey>
	{

		public IReadOnlyList<TRow> List => _list;
		public IReadOnlyDictionary<TKey, TRow> Dictionary => _dictionary;
		public int Count => _list.Count;

		private readonly List<TRow> _list = new List<TRow>();
		private readonly Dictionary<TKey, TRow> _dictionary = new Dictionary<TKey, TRow>();


		public TRow Get(TKey key)
		{
			_dictionary.TryGetValue(key, out var row);
			return row;
		}

		public bool ContainsKey(TKey key)
		{
			return _dictionary.ContainsKey(key);
		}

		public TRow ElementAt(int index) => _list.Count > index ? _list[index] : null;

		public IEnumerator<TRow> GetEnumerator() => _list.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

		public void LoadFromResources(string path)
		{
			var asset = Resources.Load<TextAsset>(path);
			LoadFromBinary(asset.bytes);
		}

		public void LoadFromPath(string path)
		{
			byte[] bytes = System.IO.File.ReadAllBytes(path);
			LoadFromBinary(bytes);
		}

		public void LoadFromBinary(byte[] bytes)
		{
			var rows = Serializer.DeSerialize<List<TRow>>(bytes, _Decrypt: true, _DecryptionKey: TableManager.SECURE_KEY);
			Load(rows);
		}

		public void Load(IReadOnlyList<TRow> rows)
		{
			_list.Clear();
			_list.AddRange(rows);

			_dictionary.Clear();
			foreach (var row in _list)
			{
				_dictionary.Add(row.Key, row);
			}

			for (int i = 0; i < _list.Count; i++)
			{
				var row = _list[i];
				row.Index = i;
			}

			OnAfterLoad();
		}

		protected virtual void OnAfterLoad()
		{

		}
	}
}
