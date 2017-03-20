using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

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
		ActionResult Validate(IEbicsRequest request);
	}
}
