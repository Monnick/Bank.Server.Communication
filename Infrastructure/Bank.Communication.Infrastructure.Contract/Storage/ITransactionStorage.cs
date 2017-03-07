using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface ITransactionStorage
	{
		/// <summary>
		/// Prepares storage to contain the transaction
		/// </summary>
		/// <param name="transactionID"></param>
		/// <param name="numberOfSegments"></param>
		TechnicalReturnCode PrepareTransaction(byte[] transactionID, IBank bankUser, int numberOfSegments);

		/// <summary>
		/// Adds a single transaction to an existing transaction
		/// </summary>
		/// <param name="transactionID"></param>
		/// <param name="number"></param>
		/// <param name="data"></param>
		TechnicalReturnCode AddTransactionSegment(byte[] transactionID, IBank bankUser, int number, object data);

		/// <summary>
		/// Closes the transaction, no futher data will be commited
		/// </summary>
		/// <param name="transactionID"></param>
		TechnicalReturnCode CloseTransaction(byte[] transactionID);

		/// <summary>
		/// Loads a transaction segment (i.e. for transmitting it back to the customer)
		/// </summary>
		/// <param name="transactionID"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		object LoadTransactionSegment(byte[] transactionID, IBank bankUser, int number);
	}
}
