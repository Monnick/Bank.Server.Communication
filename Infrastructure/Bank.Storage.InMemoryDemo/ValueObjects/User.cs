using Bank.Communication.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Storage.InMemoryDemo.ValueObjects
{
	public sealed class User
	{
		public string UserID { get; set; }

		public UserState State { get; set; }

		public byte[] Signature { get; private set; }

		public byte[] Authentication { get; private set; }

		public byte[] Encryption { get; private set; }

		public User()
		{ }

		public void AddKey(KeyType type, byte[] key)
		{
			throw new NotImplementedException();
		}
	}
}
