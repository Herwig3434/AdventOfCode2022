using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day9
    {
        public static void RunDay(string path)
        {
            //path = "c:\\dokumente\\adventofcode\\adventofcode\\adventofcode\\inputs\\InputTest" + ".txt";
            
            string[] lines = ReadFile.ReadLinesFromFile(path);
            List<(string, int)> values = new List<(string, int)>();
            foreach(string line in lines)
            {
                string[] split = line.Split(' ');
                values.Add((split[0], Int32.Parse(split[1])));
            }

            Console.WriteLine(UniquePos(values, 1));
            Console.WriteLine(UniquePos(values, 9));


        }


        public static int UniquePos(List<(string, int)> input, int nrOfKnots)
        {
            List<(int, int)> rope = new List<(int, int)>();
            for (int i = 0; i <= nrOfKnots; i++)
            {
                rope.Add((0, 0));
            }
            HashSet<(int, int)> pos = new HashSet<(int, int)> ();
            pos.Add(rope.Last());
            foreach((string action, int number) in input)
            {
                for (int i = 0; i < number; i++)
                {
                    (int, int) head = rope.First();
                    switch (action)
                    {
                        case "U":
                            head.Item2 += 1;
                            break;
                        case "D":
                            head.Item2 -= 1;
                            break;
                        case "R":
                            head.Item1 += 1;
                            break;
                        case "L":
                            head.Item1 -= 1;
                            break;
                    }
                    rope[0] = head;
                    for(int j = 1; j < rope.Count(); j++)
                    {
                        (int,int) currKnot = rope[j];
                        currKnot = CalculateStep(rope[j-1], currKnot);
                        rope[j] = currKnot;
                        if(j == rope.Count() - 1)
                        {
                            pos.Add(currKnot);
                        }
                    }
                }
                
            }


            return pos.Count();
        }


        private static (int, int) CalculateStep((int, int) curr, (int, int) next)
        {
            double distance = Math.Sqrt((Math.Pow(curr.Item1 - next.Item1, 2) + Math.Pow(curr.Item2 - next.Item2, 2)));
            if (distance > Math.Sqrt(2))
            {
                next.Item1 += Math.Sign(curr.Item1 - next.Item1);
                next.Item2 += Math.Sign(curr.Item2 - next.Item2);
            }


            return next;
        }

    }
}
