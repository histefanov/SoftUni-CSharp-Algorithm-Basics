using System;
using System.Collections.Generic;
using System.Linq;

namespace TheStoryTelling
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = ReadGraph();
            var stack = new Stack<string>();
            var visited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    DFS(node, graph, visited, stack);
                }             
            }

            Console.WriteLine(string.Join(" ", stack));
        }

        private static void DFS(string node, Dictionary<string, List<string>> graph, HashSet<string> visited, Stack<string> stack)
        {
            if (visited.Contains(node))
            {
                return;
            }

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    DFS(child, graph, visited, stack);
                }            
            }

            visited.Add(node);
            stack.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var data = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var node = data[0].TrimEnd();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                if (data.Length > 1)
                {
                    graph[node].AddRange(data[1].Trim().Split());
                }
            }

            return graph;
        }

        //private static List<string> RetrieveStoryOrder(Dictionary<string, List<string>> graph, Dictionary<string, int> predecessorsCount)
        //{
        //    var stories = new List<string>();

        //    while (predecessorsCount.Count > 0)
        //    {
        //        var prestory = predecessorsCount.FirstOrDefault(x => x.Value == 0);

        //        stories.Add(prestory.Key);
        //        predecessorsCount.Remove(prestory.Key);

        //        foreach (var poststory in graph[prestory.Key])
        //        {
        //            predecessorsCount[poststory]--;
        //        }
        //    }

        //    return stories;
        //}

        //private static Dictionary<string, int> GetPredecessorsCount(Dictionary<string, List<string>> graph)
        //{
        //    var predecessorsCount = new Dictionary<string, int>();

        //    foreach (var node in graph)
        //    {
        //        var parent = node.Key;
        //        var children = node.Value;

        //        if (!predecessorsCount.ContainsKey(parent))
        //        {
        //            predecessorsCount.Add(parent, 0);
        //        }

        //        foreach (var child in children)
        //        {
        //            if (!predecessorsCount.ContainsKey(child))
        //            {
        //                predecessorsCount.Add(child, 0);
        //            }
        //            predecessorsCount[child]++;
        //        }
        //    }

        //    return predecessorsCount;
        //}

    }
}
