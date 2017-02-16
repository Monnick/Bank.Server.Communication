using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Domain.Contract.Storage
{
	public interface ITransactionStorage
	{
		void Validate(IEbicsActivity activity);

		void StoreActivity(IEbicsActivity activity);

	}
}
