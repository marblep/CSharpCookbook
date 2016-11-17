using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpCookbook.Src;

namespace CSharpCookbook.Src.Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			//var referencedAssembly = new ReferencedAssembly();
			//referencedAssembly.Run();

			var typeReflection = new TypeReflection();
			typeReflection.Run();
		}
	}
}
