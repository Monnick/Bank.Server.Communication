using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface IAdministrationProvider
	{
		bool ExistsHost(string host);

		bool ExistsPartner(string partner);

		bool ExistsUser(string user);

		bool ExistsOrderType(string orderType);

		bool ExistsTransaction(byte[] transaction);
	}
}
