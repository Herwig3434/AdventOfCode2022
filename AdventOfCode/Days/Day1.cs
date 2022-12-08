using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day1
    {
        public static void RunDay(string path)
        {
            string[] lines = ReadFile.ReadLinesFromFile(path);
            int count = 0;
            List<int> ints = new List<int>();
            foreach (string line in lines)
            {
                if (line != "")
                {
                    count += Convert.ToInt32(line);
                }
                else
                {
                    ints.Add(count);
                    count = 0;
                }
            }
            ints.Sort();
            ints.Reverse();
            Console.WriteLine(ints[0] + ints[1] + ints[2]);
        }
    }
}
