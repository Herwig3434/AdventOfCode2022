using AdventOfCode.Helpers;
using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public static class Day7
    {
        public static void RunDay(string path)
        {
            string[] lines = ReadFile.ReadLinesFromFile(path);

            GetSize(lines);


        }

        private static void GetSize(string[] lines)
        {
            InternalNode root = new("/", null, new List<Node>());

            InternalNode currNode = root;
            foreach(string line in lines)
            {
                string[] lineSplit = line.Split(' ');
                if (lineSplit[0] == "$")
                {
                    string command = lineSplit[1];
                    if (command == "cd")
                    {
                        string name = lineSplit[2];
                        if (name == "/")
                        {
                            while(currNode.Parent != null){
                                currNode = (InternalNode)currNode.Parent;
                            }
                            //Todo
                        }else if(name == ".." && currNode.Parent != null)
                        {
                            currNode = (InternalNode)currNode.Parent;
                        }
                        else
                        {
                            InternalNode newChild = new(name, currNode, new List<Node>());
                            if (!newChild.ContainedIn(currNode.Children))
                            {
                                currNode.AppendChild(newChild);
                            }
                            InternalNode? nextNode = currNode.GetInternalChildByName(name);
                            if (nextNode != null)
                            {
                                currNode = (InternalNode)nextNode;
                            }
                        }
                        
                    }
                    else if (command == "ls")
                    {

                    }

                }
                else
                {
                    if (lineSplit[0] != "dir")
                    {
                        int size = Int32.Parse(lineSplit[0]);
                        string name = lineSplit[1];
                        Leaf leaf = new(name, currNode, size);
                        if (!leaf.ContainedIn(currNode.Children))
                        {
                            currNode.AppendChild(leaf);
                        }
                    }
                    
                }
            }
            while (currNode.Parent != null)
            {
                currNode = (InternalNode)currNode.Parent;
            }
            currNode.Print("");
            List<Node> smallNodes = currNode.GetDirsWithSize(new List<Node>());
            int counter = 0;
            foreach(InternalNode node in smallNodes)
            {
                counter += node.GetSize();
            }
            Console.WriteLine(counter);

            List<Node> bigNodes = currNode.GetDirsWithGreaterSize(new List<Node>(), 30000000 - (70000000 - currNode.GetSize()));
            int currSmallest = Int32.MaxValue;
            foreach(InternalNode node in bigNodes)
            {
                int currSize = node.GetSize();
                if(currSize < currSmallest)
                {
                    currSmallest = currSize;
                }
            }

            Console.WriteLine(currSmallest);
        }
    }
}
