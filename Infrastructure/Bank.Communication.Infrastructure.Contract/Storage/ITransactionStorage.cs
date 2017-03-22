using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface ITransactionStorage
	{
		/// <summary>
		/// Prepares storage to contain the transaction
		/// </summary>
		/// <param name="transactionID">The transaction id prepare</param>
		/// <param name="numberOfSegments">the number of segments to prepare the storage for</param>
		TechnicalReturnCode PrepareTransaction(byte[] transactionID, IBank bankUser, int numberOfSegments);

		/// <summary>
		/// Adds a single transaction to an existing transaction
		/// </summary>
		/// <param name="transactionID">The transaction id store</param>
		/// <param name="number">The number of segment to insert the data</param>
		/// <param name="data">The transaction data</param>
		TechnicalReturnCode AddTransactionSegment(byte[] transactionID, IBank bankUser, int number, object data);

		/// <summary>
		/// Closes the transaction, no futher data will be commited
		/// </summary>
		/// <param name="transactionID">The transaction id to close</param>
		TechnicalReturnCode CloseTransaction(byte[] transactionID);

		/// <summary>
		/// Loads a transaction segment (i.e. for transmitting it back to the customer)
		/// </summary>
		/// <param name="transactionID">The transaction id to look for</param>
		/// <param name="number">The segment number to fetch the data from</param>
		/// <returns>The transaction content</returns>
		object LoadTransactionSegment(byte[] transactionID, IBank bankUser, int number);

		/// <summary>
		/// Checks whether a transaction id already exists for this bankUser.
		/// </summary>
		/// <param name="transactionID">The transaction id to look for</param>
		/// <param name="bankUser">The bank user to check</param>
		/// <returns>Whether the transaction id already exists</returns>
		bool TransactionExists(byte[] transactionID, IBank bankUser);
	}
}
