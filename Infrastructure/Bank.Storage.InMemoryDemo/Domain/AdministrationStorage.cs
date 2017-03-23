using System;
using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Storage.InMemoryDemo.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract;

namespace Bank.Storage.InMemoryDemo.Domain
{
	public class AdministrationStorage : Communication.Infrastructure.Contract.Storage.Basic.AdministrationStorage
	{
		private Lazy<Store<string, ValueObjects.Bank>> _store = new Lazy<Store<string, ValueObjects.Bank>>(() => new Store<string, ValueObjects.Bank>());

		protected Store<string, ValueObjects.Bank> Store
		{
			get { return _store.Value; }
		}
		
		protected override bool ExistsBank(IBank bank)
		{
			throw new NotImplementedException();
		}

		protected override bool ExistsOrderType(IOrderDetails orderDetails)
		{
			throw new NotImplementedException();
		}

		protected override bool ExistsPartner(IBank bank)
		{
			throw new NotImplementedException();
		}

		protected override bool ExistsUser(IBank bank)
		{
			throw new NotImplementedException();
		}

		protected override bool ExistsUserKey(IBank bank, KeyType type)
		{
			throw new NotImplementedException();
		}

		protected override byte[] GetUserKey(IBank bank, KeyType type)
		{
			throw new NotImplementedException();
		}

		protected override bool IsOrderTypeUnlocked(IBank bank, IOrderDetails orderDetails)
		{
			throw new NotImplementedException();
		}

		protected override bool IsUserLocked(IBank bank)
		{
			throw new NotImplementedException();
		}

		protected override bool StoreUserKey(IBank bank, KeyType type, byte[] keyContent)
		{
			throw new NotImplementedException();
		}
	}
}
