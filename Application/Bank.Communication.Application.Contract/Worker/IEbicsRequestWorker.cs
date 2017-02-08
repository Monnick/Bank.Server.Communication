using Bank.Communication.Infrastructure.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Application.Contract.Worker
{
    public interface IEbicsRequestWorker : IEbicsWorker<IEbicsRequest>
    {
    }
}
