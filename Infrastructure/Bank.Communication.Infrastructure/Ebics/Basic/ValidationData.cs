using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Ebics.Basic
{
	public class ValidationData : IValidationData
	{
		public string FieldName { get; }

		public object FieldValue { get; }

		public bool Mandatory { get; }

		public ValidationData(string fieldName, object fieldvalue, bool mandatory)
		{
			FieldName = fieldName;
			FieldValue = fieldvalue;
			Mandatory = mandatory;
		}
	}
}
