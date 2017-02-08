using Bank.Communication.Infrastructure.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Domain.Contract.Ebics
{
	public interface ISchemaSelector
	{
		Infrastructure.Contract.Ebics.Basic.IEbicsActivity ReadData(Stream data);
	}
}
