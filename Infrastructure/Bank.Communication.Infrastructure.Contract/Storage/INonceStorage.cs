using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Storage
{
	public interface INonceStorage
	{
		TechnicalReturnCode AddNonce(byte[] nonce, TimeSpan timeToLive);
	}
}
