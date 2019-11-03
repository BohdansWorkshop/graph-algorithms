using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphAlgorithms.DetphFirstSearch

{
    class Program
    {
        static void Main()
        {
            var n1 = new Node("n1");
            var n2 = new Node("n2");
            var n3 = new Node("n3");
            var n4 = new Node("n4");
            var n5 = new Node("n5");
            var n6 = new Node("n6");
            var n7 = new Node("n7");
            var n8 = new Node("n8");
            var n9 = new Node("n9");
            var n10 = new Node("n10");

            n1.AddChildren(n2).AddChildren(n3).AddChildren(n4);

            n2.AddChildren(n5);
            n3.AddChildren(n5);
            n4.AddChildren(n6);
            n5.AddChildren(n7);

            n6.AddChildren(n8);
            n6.AddChildren(n9);

            n7.AddChildren(n10);
            n8.AddChildren(n10);
            n9.AddChildren(n10);

            DoSearch.FindPath(n6, n10);

            foreach(var item in DoSearch.fullPath)
            {
                Console.Write($"{item.Name} ");
            }

        }


        public class Node
        {
            public string Name { get; set; }
            public List<Node> Childrens { get; } = new List<Node>();

            public Node(string name)
            {
                this.Name = name;
            }

            public Node AddChildren(Node node, bool bidirect = true)
            {
                this.Childrens.Add(node);

                if(bidirect)
                {
                    node.Childrens.Add(this);
                }

                return this;
            }
        }


        public class DoSearch
        {
            public static LinkedList<Node> fullPath { get; set; } = new LinkedList<Node>();
           static List<Node> visited = new List<Node>();

            public static bool FindPath(Node start, Node end)
            {
                if(start == end)
                {
                    return true;
                }

                visited.Add(start);

                foreach(var item in start.Childrens.Where(x=>!visited.Contains(x)))
                {
                    if(FindPath(item, end))
                    {
                        fullPath.AddFirst(item);
                        visited.Add(item);
                        return true;
                    }
                }
                return false;
            }

        }

    }
}
