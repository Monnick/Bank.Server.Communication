using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Contract.Storage.Basic
{
	public abstract class AdministrationStorage : IAdministrationStorage
	{
		public ActionResult ValidateBankConfiguration(IBank bank)
		{
			if (!ExistsBank(bank))
				return new ActionResult(TechnicalReturnCode.EBICS_INVALID_HOST_ID);

			if (!ExistsPartner(bank))
				return new ActionResult(TechnicalReturnCode.EBICS_PARTNER_ID_MISMATCH);

			if (!ExistsUser(bank))
				return new ActionResult(TechnicalReturnCode.EBICS_USER_UNKOWN);

			if (!IsUserValid(bank))
				return new ActionResult(TechnicalReturnCode.EBICS_INVALID_USER_OR_STATE);

			return new ActionResult(TechnicalReturnCode.EBICS_OK);
		}

		public ActionResult ValidateOrderDetails(IBank bank, IOrderDetails orderDetails)
		{
			if (!ExistsOrderType(orderDetails))
				return new ActionResult(TechnicalReturnCode.EBICS_UNSUPPORTED_ORDER_TYPE);

			if (!IsOrderValid(bank, orderDetails))
				return new ActionResult(TechnicalReturnCode.EBICS_INVALID_ORDER_TYPE);

			return new ActionResult(TechnicalReturnCode.EBICS_OK);
		}

		protected abstract bool ExistsUser(IBank bank);

		protected abstract bool IsUserValid(IBank bank);

		protected abstract bool IsOrderValid(IBank bank, IOrderDetails orderDetails);

		protected abstract bool ExistsOrderType(IOrderDetails orderDetails);

		protected abstract bool ExistsBank(IBank bank);

		protected abstract bool ExistsPartner(IBank bank);

		public abstract ActionResult ValidateLocalConfiguration(IEbicsRequestHeader header);
	}
}
