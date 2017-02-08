﻿using Bank.Communication.Infrastructure.Contract.Ebics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using Bank.Communication.Infrastructure.Core;

namespace Bank.Communication.Infrastructure.Ebics.Versions.H004
{
	public partial class ebicsRequest : IEbicsRequest
	{
		public IEbicsRequestHeader Header
		{
			get
			{
				return header;
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
				return string.IsNullOrEmpty(mutable.SegmentNumber.Value) ? 0 : int.Parse(mutable.SegmentNumber.Value);
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
	}
}
