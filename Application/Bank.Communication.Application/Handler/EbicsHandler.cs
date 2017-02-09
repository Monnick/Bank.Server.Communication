using Bank.Communication.Application.Contract.Handler;
using Bank.Communication.Application.DependencyInjection;
using Bank.Communication.Domain.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Application.Handler
{
	public class EbicsHandler : IEbicsHandler
	{
		private static Lazy<ISchemaSelector> _selector = new Lazy<ISchemaSelector>(() => new Domain.Ebics.SchemaSelector());
		private static Lazy<Resolver> _resolver = new Lazy<Resolver>(() => new Resolver(null));

		private static ISchemaSelector Selector
		{
			get
			{
				return _selector.Value;
			}
		}

		private static Resolver Resolver
		{
			get
			{
				return _resolver.Value;
			}
		}

		public EbicsHandler()
		{
		}

		public Stream ReadData(Stream transmittedData)
		{
			var activity = Selector.ReadData(transmittedData);

			var worker = Resolver.Resolve(activity);

			var result = worker.Process(activity);

			return new MemoryStream();
		}
	}
}
