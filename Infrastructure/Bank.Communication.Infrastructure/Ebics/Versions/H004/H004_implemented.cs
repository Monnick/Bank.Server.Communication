using Bank.Communication.Infrastructure.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract;
using Bank.Communication.Infrastructure.Core;
using Bank.Communication.Infrastructure.Contract.Ebics.Composed;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public partial class ebicsResponseHeader : IEbicsResponseHeader
	{
		public int NumSegments
		{
			get
			{
				return string.IsNullOrEmpty(mutable?.SegmentNumber?.Value) ? 0 : int.Parse(mutable.SegmentNumber.Value);
			}
		}

		public string ReportText
		{
			get
			{
				return mutable?.ReportText;
			}
		}

		public string ReturnCode
		{
			get
			{
				return mutable?.ReturnCode;
			}
		}

		public byte[] TransactionID
		{
			get
			{
				return @static?.TransactionID;
			}
		}

		public TransactionPhase TransactionPhase
		{
			get
			{
				return (TransactionPhase)mutable?.TransactionPhase;
			}
		}
	}

	public partial class ebicsRequestHeader : IEbicsRequestHeader
	{
		public string HostID
		{
			get
			{
				return @static?.HostID;
			}
		}

		public int NumSegments
		{
			get
			{
				return string.IsNullOrEmpty(mutable?.SegmentNumber?.Value) ? 0 : int.Parse(mutable.SegmentNumber.Value);
			}
		}

		public string PartnerID
		{
			get
			{
				return XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.PartnerID)?.ToString();
			}
		}

		public TransactionPhase TransactionPhase
		{
			get
			{
				return (TransactionPhase)mutable.TransactionPhase;
			}
		}

		public string UserID
		{
			get
			{
				return XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.UserID)?.ToString();
			}
		}

		public IOrderDetails OrderDetails
		{
			get
			{
				return XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.OrderDetails) as IOrderDetails;
			}
		}

		public byte[] Nonce
		{
			get
			{
				return XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.Nonce) as byte[];
			}
		}

		public DateTime Timestamp
		{
			get
			{
				var data = XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.Timestamp);
				return data == null ? DateTime.MinValue : (DateTime)data;
			}
		}

		public byte[] TransactionID
		{
			get
			{
				return XmlPolymorphicArrayHelper.GetItem(@static.Items, @static.ItemsElementName, ItemsChoiceType3.TransactionID) as byte[];
			}
		}
	}

	public partial class StaticHeaderOrderDetailsType : IOrderDetails
	{
		string IOrderDetails.OrderAttribute
		{
			get
			{
				return OrderAttribute.ToString();
			}
		}

		string IOrderDetails.OrderType
		{
			get
			{
				return OrderType?.Value;
			}
		}

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
