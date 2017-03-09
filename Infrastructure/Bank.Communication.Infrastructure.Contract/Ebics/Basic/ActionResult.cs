namespace Bank.Communication.Infrastructure.Contract.Ebics.Basic
{
	public sealed class ActionResult
	{
		public TechnicalReturnCode Result { get;}

		public int ErrorCode { get; }

		public string ErrorText { get; }

		public bool Success { get; }
		
		public ActionResult(int errorCode, string errorText)
			: this(false, errorCode, errorText)
		{ }
		public ActionResult(TechnicalReturnCode errorCode)
			: this(errorCode == TechnicalReturnCode.EBICS_OK, (int)errorCode, errorCode.ToString())
		{
			Result = errorCode;
		}
		public ActionResult(bool success, int errorCode, string errorText)
		{
			Result = TechnicalReturnCode.EBICS_INTERNAL_ERROR;
			Success = success;
			ErrorCode = errorCode;
			ErrorText = errorText;
		}
	}
}
