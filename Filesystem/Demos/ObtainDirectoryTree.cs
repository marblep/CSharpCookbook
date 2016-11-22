using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Filesystem.Utils;

namespace CSharpCookbook.Src.Filesystem.Demos
{
    class ObtainDirectoryTree : BaseApp
    {
        public override int GetPriority() { return 7; }

        public override void Run()
        {
            //string path = @"E:\C#\Project\CSharpCookbook";
            string path = @"D:\temp";
            //FilesystemUtils.DisplayAllFilesAndDirectories(path);
            FilesystemUtils.DisplayAllFilesWithExtension(path, ".txt");

            Console.ReadKey();
        }
    }
}
