using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

namespace Bank.Communication.Application.Contract.Worker
{
	public interface IEbicsWorker
	{
		void Process(IEbicsActivity activity);

		IEbicsResult FetchResult();
	}

	public interface IEbicsWorker<T> : IEbicsWorker where T : IEbicsActivity
	{
	}
}
