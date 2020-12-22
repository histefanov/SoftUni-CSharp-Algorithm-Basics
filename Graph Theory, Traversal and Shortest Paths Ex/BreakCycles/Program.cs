using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakCycles
{
    class Edge
    {
        public char From { get; set; }

        public char To { get; set; }
    }
    class Program
    {
        private static Dictionary<char, List<char>> graph;
        private static HashSet<char> visited;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            edges = new List<Edge>();
            graph = ReadGraph(n);
            visited = new HashSet<char>();

            edges = edges
                .OrderBy(e => e.From)
                .ThenBy(e => e.To)
                .ToList();

            var edgesToRemove = new List<Edge>();

            foreach (var edge in edges)
            {
                var from = edge.From;
                var to = edge.To;

                if (!graph[from].Contains(to))
                {
                    continue;
                }

                graph[from].Remove(to);
                graph[to].Remove(from);

                bool pathExists = BFS(from, to);

                if (!pathExists)
                {
                    graph[from].Add(to);
                    graph[to].Add(from);
                }
                else
                {
                    edgesToRemove.Add(edge);
                }

                visited = new HashSet<char>();
            }

            PrintData(edgesToRemove);
        }

        private static void PrintData(List<Edge> edgesToRemove)
        {
            Console.WriteLine($"Edges to remove: {edgesToRemove.Count}");
            
            foreach (var edge in edgesToRemove)
            {
                Console.WriteLine($"{edge.From} - {edge.To}");
            }
        }

        private static bool BFS(char from, char to)
        {
            var queue = new Queue<char>();
            queue.Enqueue(from);
            visited.Add(from);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode == to)
                {
                    return true;
                }

                foreach (var child in graph[currentNode])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }

            return false;
        }

        private static Dictionary<char, List<char>> ReadGraph(int n)
        {
            var graph = new Dictionary<char, List<char>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                var source = char.Parse(line[0]);
                var destinations = line[1]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToList();

                foreach (var destination in destinations)
                {
                    edges.Add(new Edge() 
                    { 
                        From = source,
                        To = destination 
                    });
                }

                graph.Add(source, destinations);
            }

            return graph;
        }
    }
}
