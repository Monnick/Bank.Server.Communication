using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract.Storage;
using Bank.Communication.Infrastructure.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Domain.Contract.Storage
{
	public interface IStorageProvider
	{
		IAdministrationStorage Administration { get; }

		INonceStorage Nonces { get; }

		ITransactionStorage Transactions { get; }

		ActionResult StoreRequest(IEbicsRequest activity);

		ActionResult ValidateTransaction(ITransactionIDContainer transactionID);

		ActionResult ValidateRequestHeader(IEbicsRequestHeader header);

		ActionResult ValidateInitialHeader(IInitialHeader header);

		ActionResult AddNonce(INonceContainer nonce, TimeSpan maxTimeDifference);
	}
}
