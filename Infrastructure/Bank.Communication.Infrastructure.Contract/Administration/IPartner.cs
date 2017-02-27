using Bank.Communication.Infrastructure.Contract.DataContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Administration
{
	public interface IPartner : IPartnerContainer
	{
		IUser User { get; }
	}
}
