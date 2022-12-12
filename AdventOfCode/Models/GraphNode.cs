using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Models
{
    public class GraphNode
    {
        public char Name { get; set; }
        public List<GraphNode> Goals { get; set; }
        public int Length { get; set; }
        public bool Visited { get; set; }
        public GraphNode? Prev { get; set; }

        public GraphNode(char name, List<GraphNode> goals, int length, bool visited, GraphNode? prev)
        {
            Name = name;
            Goals = goals;
            Length = length;
            Visited = visited;
            Prev = prev;
        }
    }
}
