using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsResponse : IEbicsResult
	{
		IEbicsResponseHeader Header { get; }
	}
}
