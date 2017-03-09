using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Administration
{
	public interface IBank : IHostContainer
	{
		IPartner Partner { get; }
	}
}
