using Bank.Communication.Infrastructure.Contract.Core;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public class ObjectGenerator : BasicGenerator, IObjectGenerator
	{
		private const int ACTIVITY_HINT_START = 32;
		private const int ACTIVITY_HINT_LENGTH = 42;

		public ObjectGenerator()
			: base(typeof(ObjectGenerator).Namespace)
		{ }

		public IEbicsActivity ConvertData(Stream data)
		{
			string hint = data.ReadString(ACTIVITY_HINT_START, ACTIVITY_HINT_LENGTH);
			Type quess = base.ExtractHint(hint);
			XmlSerializer serializer = new XmlSerializer(quess);

			data.Seek(0, SeekOrigin.Begin);
			return serializer.Deserialize(data) as IEbicsActivity;
		}
	}
}
