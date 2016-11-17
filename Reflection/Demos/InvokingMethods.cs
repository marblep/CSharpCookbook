using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Xml.Linq;
using CSharpCookbook.Src.Reflection.Utils;

namespace CSharpCookbook.Src.Reflection.Demos
{
    class InvokingMethods : BaseApp
    {
        public override void Run()
        {
            XDocument xdoc = XDocument.Load(@"..\..\Src\Reflection\Demos\test.xml");
            ReflectionUtils.ReflectionInvoke(xdoc, @"CSharpCookbook.exe");

            Console.ReadKey();
        }

        public bool TestMethod1(string text)
        {
            Console.WriteLine(text);
            return (true);
        }

        public bool TestMethod2(string text, int n)
        {
            Console.WriteLine(text + " invoked with {0}", n);
            return (true);
        }
    }
}
