using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	/// <summary>
	/// Allows the access to the bank configuration with partner, user and order details.
	/// </summary>
	public interface IAdministrationStorage
	{
		/// <summary>
		/// Checks whether the order details are unlocked for a particular bank/partner/user configuration.
		/// </summary>
		/// <param name="bank">The bank configuration to check</param>
		/// <param name="orderDetails">The order details information to verify</param>
		/// <returns></returns>
		TechnicalReturnCode OrderDetailsUnlocked(IBank bank, IOrderDetails orderDetails);

		/// <summary>
		/// Checks whether the particular bank/partner/user configuration exists.
		/// </summary>
		/// <param name="bank">The bank configuration to check</param>
		/// <returns></returns>
		TechnicalReturnCode ExistsBankConfiguration(IBank bank);
	}
}
