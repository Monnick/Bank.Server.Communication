using Bank.Communication.Infrastructure.Contract.Administration;
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
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode OrderDetailsUnlocked(IBank bank, IOrderDetails orderDetails);

		/// <summary>
		/// Checks whether the particular bank/partner/user configuration exists.
		/// </summary>
		/// <param name="bank">The bank configuration to check</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode ExistsBankConfiguration(IBank bank);

		/// <summary>
		/// Stores the user key for further communication.
		/// </summary>
		/// <param name="bank">The bank/partner/user identification to store the key to</param>
		/// <param name="type">The key type to store</param>
		/// <param name="keyContent">The key content</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode AddUserKey(IBank bank, KeyType type, byte[] keyContent);

		/// <summary>
		/// Loads a key from the storage for further action.
		/// </summary>
		/// <param name="bank">The bank/partner/user identification to store the key to</param>
		/// <param name="type">The key type to load</param>
		/// <param name="keyContent">The key content</param>
		/// <returns>An action result with the result state</returns>
		TechnicalReturnCode LoadUserKey(IBank bank, KeyType type, out byte[] keyContent);
	}
}
