using Bank.Communication.Infrastructure.Contract.Ebics.Composed;
using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsRequestHeader : IRecurrentHeader, IInitialHeader
	{
	}
}
