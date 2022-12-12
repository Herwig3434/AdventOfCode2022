using AdventOfCode.Helpers;
using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day12
    {
        public static void RunDay(string path)
        {
            //path = "c:\\dokumente\\adventofcode\\adventofcode\\adventofcode\\inputs\\InputTest" + ".txt";
            string[] lines = ReadFile.ReadLinesFromFile(path);
            List<List<GraphNode>> nodes = new List<List<GraphNode>>();
            for(int i = 0; i < lines.Length; i++)
            {
                List<GraphNode> nodeList = new List<GraphNode>();
                for(int j = 0; j < lines[i].Length; j++)
                {
                    nodeList.Add(new GraphNode(lines[i][j], new List<GraphNode>(), 0, false, null));
                }
                nodes.Add(nodeList);
            }

            for(int i = 0; i < nodes.Count; i++)
            {
                for(int j = 0; j < nodes[i].Count; j++)
                {
                   
                    if(i > 0)
                    {
                        if ((nodes[i-1][j].Name <= nodes[i][j].Name + 1 && nodes[i - 1][j].Name != 'E') || (nodes[i - 1][j].Name == 'E' && 'z' <= nodes[i][j].Name + 1))
                            nodes[i][j].Goals.Add(nodes[i-1][j]);
                    }
                    if(i < nodes.Count - 1)
                    {
                        if ((nodes[i + 1][j].Name <= nodes[i][j].Name + 1 && nodes[i + 1][j].Name != 'E') || (nodes[i + 1][j].Name == 'E' && 'z' <= nodes[i][j].Name + 1))
                            nodes[i][j].Goals.Add(nodes[i + 1][j]);
                    }

                    if(j > 0)
                    {
                        if ((nodes[i][j - 1].Name <= nodes[i][j].Name + 1 && nodes[i][j - 1].Name != 'E') || (nodes[i][j - 1].Name == 'E' && 'z' <= nodes[i][j].Name + 1))
                            nodes[i][j].Goals.Add(nodes[i][j - 1]);
                    }
                    if (j < nodes[i].Count -1)
                    {
                        if ((nodes[i][j + 1].Name <= nodes[i][j].Name + 1 && nodes[i][j + 1].Name != 'E') || (nodes[i][j + 1].Name == 'E' && 'z' <= nodes[i][j].Name + 1))
                            nodes[i][j].Goals.Add(nodes[i][j+1]);
                    }
                    if (nodes[i][j].Name == 'S')
                    {
                        if (i > 0)
                        {
                            if (nodes[i - 1][j].Name <= 'a' + 1)
                                nodes[i][j].Goals.Add(nodes[i - 1][j]);
                        }
                        if (i < nodes.Count - 1)
                        {
                            if (nodes[i + 1][j].Name <= 'a' + 1)
                                nodes[i][j].Goals.Add(nodes[i + 1][j]);
                        }

                        if (j > 0)
                        {
                            if (nodes[i][j - 1].Name <= 'a' + 1)
                                nodes[i][j].Goals.Add(nodes[i][j - 1]);
                        }
                        if (j < nodes[i].Count - 1)
                        {
                            if (nodes[i][j + 1].Name <= 'a' + 1)
                                nodes[i][j].Goals.Add(nodes[i][j + 1]);
                        }
                    }
                }
            }
            List<GraphNode> list = new List<GraphNode>();
            foreach(List<GraphNode> nodeList in nodes)
            {
                list.AddRange(nodeList);
            }
            List<GraphNode> allA = list.Where(x => x.Name == 'a' || x.Name == 'S').ToList();
            List<int> results = new List<int>();
            foreach(GraphNode node in allA)
            {
                foreach(GraphNode node1 in list)
                {
                    node1.Visited = false;
                    node1.Length = 0;
                }
                node.Visited = false;
                node.Length = 0;
                results.Add(ShortestPath(list, node));
            }
            
            Console.WriteLine(results.Min());
        }


        public static int ShortestPath(List<GraphNode> nodes, GraphNode start)
        {
            List<GraphNode> queue = new List<GraphNode>();
            queue.Add(start);
            queue[0].Visited = true;
            while(queue.Count > 0)
            {
                GraphNode curr = queue.First();
                queue.RemoveAt(0);

                if (curr.Name == 'E')
                {
                    //GraphNode previous = curr;
                    //while (previous.Prev != null)
                    //{
                    //    Console.Write(previous.Prev.Name);
                    //    previous = previous.Prev;

                    //}
                    if(start.Name == 'S')
                    {
                        Console.WriteLine(curr.Length);
                    }
                    return curr.Length;

                }

                foreach (GraphNode node in curr.Goals)
                {
                    
                    if (!node.Visited)
                    {
                        queue.Add(node);
                        node.Visited = true;
                        node.Length = curr.Length + 1;
                        node.Prev = curr;
                    }
                }
            }
            return int.MaxValue;
        }
    }
}
