using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using Bank.Communication.Infrastructure.Contract.Administration;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public partial class ebicsRequest : IEbicsRequest
	{
		public IEbicsRequestHeader Header
		{
			get
			{
				return header;
			}
		}

		public Type IdentifingType
		{
			get
			{
				return typeof(IEbicsRequest);
			}
		}

		public IEnumerable<IValidationData> FormatValidationData()
		{
			throw new NotImplementedException();
		}

		public IEbicsResult CreateResult()
		{
			throw new NotImplementedException();
		}

		public IBank FormBankUser()
		{
			return new Bank(Header.HostID, Header.PartnerID, Header.UserID);
		}
	}
}
