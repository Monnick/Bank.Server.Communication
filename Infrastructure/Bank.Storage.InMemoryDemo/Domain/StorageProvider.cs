using Bank.Communication.Infrastructure.Contract.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Storage.InMemoryDemo.Domain
{
	public class StorageProvider : IStorageProvider
	{
		public void AppendSegment(byte[] transactionID, int segmentNumber, object data)
		{
			InMemoryStorage.Instance.AppendTransactionData(transactionID, segmentNumber, data);
		}

		public string GetNextOrderID()
		{
			return InMemoryStorage.Instance.GetNextOrderID().ToString("XX{D2}");
		}

		public byte[] PrepareTransaction(string host, string partner, string user, int numberOfSegments)
		{
			return InMemoryStorage.Instance.CreateTransaction(host, partner, user, numberOfSegments);
		}
	}
}
