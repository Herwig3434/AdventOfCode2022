using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Models
{
    public class Monkey
    {
        public int Id { get; set; }
        public List<Int64> Items { get; set; }
        public List<string> Operation { get; set; }
        public List<int> Test { get; set; }

        public int NrOfInspections { get; set; }


        public Monkey(int id, List<Int64> items, List<string> operation, List<int> test, int nrOfInspections = 0)
        {
            Id = id;
            Items = items;
            Operation = operation;
            Test = test;
            NrOfInspections = nrOfInspections; 
        }

        public void RemoveItems()
        {
            NrOfInspections += Items.Count();
            Items.Clear();
        }

        public void AddItem(Int64 level)
        {
            Items.Add(level);
        }

        public Int64 ApplyOperation(int level)
        {
            Int64 value;
            if (Operation[2] == "old")
            {
                value = level;
            }
            else
            {
                value = Int64.Parse(Operation[2]);
            }

            if (Operation[1] == "+")
            {
                return level + value;
            }else if (Operation[1] == "*")
            {
                return level * value;
            }

            throw new InvalidOperationException();
        }
    }
}
