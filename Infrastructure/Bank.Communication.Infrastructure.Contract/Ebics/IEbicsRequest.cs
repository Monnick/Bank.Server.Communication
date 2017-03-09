using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System.Collections.Generic;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsRequest : IEbicsActivity
	{
		IEbicsRequestHeader Header { get; }

		IEnumerable<IValidationData> FormatValidationData();

		IBank FormBankUser();
	}
}
