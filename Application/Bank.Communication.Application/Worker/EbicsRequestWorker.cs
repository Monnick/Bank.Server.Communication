using Bank.Communication.Application.Contract.Worker;
using Bank.Communication.Domain.Contract.Ebics;
using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

namespace Bank.Communication.Application.Worker
{
	public class EbicsRequestWorker : IEbicsRequestWorker
	{
		protected IEbicsRequest Activity { get; private set; }

		protected IRequestValidator Validator { get; }

		public EbicsRequestWorker(IRequestValidator validator, IStorageProvider provider)
		{
			Validator = validator;
			Validator.SetStorage(provider);
		}

		public void Process(IEbicsActivity activity)
		{
			Activity = activity as IEbicsRequest;
		}

		public IEbicsResult FetchResult()
		{
			var validationResult = Validator.Validate(Activity);

			return Activity.CreateResult();
		}
	}
}
