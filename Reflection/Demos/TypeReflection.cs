using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using CSharpCookbook.Src.Reflection.Utils;

namespace CSharpCookbook.Src.Reflection.Demos
{
	class TypeReflection : BaseApp
	{
		public override void Test() { }
		public override void VirtualMethod() { }

		public override void Run()
		{
			string nameOfMember = "BuildDependentAssemblyList";
			string file = ReflectionUtils.GetProcessPath();
			Assembly asm = ReflectionUtils.GetAssembly(file);
			var members = asm.GetMembersInAssembly(nameOfMember);
			foreach (var member in members)
			{
				Console.WriteLine(string.Format("[GetMember]  {0} is in: {1}",nameOfMember, member.DeclaringType.ToString()));
			}

			string baseName = "CSharpCookbook.Src.BaseApp";
			Type type = Type.GetType(baseName);
			var subClasses = asm.GetSubclassesForType(type);
			foreach (var subClass in subClasses)
			{
				Console.WriteLine(string.Format("[SubClass]  {0} is subClass of {1}", subClass.Name, baseName));
			}
			Console.WriteLine("");

			string typeName = "CSharpCookbook.Src.Reflection.Demos.TypeReflection";
			type = Type.GetType(typeName);
			foreach (var theType in type.GetInheritanceChain())
			{
				Console.WriteLine(string.Format("[InheritanceChain] {0}", theType.ToString()));
			}
			Console.WriteLine("");

			foreach (var member in type.GetMethodOverrides())
			{
				Console.WriteLine(string.Format("[MethodOverrides]  {0}", member.Name));
			}
			Console.WriteLine("");


			Console.ReadKey();
		}
	}

	
}
