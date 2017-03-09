using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract.Storage;
using System;

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
