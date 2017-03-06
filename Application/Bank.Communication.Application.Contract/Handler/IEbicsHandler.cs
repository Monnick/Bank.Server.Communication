using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Application.Contract.Handler
{
	public interface IEbicsHandler
	{
		Stream ReadData(Stream transmittedData);
	}
}
