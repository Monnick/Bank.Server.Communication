using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public interface IEbicsActivity
	{
		Type IdentifingType { get; }

		IEbicsResult CreateResult();
	}
}
