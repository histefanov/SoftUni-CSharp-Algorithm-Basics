using System;
using System.Collections.Generic;

namespace GraphBFS
{
    class Program
    {
        private static HashSet<int> visited;

        static void Main(string[] args)
        {
            var graph = new Dictionary<int, List<int>>()
            {
                { 1, new List<int>(){19, 21, 14} },
                { 19, new List<int>(){7, 12, 31, 21} },
                { 7, new List<int>(){1} },
                { 12, new List<int>() },
                { 31, new List<int>(){21} },
                { 21, new List<int>(){14} },
                { 14, new List<int>(){23, 6} },
                { 23, new List<int>(){21} },
                { 6, new List<int>() }
            };

            visited = new HashSet<int>();

            foreach (var vertex in graph.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    BFS(vertex, graph);
                }
            }
        }

        public static void BFS(int vertex, Dictionary<int, List<int>> graph)
        {
            var queue = new Queue<int>();
            queue.Enqueue(vertex);

            visited.Add(vertex);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex);

                foreach (var child in graph[currentVertex])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }
        }
    }
}
