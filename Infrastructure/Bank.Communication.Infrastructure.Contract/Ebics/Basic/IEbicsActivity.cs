using System;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public interface IEbicsActivity
	{
		Type IdentifingType { get; }

		IEbicsResult CreateResult();
	}
}
