using System;

namespace Bank.Communication.Infrastructure.Contract.DataContainer
{
	public interface INonceContainer
	{
		byte[] Nonce { get; }

		DateTime Timestamp { get; }
	}
}
