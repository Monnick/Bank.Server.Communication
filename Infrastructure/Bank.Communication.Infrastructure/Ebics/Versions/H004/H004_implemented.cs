using Bank.Communication.Infrastructure.Contract.Ebics;
using System;
using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Core;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public partial class ebicsResponseHeader : IEbicsResponseHeader
	{
		public int NumSegments => string.IsNullOrEmpty(mutable?.SegmentNumber?.Value) ? 0 : int.Parse(mutable.SegmentNumber.Value);

		public string ReportText => mutable?.ReportText;

		public string ReturnCode => mutable?.ReturnCode;

		public byte[] TransactionID => @static?.TransactionID;

		public TransactionPhase TransactionPhase => (TransactionPhase)mutable?.TransactionPhase;
	}

	public partial class ebicsRequestHeader : IEbicsRequestHeader
	{
		public string HostID => @static?.HostID;

		public int NumSegments => string.IsNullOrEmpty(mutable?.SegmentNumber?.Value) ? 0 : int.Parse(mutable.SegmentNumber.Value);

		public string PartnerID => XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.PartnerID)?.ToString();

		public TransactionPhase TransactionPhase => (TransactionPhase)mutable.TransactionPhase;

		public string UserID => XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.UserID)?.ToString();

		public IOrderDetails OrderDetails => XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.OrderDetails) as IOrderDetails;

		public byte[] Nonce => XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.Nonce) as byte[];

		public DateTime Timestamp
		{
			get
			{
				var data = XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.Timestamp);
				return (DateTime?) data ?? DateTime.MinValue;
			}
		}

		public byte[] TransactionID => XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.TransactionID) as byte[];
	}

	public partial class StaticHeaderOrderDetailsType : IOrderDetails
	{
		string IOrderDetails.OrderAttribute => OrderAttribute.ToString();

		string IOrderDetails.OrderType => OrderType?.Value;

		public bool IsOrderData()
		{
			return !IsTechnicalData();
		}

		public bool IsTechnicalData()
		{
			string orderAttributes = OrderAttribute.ToString();
			return orderAttributes.StartsWith("U", StringComparison.OrdinalIgnoreCase);
		}
	}
}
