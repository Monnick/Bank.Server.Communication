using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Storage.InMemoryDemo.Storage
{
	public class Store<TKey, TContent> where TContent : class
	{
		private IDictionary<TKey, TContent> _data;

		public Store()
		{
			_data = new Dictionary<TKey, TContent>();
		}

		public void Add(TKey key, TContent entity)
		{
			_data.Add(key, entity);
		}

		public TContent Get(TKey key)
		{
			return _data.ContainsKey(key) ? _data[key] : null;
		}

		public void Remove(TKey key)
		{
			_data.Remove(key);
		}
	}
}
