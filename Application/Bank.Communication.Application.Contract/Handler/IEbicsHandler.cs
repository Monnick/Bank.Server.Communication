using System.IO;

namespace Bank.Communication.Application.Contract.Handler
{
	public interface IEbicsHandler
	{
		Stream ReadData(Stream transmittedData);
	}
}
