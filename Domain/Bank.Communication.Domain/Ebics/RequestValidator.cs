using Bank.Communication.Domain.Contract.Ebics;
using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
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

		public ActionResult Validate(IEbicsRequest request)
		{
			ActionResult result = Provider.ValidateRequestHeader(request.Header);
			if (!result.Success)
				return result;

			if (request.Header.TransactionID != null && request.Header.Nonce == null) // continue transaction
			{
				Infrastructure.Contract.DataContainer.ITransactionIDContainer transactionID = request.Header;

				result = result.Success ? Provider.ValidateTransaction(transactionID) : result;

				return new ActionResult(TechnicalReturnCode.EBICS_OK);
			}
			else if (request.Header.TransactionID == null && request.Header.Nonce != null) // new transaction
			{
				Infrastructure.Contract.Ebics.Composed.IInitialHeader header = request.Header;

				if (result.Success && string.IsNullOrEmpty(header.OrderDetails.OrderID) && header.OrderDetails.IsOrderData())
					result = new ActionResult(TechnicalReturnCode.EBICS_INCOMPATIBLE_ORDER_ATTRIBUTE);

				result = result.Success ? Provider.ValidateInitialHeader(header) : result;

				result = result.Success ? Provider.AddNonce(header, new TimeSpan(6, 0, 0)) : result;

				return new ActionResult(TechnicalReturnCode.EBICS_OK);
			}

			return new ActionResult(TechnicalReturnCode.EBICS_INTERNAL_ERROR);
		}
	}
}
