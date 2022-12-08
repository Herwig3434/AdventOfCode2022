using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day2
    {
        public static void RunDay(string path)
        {
            string lines = ReadFile.ReadFileAsOneString(path);
            lines = lines.Replace('A', '1');//Rock
            lines = lines.Replace('B', '2');//Paper
            lines = lines.Replace('C', '3');//Scissors
            lines = lines.Replace('X', '1');//lose
            lines = lines.Replace('Y', '2');//draw
            lines = lines.Replace('Z', '3');//win

            string[] lines2 = lines.Split('\n');

            int counter = 0;
            foreach (string line in lines2)
            {
                if (line == "")
                    continue;

                switch (line[2])
                {
                    case '1':
                        switch (line[0])
                        {
                            case '1':
                                counter += 3;
                                break;
                            case '2':
                                counter += 1;
                                break;
                            case '3':
                                counter += 2;
                                break;  
                        }
                        break;
                    case '2':
                        counter += 3;
                        switch (line[0])
                        {
                            case '1':
                                counter += 1;
                                break;
                            case '2':
                                counter += 2;
                                break;
                            case '3':
                                counter += 3;
                                break;
                        }
                        break;
                    case '3':
                        counter += 6;
                        switch (line[0])
                        {
                            case '1':
                                counter += 2;
                                break;
                            case '2':
                                counter += 3;
                                break;
                            case '3':
                                counter += 1;
                                break;
                        }
                        break;
                    default:
                        break;
                        
                }
            }
            Console.WriteLine(counter);

        }

        
    }
}
