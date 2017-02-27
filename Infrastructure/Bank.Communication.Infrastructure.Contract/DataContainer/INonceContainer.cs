using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.DataContainer
{
	public interface INonceContainer
	{
		byte[] Nonce { get; }

		DateTime Timestamp { get; }
	}
}
