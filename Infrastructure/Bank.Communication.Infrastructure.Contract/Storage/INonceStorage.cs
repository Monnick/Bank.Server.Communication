using System;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface INonceStorage
	{
		TechnicalReturnCode AddNonce(byte[] nonce, TimeSpan timeToLive);
	}
}
