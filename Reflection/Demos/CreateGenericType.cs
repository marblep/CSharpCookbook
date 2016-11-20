using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Reflection.Utils;

namespace CSharpCookbook.Src.Reflection.Demos
{
    class CreateGenericType : BaseApp
    {
        public override int GetPriority() { return 5; }

        public override void Run()
        {
            //Assembly asm = ReflectionUtils.GetAssembly(ReflectionUtils.GetProcessPath());
            CreateDictionary();

            Console.ReadKey();
        }

        public static void CreateDictionary()
        {
            // Get the type we want to construct
            Type typeToConstruct = typeof(Dictionary<,>);
            // Get the type arguments we want to construct our type with
            Type[] typeArguments = { typeof(int), typeof(string) };
            // Bind these type arguments to our generic type
            Type newType = typeToConstruct.MakeGenericType(typeArguments);
            // Construct our type
            Dictionary<int, string> dict = (Dictionary<int, string>)Activator.CreateInstance(newType);
            // Test our newly constructed type
            Console.WriteLine($"Count == {dict.Count}");
            dict.Add(1, "test1");
            Console.WriteLine($"Count == {dict.Count}");
        }
    }
}
