using System.IO;

namespace Bank.Communication.Application.Contract.Handler
{
	/// <summary>
	/// Handle all incoming Ebics requests.
	/// </summary>
	public interface IEbicsHandler
	{
		/// <summary>
		/// Reads the data stream, processes it and returns the response content to the controller.
		/// </summary>
		/// <param name="transmittedData">The request content to process</param>
		/// <returns>The response content</returns>
		Stream ReadData(Stream transmittedData);
	}
}
