using Bank.Communication.Infrastructure.Contract.Administration;

namespace Bank.Communication.Infrastructure.Ebics
{
	public class User : IUser
	{
		public string UserID { get; }

		public User(string userID)
		{
			UserID = userID;
		}
	}
}
