using System;
using System.Linq;

namespace Bank.Storage.InMemoryDemo.ValueObjects
{
	public class Nonce
    {
		public byte[] Value { get; }

		public DateTime EndOfLife { get; }

		public Nonce(byte[] value, TimeSpan timeToLive)
		{
			Value = value;

			EndOfLife = DateTime.UtcNow + timeToLive;
		}

		public override string ToString()
		{
			return string.Join(" ", Value.Select(v => v.ToString("X")));
		}
	}
}
