using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.DataContainer
{
	public interface IHostContainer
	{
		string HostID { get; }
	}
}
