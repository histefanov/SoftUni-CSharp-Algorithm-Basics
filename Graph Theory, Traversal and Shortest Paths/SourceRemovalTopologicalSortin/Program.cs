using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceRemovalTopologicalSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = ReadGraph();
            var predecessorsCount = GetPredecessorsCount(graph);

            try
            {
                var sorted = TopoSort(graph, predecessorsCount);
                PrintSortedGraph(sorted);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        private static void PrintSortedGraph(List<string> sorted)
        {
            Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }

        private static Dictionary<string, int> GetPredecessorsCount(Dictionary<string, List<string>> graph)
        {
            var predecessorsCount = new Dictionary<string, int>();

            foreach (var node in graph)
            {
                var key = node.Key;
                var children = node.Value;

                if (!predecessorsCount.ContainsKey(key))
                {
                    predecessorsCount.Add(key, 0);
                }

                foreach (var child in children)
                {
                    if (!predecessorsCount.ContainsKey(child))
                    {
                        predecessorsCount.Add(child, 0);
                    }
                    predecessorsCount[child]++;
                }
            }

            return predecessorsCount;
        }

        private static List<string> TopoSort(
            Dictionary<string, List<string>> graph, 
            Dictionary<string, int> predecessorsCount)
        {
            var sorted = new List<string>();
            while (predecessorsCount.Count > 0)
            {
                var node = predecessorsCount
                    .FirstOrDefault(n => n.Value == 0);

                if (node.Key == null)
                {
                    break;
                }

                sorted.Add(node.Key);
                predecessorsCount.Remove(node.Key);

                foreach (var child in graph[node.Key])
                {
                    predecessorsCount[child]--;
                }
            }

            if (predecessorsCount.Count != 0)
            {
                throw new InvalidOperationException("Invalid topological sorting");
            }

            return sorted;
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ->");
                var node = line[0];
                var children = line[1].TrimStart();

                if (!String.IsNullOrEmpty(children))
                {
                    graph.Add(node,
                        new List<string>(children.Split(", ")));
                }
                else
                {
                    graph.Add(node, new List<string>());
                }
            }

            return graph;
        }
    }
}
