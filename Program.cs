using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Reflection.Demos;

namespace CSharpCookbook.Src
{
    abstract class BaseApp
    {
        public abstract void Run();
        public virtual void Test() { }
        public virtual void VirtualMethod() { }
    }

    class Program
	{
		static void Main(string[] args)
		{
            //var referencedAssembly = new ReferencedAssembly();
            //referencedAssembly.Run();

            //var typeReflection = new TypeReflection();
            //typeReflection.Run();

            //var invokingMethods = new InvokingMethods();
            //invokingMethods.Run();

            var localVariable = new LocalVariable();
            localVariable.Run();

        }
	}
}
