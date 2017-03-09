using System.IO;

namespace Bank.Communication.Domain.Contract.Ebics
{
	public interface ISchemaSelector
	{
		Infrastructure.Contract.Ebics.Basic.IEbicsActivity ReadData(Stream data);
	}
}
