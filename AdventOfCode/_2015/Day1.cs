using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2015
{
    public static class Day1
    {
        public static void RunDay(string path)
        {
            string line = ReadFile.ReadFileAsOneString(path);

            int result1 = GetLevel(line).Last().level;
            int result2 = GetLevel(line).Where(v => v.level < 0).First().index;

            Console.WriteLine(result1 + " " + result2);

        }
        public static IEnumerable<(int index, int level)> GetLevel(string line){
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                count = line[i] == '(' ? count + 1 : count - 1;
                yield return (i+1, count);
            }
            
        }
    }    
}
