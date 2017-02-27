using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface IAdministrationStorage
	{
		ActionResult ValidateOrderDetails(IBank bank, IOrderDetails orderDetails);

		ActionResult ValidateBankConfiguration(IBank bank);

		ActionResult ValidateLocalConfiguration(IEbicsRequestHeader header);
	}
}
