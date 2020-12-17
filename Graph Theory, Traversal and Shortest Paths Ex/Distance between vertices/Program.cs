using System;
using System.Collections.Generic;
using System.Linq;

namespace Distance_between_vertices
{
    class Program
    {
        private static HashSet<int> visited;
        private static Dictionary<int, int> childParentKvp;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            Dictionary<int, HashSet<int>> graph = ReadGraph(n);

            for (int i = 0; i < p; i++)
            {
                childParentKvp = new Dictionary<int, int>();
                visited = new HashSet<int>();

                var pair = Console.ReadLine()
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();

                var from = pair[0];
                var to = pair[1];

                int result = GetPathLength(graph, from, to);
                PrintPath(from, to, result);
            }
        }

        private static void PrintPath(int from, int to, int pathLength)
        {
            Console.WriteLine($"{{{from}, {to}}} -> {pathLength}");
        }

        private static int GetPathLength(Dictionary<int, HashSet<int>> graph, int from, int to)
        {
            var queue = new Queue<int>();
            queue.Enqueue(from);
            visited.Add(from);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                if (currentVertex == to)
                {
                    return ReconstructPath(from, to);
                }

                foreach (var child in graph[currentVertex])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                        childParentKvp.Add(child, currentVertex);
                    }
                }
            }

            return -1;
        }

        private static int ReconstructPath(int startNode, int endNode)
        {
            var pathLength = 1;
            var parent = childParentKvp[endNode];


            while (childParentKvp.ContainsKey(parent))
            {
                pathLength++;
                parent = childParentKvp[parent];
            }

            return pathLength;
        }

        private static Dictionary<int, HashSet<int>> ReadGraph(int n)
        {
            var graph = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                var vertex = int.Parse(line[0]);

                if (line.Length > 1)
                {
                    var children = line[1]
                    .Split()
                    .Select(int.Parse)
                    .ToHashSet();

                    graph.Add(vertex, children);
                }
                else
                {
                    graph.Add(vertex, new HashSet<int>());
                }

            }

            return graph;
        }
    }
}
