using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract.Storage;
using System;
using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Contract.Administration;

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

		public TechnicalReturnCode StoreRequest(IEbicsRequest activity)
		{
			throw new NotImplementedException();
		}

		public TechnicalReturnCode AddNonce(INonceContainer nonce, TimeSpan maxTimeDifference)
		{
			throw new NotImplementedException();
		}

		public bool TransactionExists(IBank bank, ITransactionIDContainer transaction)
		{
			return Transactions.TransactionExists(transaction.TransactionID, bank);
		}

		public TechnicalReturnCode IsOrderDetailUnlocked(IBank bank, IOrderDetails orderDetails)
		{
			throw new NotImplementedException();
		}
	}
}
