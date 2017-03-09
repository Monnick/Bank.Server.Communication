using Bank.Communication.Application.Contract.Handler;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

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
