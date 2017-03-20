using System.IO;

namespace Bank.Communication.Domain.Contract.Ebics
{
	/// <summary>
	/// Selects a schema and calls the object generator for an unkown Ebics request.
	/// </summary>
	public interface ISchemaSelector
	{
		/// <summary>
		/// Reads the first characters of the data stream and decides which shema it can be. Afterwards an object generator is called to create the concrete IEbicsActivity-implementation.
		/// </summary>
		/// <param name="data">The http request content</param>
		/// <returns>The conrete IEbicsActivity implementation choosen by the first characters</returns>
		Infrastructure.Contract.Ebics.Basic.IEbicsActivity ReadData(Stream data);
	}
}
