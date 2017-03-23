using System.Collections.Generic;

namespace Bank.Storage.InMemoryDemo.ValueObjects
{
	public sealed class Bank
	{
		public string HostID { get; set; }

		public List<Partner> Partners { get; set; }

		private byte[] AuthentucationKey_private { get; set; }

		private byte[] AuthentucationKey_public { get; set; }

		private byte[] EncryptionKey_private { get; set; }

		private byte[] EncryptionKey_public { get; set; }

		public Bank()
		{
			Partners = new List<Partner>();
		}
	}
}
