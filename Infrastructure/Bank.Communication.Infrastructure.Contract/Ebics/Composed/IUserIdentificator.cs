using Bank.Communication.Infrastructure.Contract.Ebics.DataContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Composed
{
    public interface IUserIdentificator : IHostContainer, IPartnerContainer, IUserContainer
    {
    }
}
