using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace CSharpCookbook.Src
{
	class ReferencedAssembly : BaseApp
	{
		public override void Run()
		{
			string file = ReflectionUtil.GetProcessPath();
			StringCollection assemblies = new StringCollection();
			ReflectionUtil.BuildDependentAssemblyList(file, assemblies);
			Console.WriteLine($"Assembly {file} has a dependency tree of these assemblies:{ Environment.NewLine} ");
			foreach (string name in assemblies)
			{
				Console.WriteLine($"\t{name}{Environment.NewLine}");
			}

			Console.ReadKey();
		}

		
	}
}
