using Bank.Storage.InMemoryDemo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Storage.InMemoryDemo.Domain
{
	class InMemoryStorage
	{
		private static Lazy<InMemoryStorage> _instance = new Lazy<InMemoryStorage>(() => new InMemoryStorage());

		internal static InMemoryStorage Instance
		{
			get { return _instance.Value; }
		}

		private int _orderIDCounter = 0;
		private IList<Transaction> _transactions = new List<Transaction>();

		internal bool ExistsEntity(string key, string value)
		{
			return true;
		}

		internal byte[] CreateTransaction(string host, string partner, string user, int numberOfSegments)
		{
			var transaction = new Transaction(host, partner, user, numberOfSegments, (Guid.NewGuid()).ToByteArray());
			_transactions.Add(transaction);

			return transaction.TransactionID;
		}

		internal void AppendTransactionData(byte[] transactionID, int segmentNumber, object data)
		{
			_transactions.First(t => t.TransactionID.SequenceEqual(transactionID)).AppendTransaction(segmentNumber, data);
		}

		internal int GetNextOrderID()
		{
			return ++_orderIDCounter;
		}
	}
}
