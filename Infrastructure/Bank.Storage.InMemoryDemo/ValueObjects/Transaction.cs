using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Storage.InMemoryDemo.ValueObjects
{
	sealed class Transaction
	{
		public string Host { get; }

		public string Partner { get; }

		public string User { get; }

		public byte[] TransactionID { get; }

		public int NumberOfSegments { get; }

		IList<KeyValuePair<int, object>> Transactions { get; }

		public Transaction(string host, string partner, string user, int numberOfSegments, byte[] transactionID)
		{
			Host = host;
			Partner = partner;
			User = user;
			NumberOfSegments = numberOfSegments;
			TransactionID = transactionID;

			Transactions = new List<KeyValuePair<int, object>>();
		}

		public void AppendTransaction(int number, object data)
		{
			Transactions.Add(new KeyValuePair<int, object>(number, data));
		}
	}
}
