using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Models
{
    public class Node
    {
        public string Name { get; set; }
        public Node? Parent { get; set; }


        public Node(string name, Node? parent)
        {
            Name = name;
            Parent = parent;
            
        }

        public bool ContainedIn(List<Node> nodes)
        {
            if(this.Name != null)
            {
                if(nodes.Where(n => n.Name == this.Name).Any())
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class InternalNode : Node
    {
        public List<Node> Children { get; set; }
        public InternalNode(string name, InternalNode? parent, List<Node> child) : base(name, parent)
        {
            Children = child;
            foreach(Node node in Children)
            {
                if(parent != null)
                {
                    parent.AppendChild(node);
                }
            }
        }

        public void AppendChild(Node child)
        {
            if(child != null && !child.ContainedIn(Children))
            {
                Children.Add(child);
            }
        }

        public InternalNode? GetInternalChildByName(string name)
        {
            return (InternalNode?)Children.Where(n => n.Name == name && n.GetType() == typeof(InternalNode)).FirstOrDefault();
        }

        public void Print(string prefix)
        {
            
            Console.WriteLine(prefix + Name + " " + this.GetSize());
            List<Leaf> leafs = Children.Where(n => n.GetType() == typeof(Leaf)).Select(n => (Leaf)n).ToList();
            List<InternalNode> internalNodes = Children.Where(n => n.GetType() == typeof(InternalNode)).Select(n => (InternalNode)n).ToList();
            foreach (Leaf leaf in leafs)
            {
                leaf.Print(prefix + "-");
            }
            foreach(InternalNode node in internalNodes)
            {
                node.Print(prefix + "-");
            }
            
        }

        public List<Node> GetDirsWithSize(List<Node> nodes)
        {
            List<InternalNode> internalNodes = Children.Where(n => n.GetType() == typeof(InternalNode)).Select(n => (InternalNode)n).ToList();
            if(this.GetSize() <= 100000)
            {
                nodes.Add(this);
            }
            foreach (InternalNode node in internalNodes)
            {
                node.GetDirsWithSize(nodes);
            }
            return nodes;
        }

        public List<Node> GetDirsWithGreaterSize(List<Node> nodes, int size)
        {
            List<InternalNode> internalNodes = Children.Where(n => n.GetType() == typeof(InternalNode)).Select(n => (InternalNode)n).ToList();
            if (this.GetSize() >= size)
            {
                nodes.Add(this);
            }
            foreach (InternalNode node in internalNodes)
            {
                node.GetDirsWithGreaterSize(nodes,size);
            }
            return nodes;
        }


        public int GetSize()
        {
            List<Leaf> leafs = Children.Where(n => n.GetType() == typeof(Leaf)).Select(n => (Leaf)n).ToList();
            List<InternalNode> internalNodes = Children.Where(n => n.GetType() == typeof(InternalNode)).Select(n => (InternalNode)n).ToList();
            int size = 0;
            foreach(Leaf leaf in leafs)
            {
                size += leaf.Size;
            }
            foreach(InternalNode node in internalNodes)
            {
                size += node.GetSize();
            }

            return size;
        }
    }

    public class Leaf : Node
    {
        public int Size { get; set; }
        public Leaf(string name, Node parent, int size) : base(name, parent)
        {
            Size = size;
        }

        public void Print(string prefix)
        {
            Console.WriteLine(prefix + Name + " " + Size.ToString());
            
        }
    }
}
