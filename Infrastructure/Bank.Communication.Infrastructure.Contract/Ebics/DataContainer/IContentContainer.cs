﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Ebics.DataContainer
{
	public interface IContentContainer
	{
		Stream Content { get; }
	}
}
