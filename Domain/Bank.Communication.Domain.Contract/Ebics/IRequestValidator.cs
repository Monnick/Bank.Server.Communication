using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Domain.Contract.Ebics
{
	public interface IRequestValidator
	{
		void SetStorage(IStorageProvider provider);

		ActionResult Validate(IEbicsRequest request);
	}
}
