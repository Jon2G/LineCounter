using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineCounter
{
    public static class LinesCounter
    {
        public static int CountLines(FileInfo file)
        {
            var lineCount = 0;
            try
            {
                using (var reader = File.OpenText(file.FullName))
                {
                    while (reader.ReadLine() != null)
                    {
                        lineCount++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"ERROR: {e.Message}");
            }
            return lineCount;
        }
    }
}
