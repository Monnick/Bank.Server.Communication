using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Application.Contract.Handler
{
	public interface IEbicsHandler
	{
		void SetMaxNumberOfTranscations(int number);

		void SetMaxRequestSize(int size);

		Stream ReadData(Stream transmittedData);
	}
}
