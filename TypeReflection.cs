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
	class TypeReflection : BaseApp
	{
		public override void Run()
		{
			string nameOfMember = "BuildDependentAssemblyList";
			string file = ReflectionUtil.GetProcessPath();
			Assembly asm = ReflectionUtil.GetAssembly(file);
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


			Console.ReadKey();
		}
	}

	
}
