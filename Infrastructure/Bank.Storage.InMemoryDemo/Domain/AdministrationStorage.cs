using Bank.Communication.Infrastructure.Contract.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Storage.InMemoryDemo.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract;

namespace Bank.Storage.InMemoryDemo.Domain
{
	public class AdministrationStorage : Communication.Infrastructure.Contract.Storage.Basic.AdministrationStorage
	{
		private Lazy<Store<string, IBank>> _store = new Lazy<Store<string, IBank>>(() => new Store<string, IBank>());

		protected Store<string, IBank> Store
		{
			get { return _store.Value; }
		}

		public override TechnicalReturnCode ValidateLocalConfiguration(IEbicsRequestHeader header)
		{
			throw new NotImplementedException();
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

		protected override bool IsOrderValid(IBank bank, IOrderDetails orderDetails)
		{
			throw new NotImplementedException();
		}

		protected override bool IsUserValid(IBank bank)
		{
			throw new NotImplementedException();
		}
	}
}
