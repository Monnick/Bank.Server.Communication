using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Domain.Contract.Ebics
{
	/// <summary>
	/// Validates an EbicsRequest.
	/// </summary>
	public interface IRequestValidator
	{
		/// <summary>
		/// Sets the storage provider for accessing the persistent data.
		/// </summary>
		/// <param name="provider">The storage provider to use</param>
		void SetStorage(IStorageProvider provider);

		/// <summary>
		/// Validates an EbicsRequest and returns the validation result.
		/// </summary>
		/// <param name="request">The EbicsRequest to validate</param>
		/// <returns>The validation result</returns>
		TechnicalReturnCode Validate(IEbicsRequest request);

		/// <summary>
		/// Checks whether the transaction id is already used.
		/// </summary>
		/// <param name="transactionID">The transaction id to check</param>
		/// <returns>The validation result</returns>
		TechnicalReturnCode ValidateTransaction(ITransactionIDContainer transactionID);

		/// <summary>
		/// Validates a recurrent header for transaction segments after the initial communication.
		/// </summary>
		/// <param name="header">The header data to validate</param>
		/// <returns>The validation result</returns>
		TechnicalReturnCode ValidateRecurrentHeader(IRecurrentHeader header);

		/// <summary>
		/// Validates an initial header for new transactions (i.e. checks whether the user is allowed to initiate this transaction).
		/// </summary>
		/// <param name="header">The initial header data</param>
		/// <returns>The validation result</returns>
		TechnicalReturnCode ValidateInitialHeader(IInitialHeader header);
	}
}
