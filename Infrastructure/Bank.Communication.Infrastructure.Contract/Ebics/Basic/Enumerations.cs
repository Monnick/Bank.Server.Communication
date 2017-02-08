using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public enum ErrorClass
	{
		Info = 0,
		Note = 1,
		Warning = 3,
		Error_recoverable = 6,
		Error_nonrecoverable = 9
	}

	public enum EbicsChar
	{
		NoEbicsCode = 0,
		EbicsCode = 1
	}

	public enum Meaning
	{
		NoGroup = 0,
		TransactionAdministration = 1,
		KeyManagement = 2,
		PreValidation = 3
	}

	public enum TransactionPhase
	{
		Initialization = 0,
		Transfer = 1,
		Receipt = 2
	}
}
