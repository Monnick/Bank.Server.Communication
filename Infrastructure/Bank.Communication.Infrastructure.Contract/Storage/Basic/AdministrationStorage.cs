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
		public TechnicalReturnCode ValidateBankConfiguration(IBank bank)
		{
			if (!ExistsBank(bank))
				return TechnicalReturnCode.EBICS_INVALID_HOST_ID;

			if (!ExistsPartner(bank))
				return TechnicalReturnCode.EBICS_PARTNER_ID_MISMATCH;

			if (!ExistsUser(bank))
				return TechnicalReturnCode.EBICS_USER_UNKOWN;

			if (!IsUserValid(bank))
				return TechnicalReturnCode.EBICS_INVALID_USER_OR_STATE;

			return TechnicalReturnCode.EBICS_OK;
		}

		public TechnicalReturnCode ValidateOrderDetails(IBank bank, IOrderDetails orderDetails)
		{
			if (!ExistsOrderType(orderDetails))
				return TechnicalReturnCode.EBICS_UNSUPPORTED_ORDER_TYPE;

			if (!IsOrderValid(bank, orderDetails))
				return TechnicalReturnCode.EBICS_INVALID_ORDER_TYPE;

			return TechnicalReturnCode.EBICS_OK;
		}

		protected abstract bool ExistsUser(IBank bank);

		protected abstract bool IsUserValid(IBank bank);

		protected abstract bool IsOrderValid(IBank bank, IOrderDetails orderDetails);

		protected abstract bool ExistsOrderType(IOrderDetails orderDetails);

		protected abstract bool ExistsBank(IBank bank);

		protected abstract bool ExistsPartner(IBank bank);

		public abstract TechnicalReturnCode ValidateLocalConfiguration(IEbicsRequestHeader header);
	}
}
