namespace Bank.Communication.Infrastructure.Contract.DataContainer
{
	public interface IReturnDataContainer
	{
		string ReturnCode { get; }

		string ReportText { get; }
	}
}
