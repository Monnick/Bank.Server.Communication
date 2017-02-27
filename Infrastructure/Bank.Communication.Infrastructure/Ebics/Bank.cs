using Bank.Communication.Infrastructure.Contract.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Ebics
{
	public class Bank : IBank
	{
		public string HostID { get; }

		public IPartner Partner { get; }

		public Bank(string hostID, string partnerID, string userID)
		{
			HostID = hostID;

			Partner = new Partner(partnerID, userID);
		}
	}
}
