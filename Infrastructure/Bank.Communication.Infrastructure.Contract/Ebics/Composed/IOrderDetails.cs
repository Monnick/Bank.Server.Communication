namespace Bank.Communication.Infrastructure.Contract.Ebics.Composed
{
	public interface IOrderDetails
	{
		string OrderType { get; }

		string OrderAttribute { get; }

		string OrderID { get; }

		bool IsOrderData();

		bool IsTechnicalData();
	}
}
