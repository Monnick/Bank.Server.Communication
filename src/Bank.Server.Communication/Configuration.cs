using Bank.Server.Communication.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Server.Communication
{
	public class Configuration : IConfiguration
	{
		public int MaxNumberOfTransactions { get; }

		public int MaxRequestSize { get; }

		public TimeSpan MaxTimeDifference { get; }

		public Configuration(int maxNumberOfTransactions, int maxRequestSize, TimeSpan maxTimeDifference)
		{
			MaxNumberOfTransactions = maxNumberOfTransactions;
			MaxRequestSize = maxRequestSize;
			MaxTimeDifference = maxTimeDifference;
		}
	}
}
