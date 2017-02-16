using Bank.Communication.Infrastructure.Contract.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Storage.InMemoryDemo.Domain
{
	public class AdministrationProvider : IAdministrationProvider
	{
		public bool ExistsHost(string host)
		{
			return InMemoryStorage.Instance.ExistsEntity("host", host);
		}

		public bool ExistsOrderType(string orderType)
		{
			return InMemoryStorage.Instance.ExistsEntity("orderType", orderType);
		}

		public bool ExistsPartner(string partner)
		{
			return InMemoryStorage.Instance.ExistsEntity("partner", partner);
		}

		public bool ExistsTransaction(byte[] transaction)
		{
			return true;
		}

		public bool ExistsUser(string user)
		{
			return InMemoryStorage.Instance.ExistsEntity("user", user);
		}
	}
}
