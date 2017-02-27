using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract.DataContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsRequestHeader : IHostContainer, ITransactionPhaseContainer, IInitialHeader, ITransactionIDContainer
	{
	}
}
