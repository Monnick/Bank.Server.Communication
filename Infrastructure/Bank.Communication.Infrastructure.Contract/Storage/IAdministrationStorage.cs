using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface IAdministrationStorage
	{
		TechnicalReturnCode ValidateOrderDetails(IBank bank, IOrderDetails orderDetails);

		TechnicalReturnCode ValidateBankConfiguration(IBank bank);

		TechnicalReturnCode ValidateLocalConfiguration(IEbicsRequestHeader header);
	}
}
