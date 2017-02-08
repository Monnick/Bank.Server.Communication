using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsRequest : IEbicsActivity
	{
		IEbicsRequestHeader Header { get; }
	}
}
