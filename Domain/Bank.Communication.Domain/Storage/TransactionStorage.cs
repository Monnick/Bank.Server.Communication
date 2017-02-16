using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Domain.Storage
{
	public class TransactionStorage : ITransactionStorage
	{
		protected IAdministrationProvider _admin;

		protected IStorageProvider _storage;

		public TransactionStorage(IAdministrationProvider adminProvider, IStorageProvider storageProvider)
		{
			_admin = adminProvider;
			_storage = storageProvider;
		}

		public void Validate(IEbicsActivity activity)
		{ }

		public void StoreActivity(IEbicsActivity activity)
		{ }
	}
}
