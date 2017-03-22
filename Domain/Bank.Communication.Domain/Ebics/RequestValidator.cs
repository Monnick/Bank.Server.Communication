using Bank.Communication.Domain.Contract.Ebics;
using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using System;

namespace Bank.Communication.Domain.Ebics
{
	public class RequestValidator : IRequestValidator
	{
		protected IStorageProvider Provider { get; private set; }

		public void SetStorage(IStorageProvider provider)
		{
			Provider = provider;
		}
		
		public TechnicalReturnCode Validate(IEbicsRequest request)
		{
			TechnicalReturnCode result = TechnicalReturnCode.EBICS_OK;

			if (request.Header.TransactionID != null && request.Header.Nonce == null) // continue transaction
			{
				result = result != TechnicalReturnCode.EBICS_OK ? ValidateRecurrentHeader(request.Header) : result;

				result = result != TechnicalReturnCode.EBICS_OK ? ValidateTransaction(request.Header) : result;

				return result;
			}
			else if (request.Header.TransactionID == null && request.Header.Nonce != null) // new transaction
			{
				if (string.IsNullOrEmpty(request.Header?.OrderDetails?.OrderID) && request.Header?.OrderDetails?.IsOrderData() == true)
					return TechnicalReturnCode.EBICS_INCOMPATIBLE_ORDER_ATTRIBUTE;

				result = result != TechnicalReturnCode.EBICS_OK ? ValidateInitialHeader(request.Header) : result;

				result = result != TechnicalReturnCode.EBICS_OK ? Provider.AddNonce(request.Header, new TimeSpan(6, 0, 0)) : result;

				return result;
			}

			return TechnicalReturnCode.EBICS_INTERNAL_ERROR;
		}

		public TechnicalReturnCode ValidateTransaction(ITransactionIDContainer transactionID)
		{
			throw new NotImplementedException();
		}

		public TechnicalReturnCode ValidateRecurrentHeader(IRecurrentHeader header)
		{
			throw new NotImplementedException();
		}

		public TechnicalReturnCode ValidateInitialHeader(IInitialHeader header)
		{
			TechnicalReturnCode result = TechnicalReturnCode.EBICS_OK;

			Infrastructure.Ebics.Bank bankData = new Infrastructure.Ebics.Bank(header);

			result = result != TechnicalReturnCode.EBICS_OK ? Provider.Administration.ExistsBankConfiguration(bankData) : result;

			result = result != TechnicalReturnCode.EBICS_OK ? Provider.Administration.OrderDetailsUnlocked(bankData, header?.OrderDetails) : result;

			throw new NotImplementedException();
		}
	}
}
