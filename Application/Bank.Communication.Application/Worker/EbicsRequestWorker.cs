using Bank.Communication.Application.Contract.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Domain.Contract.Ebics;

namespace Bank.Communication.Application.Worker
{
	class EbicsRequestWorker : IEbicsRequestWorker
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
