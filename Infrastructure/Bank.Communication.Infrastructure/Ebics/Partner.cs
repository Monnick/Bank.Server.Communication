using Bank.Communication.Infrastructure.Contract.Administration;

namespace Bank.Communication.Infrastructure.Ebics
{
	public class Partner : IPartner
	{
		public string PartnerID { get; }

		public IUser User { get; }

		public Partner(string partnerID, string userID)
		{
			PartnerID = partnerID;

			User = new User(userID);
		}
	}
}
