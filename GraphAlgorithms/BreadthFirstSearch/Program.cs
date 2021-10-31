using System;
using System.Collections.Generic;

namespace GraphAlgorithms.BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            var n01 = new Node("01");
            var n02 = new Node("02");
            var n03 = new Node("03");
            var n04 = new Node("04");
            var n05 = new Node("05");
            var n06 = new Node("06");
            var n07 = new Node("07");
            var n08 = new Node("08");
            var n09 = new Node("09");
            var n10 = new Node("10");
            var n11 = new Node("11");
            var n12 = new Node("12");
            var n13 = new Node("13");
            var n14 = new Node("14");
            var n15 = new Node("15");
            n01.AddChildren(n02).AddChildren(n03);
            n02.AddChildren(n05);
            n03.AddChildren(n04);
            n04.AddChildren(n05, false).AddChildren(n10, false).AddChildren(n11, false);
            n06.AddChildren(n01, false);
            n07.AddChildren(n03, false).AddChildren(n08);
            n09.AddChildren(n08).AddChildren(n10);
            n11.AddChildren(n12).AddChildren(n13);
            n12.AddChildren(n13);
            n14.AddChildren(n15);

            var fullPath = BFS.FindPath(n06, n10);

            foreach (var item in fullPath)
            {
                Console.Write($"{item.Name} ");
            }

            Console.ReadKey();
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

            if (bidirect)
            {
                node.Childrens.Add(this);
            }

            return this;
        }
    }


    public static class BFS
    {
        static List<Node> Visited { get; set; } = new List<Node>();
        static Queue<Node> fullPath { get; set; } = new Queue<Node>();

        public static Queue<Node> FindPath(Node start, Node end)
        {
            fullPath.Enqueue(start);

            if(start == end)
            {
                return fullPath;
            }

            var steps = new Queue<Node>();
            steps.Enqueue(start);

            while(steps.Count > 0)
            {
                var currentNode = steps.Dequeue();
                foreach(var item in currentNode.Childrens)
                {

                    if(!fullPath.Contains(item))
                    {
                        fullPath.Enqueue(item);

                        if(item == end)
                        {
                            return fullPath;
                        }

                        steps.Enqueue(item);
                    }
                }
            }

            return fullPath;
        }

    }
}
