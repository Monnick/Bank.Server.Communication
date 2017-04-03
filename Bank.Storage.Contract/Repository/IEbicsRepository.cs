using System;
using Bank.Communication.Infrastructure.Ebics.Versions.H004;

namespace Bank.Storage.Contract.Repository
{
	public interface IEbicsRepository: IRepository<ebicsRequest, Guid>
	{
		
	}
}