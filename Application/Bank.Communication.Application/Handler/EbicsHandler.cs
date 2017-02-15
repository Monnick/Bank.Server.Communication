using Bank.Communication.Application.Contract.Handler;
using Bank.Communication.Domain.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Application.Handler
{
	public class EbicsHandler : IEbicsHandler
	{
		protected ISchemaSelector SchemaSelector { get; }

		protected IServiceProvider ServiceProvider { get; }

		public EbicsHandler(ISchemaSelector schemaSelector, IServiceProvider serviceProvider)
		{
			SchemaSelector = schemaSelector;

			ServiceProvider = serviceProvider;
		}

		public Stream ReadData(Stream transmittedData)
		{
			var activity = SchemaSelector.ReadData(transmittedData);

			var worker = ServiceProvider.GetService(activity.IdentifingType) as Contract.Worker.IEbicsWorker;
			
			var result = worker.Process(activity);

			return new MemoryStream();
		}
	}
}
