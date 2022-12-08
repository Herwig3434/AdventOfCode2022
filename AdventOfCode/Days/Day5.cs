using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day5
    {
        public static void RunDay(string path)
        {
            string[] lines = ReadFile.ReadLinesFromFile(path);

            string result1 = Rearrange1(lines);

            string result2 = Rearrange2(lines);

            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        private static string Rearrange1(string[] lines)
        {
            List<Stack<char>> stacks = new List<Stack<char>>();

            for(int i = 0; i< 9; i++)
            {
                Stack<char> stack = new Stack<char>();
                stacks.Add(stack);
            }

            for(int i = 7; i >= 0; i--)
            {
                int currStackNr = 0;
                for(int j = 1; j< lines[i].Length; j+=4)
                {
                    if (lines[i][j] != ' ')
                    {
                        stacks[currStackNr].Push(lines[i][j]);
                    }
                    currStackNr++;
                }
            }
            List<string[]> instructions = new List<string[]>();
            for(int i = 10; i< lines.Length; i++)
            {
                instructions.Add(lines[i].Split(' '));
            }

            foreach (string[] instruction in instructions)
            {

                for (int i = 0; i < Int32.Parse(instruction[1]); i++)
                {
                    int pileFrom = Int32.Parse(instruction[3]) - 1;
                    int pileTo = Int32.Parse(instruction[5]) - 1;
                    stacks[pileTo].Push(stacks[pileFrom].Pop());
                }
                
            }

            return string.Concat(stacks.Select(v => v.Pop()));
        }



        private static string Rearrange2(string[] lines)
        {
            List<Stack<char>> stacks = new List<Stack<char>>();

            for (int i = 0; i < 9; i++)
            {
                Stack<char> stack = new Stack<char>();
                stacks.Add(stack);
            }

            for (int i = 7; i >= 0; i--)
            {
                int currStackNr = 0;
                for (int j = 1; j < lines[i].Length; j += 4)
                {
                    if (lines[i][j] != ' ')
                    {
                        stacks[currStackNr].Push(lines[i][j]);
                    }
                    currStackNr++;
                }
            }
            List<string[]> instructions = new List<string[]>();
            for (int i = 10; i < lines.Length; i++)
            {
                instructions.Add(lines[i].Split(' '));
            }

            foreach (string[] instruction in instructions)
            {
                Stack<char> intermediateStack = new Stack<char>();
                int pileTo = 0;
                for (int i = 0; i < Int32.Parse(instruction[1]); i++)
                {
                    int pileFrom = Int32.Parse(instruction[3]) - 1;
                    pileTo = Int32.Parse(instruction[5]) - 1;
                    intermediateStack.Push(stacks[pileFrom].Pop());
                }
                for (int i = 0; i < Int32.Parse(instruction[1]); i++)
                {
                    stacks[pileTo].Push(intermediateStack.Pop());
                }

            }

            return string.Concat(stacks.Select(v => v.Pop()));
        }
    }
}
