﻿using Bank.Communication.Infrastructure.Contract.Storage;
using Bank.Storage.InMemoryDemo.Storage;
using Bank.Storage.InMemoryDemo.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Communication.Infrastructure.Ebics.Basic;
using Bank.Communication.Infrastructure.Contract;

namespace Bank.Storage.InMemoryDemo.Domain
{
	public class NonceStorage : INonceStorage
	{
		private Lazy<Store<string, Nonce>> _store = new Lazy<Store<string, Nonce>>(() => new Store<string, Nonce>());

		protected Store<string, Nonce> Store
		{
			get { return _store.Value; }
		}

		public ActionResult AddNonce(byte[] nonce, TimeSpan timeToLive)
		{
			var newNonce = new Nonce(nonce, timeToLive);
			var entity = Store.Get(newNonce.ToString());

			if (entity != null && entity.EndOfLife > DateTime.UtcNow)
			{
				return new ActionResult(TechnicalReturnCode.EBICS_TX_MESSAGE_REPLAY);
			}
			else if (entity != null)
			{
				Store.Remove(entity.ToString());
			}

			Store.Add(newNonce.ToString(), newNonce);
			return new ActionResult(TechnicalReturnCode.EBICS_OK);
		}
	}
}
