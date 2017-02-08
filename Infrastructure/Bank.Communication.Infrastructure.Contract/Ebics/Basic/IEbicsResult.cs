using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public interface IEbicsResult
	{
		ErrorClass ErrorClass { get; }

		EbicsChar EbicsChar { get; }

		Meaning Meaning { get; }

		int ErrorCode { get; }

		string ReturnCode();

		string SymbolicName();

		Stream Content { get; }
	}
}
