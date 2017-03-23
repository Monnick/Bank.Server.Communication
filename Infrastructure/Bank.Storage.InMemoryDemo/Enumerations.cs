using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Storage.InMemoryDemo
{
	public enum UserState
	{
		Created,
		Signaturereceived,
		AuthenticationReceived,
		EncryptionReceived,
		Ready,
		Locked
	}
}
