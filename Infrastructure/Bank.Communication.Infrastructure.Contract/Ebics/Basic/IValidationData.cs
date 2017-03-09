namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public interface IValidationData
	{
		string FieldName { get; }

		object FieldValue { get; }

		bool Mandatory { get; }
	}
}
