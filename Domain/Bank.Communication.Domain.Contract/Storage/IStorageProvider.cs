using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
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
		ActionResult StoreRequest(IEbicsRequest activity);

		/// <summary>
		/// Validates a transaction ID to check, if the ID already exists. 
		/// </summary>
		/// <param name="transactionID">The ID to check</param>
		/// <returns>An action result with the result state</returns>
		ActionResult ValidateTransaction(ITransactionIDContainer transactionID);

		/// <summary>
		/// Validates the header for reccuring data transmittion.
		/// </summary>
		/// <param name="header">The header with all needed information to validate</param>
		/// <returns>An action result with the result state</returns>
		ActionResult ValidateRequestHeader(IEbicsRequestHeader header);

		/// <summary>
		/// Validates an initial header data set, with more data structures than the recurrent header data.
		/// </summary>
		/// <param name="header">The header to validate</param>
		/// <returns>An action result with the result state</returns>
		ActionResult ValidateInitialHeader(IInitialHeader header);

		/// <summary>
		/// Adds a nonce to the storage for repetition awarness.
		/// </summary>
		/// <param name="nonce">The nonce data to store</param>
		/// <param name="maxTimeDifference">The time span a nonce is allowed to life</param>
		/// <returns>An action result with the result state</returns>
		ActionResult AddNonce(INonceContainer nonce, TimeSpan maxTimeDifference);
	}
}
