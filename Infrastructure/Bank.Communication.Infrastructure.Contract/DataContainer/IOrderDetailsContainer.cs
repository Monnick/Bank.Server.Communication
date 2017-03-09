using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Contract.DataContainer
{
	public interface IOrderDetailsContainer
	{
		IOrderDetails OrderDetails { get; }
	}
}
