using Bank.Communication.Infrastructure.Contract.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
