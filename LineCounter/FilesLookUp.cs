using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineCounter
{
    public static class FilesLookUp
    {
        public static IEnumerable<FileInfo>? Search(DirectoryInfo root, string? pattern = null)
        {
            try
            {
                if (string.IsNullOrEmpty(pattern))
                    return GetAll(root);
                return root.EnumerateFiles(pattern, SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        static IEnumerable<FileInfo>? GetAll(DirectoryInfo root)
        {
            try
            {
                List<IEnumerable<FileInfo>> enums = new List<IEnumerable<FileInfo>> { };
                GetFiles(enums, root);
                return enums.SelectMany(x => x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        static void GetFiles(List<IEnumerable<FileInfo>> enums, DirectoryInfo root)
        {
            enums.Add(root.EnumerateFiles());
            foreach (DirectoryInfo directory in root.EnumerateDirectories())
            {
                GetFiles(enums, directory);
            }
        }
    }
}
