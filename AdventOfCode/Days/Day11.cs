using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day11
    {
        public static void RunDay(string path)
        {
            Monkey monkey0 = new Monkey(0, new List<Int64>() { 50, 70, 54, 83, 52, 78 }, new List<string>() { "old", "*", "3" }, new List<int>() { 11, 2, 7 });
            Monkey monkey1 = new Monkey(1, new List<Int64>() { 71, 52, 58, 60, 71 }, new List<string>() { "old", "*", "old" }, new List<int>() { 7, 0, 2 });
            Monkey monkey2 = new Monkey(2, new List<Int64>() { 66, 56, 56, 94, 60, 86, 73 }, new List<string>() { "old", "+", "1" }, new List<int>() { 3, 7, 5 });
            Monkey monkey3 = new Monkey(3, new List<Int64>() { 83, 99 }, new List<string>() { "old", "+", "8" }, new List<int>() { 5, 6, 4 });
            Monkey monkey4 = new Monkey(4, new List<Int64>() { 98, 98, 79 }, new List<string>() { "old", "+", "3" }, new List<int>() { 17, 1, 0 });
            Monkey monkey5 = new Monkey(5, new List<Int64>() { 76 }, new List<string>() { "old", "+", "4" }, new List<int>() { 13, 6, 3 });
            Monkey monkey6 = new Monkey(6, new List<Int64>() { 52, 51, 84, 54 }, new List<string>() { "old", "*", "17" }, new List<int>() { 19, 4, 1 });
            Monkey monkey7 = new Monkey(7, new List<Int64>() { 82, 86, 91, 79, 94, 92, 59, 94 }, new List<string>() { "old", "+", "7" }, new List<int>() { 2, 5, 3 });
            List<Monkey> list = new List<Monkey>() { monkey0, monkey1, monkey2, monkey3, monkey4, monkey5, monkey6, monkey7 };

            

            //TestInput
            //Monkey monkey0 = new Monkey(0, new List<int>() { 79, 98 }, new List<string>() { "old", "*", "19" }, new List<int>() { 23, 2, 3 });
            //Monkey monkey1 = new Monkey(1, new List<int>() { 54, 65, 75, 74 }, new List<string>() { "old", "+", "6" }, new List<int>() { 19, 2, 0 });
            //Monkey monkey2 = new Monkey(2, new List<int>() { 79, 60, 97 }, new List<string>() { "old", "*", "old" }, new List<int>() { 13, 1, 3 });
            //Monkey monkey3 = new Monkey(3, new List<int>() { 74 }, new List<string>() { "old", "+", "3" }, new List<int>() { 17, 0, 1 });
            //List<Monkey> list = new List<Monkey>() { monkey0, monkey1, monkey2, monkey3 };


            Int64 result1 = CalculateMonkeys1(list);

            Console.WriteLine(result1);
        }


        private static Int64 CalculateMonkeys1(List<Monkey> monkeyFamily)
        {
            int kgv = 11 * 7 * 3 * 5 * 17 * 13 * 19 * 2;
            for (int i = 0; i < 10000; i++)
            {
                foreach (Monkey monkey in monkeyFamily)
                {
                    foreach (int item in monkey.Items)
                    {
                        Int64 worryLevel = monkey.ApplyOperation(item);
                        if (worryLevel % monkey.Test[0] == 0)
                        {
                            monkeyFamily.Where(x => x.Id == monkey.Test[1]).First().AddItem(worryLevel % kgv);
                        }
                        else
                        {
                            monkeyFamily.Where(x => x.Id == monkey.Test[2]).First().AddItem(worryLevel % kgv);
                        }

                    }
                    monkey.RemoveItems();
                }
            }
            List<Int64> activeness = new List<Int64>();
            foreach(Monkey monkey in monkeyFamily)
            {
                activeness.Add(monkey.NrOfInspections);
            }

            activeness.Sort();


            return activeness[activeness.Count-1] * activeness[activeness.Count-2];
        }
    }
}
