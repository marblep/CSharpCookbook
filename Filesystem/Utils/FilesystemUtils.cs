using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpCookbook.Src.Filesystem.Utils
{
    static class FilesystemUtils
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

        // 只显示子文件夹
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

        // 只显示文件
        public static void DisplayFiles(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            string[] items = Directory.GetFiles(path);
            Array.ForEach(items, item =>
            {
                Console.WriteLine(item);
            });
        }

        public static void DisplayDirectoryContents(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            DirectoryInfo mainDir = new DirectoryInfo(path);
            var fileSystemDisplayInfos = (from fsi in mainDir.GetFileSystemInfos()
                                          where fsi is FileSystemInfo || fsi is DirectoryInfo
                                          select fsi.ToDisplayString()).ToArray();
            Array.ForEach(fileSystemDisplayInfos, s =>
            {
                Console.WriteLine(s);
            });
        }

        public static string ToDisplayString(this FileSystemInfo fileSystemInfo)
        {
            string type = fileSystemInfo.GetType().ToString();
            if (fileSystemInfo is DirectoryInfo)
                type = "DIRECTORY";
            else if (fileSystemInfo is FileInfo)
                type = "FILE";
            return $"{type}: {fileSystemInfo.Name}";
        }

        public static void DisplayDirectoriesFromInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            DirectoryInfo mainDir = new DirectoryInfo(path);
            DirectoryInfo[] items = mainDir.GetDirectories();
            Array.ForEach(items, item =>
            {
                Console.WriteLine($"DIRECTORY: {item.Name}");
            });
        }

        public static void DisplayFilesFromInfo(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            DirectoryInfo mainDir = new DirectoryInfo(path);
            FileInfo[] items = mainDir.GetFiles();
            Array.ForEach(items, item =>
            {
                Console.WriteLine($"FILE: {item.Name}");
            });
        }

        public static void DisplayFilesWithPattern(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));
            string[] items = Directory.GetFileSystemEntries(path, pattern);
            Array.ForEach(items, item =>
            {
                Console.WriteLine(item);
            });
        }

        public static void DisplayDirectoriesWithPattern(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));
            string[] items = Directory.GetDirectories(path, pattern);
            Array.ForEach(items, item =>
            {
                Console.WriteLine(item);
            });
        }

        public static void DisplayFilesWithGetFiles(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));
            string[] items = Directory.GetFiles(path, pattern);
            Array.ForEach(items, item =>
            {
                Console.WriteLine(item);
            });
        }

        public static void DisplayDirectoryContentsWithPattern(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));
            DirectoryInfo mainDir = new DirectoryInfo(path);
            var fileSystemDisplayInfos =
            (from fsi in mainDir.GetFileSystemInfos(pattern)
             where fsi is FileSystemInfo || fsi is DirectoryInfo
             select fsi.ToDisplayString()).ToArray();
            Array.ForEach(fileSystemDisplayInfos, s =>
            {
                Console.WriteLine(s);
            });
        }

        public static void DisplayDirectoriesWithPatternFromInfo(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));
            DirectoryInfo mainDir = new DirectoryInfo(path);
            DirectoryInfo[] items = mainDir.GetDirectories(pattern);
            Array.ForEach(items, item =>
            {
                Console.WriteLine($"DIRECTORY: {item.Name}");
            });
        }

        public static void DisplayFilesWithInstanceGetFiles(string path, string pattern)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));
            DirectoryInfo mainDir = new DirectoryInfo(path);
            FileInfo[] items = mainDir.GetFiles(pattern);
            Array.ForEach(items, item =>
            {
                Console.WriteLine($"FILE: {item.Name}");
            });
        }

        public static IEnumerable<FileSystemInfo> GetAllFilesAndDirectories(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            Stack<FileSystemInfo> stack = new Stack<FileSystemInfo>();
            stack.Push(dirInfo);
            while (dirInfo != null || stack.Count > 0)
            {
                FileSystemInfo fileSystemInfo = stack.Pop();
                DirectoryInfo subDirectoryInfo = fileSystemInfo as DirectoryInfo;
                if (subDirectoryInfo != null)
                {
                    yield return subDirectoryInfo;
                    foreach (FileSystemInfo fsi in subDirectoryInfo.GetFileSystemInfos())
                        stack.Push(fsi);
                    dirInfo = stack.Count > 0 ? subDirectoryInfo : null;
                }
                else
                {
                    yield return fileSystemInfo;
                    dirInfo = null;
                }
            }
        }

        public static void DisplayAllFilesAndDirectories(string dir)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));
            var strings = (from fileSystemInfo in GetAllFilesAndDirectories(dir)
                           select fileSystemInfo.ToDisplayString()).ToArray();
            Array.ForEach(strings, s => { Console.WriteLine(s); });
        }

        public static void DisplayAllFilesWithExtension(string dir, string extension)
        {
            if (string.IsNullOrWhiteSpace(dir))
                throw new ArgumentNullException(nameof(dir));
            if (string.IsNullOrWhiteSpace(extension))
                throw new ArgumentNullException(nameof(extension));
            var strings = (from fileSystemInfo in GetAllFilesAndDirectories(dir)
                           where fileSystemInfo is FileInfo /*&&
                           fileSystemInfo.FullName.Contains("Chapter 1")*/ &&
                           (string.Compare(fileSystemInfo.Extension, extension,
                           StringComparison.OrdinalIgnoreCase) == 0)
                           select fileSystemInfo.ToDisplayString()).ToArray();
            Array.ForEach(strings, s => { Console.WriteLine(s); });
        }

        public static void DisplayPathParts(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            string root = Path.GetPathRoot(path);
            string dirName = Path.GetDirectoryName(path);
            string fullFileName = Path.GetFileName(path);
            string fileExt = Path.GetExtension(path);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(path);
            StringBuilder format = new StringBuilder();
            format.Append($"ParsePath of {path} breaks up into the following pieces:" + $"{Environment.NewLine}");
            format.Append($"\tRoot: {root}{Environment.NewLine}");
            format.Append($"\tDirectory Name: {dirName}{Environment.NewLine}");
            format.Append($"\tFull File Name: {fullFileName}{Environment.NewLine}");
            format.Append($"\tFile Extension: {fileExt}{Environment.NewLine}");
            format.Append($"\tFile Name Without Extension: {fileNameWithoutExt}" + $"{Environment.NewLine}");
            Console.WriteLine(format.ToString());
        }
    }
}
