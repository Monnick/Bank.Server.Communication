using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Composed
{
	public interface IRecurrentHeader : IHostContainer, ITransactionPhaseContainer, ITransactionIDContainer
	{
	}
}