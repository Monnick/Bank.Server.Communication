using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract.Storage;
using System;

namespace Bank.Communication.Domain.Contract.Storage
{
	/// <summary>
	/// Provides access to the storage for persisting a request or requesting data for validation.
	/// </summary>
	public interface IStorageProvider
	{
		/// <summary>
		/// The Administration storage (for user configuration data - i.e. bank data and unlocked order types).
		/// </summary>
		IAdministrationStorage Administration { get; }

		/// <summary>
		/// The nonce are stored for repetition awarness. A nonce is only once allowed within a given time frame.
		/// </summary>
		INonceStorage Nonces { get; }

		/// <summary>
		/// The transactions are persisted this storage for later access by other services or for reading the result which other services generated.
		/// </summary>
		ITransactionStorage Transactions { get; }

		/// <summary>
		/// Stores an EbicsRequest for further proccessing (i.e. by other services).
		/// </summary>
		/// <param name="activity">The request to store</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode StoreRequest(IEbicsRequest activity);
		
		/// <summary>
		/// Adds a nonce to the storage for repetition awarness.
		/// </summary>
		/// <param name="nonce">The nonce data to store</param>
		/// <param name="maxTimeDifference">The time span a nonce is allowed to life</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode AddNonce(INonceContainer nonce, TimeSpan maxTimeDifference);

		/// <summary>
		/// Check whether a transaction id already exists. Attention: A transaction id can be used twice or mire, but only once for each bank!
		/// </summary>
		/// <param name="bank">The bank to initially process the transaction</param>
		/// <param name="transaction">The transaction id container to check</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode TransactionExists(IBank bank, ITransactionIDContainer transaction);

		/// <summary>
		/// Check whether a order detail is unlocked for a bank/partner/user configuration.
		/// </summary>
		/// <param name="bank">The bank/partner/user configuration to look for</param>
		/// <param name="orderDetails">The order detail with detailed information to be unlocked by bank administration</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode IsOrderDetailUnlocked(IBank bank, IOrderDetails orderDetails);
	}
}
