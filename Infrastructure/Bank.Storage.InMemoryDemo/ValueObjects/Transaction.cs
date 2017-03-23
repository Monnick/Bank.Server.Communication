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

		Dictionary<int, byte[]> Transactions { get; }

		public int NumberOfStoredTransactions { get { return Transactions.Count; } }

		public Transaction(string host, string partner, string user, int numberOfSegments, byte[] transactionID)
		{
			Host = host;
			Partner = partner;
			User = user;
			NumberOfSegments = numberOfSegments;
			TransactionID = transactionID;

			Transactions = new Dictionary<int, byte[]>();
		}

		public void AppendTransaction(int number, byte[] data)
		{
			Transactions.Add(number, data);
		}

		public byte[] GetTransaction(int number)
		{
			return Transactions[number];
		}
	}
}
