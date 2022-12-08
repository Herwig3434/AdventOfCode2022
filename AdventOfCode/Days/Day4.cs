using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day4
    {
        public static void RunDay(string path)
        {
            string[] lines = ReadFile.ReadLinesFromFile(path);

            int pairs = numPairs(lines);

            int overlaps = numOverlap(lines);

            Console.WriteLine(pairs);
            Console.WriteLine(overlaps);

        }

        public static int numPairs(string[] lines)
        {
            int count = 0;

            foreach(string line in lines)
            {
                string[] lineSplit = line.Split(',');
                int[] line1 = lineSplit[0].Split('-').Select(v => Int32.Parse(v)).ToArray();
                int[] line2 = lineSplit[1].Split('-').Select(v => Int32.Parse(v)).ToArray();

                if (line1[0] >= line2[0] && line1[1] <= line2[1])
                {
                   
                    count++;
                    
                }else if(line2[0] >= line1[0] && line2[1] <= line1[1])
                {
                
                    count++;
                
                }
            }



            return count;
        }


        public static int numOverlap(string[] lines)
        {
            int count = 0;

            foreach (string line in lines)
            {
                string[] lineSplit = line.Split(',');
                int[] line1 = lineSplit[0].Split('-').Select(v => Int32.Parse(v)).ToArray();
                int[] line2 = lineSplit[1].Split('-').Select(v => Int32.Parse(v)).ToArray();

                if (line1[1] >= line2[0] && line1[1] <= line2[1])
                {

                    count++;

                }
                else if (line2[1] >= line1[0] && line2[1] <= line1[1])
                {

                    count++;

                }
            }



            return count;
        }
    }
}
