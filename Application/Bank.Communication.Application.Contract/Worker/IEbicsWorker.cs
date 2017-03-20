using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

namespace Bank.Communication.Application.Contract.Worker
{
	/// <summary>
	/// Handles all EbicsActivity objtects received from outside.
	/// </summary>
	public interface IEbicsWorker
	{
		/// <summary>
		/// Process a single EbicsActivity including validation, storages and follow up actions.
		/// </summary>
		/// <param name="activity">The EbicsActivity to process</param>
		void Process(IEbicsActivity activity);

		/// <summary>
		/// Fetches the result from the process activity, from which a respoonse can be generated.
		/// </summary>
		/// <returns>The result information</returns>
		IEbicsResult FetchResult();
	}

	/// <summary>
	/// A more concrete and generic EBics worker to set a single EbicsActivity responsibility.
	/// </summary>
	public interface IEbicsWorker<T> : IEbicsWorker where T : IEbicsActivity
	{
	}
}
