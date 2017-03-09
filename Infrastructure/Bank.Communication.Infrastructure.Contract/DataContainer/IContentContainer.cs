using System.IO;

namespace Bank.Communication.Infrastructure.Contract.DataContainer
{
	public interface IContentContainer
	{
		Stream Content { get; }
	}
}
