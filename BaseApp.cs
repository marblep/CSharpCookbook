using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCookbook.Src.Demo
{
	abstract class BaseApp
	{
		public abstract void Run();
		public abstract void Test();
		public virtual void VirtualMethod() { }
	}
}
