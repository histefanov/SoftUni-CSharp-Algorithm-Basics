using System;
using System.Collections.Generic;
using System.Linq;

namespace CyclesInGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Dictionary<char, List<char>>();
            var visited = new HashSet<char>();
            var currentHierarchy = new HashSet<char>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var edge = input
                    .Split('-')
                    .Select(char.Parse)
                    .ToArray();

                var from = edge[0];
                var to = edge[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<char>());
                }
                graph[from].Add(to);

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<char>());
                }
            }

            foreach (var node in graph.Keys)
            {
                try
                {
                    DFS(graph, node, visited, currentHierarchy);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Acyclic: No");
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");
        }
        private static void DFS(Dictionary<char, List<char>> graph, char node, HashSet<char> visited, HashSet<char> currentHierarchy)
        {
            if (currentHierarchy.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);
            currentHierarchy.Add(node);

            foreach (var child in graph[node])
            {
                DFS(graph, child, visited, currentHierarchy);
            }

            currentHierarchy.Remove(node);
        }
    }
}
