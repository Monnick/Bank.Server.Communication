using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface IStorageProvider
	{
		string GetNextOrderID();

		byte[] PrepareTransaction(string host, string partner, string user, int numberOfSegments);

		void AppendSegment(byte[] transactionID, int segmentNumber, object data);
	}
}
