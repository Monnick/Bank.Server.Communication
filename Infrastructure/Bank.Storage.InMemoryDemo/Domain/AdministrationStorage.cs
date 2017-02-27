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
	public class AdministrationStorage : IAdministrationStorage
	{
		private Lazy<Store<string, IBank>> _store = new Lazy<Store<string, IBank>>(() => new Store<string, IBank>());

		protected Store<string, IBank> Store
		{
			get { return _store.Value; }
		}

		public ActionResult ValidateBankConfiguration(IBank bank)
		{
			var entity = Store.Get(bank.HostID);

			if (entity == null)
				return new ActionResult(TechnicalReturnCode.EBICS_INVALID_HOST_ID);

			if (entity?.Partner?.PartnerID != bank?.Partner?.PartnerID)
				return new ActionResult(TechnicalReturnCode.EBICS_PARTNER_ID_MISMATCH);

			if (entity?.Partner?.User?.UserID != entity?.Partner?.User?.UserID)
				return new ActionResult(TechnicalReturnCode.EBICS_USER_UNKOWN);

			return new ActionResult(TechnicalReturnCode.EBICS_OK);
		}

		public ActionResult ValidateLocalConfiguration(IEbicsRequestHeader header)
		{
			return new ActionResult(TechnicalReturnCode.EBICS_OK);
		}

		public ActionResult ValidateOrderDetails(IBank bank, IOrderDetails orderDetails)
		{
			return new ActionResult(TechnicalReturnCode.EBICS_OK);
		}
	}
}
