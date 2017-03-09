using Bank.Communication.Infrastructure.Contract.DataContainer;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Composed
{
	public interface IInitialHeader : IPartnerContainer, IUserContainer, IOrderDetailsContainer, INonceContainer, INumberSegmentContainer
	{
	}
}
