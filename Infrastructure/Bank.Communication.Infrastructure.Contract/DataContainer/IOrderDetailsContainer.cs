using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.DataContainer
{
	public interface IOrderDetailsContainer
	{
		IOrderDetails OrderDetails { get; }
	}
}
