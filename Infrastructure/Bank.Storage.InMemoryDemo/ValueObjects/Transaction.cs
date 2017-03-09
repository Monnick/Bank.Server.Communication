using System.Collections.Generic;

namespace Bank.Storage.InMemoryDemo.ValueObjects
{
	public sealed class Transaction
	{
		public string Host { get; }

		public string Partner { get; }

		public string User { get; }

		public byte[] TransactionID { get; }

		public int NumberOfSegments { get; }

		IList<KeyValuePair<int, object>> Transactions { get; }

		public int NumberOfStoredTransactions { get { return Transactions.Count; } }

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

		public object GetTransaction(int number)
		{
			return Transactions[number];
		}
	}
}
