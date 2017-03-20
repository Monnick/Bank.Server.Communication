using Bank.Communication.Infrastructure.Contract.Ebics;

namespace Bank.Communication.Application.Contract.Worker
{
	/// <summary>
	/// Handles all EbicsRequests (i.e. payment requests).
	/// </summary>
	public interface IEbicsRequestWorker : IEbicsWorker<IEbicsRequest>
	{
	}
}
