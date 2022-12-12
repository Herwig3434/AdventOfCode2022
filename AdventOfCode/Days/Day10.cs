using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day10
    {
        public static void RunDay(string path)
        {
            //path = "c:\\dokumente\\adventofcode\\adventofcode\\adventofcode\\inputs\\InputTest" + ".txt";
            string[] lines = ReadFile.ReadLinesFromFile(path);
            List<int> results = ExecuteProgram(lines).ToList();

            int sum = 0;
            for (int i = 19; i < results.Count(); i += 40)
            {
                sum += results[i];

            }
            Console.WriteLine(sum);
            Console.WriteLine(DrawPixels(lines));

        }



        private static IEnumerable<int> ExecuteProgram(string[] lines)
        {
            int reg = 1;
            int cycle = 0;
            foreach(string line in lines)
            {
                cycle++;
                if (line.Contains("noop"))
                {
                    yield return reg * cycle;
                }
                else
                {
                    string[] split = line.Split(' ');
                    int num = int.Parse(split[1]);

                    yield return reg * cycle;

                    cycle++;
                    yield return reg * cycle;

                    reg += num;

                }
            }
        }

        private static string DrawPixels(string[] lines)
        {
            string result = "";
            int reg = 1;
            int cycle = -1;
            foreach (string line in lines)
            {
                cycle++;
                if (line.Contains("noop"))
                {
                    result += GetCurrSymbol(cycle, reg);
                }
                else
                {
                    string[] split = line.Split(' ');
                    int num = int.Parse(split[1]);

                    result += GetCurrSymbol(cycle, reg);
                    cycle++;
                    result += GetCurrSymbol(cycle, reg);
                    reg += num;

                }
            }
            return result;
        }


        private static string GetCurrSymbol(int cycle, int reg)
        {
            string returnSymbol = "";

            cycle = cycle % 40;
            if(cycle == 0)
            {
                returnSymbol += Environment.NewLine;
            }
            
            if(cycle == reg || cycle == reg- 1 || cycle == reg + 1)
            {
                return returnSymbol + '#';
            }
            else
            {
                return returnSymbol + '.';
            }
        }
    }
}
