using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using CSharpCookbook.Src.Reflection.Utils;

namespace CSharpCookbook.Src.Reflection.Demos
{
	class ReferencedAssembly : BaseApp
	{
		public override void Test() { }

		public override void Run()
		{
			string file = ReflectionUtils.GetProcessPath();
			StringCollection assemblies = new StringCollection();
			ReflectionUtils.BuildDependentAssemblyList(file, assemblies);
			Console.WriteLine($"Assembly {file} has a dependency tree of these assemblies:{ Environment.NewLine} ");
			foreach (string name in assemblies)
			{
				Console.WriteLine($"\t{name}{Environment.NewLine}");
			}

			Console.ReadKey();
		}

		
	}
}
