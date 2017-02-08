using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Bank.Communication.Infrastructure.Contract.Core
{
    public class AppDomain
	{
		private Type _interfaceType;
		private string _namespacePrefix;

		public AppDomain(Type interfaceType, string namespacePrefix)
		{
			_interfaceType = interfaceType;
			_namespacePrefix = namespacePrefix;
		}

		public IEnumerable<Type> ReadTypes()
		{
			return GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => _interfaceType.IsAssignableFrom(p) && p.Namespace.StartsWith(_namespacePrefix));
		}

		private Assembly[] GetAssemblies()
		{
			var assemblies = new List<Assembly>();
			var dependencies = DependencyContext.Default.RuntimeLibraries;
			foreach (var library in dependencies)
			{
				if (IsCandidateCompilationLibrary(library))
				{
					var assembly = Assembly.Load(new AssemblyName(library.Name));
					assemblies.Add(assembly);
				}
			}
			return assemblies.ToArray();
		}

		private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary)
		{
			return compilationLibrary.Name == ("Bank.Communication")
				|| compilationLibrary.Dependencies.Any(d => d.Name.StartsWith("Bank.Communication"));
		}
	}
}
