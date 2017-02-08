using Bank.Communication.Application.Contract.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

namespace Bank.Communication.Application.Worker
{
	class EbicsRequestWorker : IEbicsRequestWorker
	{
		public IEbicsResult Process(IEbicsActivity activity)
		{
			throw new NotImplementedException();
		}
	}
}
