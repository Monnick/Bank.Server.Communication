using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Administration
{
	public interface IPartner : IPartnerContainer
	{
		IUser User { get; }
	}
}
