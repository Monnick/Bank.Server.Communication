using Bank.Communication.Infrastructure.Contract.Core;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Ebics.Versions
{
    public class BasicGenerator
    {
		private Dictionary<string, Type> _types;
		
		protected BasicGenerator(string namespacePrefix)
		{
			AppDomain app = new AppDomain(typeof(IEbicsActivity), namespacePrefix);

			_types = new Dictionary<string, Type>();
			foreach (var type in app.ReadTypes())
			{
				_types.Add(type.Name.ToLower(), type);
			}
		}

		protected Type ResolveType(string name)
		{
			return _types.ContainsKey(name) ? _types[name] : null;
		}

		protected Type ExtractHint(string quest)
		{
			int startIndex = quest.IndexOf('<', 3) + 1;

			if (startIndex > 0)
			{
				int endIndex = quest.IndexOfAny(new char[] { ' ', '>', '\r', '\n' }, startIndex);
				
				if (endIndex < startIndex)
					return null;

				string quess = quest.Substring(startIndex, endIndex - startIndex)?.ToLower();

				if (_types.ContainsKey(quess))
					return _types[quess];
			}

			return null;
		}
	}
}
