using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Reflection.Demos;
using CSharpCookbook.Src.Reflection.Utils;
using System.Reflection;

namespace CSharpCookbook.Src
{
    abstract class BaseApp
    {
        public abstract void Run();
        public virtual void Test() { }
        public virtual void VirtualMethod() { }

        public abstract int GetPriority();
    }

    class Program
	{
		static void Main(string[] args)
		{
			//var referencedAssembly = new ReferencedAssembly();
			//referencedAssembly.Run();

			RunTopPriority();

		}

		private static void RunTopPriority()
		{
			string file = ReflectionUtils.GetProcessPath();
			Assembly asm = ReflectionUtils.GetAssembly(file);

			string baseName = "CSharpCookbook.Src.BaseApp";
			Type type = Type.GetType(baseName);
			var subClasses = asm.GetSubclassesForType(type);
			int maxPriority = 0;
			BaseApp theApp = null;
			foreach (var subClass in subClasses)
			{
				var obj = Activator.CreateInstance(subClass);
				if (obj != null)
				{
					MethodInfo method = subClass.GetMethod("GetPriority");
					if (method != null)
					{
						int priority = (int)method.Invoke(obj, null);
						if (priority > maxPriority)
						{
							maxPriority = priority;
							theApp = (BaseApp)obj;
						}
					}
				}
			}
			Console.WriteLine(string.Format("--- [{0}]  {1} --- {2}", theApp.GetType().ToString(), theApp.GetPriority(), "\n"));
			theApp.Run();
		}
    }
}
