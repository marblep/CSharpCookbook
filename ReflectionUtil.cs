﻿using System;
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
	static class ReflectionUtil
	{
		public static Assembly GetAssembly(string path)
		{
			Assembly asm = null;
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
			return asm;
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

		public static string GetProcessPath()
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

		public static IEnumerable<MemberInfo> GetMembersInAssembly(this Assembly asm, string memberName) =>
			from type in asm.GetTypes()
			from ms in type.GetMember(memberName, MemberTypes.All,
			BindingFlags.Public | BindingFlags.NonPublic |
			BindingFlags.Static | BindingFlags.Instance)
			select ms;

		public static IEnumerable<Type> GetSerializableTypes(this Assembly asm) =>
			from type in asm.GetTypes()
			where type.IsSerializable &&
			!type.IsNestedPrivate // filters out anonymous types
			select type;

		public static IEnumerable<Type> GetSubclassesForType(this Assembly asm,
			Type baseClassType) =>
			from type in asm.GetTypes()
			where type.IsSubclassOf(baseClassType)
			select type;

		public static IEnumerable<Type> GetNestedTypes(this Assembly asm) =>
			from t in asm.GetTypes()
			from t2 in t.GetNestedTypes(BindingFlags.Instance |
			BindingFlags.Static |
			BindingFlags.Public |
			BindingFlags.NonPublic)
			where !t2.IsEnum && !t2.IsInterface &&
			!t2.IsNestedPrivate // filters out anonymous types
			select t2;
	}
}
