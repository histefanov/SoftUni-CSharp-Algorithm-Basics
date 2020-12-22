using System;
using System.Collections.Generic;

namespace Salaries
{
    class Program
    {
        private static List<int>[] graph;

        static void Main(string[] args)
        {           
            graph = ReadGraph();

            var total = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                total += DFS(i);
            }

            Console.WriteLine(total);
        }

        private static int DFS(int node)
        {
            if (graph[node].Count == 0)
            {
                return 1;
            }

            var sum = 0;

            foreach (var child in graph[node])
            {
                sum += DFS(child);
            }

            return sum;
        }

        private static List<int>[] ReadGraph()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());
            var graph = new List<int>[numberOfEmployees];

            for (int i = 0; i < numberOfEmployees; i++)
            {
                graph[i] = new List<int>();
                var managedEmployees = Console.ReadLine();

                for (int j = 0; j < managedEmployees.Length; j++)
                {
                    if (managedEmployees[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            return graph;
        }
    }
}
