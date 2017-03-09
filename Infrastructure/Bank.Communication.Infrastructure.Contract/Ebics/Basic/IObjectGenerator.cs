using System.IO;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public interface IObjectGenerator
    {
		IEbicsActivity ConvertData(Stream data);
    }
}
