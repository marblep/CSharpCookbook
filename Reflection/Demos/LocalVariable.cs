using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Reflection.Utils;
using System.Reflection;

namespace CSharpCookbook.Src.Reflection.Demos
{
    class LocalVariable : BaseApp
    {
        public override int GetPriority() { return 4; }

        public override void Run()
        {
            string file = ReflectionUtils.GetProcessPath();
            // Get all local var info for the CSharpRecipes.Reflection.GetLocalVars method
            System.Collections.ObjectModel.ReadOnlyCollection<LocalVariableInfo> vars =
                ReflectionUtils.GetLocalVars(file, "CSharpCookbook.Src.Reflection.Demos.LocalVariable", "Run");

            Console.ReadKey();
        }

        public void TestLocalVars()
        {
            int i = 0;
            float f = 0;

            return;
        }
    }
}
