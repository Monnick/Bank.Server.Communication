using Bank.Communication.Application.Contract.Handler;
using Bank.Communication.Domain.Contract.Ebics;
using System;
using System.IO;

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

			worker.Process(activity);

			var result = worker.FetchResult();

			return new MemoryStream();
		}
	}
}
