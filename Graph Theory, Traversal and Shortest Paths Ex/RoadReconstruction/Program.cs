using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadReconstruction
{
    class Street
    {
        public Street(int from, int to)
        {
            From = from;
            To = to;
        }

        public int From { get; set; }

        public int To { get; set; }
    }

    class Program
    {
        private static List<int>[] map;
        private static List<Street> streets;

        static void Main(string[] args)
        {
            int numberOfBuildings = int.Parse(Console.ReadLine());
            int numberOfStreets = int.Parse(Console.ReadLine());

            streets = new List<Street>();
            map = ReadMap(numberOfBuildings, numberOfStreets);

            var importantStreets = new HashSet<Street>();

            foreach (var street in streets)
            {
                map[street.From].Remove(street.To);
                map[street.To].Remove(street.From);

                if (IsImportant(street.From, street.To, numberOfBuildings))
                {
                    importantStreets.Add(street);
                }

                map[street.From].Add(street.To);
                map[street.To].Add(street.From);
            }

            Console.WriteLine("Important streets:");

            foreach (var street in importantStreets)
            {
                var first = Math.Min(street.From, street.To);
                var second = Math.Max(street.From, street.To);

                Console.WriteLine($"{first} {second}");
            }
        }

        private static bool IsImportant(int from, int to, int numberOfBuildings)
        {
            var queue = new Queue<int>();
            var visited = new bool[numberOfBuildings];

            queue.Enqueue(from);
            visited[from] = true;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == to)
                {
                    return false;
                }

                foreach (var child in map[current])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                    }
                }
            }

            return true;
        }

        private static List<int>[] ReadMap(int numberOfBuildings, int numberOfStreets)
        {
            var map = new List<int>[numberOfBuildings];

            for (int i = 0; i < numberOfBuildings; i++)
            {
                map[i] = new List<int>();
            }

            for (int i = 0; i < numberOfStreets; i++)
            {
                var street = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                var firstBuilding = street[0];
                var secondBuilding = street[1];

                map[firstBuilding].Add(secondBuilding);
                map[secondBuilding].Add(firstBuilding);

                streets.Add(new Street(firstBuilding, secondBuilding));
            }

            return map;
        }
    }
}
