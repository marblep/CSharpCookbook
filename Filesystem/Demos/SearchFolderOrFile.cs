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
            string path = @"E:\C#\Project\CSharpCookbook";
            FilesystemUtils.DisplaySubDirectories(path);
            Console.WriteLine("");
            FilesystemUtils.DisplayFiles(path);
            Console.WriteLine("");
            FilesystemUtils.DisplayDirectoryContents(path);
            Console.WriteLine("");
            FilesystemUtils.DisplayDirectoriesFromInfo(path);
            Console.WriteLine("");
            FilesystemUtils.DisplayFilesFromInfo(path);
            Console.WriteLine("---");
            FilesystemUtils.DisplayFilesWithPattern(path, "*.*");
            Console.WriteLine("---");
            FilesystemUtils.DisplayDirectoriesWithPattern(path, "*.*");

            Console.ReadKey();
        }
    }
}
