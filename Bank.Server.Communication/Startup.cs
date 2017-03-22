using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LightweightIOC.Configuration;

namespace Bank.Server.Communication
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; }
		
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}
		
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddMvc();

			// Add application services.
			RegisterConfiguration(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();
			
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=EBICS}/{action=Payment}/{id?}");
			});
		}

		/// <summary>
		/// Reads and registers all services from the appsettings file.
		/// </summary>
		/// <param name="services">The services collection to create a dependency dependency injection from .Net core</param>
		private void RegisterConfiguration(IServiceCollection services)
		{
			var config = ReadConfiguration();

			foreach (var registered in config)
			{
				services.AddTransient(registered.ResolveContract(), registered.ResolveImplementation());
			}

			RegisterMinimalConfiguration(services, config);
		}

		/// <summary>
		/// Reads the configuration from the appsettings file.
		/// </summary>
		/// <returns>The services configuration</returns>
		private DIConfiguration ReadConfiguration()
		{
			var iocConfig = new DIConfiguration();

			Configuration.GetSection("DIConfiguration").Bind(iocConfig);

			return iocConfig;
		}

		/// <summary>
		/// Registers the minimal configuration to run the service.
		/// </summary>
		/// <param name="services">The services collection for dependency injection</param>
		/// <param name="config">The configuration to check, which services are already registered</param>
		private void RegisterMinimalConfiguration(IServiceCollection services, DIConfiguration config)
		{
			Type contract = typeof(Bank.Communication.Infrastructure.Contract.Ebics.IEbicsRequest);
			if (!config.IsRegistered(contract))
				services.AddTransient(contract, typeof(Bank.Communication.Application.Worker.EbicsRequestWorker));

			contract = typeof(Bank.Communication.Domain.Contract.Ebics.IRequestValidator);
			if (!config.IsRegistered(contract))
				services.AddTransient(contract, typeof(Bank.Communication.Domain.Ebics.RequestValidator));

			contract = typeof(Bank.Communication.Domain.Contract.Ebics.ISchemaSelector);
			if (!config.IsRegistered(contract))
				services.AddTransient(contract, typeof(Bank.Communication.Domain.Ebics.SchemaSelector));

			contract = typeof(Bank.Communication.Application.Contract.Handler.IEbicsHandler);
			if (!config.IsRegistered(contract))
				services.AddTransient(contract, typeof(Bank.Communication.Application.Handler.EbicsHandler));

			contract = typeof(Bank.Communication.Domain.Contract.Storage.IStorageProvider);
			if (!config.IsRegistered(contract))
				services.AddTransient(contract, typeof(Bank.Communication.Domain.Storage.StorageProvider));
		}
	}
}
