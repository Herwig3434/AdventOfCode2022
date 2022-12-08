using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day8
    {
        public static void RunDay(string path)
        {
            string[] lines = ReadFile.ReadLinesFromFile(path);
            string[] collumns = new string[lines[0].Length];

            for(int i = 0; i < lines[0].Length; i++)
            {
                string line = "";
                for(int j = 0; j < lines.Length; j++)
                {
                    line = line + lines[j][i];
                }
                collumns[i] = line;
            }

            int result1 = VisTrees(lines, collumns);

            int result2 = VisTrees2(lines, collumns);

            Console.WriteLine(result1);

            Console.WriteLine(result2);

        }

        public static int VisTrees(string[] lines, string[] collumns)
        {
            int count = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    if (IsVisible(lines[i], collumns[j], j, i))
                    {
                        count++;
                    }
                }
            }


            return count;
        }

        public static int VisTrees2(string[] lines, string[] collumns)
        {
            int currMax = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    int currScore = ScenicScore(lines[i], collumns[j], j, i);
                    if (currScore > currMax)
                    {
                        currMax = currScore;
                    }
                }
            }


            return currMax;
        }


        private static bool IsVisible(string line, string col, int posLine, int posCol)
        {
            char curr = line[posLine];
            string left = line[0..posLine];
            string right = line[(posLine+1)..line.Length];
            string top = col[0..posCol];
            string bottom = col[(posCol+1)..col.Length];

            if(left == "" || right == "" || top == "" || bottom == "")
            {
                return true;
            }
            else if(curr > left.Max() || curr > right.Max() || curr > top.Max() || curr > bottom.Max())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int ScenicScore(string line, string col, int posLine, int posCol)
        {
            char curr = line[posLine];
            string left = line[0..posLine];
            string right = line[(posLine + 1)..line.Length];
            string top = col[0..posCol];
            string bottom = col[(posCol + 1)..col.Length];
            int currScore = 0;
            int totalScore = 0;

            for (int i = left.Length -1 ; i >= 0; i--)
            {
                currScore++;
                if (curr <= left[i])
                {
                    break;
                }
            }
            totalScore = currScore;
            currScore = 0;
            for (int i = top.Length - 1; i >= 0; i--)
            {
                currScore++;
                if (curr <= top[i])
                {
                    break;
                }
            }
            totalScore = totalScore * currScore;
            currScore = 0;
            for (int i = 0; i < right.Length; i++)
            {
                currScore++;
                if (curr <= right[i])
                {
                    break;
                }
            }
            totalScore = totalScore * currScore;
            currScore = 0;
            for (int i = 0; i < bottom.Length; i++)
            {
                currScore++;
                if (curr <= bottom[i])
                {
                    break;
                }
            }
            totalScore = totalScore * currScore;
            return totalScore;

        }
    }
}
