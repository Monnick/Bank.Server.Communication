using Bank.Communication.Infrastructure.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public partial class ebicsResponse : IEbicsResponse
	{
		public IEbicsResponseHeader Header
		{
			get
			{
				return header;
			}
		}
	}
}
