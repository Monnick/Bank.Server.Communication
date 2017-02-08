using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Bank.Communication.Domain.Contract.Ebics;
using Bank.Communication.Application.Contract.Handler;
using System.IO;

namespace Bank.Server.Communication.Controllers
{
    public class EBICSController : Controller
	{
		private static Lazy<IEbicsHandler> _handler = new Lazy<IEbicsHandler>(() => new Bank.Communication.Application.Handler.EbicsHandler());

		protected static IEbicsHandler Handler
		{
			get
			{
				return _handler.Value;
			}
		}

		public EBICSController()
        {
        }

        [HttpGet]
        public string Payment()
        {
            const string version = "Version: {0}";

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationName);

            builder.AppendFormat(version, Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion);

			builder.AppendLine("initialized: " + (Handler != null ? "true" : "false"));

            return builder.ToString();
        }

        [HttpPost]
        public void Ebics()
        {
			MemoryStream stream = new MemoryStream();
			HttpContext.Request.Body.CopyTo(stream);
			stream.Position = 0;

			HttpContext.Response.Body = Handler.ReadData(stream);
        }
    }
}
