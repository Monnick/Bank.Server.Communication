using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Storage.InMemoryDemo.ValueObjects
{
	public sealed class Partner
	{
		public string PartnerID { get; set; }

		public List<User> Users { get; set; }

		public Partner()
		{
			Users = new List<User>();
		}
	}
}
