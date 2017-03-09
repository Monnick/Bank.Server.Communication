using Bank.Communication.Infrastructure.Contract.Ebics;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public partial class ebicsResponse : IEbicsResponse
	{
		public IEbicsResponseHeader Header
		{
			get
			{
				return header;
			}
		}
	}
}
