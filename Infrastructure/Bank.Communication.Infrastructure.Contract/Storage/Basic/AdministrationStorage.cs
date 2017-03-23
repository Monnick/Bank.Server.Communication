using System;
using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Contract.Storage.Basic
{
	public abstract class AdministrationStorage : IAdministrationStorage
	{
		public virtual TechnicalReturnCode ExistsBankConfiguration(IBank bank)
		{
			if (!ExistsBank(bank))
				return TechnicalReturnCode.EBICS_INVALID_HOST_ID;

			if (!ExistsPartner(bank))
				return TechnicalReturnCode.EBICS_PARTNER_ID_MISMATCH;

			if (!ExistsUser(bank))
				return TechnicalReturnCode.EBICS_USER_UNKOWN;

			if (IsUserLocked(bank))
				return TechnicalReturnCode.EBICS_INVALID_USER_OR_STATE;

			return TechnicalReturnCode.EBICS_OK;
		}

		public virtual TechnicalReturnCode OrderDetailsUnlocked(IBank bank, IOrderDetails orderDetails)
		{
			if (!ExistsOrderType(orderDetails))
				return TechnicalReturnCode.EBICS_UNSUPPORTED_ORDER_TYPE;

			if (!IsOrderTypeUnlocked(bank, orderDetails))
				return TechnicalReturnCode.EBICS_INVALID_ORDER_TYPE;

			return TechnicalReturnCode.EBICS_OK;
		}

		/// <summary>
		/// Checks whether the user is registered to this bank.
		/// </summary>
		/// <param name="bank">The bank/partner/user configuration to check</param>
		/// <returns>True if the user exists</returns>
		protected abstract bool ExistsUser(IBank bank);

		/// <summary>
		/// Is the user at the bank configuration unlocked to use the order type?
		/// </summary>
		/// <param name="bank">The bank/partner/user configuration to check</param>
		/// <param name="orderDetails">The order details to check</param>
		/// <returns>True if the user can use the order details</returns>
		protected abstract bool IsOrderTypeUnlocked(IBank bank, IOrderDetails orderDetails);

		/// <summary>
		/// Isn the user locked or any other state forbidden to participate in bank communication?
		/// </summary>
		/// <param name="bank">The bank/partner/user to check</param>
		/// <returns>True if the user is locked or something similar</returns>
		protected abstract bool IsUserLocked(IBank bank);

		/// <summary>
		/// Checks whether the order details configuration exists at this server.
		/// </summary>
		/// <param name="orderDetails">The order details to check</param>
		/// <returns>True if the order details exists</returns>
		protected abstract bool ExistsOrderType(IOrderDetails orderDetails);

		/// <summary>
		/// Checks whether the bank is registered.
		/// </summary>
		/// <param name="bank">The bank/partner/user configuration to check</param>
		/// <returns>True if the bank exists</returns>
		protected abstract bool ExistsBank(IBank bank);

		/// <summary>
		/// Checks whether the partner is registered to this bank.
		/// </summary>
		/// <param name="bank">The bank/partner/user configuration to check</param>
		/// <returns>True if the partner exists</returns>
		protected abstract bool ExistsPartner(IBank bank);

		/// <summary>
		/// Checks whether the user keys already exists.
		/// </summary>
		/// <param name="bank">The bank/partner/user identification to check</param>
		/// <param name="type">The key type to check</param>
		/// <returns>True if the key is stored</returns>
		protected abstract bool ExistsUserKey(IBank bank, KeyType type);

		/// <summary>
		/// Store the user key.
		/// </summary>
		/// <param name="bank">The bank/partner/user identification</param>
		/// <param name="type">The key type to store</param>
		/// <param name="keyContent">The actual key content</param>
		/// <returns>True if the key had been successfully stored</returns>
		protected abstract bool StoreUserKey(IBank bank, KeyType type, byte[] keyContent);

		/// <summary>
		/// Gets the user key from the storage
		/// </summary>
		/// <param name="bank">The bank/partner/user identification</param>
		/// <param name="type">The key type to load</param>
		/// <returns></returns>
		protected abstract byte[] GetUserKey(IBank bank, KeyType type);

		public TechnicalReturnCode AddUserKey(IBank bank, KeyType type, byte[] keyContent)
		{
			var keyExists = ExistsUserKey(bank, type);

			if (!keyExists || IsUserLocked(bank)) // locked user can reinitialize
			{
				if (StoreUserKey(bank, type, keyContent))
					return TechnicalReturnCode.EBICS_OK;

				return TechnicalReturnCode.EBICS_INTERNAL_ERROR;
			}

			return TechnicalReturnCode.EBICS_INVALID_USER_STATE;
		}

		public TechnicalReturnCode LoadUserKey(IBank bank, KeyType type, out byte[] keyContent)
		{
			keyContent = null;

			if (IsUserLocked(bank) || !ExistsUserKey(bank, type))
				return TechnicalReturnCode.EBICS_INVALID_USER_STATE;

			keyContent = GetUserKey(bank, type);

			return TechnicalReturnCode.EBICS_OK;
		}
	}
}
