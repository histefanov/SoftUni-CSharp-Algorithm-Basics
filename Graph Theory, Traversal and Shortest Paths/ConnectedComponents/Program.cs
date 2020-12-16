using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedComponents
{
    class Program
    {
        private static HashSet<int> visited;

        static void Main(string[] args)
        {
            
            visited = new HashSet<int>();
            var graph = ReadGraph();

            FindConnectedComponents(graph);
        }

        private static Dictionary<int, List<int>> ReadGraph()
        {
            var graph = new Dictionary<int, List<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var children = Console.ReadLine();

                if (children != String.Empty)
                {
                    graph.Add(i, new List<int>(children.Split().Select(int.Parse)));
                }
                else
                {
                    graph.Add(i, new List<int>());
                }
            }

            return graph;
        }

        private static void FindConnectedComponents(Dictionary<int, List<int>> graph)
        {
            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    Console.Write("Connected component:");
                    DFS(graph, node);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(Dictionary<int, List<int>> graph, int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(graph, child);
            }

            Console.Write(" " + node);
        }
    }
}
