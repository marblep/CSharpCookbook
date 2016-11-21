using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpCookbook.Src.Filesystem.Utils
{
    class FilesystemUtils
    {
        public static void DisplayFilesAndSubDirectories(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            string[] items = Directory.GetFileSystemEntries(path);
            Array.ForEach(items, item =>
            {
                Console.WriteLine(item);
            });
        }

        public static void DisplaySubDirectories(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            string[] items = Directory.GetDirectories(path);
            Array.ForEach(items, item =>
            {
                Console.WriteLine(item);
            });
        }
    }
}
