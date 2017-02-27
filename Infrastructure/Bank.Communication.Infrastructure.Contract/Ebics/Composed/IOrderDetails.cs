using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Composed
{
	public interface IOrderDetails
	{
		string OrderType { get; }

		string OrderAttribute { get; }

		string OrderID { get; }

		bool IsOrderData();

		bool IsTechnicalData();
	}
}
