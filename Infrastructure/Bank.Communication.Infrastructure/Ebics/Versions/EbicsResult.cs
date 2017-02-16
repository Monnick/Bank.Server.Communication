using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Ebics.Versions
{
	[Obsolete("Is this class needed?", true)]
	public class EbicsResult : IEbicsResult
	{
		public EbicsChar EbicsChar
		{
			get;
		}

		public ErrorClass ErrorClass
		{
			get;
		}

		public int ErrorCode
		{
			get;
		}

		public Meaning Meaning
		{
			get;
		}

		public Stream Content
		{
			get;
		}

		public EbicsResult(EbicsChar marker, ErrorClass errorClass, Meaning meaning, int code)
		{
			EbicsChar = marker;
			ErrorClass = errorClass;
			Meaning = meaning;
			ErrorCode = code;
		}

		public string ReturnCode()
		{
			return string.Format("{0:00}{1:0}{2:0}{3:00}", ErrorClass, EbicsChar, Meaning, ErrorCode);
		}

		public string SymbolicName()
		{
			throw new NotImplementedException();
		}
	}
}
