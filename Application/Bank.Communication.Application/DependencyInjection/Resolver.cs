using Bank.Communication.Application.Contract.Worker;
using Bank.Communication.Infrastructure.Contract.Core;
using Bank.Communication.Infrastructure.Contract.Ebics.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bank.Communication.Application.DependencyInjection
{
	class Resolver
	{
		Dictionary<Type, Type> _types; // first iebicsactivity, second worker

		public Resolver()
		{
			AppDomain domain = new AppDomain(typeof(IEbicsWorker), "Bank.Communication.Application.Worker");
			_types = new Dictionary<Type, Type>();

			var types = domain.ReadTypes().ToDictionary(t => t, t => t.GetInterfaces());

			foreach (var type in types)
			{
				foreach (var inter in type.Value)
				{
					var generics = inter.GetGenericArguments();

					if (generics.Length == 1 && typeof(IEbicsActivity).IsAssignableFrom(generics.First()))
					{
						_types.Add(generics[0], type.Key);
					}
				}
			}
		}

		public IEbicsWorker Resolve(IEbicsActivity activity)
		{
			foreach (var inter in activity.GetType().GetInterfaces())
			{
				if (_types.ContainsKey(inter))
					return Activator.CreateInstance(_types[inter]) as IEbicsWorker;
			}

			return null;
		}
	}
}
