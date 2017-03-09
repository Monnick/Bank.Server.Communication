using Bank.Communication.Domain.Contract.Storage;
using Bank.Communication.Infrastructure.Contract.Ebics;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;

namespace Bank.Communication.Domain.Contract.Ebics
{
	public interface IRequestValidator
	{
		void SetStorage(IStorageProvider provider);

		ActionResult Validate(IEbicsRequest request);
	}
}
