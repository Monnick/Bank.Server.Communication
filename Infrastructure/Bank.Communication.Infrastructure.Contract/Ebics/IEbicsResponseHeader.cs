using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Ebics
{
	public interface IEbicsResponseHeader : ITransactionPhaseContainer, ITransactionIDContainer, INumberSegmentContainer, IReturnDataContainer
	{
	}
}
