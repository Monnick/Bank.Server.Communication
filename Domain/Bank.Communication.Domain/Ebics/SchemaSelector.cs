using Bank.Communication.Domain.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System.Xml.Serialization;
using System.IO;
using Bank.Communication.Infrastructure.Core;

namespace Bank.Communication.Domain.Ebics
{
	public class SchemaSelector : ISchemaSelector
	{
		private const int SCHEMA_HINT_START = 55;
		private const int SCHEMA_HINT_LENGTH = 42;
		private Dictionary<string, IObjectGenerator> _generators;

		public SchemaSelector()
		{
			_generators = new Dictionary<string, IObjectGenerator>();

			_generators.Add("H004", new Infrastructure.Ebics.Versions.H004.ObjectGenerator());
		}

		public IEbicsActivity ReadData(Stream data)
		{
			string quess = data.ReadString(SCHEMA_HINT_START, SCHEMA_HINT_LENGTH);

			foreach (var generator in _generators)
			{
				if (quess.Contains(generator.Key))
					return generator.Value.ConvertData(data);
			}

			return null;
		}
	}
}
