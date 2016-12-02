using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpCookbook.Src.Threading.Demos
{
    class BasicThread : BaseApp
    {
        public override int GetPriority() { return 10; }

        public override void Run()
        {
            Thread t = new Thread(PrintNumbers_thread);
            t.Start();
            PrintNumbers_main();

            Console.ReadKey();
        }

        static void PrintNumbers_thread()
        {
            Console.WriteLine("Starting thread...");
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine("++ " + i);
            }
        }

        static void PrintNumbers_main()
        {
            Console.WriteLine("Starting main...");
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
