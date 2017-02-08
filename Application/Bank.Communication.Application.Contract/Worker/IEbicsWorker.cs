using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Application.Contract.Worker
{
	public interface IEbicsWorker
	{
		IEbicsResult Process(IEbicsActivity activity);
	}

	public interface IEbicsWorker<T> : IEbicsWorker where T : IEbicsActivity
	{
	}
}
