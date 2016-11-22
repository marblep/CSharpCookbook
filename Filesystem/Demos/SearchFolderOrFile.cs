using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpCookbook.Src.Filesystem.Utils;

namespace CSharpCookbook.Src.Filesystem.Demos
{
    class SearchFolderOrFile : BaseApp
    {
        public override int GetPriority() { return 6; }

        public override void Run()
        {
            FilesystemUtils.DisplayFilesAndSubDirectories(@"E:\");
            //FilesystemUtils.DisplayFilesAndSubDirectories(@"D:\Books\马天心");
            Console.WriteLine("");

            FilesystemUtils.DisplaySubDirectories(@"E:\");

            Console.ReadKey();
        }
    }
}
