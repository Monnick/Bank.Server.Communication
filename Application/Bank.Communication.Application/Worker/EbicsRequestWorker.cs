using Bank.Communication.Application.Contract.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Domain.Contract.Storage;

namespace Bank.Communication.Application.Worker
{
	class EbicsRequestWorker : IEbicsRequestWorker
	{
		protected IEbicsActivity Activity { get; private set; }

		protected ITransactionStorage _storage { get; }

		public EbicsRequestWorker(ITransactionStorage storage)
		{
			_storage = storage;
		}

		public void Process(IEbicsActivity activity)
		{
			Activity = activity;
		}

		public IEbicsResult FetchResult()
		{
			return Activity.CreateResult();
		}
	}
}
