using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day3
    {
        public static void RunDay(string path)
        {
            string[] lines = ReadFile.ReadLinesFromFile(path);

            int counter = 0;
            //foreach (string line in lines)
            //{
            //    counter += oneSack(line.Substring(0, line.Length/2), line.Substring(line.Length/2));
            //}

            
            for(int i = 0; i < lines.Length-2; i+=3)
            {
                counter += threeSacks(lines[i], lines[i+1], lines[i+2]);
            }
            Console.WriteLine(counter);
        }

        public static int oneSack(string comp1, string comp2)
        {

            HashSet<char> letters1 = new HashSet<char>(comp1);

            foreach(char c in comp2)
            {
                if (letters1.Contains(c))
                {
                    if(c == Char.ToUpper(c))
                    {
                        return (c - 38);
                    }
                    else
                    {
                        return (c - 96);
                    }
                    
                }
            }
            throw new ApplicationException("Oh nein!");
            

        }

        public static int threeSacks(string sack1, string sack2, string sack3)
        {
            HashSet<char> letters1 = new HashSet<char>(sack1);
            HashSet<char> letters2 = new HashSet<char>();
            foreach (char c in sack2)
            {
                if (letters1.Contains(c))
                {
                    letters2.Add(c);
                    

                }
            }

            foreach(char c in sack3)
            {

                if (letters2.Contains(c))
                {
                    if (c == Char.ToUpper(c))
                    {
                        return (c - 38);
                    }
                    else
                    {
                        return (c - 96);
                    }
                }
            }

            
            throw new ApplicationException("Oh nein!");
        }
    }
}
