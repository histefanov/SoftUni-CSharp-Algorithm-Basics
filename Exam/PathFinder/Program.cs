using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    class Program
    {
        private static bool[] visited;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<int>[] graph = ReadGraph(n);

            int p = int.Parse(Console.ReadLine());
            CheckPaths(graph, p);
        }

        private static void CheckPaths(List<int>[] graph, int p)
        {
            for (int i = 0; i < p; i++)
            {
                visited = new bool[graph.Length];

                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                Queue<int> path = new Queue<int>();

                foreach (var node in input)
                {
                    path.Enqueue(node);
                }

                bool result = BFS(graph, path);
                Console.WriteLine(result ? "yes" : "no");
            }
        }

        private static bool BFS(List<int>[] graph, Queue<int> path)
        {
            var source = path.Dequeue();

            var BFSQueue = new Queue<int>();
            
            BFSQueue.Enqueue(source);
            visited[source] = true;

            while (BFSQueue.Count > 0 && path.Count > 0)
            {
                var currentNode = BFSQueue.Dequeue();
                var nextPathNode = path.Peek();
                
                foreach (var child in graph[currentNode])
                {
                    if (!visited[child] && child == nextPathNode)
                    {
                        BFSQueue.Enqueue(child);
                        path.Dequeue();
                        visited[child] = true;
                        break;
                    }
                }
            }

            return path.Count == 0;
        }

        private static List<int>[] ReadGraph(int n)
        {
            var result = new List<int>[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                {
                    result[i] = new List<int>();
                }
                else
                {
                    var children = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    result[i] = new List<int>(children);
                }
            }

            return result;
        }
    }
}
