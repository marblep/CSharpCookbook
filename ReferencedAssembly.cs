using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace CSharpCookbook.Src
{
	class ReferencedAssembly : BaseApp
	{
		public override void Run()
		{
			string file = GetProcessPath();
			StringCollection assemblies = new StringCollection();
			BuildDependentAssemblyList(file, assemblies);
			Console.WriteLine($"Assembly {file} has a dependency tree of these assemblies:{ Environment.NewLine} ");
			foreach (string name in assemblies)
			{
				Console.WriteLine($"\t{name}{Environment.NewLine}");
			}

			Console.ReadKey();
		}

		public static void BuildDependentAssemblyList(string path, StringCollection assemblies)
		{
			// maintain a list of assemblies the original one needs
			if (assemblies == null)
				assemblies = new StringCollection();
			// have we already seen this one?
			if (assemblies.Contains(path) == true)
				return;
			try
			{
				Assembly asm = null;
				// look for common path delimiters in the string
				// to see if it is a name or a path
				if ((path.IndexOf(@"\", 0, path.Length, StringComparison.Ordinal) != -1) ||
				(path.IndexOf("/", 0, path.Length, StringComparison.Ordinal) != -1))
				{
					// load the assembly from a path
					asm = Assembly.LoadFrom(path);
				}
				else
				{
					// try as assembly name
					asm = Assembly.Load(path);
				}
				// add the assembly to the list
				if (asm != null)
					assemblies.Add(path);
				// get the referenced assemblies
				AssemblyName[] imports = asm.GetReferencedAssemblies();
				// iterate
				foreach (AssemblyName asmName in imports)
				{
					// now recursively call this assembly to get the new modules
					// it references
					BuildDependentAssemblyList(asmName.FullName, assemblies);
				}
			}
			catch (FileLoadException fle)
			{
				// just let this one go…
				Console.WriteLine(fle);
			}
		}

		private static string GetProcessPath()
		{
			// fix the path so that if running under the debugger we get the original
			// file
			string processName = Process.GetCurrentProcess().MainModule.FileName;
			int index = processName.IndexOf("vshost", StringComparison.Ordinal);
			if (index != -1)
			{
				string first = processName.Substring(0, index);
				int numChars = processName.Length - (index + 7);
				string second = processName.Substring(index + 7, numChars);
				processName = first + second;
			}
			return processName;
		}
	}
}
