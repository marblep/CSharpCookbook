using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Filesystem.Utils;
using System.Diagnostics;
using System.IO;

namespace CSharpCookbook.Src.Filesystem.Demos
{
    class ParsePath : BaseApp
    {
        public override int GetPriority() { return 8; }

        public override void Run()
        {
            string path = @"C:\test\tempfile.txt";
            FilesystemUtils.DisplayPathParts(path);

            Console.ReadKey();
        }
    }
}
