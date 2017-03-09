using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Storage;
using Bank.Storage.InMemoryDemo.Storage;
using Bank.Storage.InMemoryDemo.ValueObjects;
using System;
using Bank.Communication.Infrastructure.Contract;

namespace Bank.Storage.InMemoryDemo.Domain
{
	public class TransactionStorage : ITransactionStorage
	{
		private Lazy<Store<byte[], Transaction>> _store = new Lazy<Store<byte[], Transaction>>(() => new Store<byte[], Transaction>());

		protected Store<byte[], Transaction> Store
		{
			get { return _store.Value; }
		}

		public TechnicalReturnCode AddTransactionSegment(byte[] transactionID, IBank bankUser, int number, object data)
		{
			var entity = Store.Get(transactionID);

			if (entity == null)
				return TechnicalReturnCode.EBICS_TX_UNKOWN_TXID;

			if (entity.NumberOfSegments > entity.NumberOfStoredTransactions)
				return TechnicalReturnCode.EBICS_TX_SEGMENT_NUMBER_EXCEEDED;

			if (entity.NumberOfSegments < entity.NumberOfStoredTransactions)
				return TechnicalReturnCode.EBICS_TX_SEGMENT_NUMBER_UNDERRUN;

			entity.AppendTransaction(number, data);

			return TechnicalReturnCode.EBICS_OK;
		}

		public TechnicalReturnCode CloseTransaction(byte[] transactionID)
		{
			var entity = Store.Get(transactionID);

			if (entity == null)
				return TechnicalReturnCode.EBICS_TX_UNKOWN_TXID;

			if (entity.NumberOfSegments > entity.NumberOfStoredTransactions)
				return TechnicalReturnCode.EBICS_TX_SEGMENT_NUMBER_EXCEEDED;

			if (entity.NumberOfSegments < entity.NumberOfStoredTransactions)
				return TechnicalReturnCode.EBICS_TX_SEGMENT_NUMBER_UNDERRUN;

			return TechnicalReturnCode.EBICS_OK;
		}

		public object LoadTransactionSegment(byte[] transactionID, IBank bankUser, int number)
		{
			var entity = Store.Get(transactionID);

			if (entity == null)
				return new NotImplementedException(TechnicalReturnCode.EBICS_TX_UNKOWN_TXID.ToString());

			if (number > entity.NumberOfStoredTransactions)
				return new NotImplementedException(TechnicalReturnCode.EBICS_TX_SEGMENT_NUMBER_EXCEEDED.ToString());

			if (number < entity.NumberOfStoredTransactions)
				return new NotImplementedException(TechnicalReturnCode.EBICS_TX_SEGMENT_NUMBER_UNDERRUN.ToString());

			return entity.GetTransaction(number);
		}

		public TechnicalReturnCode PrepareTransaction(byte[] transactionID, IBank bankUser, int numberOfSegments)
		{
			var entity = Store.Get(transactionID);

			if (entity != null)
				return TechnicalReturnCode.EBICS_TX_MESSAGE_REPLAY;

			entity = new Transaction(bankUser.HostID, bankUser.Partner.PartnerID, bankUser.Partner.User.UserID, numberOfSegments, transactionID);

			Store.Add(transactionID, entity);

			return TechnicalReturnCode.EBICS_OK;
		}
	}
}
