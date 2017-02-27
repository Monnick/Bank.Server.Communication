using Bank.Communication.Infrastructure.Contract.DataContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Composed
{
	public interface IInitialHeader : IPartnerContainer, IUserContainer, IOrderDetailsContainer, INonceContainer, INumberSegmentContainer
	{
	}
}
