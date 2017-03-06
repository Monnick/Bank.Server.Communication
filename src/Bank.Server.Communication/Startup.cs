using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Bank.Communication.Application.Contract.Handler;
using SimpleIOC.Configuration;
using SimpleIOC.Contract;

namespace Bank.Server.Communication
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }
		
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
			
			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=EBICS}/{action=Payment}/{id?}");
			});
		}

		private void RegisterConfiguration(IServiceCollection services)
		{
			var config = ReadConfiguration();

			foreach (var registered in config)
			{
				services.AddTransient(registered.ResolveContract(), registered.ResolveImplementation());
			}

			RegisterMinimalConfiguration(services, config);
		}

		private DIConfiguration ReadConfiguration()
		{
			var iocConfig = new DIConfiguration();

			Configuration.GetSection("DIConfiguration").Bind(iocConfig);

			return iocConfig;
		}

		/// <summary>
		/// Registers the minimal configuration to run the service.
		/// </summary>
		/// <param name="services"></param>
		/// <param name="config"></param>
		private void RegisterMinimalConfiguration(IServiceCollection services, DIConfiguration config)
		{
			
		}
	}
}
