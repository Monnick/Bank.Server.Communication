using Bank.Communication.Infrastructure.Contract.Administration;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Ebics
{
	public class Bank : IBank
	{
		public string HostID { get; }

		public IPartner Partner { get; }

		public Bank(IInitialHeader header)
			: this(header?.HostID, header?.PartnerID, header?.UserID)
		{ }

		public Bank(string hostID, string partnerID, string userID)
		{
			HostID = hostID;

			Partner = new Partner(partnerID, userID);
		}
	}
}
