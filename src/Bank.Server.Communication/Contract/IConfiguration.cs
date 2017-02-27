using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Server.Communication.Contract
{
	public interface IConfiguration
	{
		int MaxNumberOfTransactions { get; }

		/// <summary>
		/// Maximal data length in byte
		/// </summary>
		int MaxRequestSize { get; }

		TimeSpan MaxTimeDifference { get; }
	}
}
