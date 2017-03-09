using System;

namespace Bank.Communication.Infrastructure.Core
{
	public static class XmlPolymorphicArrayHelper
	{
		public static TResult GetItem<TIDentifier, TResult>(TResult[] items, TIDentifier[] itemIdentifiers, TIDentifier itemIdentifier)
		{
			if (itemIdentifiers == null)
			{
				return default(TResult);
			}
			var i = Array.IndexOf(itemIdentifiers, itemIdentifier);
			if (i < 0)
				return default(TResult);
			return items[i];
		}
	}
}
