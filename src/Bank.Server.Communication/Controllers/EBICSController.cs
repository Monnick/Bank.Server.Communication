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
			
			return builder.ToString();
		}

		[HttpPost]
		public void Ebics([FromServices] IEbicsHandler handler)
		{
			MemoryStream stream = new MemoryStream();
			HttpContext.Request.Body.CopyTo(stream);
			stream.Position = 0;
			
			HttpContext.Response.Body = handler.ReadData(stream);
		}
	}
}
