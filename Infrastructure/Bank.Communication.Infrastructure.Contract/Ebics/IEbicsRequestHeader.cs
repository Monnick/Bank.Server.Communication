using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsRequestHeader
	{
		string HostID { get; }

		string PartnerID { get; }

		string UserID { get; }

		TransactionPhase TransactionPhase { get; }

		int NumSegments { get; }

		IOrderDetails OrderDetails { get; }
	}
}
