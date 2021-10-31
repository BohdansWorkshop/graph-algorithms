using System;

namespace DijsktraAlgo
{
    class Program
    {
        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", 1 + i, distance[i]);
        }

        public static void DijkstraAlgo(int[,] graph, int start)
        {
            var distancesArray = new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
            distancesArray[start] = 0;
            for (int currentPointIndex = 0; currentPointIndex < 9; currentPointIndex++)
            {
                var currentPointWeight = distancesArray[currentPointIndex];

                for (int j = 0; j < distancesArray.Length; j++)
                {
                    if (currentPointIndex != j)
                    {
                        var relativePointWeight = graph[currentPointIndex, j];
                        if (relativePointWeight != int.MaxValue && currentPointIndex != j && relativePointWeight != 0 && distancesArray[j] != 0)
                        {
                            var currentWeight = relativePointWeight + currentPointWeight;
                            if (currentWeight < distancesArray[j])
                                distancesArray[j] = currentWeight;
                        }
                    }

                }
            }

            Print(distancesArray, distancesArray.Length);
        }

        static void Main(string[] args)
        {
            int[,] graph =  {
                         { 0, 1, 2, 0, 0, 0, 0, 0, 0 },
                         { 1,0, 0, 2, 0, 3, 0, 0, 0 },
                         { 2, 0, 0, 0, 0, 1, 0, 0, 0 },
                         { 0, 2, 0, 0, 1, 0, 2, 0, 0 },
                         { 0, 0, 0, 1, 0, 0, 2, 0, 0 },
                         { 0, 3, 1, 0, 0, 0, 0, 1, 0 },
                         { 0, 0, 0, 2, 2, 0, 0, 3, 1 },
                         { 0, 0, 0, 0, 0, 1, 3, 0, 2 },
                         { 0, 0, 0, 0, 0, 0, 1, 2, 0 }
                            };

            DijkstraAlgo(graph, 0);
        }
    }
}
