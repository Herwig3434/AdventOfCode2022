using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day6
    {
        public static void RunDay(string path)
        {
            string line = ReadFile.ReadFileAsOneString(path);

            int result1 = GetSubsequence1(line);

            int result2 = 0;

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }


        private static int GetSubsequence1(string line)
        {

            for (int i = 0; i < line.Length; i++)
            {
                HashSet<char> set = line[i..(i+4)].ToHashSet<char>();

                if(set.Count == 4)
                {
                    return i + 4;
                }

            }



            return 0;
        }



        private static int GetSubsequence2(string line)
        {

            for (int i = 0; i < line.Length; i++)
            {
                HashSet<char> set = line[i..(i + 14)].ToHashSet<char>();

                if (set.Count == 14)
                {
                    return i + 14;
                }

            }



            return 0;
        }
    }
}
