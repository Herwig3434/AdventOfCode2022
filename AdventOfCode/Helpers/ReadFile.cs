using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Helpers
{
    public static class ReadFile
    {
        public static string[] ReadLinesFromFile(string path)
        {
            return File.ReadAllLines(path);
        }

        public static string ReadFileAsOneString(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
