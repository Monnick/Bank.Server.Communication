using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Domain.Storage;
using Bank.Communication.Infrastructure.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Domain.Storage
{
	public class StorageProvider : IStorageProvider
	{
		public IAdministrationStorage Administration { get; }

		public INonceStorage Nonces { get; }

		public ITransactionStorage Transactions { get; }

		public StorageProvider(IAdministrationStorage administration, INonceStorage nonces, ITransactionStorage transactions)
		{
			Administration = administration;
			Nonces = nonces;
			Transactions = transactions;
		}

		public ActionResult StoreRequest(IEbicsRequest activity)
		{
			throw new NotImplementedException();
		}

		public ActionResult ValidateTransaction(ITransactionIDContainer transactionID)
		{
			throw new NotImplementedException();
		}

		public ActionResult ValidateRequestHeader(IEbicsRequestHeader header)
		{
			throw new NotImplementedException();
		}

		public ActionResult ValidateInitialHeader(IInitialHeader header)
		{
			throw new NotImplementedException();
		}

		public ActionResult AddNonce(INonceContainer nonce, TimeSpan maxTimeDifference)
		{
			throw new NotImplementedException();
		}
	}
}
